using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeProduce
{
    public partial class FmPrint : Form
    {
        public FmPrint(string str)
        {
            InitializeComponent();
            textBox1.Text = str;
        }
    }
}
