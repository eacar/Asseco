namespace UI.Win.DataPresenter
{
    partial class FormMain
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
            this.groupBox_FileLoad = new System.Windows.Forms.GroupBox();
            this.button_Log = new System.Windows.Forms.Button();
            this.numericUpDown_ThreadCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label_FailCount = new System.Windows.Forms.Label();
            this.label_SuccessCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadFile = new System.Windows.Forms.Button();
            this.openFileDialog_Subscriber = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_Search = new System.Windows.Forms.GroupBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label_SearchResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.groupBox_Data = new System.Windows.Forms.GroupBox();
            this.dataGridView_Subscribers = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_FileLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ThreadCount)).BeginInit();
            this.groupBox_Search.SuspendLayout();
            this.groupBox_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subscribers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_FileLoad
            // 
            this.groupBox_FileLoad.Controls.Add(this.button_Log);
            this.groupBox_FileLoad.Controls.Add(this.numericUpDown_ThreadCount);
            this.groupBox_FileLoad.Controls.Add(this.label2);
            this.groupBox_FileLoad.Controls.Add(this.label_FailCount);
            this.groupBox_FileLoad.Controls.Add(this.label_SuccessCount);
            this.groupBox_FileLoad.Controls.Add(this.label4);
            this.groupBox_FileLoad.Controls.Add(this.label1);
            this.groupBox_FileLoad.Controls.Add(this.button_LoadFile);
            this.groupBox_FileLoad.Location = new System.Drawing.Point(13, 12);
            this.groupBox_FileLoad.Name = "groupBox_FileLoad";
            this.groupBox_FileLoad.Size = new System.Drawing.Size(210, 186);
            this.groupBox_FileLoad.TabIndex = 0;
            this.groupBox_FileLoad.TabStop = false;
            this.groupBox_FileLoad.Text = "Yükleme";
            // 
            // button_Log
            // 
            this.button_Log.Location = new System.Drawing.Point(12, 144);
            this.button_Log.Name = "button_Log";
            this.button_Log.Size = new System.Drawing.Size(97, 25);
            this.button_Log.TabIndex = 3;
            this.button_Log.Text = "Başarısız olanlar";
            this.button_Log.UseVisualStyleBackColor = true;
            this.button_Log.Click += new System.EventHandler(this.button_Log_Click);
            // 
            // numericUpDown_ThreadCount
            // 
            this.numericUpDown_ThreadCount.Location = new System.Drawing.Point(86, 24);
            this.numericUpDown_ThreadCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_ThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_ThreadCount.Name = "numericUpDown_ThreadCount";
            this.numericUpDown_ThreadCount.Size = new System.Drawing.Size(73, 20);
            this.numericUpDown_ThreadCount.TabIndex = 2;
            this.numericUpDown_ThreadCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Başarısız adet:";
            // 
            // label_FailCount
            // 
            this.label_FailCount.AutoSize = true;
            this.label_FailCount.Location = new System.Drawing.Point(83, 118);
            this.label_FailCount.Name = "label_FailCount";
            this.label_FailCount.Size = new System.Drawing.Size(13, 13);
            this.label_FailCount.TabIndex = 1;
            this.label_FailCount.Text = "--";
            // 
            // label_SuccessCount
            // 
            this.label_SuccessCount.AutoSize = true;
            this.label_SuccessCount.Location = new System.Drawing.Point(82, 95);
            this.label_SuccessCount.Name = "label_SuccessCount";
            this.label_SuccessCount.Size = new System.Drawing.Size(13, 13);
            this.label_SuccessCount.TabIndex = 1;
            this.label_SuccessCount.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Thread Adedi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Başarılı adet:";
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Location = new System.Drawing.Point(9, 50);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(185, 35);
            this.button_LoadFile.TabIndex = 0;
            this.button_LoadFile.Text = "Dosya Yükle";
            this.button_LoadFile.UseVisualStyleBackColor = true;
            this.button_LoadFile.Click += new System.EventHandler(this.button_LoadFile_Click);
            // 
            // openFileDialog_Subscriber
            // 
            this.openFileDialog_Subscriber.FileName = "openFileDialog1";
            // 
            // groupBox_Search
            // 
            this.groupBox_Search.Controls.Add(this.button_Search);
            this.groupBox_Search.Controls.Add(this.label_SearchResult);
            this.groupBox_Search.Controls.Add(this.label5);
            this.groupBox_Search.Controls.Add(this.label3);
            this.groupBox_Search.Controls.Add(this.textBox_Search);
            this.groupBox_Search.Location = new System.Drawing.Point(13, 204);
            this.groupBox_Search.Name = "groupBox_Search";
            this.groupBox_Search.Size = new System.Drawing.Size(210, 92);
            this.groupBox_Search.TabIndex = 1;
            this.groupBox_Search.TabStop = false;
            this.groupBox_Search.Text = "Arama";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(119, 36);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 1;
            this.button_Search.Text = "Ara";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label_SearchResult
            // 
            this.label_SearchResult.AutoSize = true;
            this.label_SearchResult.Location = new System.Drawing.Point(82, 63);
            this.label_SearchResult.Name = "label_SearchResult";
            this.label_SearchResult.Size = new System.Drawing.Size(13, 13);
            this.label_SearchResult.TabIndex = 1;
            this.label_SearchResult.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Abone No";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(6, 39);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(100, 20);
            this.textBox_Search.TabIndex = 0;
            // 
            // groupBox_Data
            // 
            this.groupBox_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Data.Controls.Add(this.dataGridView_Subscribers);
            this.groupBox_Data.Location = new System.Drawing.Point(235, 13);
            this.groupBox_Data.Name = "groupBox_Data";
            this.groupBox_Data.Size = new System.Drawing.Size(559, 283);
            this.groupBox_Data.TabIndex = 2;
            this.groupBox_Data.TabStop = false;
            this.groupBox_Data.Text = "Aboneler";
            // 
            // dataGridView_Subscribers
            // 
            this.dataGridView_Subscribers.AllowUserToAddRows = false;
            this.dataGridView_Subscribers.AllowUserToDeleteRows = false;
            this.dataGridView_Subscribers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Subscribers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Subscribers.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_Subscribers.Name = "dataGridView_Subscribers";
            this.dataGridView_Subscribers.ReadOnly = true;
            this.dataGridView_Subscribers.Size = new System.Drawing.Size(553, 264);
            this.dataGridView_Subscribers.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Toplam Borç:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 311);
            this.Controls.Add(this.groupBox_Data);
            this.Controls.Add(this.groupBox_Search);
            this.Controls.Add(this.groupBox_FileLoad);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(818, 350);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aboneler";
            this.groupBox_FileLoad.ResumeLayout(false);
            this.groupBox_FileLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ThreadCount)).EndInit();
            this.groupBox_Search.ResumeLayout(false);
            this.groupBox_Search.PerformLayout();
            this.groupBox_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subscribers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_FileLoad;
        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Subscriber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_FailCount;
        private System.Windows.Forms.Label label_SuccessCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_Search;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label_SearchResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.NumericUpDown numericUpDown_ThreadCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Log;
        private System.Windows.Forms.GroupBox groupBox_Data;
        private System.Windows.Forms.DataGridView dataGridView_Subscribers;
        private System.Windows.Forms.Label label5;
    }
}

