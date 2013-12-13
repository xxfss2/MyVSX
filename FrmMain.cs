using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using CodeProduce.CodeAnalysis;
using CodeProduce.Temp;
using CodeProduce.Solution;
using CodeProduce.BaseCode;
using CodeProduce;

namespace MyVSX
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public DTE2 VSObject { get; set; }

        private CodeAnysis _codeAnysis;
        private CodeBuildService _databaseSer;
        private CodeBuildService _factorySer;
        //Core EF 项目文件夹路径
        public string _coreProjPath;
        public string _efProjPath;
        //Core EF 项目名称 命令空间
        string _coreProjName;
        string _efProjName;
        //确定Core EF项目 编程对象
        Project _coreProjObj = null;
        Project _efProjObj = null;

        Solution2 _soln = null;

        private void button1_Click(object sender, EventArgs e)
        {

            //获取解决方案路径
            string solutionPath = _soln.FullName.Substring(0, _soln.FullName.LastIndexOf('\\') + 1);
            //Core EF 项目名称 命令空间
            string coreProjName = txtModuleNamespace.Text + ".Core";
            string efProjName = txtModuleNamespace.Text + ".EF";
            //Core EF 项目文件夹路径
            string coreProjPath = solutionPath + coreProjName;
            string efProjPath = solutionPath + efProjName;
            //加载类库项目模板
            string CoreTemplatePath = _soln.GetProjectTemplate("Core_Templete.zip", "CSharp");
            string EFTemplatePath = _soln.GetProjectTemplate("EF_Templete.zip", "CSharp");//
            //向解决方案中添加两个项目
            _soln.AddFromTemplate(CoreTemplatePath, coreProjPath, coreProjName, false);
            _soln.AddFromTemplate(EFTemplatePath, efProjPath, efProjName, false);
            //确定Core EF项目 编程对象
            _coreProjObj = null;
            _efProjObj = null;
            for (int i = 1; i <= _soln.Projects.Count; i++)
            {
                Project curr = _soln.Projects.Item(i);
                if (curr.Name == coreProjName)
                    _coreProjObj = curr;
                if (curr.Name == efProjName)
                    _efProjObj = curr;
            }


        }

        private void FamMain_Load(object sender, EventArgs e)
        {
            _soln = (Solution2)VSObject.Solution;

            _codeAnysis = new EntityModel4Analysis();
            _databaseSer = new EditEF4DatabaseFile();
            _factorySer = new EditFactoryFile2();

            //获取解决方案路径
            string solutionPath = _soln.FullName.Substring(0, _soln.FullName.LastIndexOf('\\') + 1);
            int inx = _soln.FullName.LastIndexOf('\\') + 1;
            string solutionName = _soln.FullName.Substring(inx, _soln.FullName.LastIndexOf('.') - inx);
            if (!SolutionAction.Open(solutionName))
            {
                SolutionAction.CurrSolution.Name = solutionName;
                SolutionAction.CurrSolution.Type = SolutionType.EntityFramework4;
            }

            _codeAnysis.Connetion(VSObject.SelectedItems.Item(1).ProjectItem.get_FileNames(1));
            foreach (TempInfo temp in SolutionAction.CurrSolution.Temps)
            {
                this.TempListCtrlAddItem(temp);
            }
            TVentitys.Nodes.Clear();
            foreach (EntityInfo entity in _codeAnysis.GetEntitys().ToList())
            {
                TreeNode nodeEntity = new TreeNode(entity.Name);
                nodeEntity.Tag = entity;
                foreach (FieldInfo field in entity.Fields)
                {
                    TreeNode nodeField = new TreeNode(field.Name);
                    nodeEntity.Nodes.Add(nodeField);
                }
                TVentitys.Nodes.Add(nodeEntity);
            }


   
            txtModuleNamespace.Text = "Xxf." + SolutionAction.CurrSolution.Name;
            //Core EF 项目名称 命令空间
            _coreProjName = txtModuleNamespace.Text + ".Core";
            _efProjName = txtModuleNamespace.Text + ".EF";
            //Core EF 项目文件夹路径
            _coreProjPath = solutionPath + _coreProjName;
            _efProjPath = solutionPath + _efProjName;

        }

        private void TempListCtrlAddItem(TempInfo tmp)
        {
            string[] infos = new string[3];
            infos[0] = tmp.FullName;
            infos[1] = tmp.BuildFilename;
            infos[2] = tmp.SavePath;
            ListViewItem item = new ListViewItem(infos);
            item.Tag = tmp;
            item.Checked = true;
            lvTemps.Items.Add(item);
        }

        private void btAddTemp_Click(object sender, EventArgs e)
        {
            FmAddTemp dlg = new FmAddTemp();
            dlg.Owner = this;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.TempListCtrlAddItem(dlg.CurrTemp);
                SolutionAction.CurrSolution.Temps.Add(dlg.CurrTemp);
            }
        }

        private void btEditTemp_Click(object sender, EventArgs e)
        {
            if (lvTemps.SelectedItems.Count > 0)
            {
                TempInfo entity = (TempInfo)lvTemps.SelectedItems[0].Tag;
                FmAddTemp dlg = new FmAddTemp();
                dlg.CurrTemp = entity;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lvTemps.SelectedItems[0].SubItems[0].Text = entity.FullName;
                    lvTemps.SelectedItems[0].SubItems[1].Text = entity.BuildFilename;
                    lvTemps.SelectedItems[0].SubItems[2].Text = entity.SavePath;
                }
            }
        }

        private List<EntityInfo> GetSelectedEntitys()
        {
            List<EntityInfo> entitys = new List<EntityInfo>();
            foreach (TreeNode node in TVentitys.Nodes)
            {
                if (node.Checked)
                    entitys.Add((EntityInfo)node.Tag);
            }
            return entitys;
        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            CodeBuild cb = CodeBuild.GetInstance();
            List<EntityInfo> entitys = GetSelectedEntitys();
            if (entitys.Count == 0)
            {
                MessageBox.Show("请至少选择一个实体类", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < lvTemps.Items.Count; i++)
            {
                TempInfo temp = new TempInfo();
                temp.FullName = lvTemps.Items[i].SubItems[0].Text;
                temp.BuildFilename = lvTemps.Items[i].SubItems[1].Text;
                temp.SavePath = lvTemps.Items[i].SubItems[2].Text;
                temp.IsInterface = false;
            }
            cb.BuildBaseCode(SolutionAction.CurrSolution.Temps, entitys);

            MoveFileToProject();


            if (CBeditDBfile.Checked)
            {
                //        EditDatabaseFile editDB = new EditDatabaseFile(tbfilePath1.Text );
                //      editDB.CodeBuild(entitys);
                //      editDB.CodeFileBuild();
            }
            if (CBbuildIocXML.Checked)
            {
                //               EditIocConfigFile editIOC = new EditIocConfigFile(tbfilePath2.Text);
                //         editIOC.CodeBuild(entitys);
                //         editIOC.CodeFileBuild();
            }
        }

        private void cbAllChoose_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in TVentitys.Nodes)
            {
                node.Checked = cbAllChoose.Checked;
            }
        }

        private void EnsureProjectObj()
        {
            for (int i = 1; i <= _soln.Projects.Count; i++)
            {
                Project curr = _soln.Projects.Item(i);
                if (curr.Name == _coreProjName)
                    _coreProjObj = curr;
                if (curr.Name == _efProjName)
                    _efProjObj = curr;
            }
        }

        /// <summary>
        /// 将生成的文件添加到项目对应的目录中
        /// </summary>
        public void MoveFileToProject()
        {
            if (_coreProjObj == null)
                this.EnsureProjectObj();
            foreach (var item in SolutionAction.CurrSolution.Temps)
            {
                var projectItem = this.FindFolderItem(_coreProjObj, item.ProjectPath);
                if (projectItem == null)
                    projectItem = this.FindFolderItem(_efProjObj , item.ProjectPath);
                var files = System.IO.Directory.GetFiles(item.SavePath);
                foreach (var file in files)
                {
                    projectItem.ProjectItems.AddFromFileCopy(file);
                }
            }
        }

        public ProjectItem FindFolderItem(Project project, string path)
        {
            path += "\\";
            ProjectItem result=null ;
            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.get_FileNames(1) == path)
                    return item;
                result = this.FindFolderItem(item, path);
                if (result != null)
                    return result;
            }
            return null;
        }

        public ProjectItem FindFolderItem(ProjectItem projectItem, string path)
        {
            foreach (ProjectItem item in projectItem.ProjectItems)
            {
                if (item.get_FileNames(1) == path)
                    return item;
                this.FindFolderItem(item, path);
            }
            return null;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SolutionAction act = new SolutionAction();
            //以解决方案名字是否为空来判断该解决方案是否是新建的
            DialogResult result = MessageBox.Show("是否保存当前代码生成方案?", "是否保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                act.Save(SolutionAction.CurrSolution);
            }
            base.OnClosing(e);
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            CodeBuild cb = CodeBuild.GetInstance();
            List<EntityInfo> entitys = GetSelectedEntitys();
            //   EditEF1DatabaseFile editDB = new EditEF1DatabaseFile();
            _databaseSer.CodeBuild(entitys);
            FmPrint dlg = new FmPrint(_databaseSer.CodePrint());
            dlg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CodeBuild cb = CodeBuild.GetInstance();
            List<EntityInfo> entitys = GetSelectedEntitys();
            EditIocConfigFile editDB = new EditIocConfigFile();
            editDB.CodeBuild(entitys);
            FmPrint dlg = new FmPrint(editDB.CodePrint());
            dlg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CodeBuild cb = CodeBuild.GetInstance();
            List<EntityInfo> entitys = GetSelectedEntitys();
            //EditFactoryFile1 editDB = new EditFactoryFile1();
            _factorySer.CodeBuild(entitys);
            FmPrint dlg = new FmPrint(_factorySer.CodePrint());
            dlg.ShowDialog();
        }
    }
}
