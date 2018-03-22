namespace NovelDownloader
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetChapter = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.clbChapter = new System.Windows.Forms.CheckedListBox();
            this.btnSetectAllChapter = new System.Windows.Forms.Button();
            this.btnDownloadSelected = new System.Windows.Forms.Button();
            this.btnClearSelectedChapter = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSticky = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetChapter
            // 
            this.btnGetChapter.Location = new System.Drawing.Point(499, 315);
            this.btnGetChapter.Name = "btnGetChapter";
            this.btnGetChapter.Size = new System.Drawing.Size(75, 23);
            this.btnGetChapter.TabIndex = 0;
            this.btnGetChapter.Text = "Get Chapter";
            this.btnGetChapter.UseVisualStyleBackColor = true;
            this.btnGetChapter.Click += new System.EventHandler(this.btnGetChapter_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(22, 86);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(213, 219);
            this.tbLog.TabIndex = 1;
            // 
            // clbChapter
            // 
            this.clbChapter.FormattingEnabled = true;
            this.clbChapter.Location = new System.Drawing.Point(241, 13);
            this.clbChapter.Name = "clbChapter";
            this.clbChapter.Size = new System.Drawing.Size(333, 293);
            this.clbChapter.TabIndex = 2;
            this.clbChapter.SelectedIndexChanged += new System.EventHandler(this.clbChapter_SelectedIndexChanged);
            // 
            // btnSetectAllChapter
            // 
            this.btnSetectAllChapter.Location = new System.Drawing.Point(241, 315);
            this.btnSetectAllChapter.Name = "btnSetectAllChapter";
            this.btnSetectAllChapter.Size = new System.Drawing.Size(75, 23);
            this.btnSetectAllChapter.TabIndex = 3;
            this.btnSetectAllChapter.Text = "Select All";
            this.btnSetectAllChapter.UseVisualStyleBackColor = true;
            this.btnSetectAllChapter.Click += new System.EventHandler(this.btnSetectAllChapter_Click);
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Location = new System.Drawing.Point(108, 315);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(118, 23);
            this.btnDownloadSelected.TabIndex = 4;
            this.btnDownloadSelected.Text = "Download Selected";
            this.btnDownloadSelected.UseVisualStyleBackColor = true;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownloadSelected_Click);
            // 
            // btnClearSelectedChapter
            // 
            this.btnClearSelectedChapter.Location = new System.Drawing.Point(322, 315);
            this.btnClearSelectedChapter.Name = "btnClearSelectedChapter";
            this.btnClearSelectedChapter.Size = new System.Drawing.Size(75, 23);
            this.btnClearSelectedChapter.TabIndex = 5;
            this.btnClearSelectedChapter.Text = "Clear All";
            this.btnClearSelectedChapter.UseVisualStyleBackColor = true;
            this.btnClearSelectedChapter.Click += new System.EventHandler(this.btnClearSelectedChapter_Click);
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(22, 33);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(213, 22);
            this.tbURL.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Log";
            // 
            // btnSticky
            // 
            this.btnSticky.Location = new System.Drawing.Point(403, 315);
            this.btnSticky.Name = "btnSticky";
            this.btnSticky.Size = new System.Drawing.Size(75, 23);
            this.btnSticky.TabIndex = 9;
            this.btnSticky.Text = "Sticky";
            this.btnSticky.UseVisualStyleBackColor = true;
            this.btnSticky.Click += new System.EventHandler(this.btnSticky_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 349);
            this.Controls.Add(this.btnSticky);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.btnClearSelectedChapter);
            this.Controls.Add(this.btnDownloadSelected);
            this.Controls.Add(this.btnSetectAllChapter);
            this.Controls.Add(this.clbChapter);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnGetChapter);
            this.Name = "Form1";
            this.Text = "NovelDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetChapter;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.CheckedListBox clbChapter;
        private System.Windows.Forms.Button btnSetectAllChapter;
        private System.Windows.Forms.Button btnDownloadSelected;
        private System.Windows.Forms.Button btnClearSelectedChapter;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSticky;
    }
}

