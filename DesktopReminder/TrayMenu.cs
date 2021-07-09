using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopReminder
{
    partial class Form1
    {
        private void nfi_trayMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //当鼠标左键按下时
                this.Show();
            else
                return;
        }
        private void 打开窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            nfi_trayMenu.Visible = false;          //否则结束进程之后，图标会延时一段时间才会消失

            Environment.Exit(Environment.ExitCode);    //结束进程
            //this.Close();         //窗体关闭了，但是程序进程以让在运行                   
        }

        private void 开机自动运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 取消开机自动运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设置定时关机功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
