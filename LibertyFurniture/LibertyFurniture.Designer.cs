namespace ManoganyAndMore
{
    partial class HookerBulkDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HookerBulkDownload));
            this.m_FileList = new System.Windows.Forms.DataGridView();
            this.col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Convert_Button = new System.Windows.Forms.Button();
            this.m_Load_Button = new System.Windows.Forms.Button();
            this.m_Description = new System.Windows.Forms.Label();
            this.m_TableLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_LogList = new System.Windows.Forms.ListBox();
            this.m_Logo = new System.Windows.Forms.PictureBox();
            this.m_TableLayout4 = new System.Windows.Forms.TableLayoutPanel();
            this.m_DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.m_TableLayout3 = new System.Windows.Forms.TableLayoutPanel();
            this.m_TableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.m_FileList)).BeginInit();
            this.m_TableLayout2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_Logo)).BeginInit();
            this.m_TableLayout4.SuspendLayout();
            this.m_TableLayout3.SuspendLayout();
            this.m_TableLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_FileList
            // 
            this.m_FileList.AllowUserToAddRows = false;
            this.m_FileList.AllowUserToOrderColumns = true;
            this.m_FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_FileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_no,
            this.col_filename});
            this.m_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_FileList.Location = new System.Drawing.Point(3, 3);
            this.m_FileList.Name = "m_FileList";
            this.m_FileList.RowHeadersVisible = false;
            this.m_FileList.Size = new System.Drawing.Size(366, 433);
            this.m_FileList.TabIndex = 3;
            // 
            // col_no
            // 
            this.col_no.HeaderText = "No";
            this.col_no.Name = "col_no";
            this.col_no.ReadOnly = true;
            this.col_no.Width = 50;
            // 
            // col_filename
            // 
            this.col_filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_filename.HeaderText = "FileName";
            this.col_filename.Name = "col_filename";
            this.col_filename.ReadOnly = true;
            // 
            // m_Convert_Button
            // 
            this.m_Convert_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Convert_Button.Location = new System.Drawing.Point(375, 3);
            this.m_Convert_Button.Name = "m_Convert_Button";
            this.m_Convert_Button.Size = new System.Drawing.Size(366, 30);
            this.m_Convert_Button.TabIndex = 2;
            this.m_Convert_Button.Text = "Select Output Folder and Generate";
            this.m_Convert_Button.UseVisualStyleBackColor = true;
            this.m_Convert_Button.Click += new System.EventHandler(this.OnConvert);
            // 
            // m_Load_Button
            // 
            this.m_Load_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Load_Button.Location = new System.Drawing.Point(3, 3);
            this.m_Load_Button.Name = "m_Load_Button";
            this.m_Load_Button.Size = new System.Drawing.Size(366, 30);
            this.m_Load_Button.TabIndex = 0;
            this.m_Load_Button.Text = "Load Excel Files";
            this.m_Load_Button.UseVisualStyleBackColor = true;
            this.m_Load_Button.Click += new System.EventHandler(this.OnLoadExcelFile);
            // 
            // m_Description
            // 
            this.m_Description.AutoSize = true;
            this.m_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Description.Location = new System.Drawing.Point(3, 0);
            this.m_Description.Name = "m_Description";
            this.m_Description.Size = new System.Drawing.Size(366, 80);
            this.m_Description.TabIndex = 1;
            this.m_Description.Text = "Steps:\r\n\r\n1. Open Excel Files. [Load Excel Files]\r\n2. Select Output Folder To Dow" +
    "nload. [Select Output Folder and Generate]\r\n3. Wait Until Downloading Finishes.";
            // 
            // m_TableLayout2
            // 
            this.m_TableLayout2.ColumnCount = 2;
            this.m_TableLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout2.Controls.Add(this.m_Load_Button, 0, 0);
            this.m_TableLayout2.Controls.Add(this.m_Convert_Button, 1, 0);
            this.m_TableLayout2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_TableLayout2.Location = new System.Drawing.Point(10, 90);
            this.m_TableLayout2.Name = "m_TableLayout2";
            this.m_TableLayout2.RowCount = 1;
            this.m_TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.60274F));
            this.m_TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.39726F));
            this.m_TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.m_TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.m_TableLayout2.Size = new System.Drawing.Size(744, 36);
            this.m_TableLayout2.TabIndex = 2;
            // 
            // m_LogList
            // 
            this.m_LogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LogList.FormattingEnabled = true;
            this.m_LogList.Location = new System.Drawing.Point(375, 3);
            this.m_LogList.Name = "m_LogList";
            this.m_LogList.Size = new System.Drawing.Size(366, 433);
            this.m_LogList.TabIndex = 5;
            // 
            // m_Logo
            // 
            this.m_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Logo.Image = ((System.Drawing.Image)(resources.GetObject("m_Logo.Image")));
            this.m_Logo.Location = new System.Drawing.Point(375, 3);
            this.m_Logo.Name = "m_Logo";
            this.m_Logo.Size = new System.Drawing.Size(366, 74);
            this.m_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_Logo.TabIndex = 6;
            this.m_Logo.TabStop = false;
            // 
            // m_TableLayout4
            // 
            this.m_TableLayout4.ColumnCount = 1;
            this.m_TableLayout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.18817F));
            this.m_TableLayout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.811828F));
            this.m_TableLayout4.Controls.Add(this.m_DownloadProgressBar, 0, 0);
            this.m_TableLayout4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_TableLayout4.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_TableLayout4.Location = new System.Drawing.Point(10, 562);
            this.m_TableLayout4.Name = "m_TableLayout4";
            this.m_TableLayout4.RowCount = 1;
            this.m_TableLayout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout4.Size = new System.Drawing.Size(744, 30);
            this.m_TableLayout4.TabIndex = 7;
            // 
            // m_DownloadProgressBar
            // 
            this.m_DownloadProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_DownloadProgressBar.Location = new System.Drawing.Point(3, 3);
            this.m_DownloadProgressBar.Maximum = 1000;
            this.m_DownloadProgressBar.Name = "m_DownloadProgressBar";
            this.m_DownloadProgressBar.Size = new System.Drawing.Size(738, 24);
            this.m_DownloadProgressBar.Step = 1;
            this.m_DownloadProgressBar.TabIndex = 0;
            // 
            // m_TableLayout3
            // 
            this.m_TableLayout3.ColumnCount = 2;
            this.m_TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout3.Controls.Add(this.m_FileList, 0, 0);
            this.m_TableLayout3.Controls.Add(this.m_LogList, 1, 0);
            this.m_TableLayout3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_TableLayout3.Location = new System.Drawing.Point(10, 123);
            this.m_TableLayout3.Name = "m_TableLayout3";
            this.m_TableLayout3.RowCount = 1;
            this.m_TableLayout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout3.Size = new System.Drawing.Size(744, 439);
            this.m_TableLayout3.TabIndex = 8;
            // 
            // m_TableLayout1
            // 
            this.m_TableLayout1.CausesValidation = false;
            this.m_TableLayout1.ColumnCount = 2;
            this.m_TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout1.Controls.Add(this.m_Description, 0, 0);
            this.m_TableLayout1.Controls.Add(this.m_Logo, 1, 0);
            this.m_TableLayout1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_TableLayout1.Location = new System.Drawing.Point(10, 10);
            this.m_TableLayout1.Name = "m_TableLayout1";
            this.m_TableLayout1.RowCount = 1;
            this.m_TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayout1.Size = new System.Drawing.Size(744, 80);
            this.m_TableLayout1.TabIndex = 0;
            // 
            // HookerBulkDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 602);
            this.Controls.Add(this.m_TableLayout2);
            this.Controls.Add(this.m_TableLayout1);
            this.Controls.Add(this.m_TableLayout3);
            this.Controls.Add(this.m_TableLayout4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(780, 641);
            this.MinimumSize = new System.Drawing.Size(780, 641);
            this.Name = "HookerBulkDownload";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[MahoganyAndMore] Hooker Furniture Product Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.m_FileList)).EndInit();
            this.m_TableLayout2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_Logo)).EndInit();
            this.m_TableLayout4.ResumeLayout(false);
            this.m_TableLayout3.ResumeLayout(false);
            this.m_TableLayout1.ResumeLayout(false);
            this.m_TableLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView m_FileList;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_filename;
        private System.Windows.Forms.Button m_Convert_Button;
        private System.Windows.Forms.Button m_Load_Button;
        private System.Windows.Forms.Label m_Description;
        private System.Windows.Forms.TableLayoutPanel m_TableLayout2;
        private System.Windows.Forms.ListBox m_LogList;
        private System.Windows.Forms.PictureBox m_Logo;
        private System.Windows.Forms.TableLayoutPanel m_TableLayout4;
        private System.Windows.Forms.ProgressBar m_DownloadProgressBar;
        private System.Windows.Forms.TableLayoutPanel m_TableLayout3;
        private System.Windows.Forms.TableLayoutPanel m_TableLayout1;
    }
}

