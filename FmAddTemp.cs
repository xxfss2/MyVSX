using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeProduce.BaseCode;
using CodeProduce.Solution;

namespace MyVSX
{
    public partial class FmAddTemp : Form
    {

        public FmAddTemp()
        {
            InitializeComponent();
        }
        public FrmMain _frmMain;
        public TempInfo CurrTemp = new TempInfo();
        public string CoreProjectPath { get; set; }
        public string EFProjectPath { get; set; }

        private void btTempPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbTempFile.Text = openFileDialog1.FileName;
                if (tbTempFile.Text.EndsWith("IEntity.txt"))
                {
                    tbBuildFilename.Text = "I*";
                    txtSavePath.Text = SolutionAction.DIRECTORY+SolutionAction .CurrSolution .Name + "\\IEntity";
                    txtProjectSavePath.Text = _frmMain._coreProjPath + "\\DomainObjects";
                    return;
                }

                if (tbTempFile.Text.EndsWith("IRepository.txt"))
                {
                    tbBuildFilename.Text = "I*Repository";
                    txtSavePath.Text = SolutionAction.DIRECTORY  + SolutionAction.CurrSolution.Name + "\\IRepository";
                    txtProjectSavePath.Text = _frmMain._coreProjPath + "\\Repository";
                    return;
                }

                if (tbTempFile.Text.EndsWith("IService.txt"))
                {
                    tbBuildFilename.Text = "I*Service";
                    txtSavePath.Text = SolutionAction.DIRECTORY + SolutionAction.CurrSolution.Name + "\\IService";
                    txtProjectSavePath.Text = _frmMain._coreProjPath + "\\Service";
                    return;
                }
                if (tbTempFile.Text.EndsWith("Repository.txt"))
                {
                    tbBuildFilename.Text = "*Repository";
                    txtSavePath.Text = SolutionAction.DIRECTORY + SolutionAction.CurrSolution.Name + "\\Repository";
                    txtProjectSavePath.Text = _frmMain._efProjPath + "\\Repository";
                }
                if (tbTempFile.Text.EndsWith("Service.txt"))
                {
                    tbBuildFilename.Text = "*Service";
                    txtSavePath.Text = SolutionAction.DIRECTORY + SolutionAction.CurrSolution.Name + "\\Service";
                    txtProjectSavePath.Text = _frmMain._efProjPath + "\\Service";
                }
                if (tbTempFile.Text.EndsWith("Entity.txt"))
                {
                    tbBuildFilename.Text = "*";
                    txtSavePath.Text = SolutionAction.DIRECTORY + SolutionAction.CurrSolution.Name + "\\Entity";
                    txtProjectSavePath.Text = _frmMain._efProjPath + "\\DomainObjects\\Xxf";
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CurrTemp.IsInterface = false;
            CurrTemp.BuildFilename = tbBuildFilename.Text.Trim();
            CurrTemp.FullName = tbTempFile.Text;
            CurrTemp.SavePath = txtSavePath.Text;
            CurrTemp.ProjectPath = txtProjectSavePath.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FmAddTemp_Load(object sender, EventArgs e)
        {
            if (CurrTemp != null)
            {
                tbBuildFilename.Text = CurrTemp.BuildFilename;
                tbTempFile.Text = CurrTemp.FullName;
            }
            _frmMain =(FrmMain) Owner;
        }

    }
}
