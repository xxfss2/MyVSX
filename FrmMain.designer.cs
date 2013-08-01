namespace MyVSX
{
    partial class FrmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtModuleNamespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvTemps = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TVentitys = new System.Windows.Forms.TreeView();
            this.btEditTemp = new System.Windows.Forms.Button();
            this.btAddTemp = new System.Windows.Forms.Button();
            this.btDelTemp = new System.Windows.Forms.Button();
            this.btBuild = new System.Windows.Forms.Button();
            this.cbAllChoose = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbfilePath3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFactoryFile = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbfilePath2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBbuildIocXML = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCopy = new System.Windows.Forms.Button();
            this.tbfilePath1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBeditDBfile = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Core项目目录生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtModuleNamespace
            // 
            this.txtModuleNamespace.Location = new System.Drawing.Point(518, 377);
            this.txtModuleNamespace.Name = "txtModuleNamespace";
            this.txtModuleNamespace.Size = new System.Drawing.Size(170, 21);
            this.txtModuleNamespace.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "模块命名空间";
            // 
            // lvTemps
            // 
            this.lvTemps.BackColor = System.Drawing.Color.AliceBlue;
            this.lvTemps.CheckBoxes = true;
            this.lvTemps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTemps.FullRowSelect = true;
            this.lvTemps.GridLines = true;
            this.lvTemps.Location = new System.Drawing.Point(12, 12);
            this.lvTemps.MultiSelect = false;
            this.lvTemps.Name = "lvTemps";
            this.lvTemps.Size = new System.Drawing.Size(714, 140);
            this.lvTemps.TabIndex = 4;
            this.lvTemps.UseCompatibleStateImageBehavior = false;
            this.lvTemps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "模板文件";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "代码文件名称";
            this.columnHeader2.Width = 150;
            // 
            // TVentitys
            // 
            this.TVentitys.CheckBoxes = true;
            this.TVentitys.Location = new System.Drawing.Point(12, 158);
            this.TVentitys.Name = "TVentitys";
            this.TVentitys.Size = new System.Drawing.Size(198, 291);
            this.TVentitys.TabIndex = 16;
            // 
            // btEditTemp
            // 
            this.btEditTemp.Location = new System.Drawing.Point(567, 158);
            this.btEditTemp.Name = "btEditTemp";
            this.btEditTemp.Size = new System.Drawing.Size(75, 23);
            this.btEditTemp.TabIndex = 18;
            this.btEditTemp.Text = "修改";
            this.btEditTemp.UseVisualStyleBackColor = true;
            this.btEditTemp.Click += new System.EventHandler(this.btEditTemp_Click);
            // 
            // btAddTemp
            // 
            this.btAddTemp.Location = new System.Drawing.Point(486, 158);
            this.btAddTemp.Name = "btAddTemp";
            this.btAddTemp.Size = new System.Drawing.Size(75, 23);
            this.btAddTemp.TabIndex = 19;
            this.btAddTemp.Text = "添加模板";
            this.btAddTemp.UseVisualStyleBackColor = true;
            this.btAddTemp.Click += new System.EventHandler(this.btAddTemp_Click);
            // 
            // btDelTemp
            // 
            this.btDelTemp.Location = new System.Drawing.Point(648, 158);
            this.btDelTemp.Name = "btDelTemp";
            this.btDelTemp.Size = new System.Drawing.Size(75, 23);
            this.btDelTemp.TabIndex = 17;
            this.btDelTemp.Text = "删除模板";
            this.btDelTemp.UseVisualStyleBackColor = true;
            // 
            // btBuild
            // 
            this.btBuild.BackColor = System.Drawing.Color.Lavender;
            this.btBuild.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btBuild.Location = new System.Drawing.Point(596, 415);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(92, 34);
            this.btBuild.TabIndex = 20;
            this.btBuild.Text = "生成";
            this.btBuild.UseVisualStyleBackColor = false;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
            // 
            // cbAllChoose
            // 
            this.cbAllChoose.AutoSize = true;
            this.cbAllChoose.Location = new System.Drawing.Point(12, 455);
            this.cbAllChoose.Name = "cbAllChoose";
            this.cbAllChoose.Size = new System.Drawing.Size(48, 16);
            this.cbAllChoose.TabIndex = 21;
            this.cbAllChoose.Text = "全选";
            this.cbAllChoose.UseVisualStyleBackColor = true;
            this.cbAllChoose.CheckedChanged += new System.EventHandler(this.cbAllChoose_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.tbfilePath3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbFactoryFile);
            this.groupBox3.Location = new System.Drawing.Point(225, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 45);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他选项";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(419, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 24);
            this.button2.TabIndex = 16;
            this.button2.Text = "手动复制";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbfilePath3
            // 
            this.tbfilePath3.Location = new System.Drawing.Point(81, 18);
            this.tbfilePath3.Name = "tbfilePath3";
            this.tbfilePath3.ReadOnly = true;
            this.tbfilePath3.Size = new System.Drawing.Size(332, 21);
            this.tbfilePath3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "文件目录:";
            // 
            // cbFactoryFile
            // 
            this.cbFactoryFile.AutoSize = true;
            this.cbFactoryFile.Enabled = false;
            this.cbFactoryFile.Location = new System.Drawing.Point(8, 0);
            this.cbFactoryFile.Name = "cbFactoryFile";
            this.cbFactoryFile.Size = new System.Drawing.Size(138, 16);
            this.cbFactoryFile.TabIndex = 0;
            this.cbFactoryFile.Text = "是否编辑Factory文件";
            this.cbFactoryFile.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.tbfilePath2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CBbuildIocXML);
            this.groupBox2.Location = new System.Drawing.Point(225, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 48);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(419, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 24);
            this.button3.TabIndex = 15;
            this.button3.Text = "手动复制";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbfilePath2
            // 
            this.tbfilePath2.Location = new System.Drawing.Point(81, 20);
            this.tbfilePath2.Name = "tbfilePath2";
            this.tbfilePath2.ReadOnly = true;
            this.tbfilePath2.Size = new System.Drawing.Size(332, 21);
            this.tbfilePath2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "文件目录:";
            // 
            // CBbuildIocXML
            // 
            this.CBbuildIocXML.AutoSize = true;
            this.CBbuildIocXML.Location = new System.Drawing.Point(8, 0);
            this.CBbuildIocXML.Name = "CBbuildIocXML";
            this.CBbuildIocXML.Size = new System.Drawing.Size(138, 16);
            this.CBbuildIocXML.TabIndex = 12;
            this.CBbuildIocXML.Text = "是否编辑IOC配置文件";
            this.CBbuildIocXML.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btCopy);
            this.groupBox1.Controls.Add(this.tbfilePath1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBeditDBfile);
            this.groupBox1.Location = new System.Drawing.Point(225, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 49);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btCopy
            // 
            this.btCopy.BackColor = System.Drawing.SystemColors.Control;
            this.btCopy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCopy.Location = new System.Drawing.Point(419, 17);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(69, 24);
            this.btCopy.TabIndex = 14;
            this.btCopy.Text = "手动复制";
            this.btCopy.UseVisualStyleBackColor = false;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // tbfilePath1
            // 
            this.tbfilePath1.Location = new System.Drawing.Point(81, 20);
            this.tbfilePath1.Name = "tbfilePath1";
            this.tbfilePath1.ReadOnly = true;
            this.tbfilePath1.Size = new System.Drawing.Size(332, 21);
            this.tbfilePath1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "文件目录:";
            // 
            // CBeditDBfile
            // 
            this.CBeditDBfile.AutoSize = true;
            this.CBeditDBfile.Location = new System.Drawing.Point(8, 0);
            this.CBeditDBfile.Name = "CBeditDBfile";
            this.CBeditDBfile.Size = new System.Drawing.Size(144, 16);
            this.CBeditDBfile.TabIndex = 11;
            this.CBeditDBfile.Text = "是否编辑Database文件";
            this.CBeditDBfile.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 478);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbAllChoose);
            this.Controls.Add(this.btBuild);
            this.Controls.Add(this.btEditTemp);
            this.Controls.Add(this.btAddTemp);
            this.Controls.Add(this.btDelTemp);
            this.Controls.Add(this.TVentitys);
            this.Controls.Add(this.lvTemps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModuleNamespace);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "FamMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FamMain_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtModuleNamespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvTemps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TreeView TVentitys;
        private System.Windows.Forms.Button btEditTemp;
        private System.Windows.Forms.Button btAddTemp;
        private System.Windows.Forms.Button btDelTemp;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.CheckBox cbAllChoose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbfilePath3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbFactoryFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbfilePath2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CBbuildIocXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.TextBox tbfilePath1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CBeditDBfile;
    }
}