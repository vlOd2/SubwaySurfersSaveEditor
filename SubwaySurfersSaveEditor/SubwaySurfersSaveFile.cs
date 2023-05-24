using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/*
	Created by Jan-Pascal on 23-8-2015                                                              
	Ported, cleaned and improved by vlOd on 23-5-2023                                                        
																									
	File format of the subway surfers save file:                                                    
	Offset Size Content                                                                             
	0000   0004 Hash size (always 0x0014 or 20 in decimal)                                          
	0004   0014 SHA1 hash of salt + file after offset 0x001C                                        
	0018   0004 Length of rest of file (filesize - 0x001C)                                          
	001C   0004 0x0001 (maybe file version?)                                                        
	0020   0004 Number of key/value strings                                                         
		   1-2  Length of first key                                                                 
				Characters of first key                                                             
		   1-2  Length of first value                                                               
				Characters of second value                                                          
																									
		   1-2  Length of second key                                                                
		   (etc)                                                                                    
	...                                                                                             
		   0004 Number of key/number pairs                                                          
		   1-2  Length of first key                                                                 
				Characters of first key                                                             
		   0004 First value (32-bit value)                                                          
	...                                                                                             
		   0004 Number of key/number pairs (second set)                                             
	....                                                                                            
																									
	All 4-byte numbers are high-endian (least significant byte first)                               
																									
	All string length fields are as follows.                                                        
	If the length is less than 128 (0x80) bytes, only a one byte length field is used.              
	Else, the first byte is (length XOR 0x7f) + 0x80. The second byte is the length divided by 0x80.
*/
/// <summary>
/// A save file for the game Subway Surfers
/// </summary>
public class SubwaySurfersSaveFile
{
	private static readonly byte[] TOPRUN_SALT = { 0x47, 0x68, 0x67, 0x74, 0x72, 0x52, 0x46,
        0x52, 0x66, 0x50, 0x4C, 0x4A, 0x68, 0x46, 0x44, 0x73, 0x57, 0x65, 0x23, 0x64, 0x45,
        0x64, 0x72, 0x74, 0x35, 0x72, 0x66, 0x67, 0x35, 0x36 };
    private static readonly byte[] ONLINESETTINGS_SALT = { 0x70, 0x64, 0x76, 0x73, 0x68, 0x62,
        0x68, 0x6B, 0x6E, 0x64, 0x66, 0x39, 0x32, 0x6B, 0x31, 0x39, 0x7A, 0x76, 0x62, 0x63,
        0x6B, 0x61, 0x77, 0x64, 0x39, 0x32, 0x66, 0x6A, 0x6B };
    private static readonly byte[] PLAYERINFO_SALT = { 0x77, 0x65, 0x31, 0x32, 0x72, 0x74, 0x79, 0x75, 
        0x69, 0x6B, 0x6C, 0x68, 0x67, 0x66, 0x64, 0x6A, 0x65, 0x72, 0x4B, 0x4A, 0x47, 0x48, 0x66,
        0x76, 0x67, 0x68, 0x79, 0x75, 0x68, 0x6E, 0x6A, 0x69, 0x6F, 0x6B, 0x4C, 0x4A, 0x48, 0x6C,
        0x31, 0x34, 0x35, 0x72, 0x74, 0x79, 0x66, 0x67, 0x68, 0x6A, 0x76, 0x62, 0x6E };

    /// <summary>
    /// The file name of the save
    /// </summary>
	public string FileName;
    /// <summary>
    /// The file version of the save
    /// </summary>
	public int FileVersion { get; private set; }
    /// <summary>
    /// The string entries in the save
    /// </summary>
    public readonly Dictionary<string, string> Entries = new Dictionary<string, string>();
    /// <summary>
    /// The first chunk of numbers in the save
    /// </summary>
    public readonly Dictionary<string, int> FirstNumberEntries = new Dictionary<string, int>();
    /// <summary>
    /// The second chunk of numbers in the save
    /// </summary>
    public readonly Dictionary<string, int> SecondNumberEntries = new Dictionary<string, int>();

    private int ReadDword(BinaryReader reader)
    {
        return reader.ReadByte() + reader.ReadByte() * (1 << 8) + 
            reader.ReadByte() * (1 << 16) + reader.ReadByte() * (1 << 24);
    }

    private void WriteDword(BinaryWriter writer, int dword)
    {
        writer.Write((byte)(dword & 0x000000ff));
        writer.Write((byte)((dword & 0x0000ff00) >> 8));
        writer.Write((byte)((dword & 0x00ff0000) >> 16));
        writer.Write((byte)((dword & 0xff000000) >> 24));
    }

    private string ReadString(BinaryReader reader)
    {
        int count = reader.ReadByte();
        if (count >= 0x80)
            count = (count - 0x80) + 0x80 * reader.ReadByte();

        byte[] chars = new byte[count];
        reader.Read(chars, 0, count);

        return Encoding.ASCII.GetString(chars);
    }

    private void WriteString(BinaryWriter writer, string str)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(str);

        int count = bytes.Length;
        if (count < 0x80)
            writer.Write((byte)count);
        else
        {
            writer.Write((byte)((count & 0x7f) + 0x80));
            writer.Write((byte)(count >> 7));
        }

