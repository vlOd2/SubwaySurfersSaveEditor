using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataGridView;

namespace SubwaySurfersSaveEditor
{
    public partial class MainForm : Form
    {
        public SubwaySurfersSaveFile Save;
        private bool HasSaved;

        public MainForm()
        {
            InitializeComponent();
        }

        private void dgvNumbers1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (!int.TryParse((string)e.Value, out _)) 
            {
                e.Value = 0;
                e.ParsingApplied = true;
            }
        }

        private void dgvNumbers2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (!int.TryParse((string)e.Value, out _))
            {
                e.Value = 0;
                e.ParsingApplied = true;
            }
        }

        private void tsmiMenuFileOpen_Click(object sender, EventArgs e)
        {
            ofdOpenFile.FileName = null;
            DialogResult result = ofdOpenFile.ShowDialog();

            if (result == DialogResult.OK) 
                LoadFile(ofdOpenFile.FileName);
        }

        private void tsmiMenuFileSave_Click(object sender, EventArgs e) => SaveFile();

        private void tsmiMenuFileSaveAs_Click(object sender, EventArgs e)
        {
            sfdSaveFile.FileName = null;
            DialogResult result = sfdSaveFile.ShowDialog();

            if (result == DialogResult.OK)
                SaveFile(sfdSaveFile.FileName);
        }

        private void tsmiMenuFileClose_Click(object sender, EventArgs e) => CloseFile();

        private void dgvStrings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            => ShowUnsavedIndicator();

        private void dgvNumbers1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            => ShowUnsavedIndicator();

        private void dgvNumbers2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            => ShowUnsavedIndicator();

        public void CloseFile() 
        {
            if (!HasSaved && 
                MessageBox.Show("Discard your changes?", 
                    "SSSE - Question", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

            HideUnsavedIndicator();
            FileClosed();
            Save = null;
            HasSaved = false;

            dgvStrings.Rows.Clear();
            dgvNumbers1.Rows.Clear();
            dgvNumbers2.Rows.Clear();
        }

        public void LoadFile(string path) 
        {
            try 
            {
                if (Save != null) return;
                Save = new SubwaySurfersSaveFile() { FileName = path };
                Save.ImportFile();

                foreach (KeyValuePair<string, string> entry in Save.Entries)
                    dgvStrings.Rows.Add(entry.Key, entry.Value);
                foreach (KeyValuePair<string, int> entry in Save.FirstNumberEntries)
                    dgvNumbers1.Rows.Add(entry.Key, entry.Value);
                foreach (KeyValuePair<string, int> entry in Save.SecondNumberEntries)
                    dgvNumbers2.Rows.Add(entry.Key, entry.Value);

                HasSaved = true;
                FileOpened();
            }
            catch (Exception ex) 
            {
                HasSaved = true;
                CloseFile();
                MessageBox.Show($"Unable to load the specified file:{Environment.NewLine}" +
                    $"{ex.Message}", "SSSE - Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void SaveFile(string path = null) 
        {
            if (Save == null) return;
            Save.Entries.Clear();
            Save.FirstNumberEntries.Clear();
            Save.SecondNumberEntries.Clear();

            foreach (DataGridViewRow row in dgvStrings.Rows)
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    Save.Entries.Add((string)row.Cells[0].Value, (string)row.Cells[1].Value);
            foreach (DataGridViewRow row in dgvNumbers1.Rows)
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    Save.FirstNumberEntries.Add((string)row.Cells[0].Value, (int)row.Cells[1].Value);
            foreach (DataGridViewRow row in dgvNumbers2.Rows)
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    Save.SecondNumberEntries.Add((string)row.Cells[0].Value, (int)row.Cells[1].Value);

            try 
            {
                Save.ExportFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to save:{Environment.NewLine}{ex.Message}", "SSSE - Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HideUnsavedIndicator();
        }

        private void FileOpened() 
        {
            tsmiMenuFileOpen.Enabled = false;
            tsmiMenuFileSave.Enabled = true;
            tsmiMenuFileSaveAs.Enabled = true;
            tsmiMenuFileClose.Enabled = true;
        }

        private void FileClosed() 
        {
            tsmiMenuFileOpen.Enabled = true;
            tsmiMenuFileSave.Enabled = false;
            tsmiMenuFileSaveAs.Enabled = false;
            tsmiMenuFileClose.Enabled = false;
        }

        private void ShowUnsavedIndicator() 
        {
            if (!HasSaved) return;
            HasSaved = false;
            Text += "*";
        }

        private void HideUnsavedIndicator() 
        {
            if (HasSaved) return;
            HasSaved = true;
            Text = Text.Substring(0, Text.Length - 1);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O) 
            {
                tsmiMenuFileOpen.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
                
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) 
            {
                tsmiMenuFileSave.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.S)
            {
                tsmiMenuFileSaveAs.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tsbMenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"SubwaySurfersSaveEditor{Environment.NewLine}" +
                $"Written by vlOd{Environment.NewLine}" +
                $"Using https://github.com/vlOd2/SubwaySurfersSaveFile", 
                "SSSE - About",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvStrings_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HitTestInfo hitTestInfo = dgvStrings.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    dgvStrings.BeginEdit(true);
                else
                    dgvStrings.EndEdit();
            }
        }

        private void dgvNumbers1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HitTestInfo hitTestInfo = dgvNumbers1.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    dgvNumbers1.BeginEdit(true);
                else
                    dgvNumbers1.EndEdit();
            }
        }

        private void dgvNumbers2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HitTestInfo hitTestInfo = dgvNumbers2.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    dgvNumbers2.BeginEdit(true);
                else
                    dgvNumbers2.EndEdit();
            }
        }
    }
}
