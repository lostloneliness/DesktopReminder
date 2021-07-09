using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopReminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            InitPlanInputForm();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;  //取消当前的操作，即取消关闭窗体的操作
            //this.Hide();
        }

        
    }
}
