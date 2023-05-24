
namespace SubwaySurfersSaveEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvStrings = new System.Windows.Forms.DataGridView();
            this.strs_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strs_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsddbMenuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvNumbers1 = new System.Windows.Forms.DataGridView();
            this.nrs1_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrs1_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNumbers2 = new System.Windows.Forms.DataGridView();
            this.nrs2_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrs2_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tsmiMenuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.tsmiMenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMenuAbout = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrings)).BeginInit();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumbers1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumbers2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStrings
            // 
            this.dgvStrings.AllowUserToResizeColumns = false;
            this.dgvStrings.AllowUserToResizeRows = false;
            this.dgvStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStrings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStrings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.strs_key,
            this.strs_value});
            this.dgvStrings.Location = new System.Drawing.Point(15, 52);
            this.dgvStrings.Name = "dgvStrings";
            this.dgvStrings.RowHeadersVisible = false;
            this.dgvStrings.Size = new System.Drawing.Size(773, 150);
            this.dgvStrings.TabIndex = 0;
            this.dgvStrings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStrings_CellValueChanged);
            this.dgvStrings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvStrings_MouseUp);
            // 
            // strs_key
            // 
            this.strs_key.HeaderText = "Key";
            this.strs_key.Name = "strs_key";
            // 
            // strs_value
            // 
            this.strs_value.HeaderText = "Value";
            this.strs_value.Name = "strs_value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Strings:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First chunk of numbers:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Second chunk of numbers:";
            // 
            // tsMenu
            // 
            this.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMenuFile,
            this.tsbMenuAbout});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMenu.Size = new System.Drawing.Size(800, 25);
            this.tsMenu.TabIndex = 6;
            // 
            // tsddbMenuFile
            // 
            this.tsddbMenuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenuFileOpen,
            this.tsmiMenuFileSave,
            this.tsmiMenuFileSaveAs,
            this.tsmiMenuFileClose});
            this.tsddbMenuFile.Image = ((System.Drawing.Image)(resources.GetObject("tsddbMenuFile.Image")));
            this.tsddbMenuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMenuFile.Name = "tsddbMenuFile";
            this.tsddbMenuFile.ShowDropDownArrow = false;
            this.tsddbMenuFile.Size = new System.Drawing.Size(29, 22);
            this.tsddbMenuFile.Text = "File";
            this.tsddbMenuFile.ToolTipText = "File";
            // 
            // tsmiMenuFileOpen
            // 
            this.tsmiMenuFileOpen.Name = "tsmiMenuFileOpen";
            this.tsmiMenuFileOpen.ShortcutKeyDisplayString = "Ctrl + O";
            this.tsmiMenuFileOpen.Size = new System.Drawing.Size(196, 22);
            this.tsmiMenuFileOpen.Text = "Open";
            this.tsmiMenuFileOpen.Click += new System.EventHandler(this.tsmiMenuFileOpen_Click);
            // 
            // tsmiMenuFileSave
            // 
            this.tsmiMenuFileSave.Enabled = false;
            this.tsmiMenuFileSave.Name = "tsmiMenuFileSave";
            this.tsmiMenuFileSave.ShortcutKeyDisplayString = "Ctrl + S";
            this.tsmiMenuFileSave.Size = new System.Drawing.Size(196, 22);
            this.tsmiMenuFileSave.Text = "Save";
            this.tsmiMenuFileSave.Click += new System.EventHandler(this.tsmiMenuFileSave_Click);
            // 
            // dgvNumbers1
            // 
            this.dgvNumbers1.AllowUserToResizeColumns = false;
            this.dgvNumbers1.AllowUserToResizeRows = false;
            this.dgvNumbers1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNumbers1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNumbers1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumbers1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrs1_key,
            this.nrs1_value});
            this.dgvNumbers1.Location = new System.Drawing.Point(15, 234);
            this.dgvNumbers1.Name = "dgvNumbers1";
            this.dgvNumbers1.RowHeadersVisible = false;
            this.dgvNumbers1.Size = new System.Drawing.Size(773, 150);
            this.dgvNumbers1.TabIndex = 7;
            this.dgvNumbers1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvNumbers1_CellParsing);
            this.dgvNumbers1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumbers1_CellValueChanged);
            this.dgvNumbers1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvNumbers1_MouseUp);
            // 
            // nrs1_key
            // 
            this.nrs1_key.HeaderText = "Key";
            this.nrs1_key.Name = "nrs1_key";
            // 
            // nrs1_value
            // 
            this.nrs1_value.HeaderText = "Value";
            this.nrs1_value.Name = "nrs1_value";
            // 
            // dgvNumbers2
            // 
            this.dgvNumbers2.AllowUserToResizeColumns = false;
            this.dgvNumbers2.AllowUserToResizeRows = false;
            this.dgvNumbers2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNumbers2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNumbers2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumbers2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrs2_key,
            this.nrs2_value});
            this.dgvNumbers2.Location = new System.Drawing.Point(15, 418);
            this.dgvNumbers2.Name = "dgvNumbers2";
            this.dgvNumbers2.RowHeadersVisible = false;
            this.dgvNumbers2.Size = new System.Drawing.Size(773, 150);
            this.dgvNumbers2.TabIndex = 8;
            this.dgvNumbers2.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvNumbers2_CellParsing);
            this.dgvNumbers2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumbers2_CellValueChanged);
            this.dgvNumbers2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvNumbers2_MouseUp);
            // 
            // nrs2_key
            // 
            this.nrs2_key.HeaderText = "Key";
            this.nrs2_key.Name = "nrs2_key";
            // 
            // nrs2_value
            // 
            this.nrs2_value.HeaderText = "Value";
            this.nrs2_value.Name = "nrs2_value";
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Title = "Select the Subway Surfers save";
            // 
            // tsmiMenuFileClose
            // 
            this.tsmiMenuFileClose.Enabled = false;
            this.tsmiMenuFileClose.Name = "tsmiMenuFileClose";
            this.tsmiMenuFileClose.Size = new System.Drawing.Size(196, 22);
            this.tsmiMenuFileClose.Text = "Close";
            this.tsmiMenuFileClose.Click += new System.EventHandler(this.tsmiMenuFileClose_Click);
            // 
            // sfdSaveFile
            // 
            this.sfdSaveFile.Title = "Select where the Subway Surfers save should be put";
            // 
            // tsmiMenuFileSaveAs
            // 
            this.tsmiMenuFileSaveAs.Enabled = false;
            this.tsmiMenuFileSaveAs.Name = "tsmiMenuFileSaveAs";
            this.tsmiMenuFileSaveAs.ShortcutKeyDisplayString = "Ctrl + Shift + S";
            this.tsmiMenuFileSaveAs.Size = new System.Drawing.Size(196, 22);
            this.tsmiMenuFileSaveAs.Text = "Save as";
            this.tsmiMenuFileSaveAs.Click += new System.EventHandler(this.tsmiMenuFileSaveAs_Click);
            // 
            // tsbMenuAbout
            // 
            this.tsbMenuAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbMenuAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuAbout.Image")));
            this.tsbMenuAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuAbout.Name = "tsbMenuAbout";
            this.tsbMenuAbout.Size = new System.Drawing.Size(44, 22);
            this.tsbMenuAbout.Text = "About";
            this.tsbMenuAbout.Click += new System.EventHandler(this.tsbMenuAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.dgvNumbers2);
            this.Controls.Add(this.dgvNumbers1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStrings);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "SSSE (Subways Surfers Save Editor)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrings)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumbers1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumbers2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStrings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMenuFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuFileSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn strs_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn strs_value;
        private System.Windows.Forms.DataGridView dgvNumbers1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrs1_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrs1_value;
        private System.Windows.Forms.DataGridView dgvNumbers2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrs2_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrs2_value;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuFileClose;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuFileSaveAs;
        private System.Windows.Forms.ToolStripButton tsbMenuAbout;
    }
}

