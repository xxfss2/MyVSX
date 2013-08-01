namespace MyVSX
{
    partial class FmAddTemp
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbTempFile = new System.Windows.Forms.TextBox();
            this.tbBuildFilename = new System.Windows.Forms.TextBox();
            this.btTempPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProjectSavePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "生成文件名称:";
            // 
            // tbTempFile
            // 
            this.tbTempFile.Location = new System.Drawing.Point(101, 6);
            this.tbTempFile.Name = "tbTempFile";
            this.tbTempFile.ReadOnly = true;
            this.tbTempFile.Size = new System.Drawing.Size(364, 21);
            this.tbTempFile.TabIndex = 3;
            // 
            // tbBuildFilename
            // 
            this.tbBuildFilename.Location = new System.Drawing.Point(102, 34);
            this.tbBuildFilename.Name = "tbBuildFilename";
            this.tbBuildFilename.Size = new System.Drawing.Size(364, 21);
            this.tbBuildFilename.TabIndex = 4;
            this.tbBuildFilename.Text = "*";
            // 
            // btTempPath
            // 
            this.btTempPath.Location = new System.Drawing.Point(20, 4);
            this.btTempPath.Name = "btTempPath";
            this.btTempPath.Size = new System.Drawing.Size(75, 23);
            this.btTempPath.TabIndex = 6;
            this.btTempPath.Text = "模板路径:";
            this.btTempPath.UseVisualStyleBackColor = true;
            this.btTempPath.Click += new System.EventHandler(this.btTempPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(390, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "文件生成路径:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(102, 61);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(363, 21);
            this.txtSavePath.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "保存路径:";
            // 
            // txtProjectSavePath
            // 
            this.txtProjectSavePath.Location = new System.Drawing.Point(101, 90);
            this.txtProjectSavePath.Name = "txtProjectSavePath";
            this.txtProjectSavePath.Size = new System.Drawing.Size(363, 21);
            this.txtProjectSavePath.TabIndex = 13;
            // 
            // FmAddTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 158);
            this.Controls.Add(this.txtProjectSavePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btTempPath);
            this.Controls.Add(this.tbBuildFilename);
            this.Controls.Add(this.tbTempFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FmAddTemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模板添加";
            this.Load += new System.EventHandler(this.FmAddTemp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTempFile;
        private System.Windows.Forms.TextBox tbBuildFilename;
        private System.Windows.Forms.Button btTempPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjectSavePath;
    }
}