        writer.Write(bytes);
    }

    /// <summary>
    /// Imports the specified file into this save
    /// <para>If no file is specified, uses the one associated with this instance</para>
    /// </summary>
    /// <param name="fileName"></param>
    /// <exception cref="ArgumentNullException">When no file name specified and none associated with this instance</exception>
    /// <exception cref="FileNotFoundException">When the specified file doesn't exist</exception>
    public void ImportFile(string fileName = null)
    {
        if (fileName == null) fileName = FileName;
        if (fileName == null) throw new ArgumentNullException("No file name specified and the instance didn't contain one");
        if (!File.Exists(fileName)) throw new FileNotFoundException("Specified file doesn't exist!");
        Log($"Reading data from \"{FileName}\"...");
        BinaryReader reader = new BinaryReader(new FileStream(FileName, FileMode.Open));

        // Get the hash size
        int hashSize = ReadDword(reader);
        Log($"File hash size: {hashSize}");

        // Get the hash
        byte[] hash = new byte[hashSize];
        reader.Read(hash, 0, hashSize);
        Log($"File hash: {BitConverter.ToString(hash).Replace("-", "").ToLower()}");

        // Get file information
        int fileSize = ReadDword(reader);
        Log($"File size: {fileSize}");
        FileVersion = ReadDword(reader);
        Log($"File version: {FileVersion}");

        // Read the strings
        int numStrings = ReadDword(reader);
        Log($"Number of strings: {numStrings}");
        for (int i = 0; i < numStrings; i++)
        {
            string key = ReadString(reader);
            string value = ReadString(reader);
            Entries[key] = value;
            Log($"Read string {i}: {key} -> {value}");
        }

        // Read the first chunk of numbers
        int numInts = ReadDword(reader);
        Log($"Number of integers (first set): {numInts}");
        for (int i = 0; i < numInts; i++)
        {
            string key = ReadString(reader);
            int value = ReadDword(reader);
            FirstNumberEntries[key] = value;
            Log($"Read number {i}: {key} -> {value}");
        }

        // Read the second chunk of numbers
        numInts = ReadDword(reader);
        Log($"Number of integers (second set): {numInts}");
        for (int i = 0; i < numInts; i++)
        {
            string key = ReadString(reader);
            int value = ReadDword(reader);
            SecondNumberEntries[key] = value;
            Log($"Read number {i}: {key} -> {value}");
        }

        // Clean-up
        reader.Close();
        reader.Dispose();
    }

    /// <summary>
    /// Exports this save into the specified file
    /// <para>If no file is specified, uses the one associated with this instance</para>
    /// </summary>
    /// <param name="fileName"></param>
    /// <exception cref="ArgumentNullException">When no file name specified and none associated with this instance</exception>
    public void ExportFile(string fileName = null)
    {
        if (fileName == null) fileName = FileName;
        if (fileName == null) throw new ArgumentNullException("No file name specified and the instance didn't contain one");
        Log($"Writing data to file {fileName}...");
        FileStream stream = new FileStream(fileName, FileMode.Create);
        BinaryWriter writer = new BinaryWriter(stream);

        // Write the hash size
        int hashSize = 20; // This is always 20
        WriteDword(writer, hashSize);
        Log($"File hash size: {hashSize}");

        // Write an empty hash
        long hashOffset = stream.Position;
        for (int i = 0; i < hashSize; i++) writer.Write((byte)0);

        // Write an empty file size
        long sizeOffset = stream.Position;
        WriteDword(writer, 0);

        // Keep track of where the hash ends
        long hashEndOffset = stream.Position;

        // Write the file version
        WriteDword(writer, FileVersion);
        Log($"File version: {FileVersion}");

        // Write the strings
        int numStrings = Entries.Count;
        WriteDword(writer, numStrings);
        Log($"Number of strings: {numStrings}");
        foreach (KeyValuePair<string, string> entry in Entries)
        {
            WriteString(writer, entry.Key);
            WriteString(writer, entry.Value);
        }

        // Write the first chunk of numbers
        int numInts = FirstNumberEntries.Count;
        WriteDword(writer, numInts);
        Log($"Number of integers (first set): {numInts}");
        foreach (KeyValuePair<string, int> entry in FirstNumberEntries)
        {
            WriteString(writer, entry.Key);
            WriteDword(writer, entry.Value);
        }

        // Write the second chunk of numbers
        numInts = SecondNumberEntries.Count;
        WriteDword(writer, numInts);
        Log($"Number of integers (second set): {numInts}");
        foreach (KeyValuePair<string, int> entry in SecondNumberEntries)
        {
            WriteString(writer, entry.Key);
            WriteDword(writer, entry.Value);
        }

        // Write the file size
        int fileSize = (int)(stream.Position - hashEndOffset);
        stream.Seek(sizeOffset, SeekOrigin.Begin);
        WriteDword(writer, fileSize);
        Log($"File size: {fileSize}");

        // Get the file data
        byte[] data = new byte[fileSize];
        stream.Seek(hashEndOffset, SeekOrigin.Begin);
        stream.Read(data, 0, data.Length);

        // Write the file hash
        byte[] hash = SHA1.Create().ComputeHash(PLAYERINFO_SALT.Concat(data).ToArray());
        stream.Seek(hashOffset, SeekOrigin.Begin);
        stream.Write(hash, 0, hash.Length);
        Log($"File hash: {BitConverter.ToString(hash).Replace("-", "").ToLower()}");

        // Clean-up
        writer.Close();
        writer.Dispose();
        stream.Dispose();
    }

    public void Log(string log) 
    {
        Console.WriteLine(log);
    }
}