using Microsoft.Win32;
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
            //this.Close();         //窗体关闭了，但是程序进程以仍在运行                   
        }
        //修改注册表控制程序自动运行
        private void 开机自动运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;     //应用程序完整路径
            //获取可执行文件名称，不包含路径，包含后缀名
            string strName = Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf("/")+1);
            //读取注册表指定项
            //RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //if (RKey == null)    //若指定的子项不存在
            //{
            //    //以创建的方式打开指定项
            //    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            //    RKey.SetValue(strName, path);          //设置该子项的新“键值对”
            //}
            //else
            //{
            //    RKey.DeleteValue(strName, false);         //若指定的子项存在，删除指定的“键名的值”;
            //}
            //开机自启动的两种方式
            // https://www.cnblogs.com/mq0036/p/12117955.html
            //设置当前菜单项被选中，上一个菜单项取消选中
            //item是ToolStripItem类型的，需要强制转换为ToolStripMenuItem，否则没有.checked选项
            ToolStripMenuItem menuItem = (ToolStripMenuItem)cms_tryMenu.Items[1];   //菜单灰度校正的子菜单
            for (int i = 0; i < menuItem.DropDownItems.Count; i++)
            {
                if (menuItem.DropDownItems[i] == (ToolStripMenuItem)sender)
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = true;
                else
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = false;

            }
        }

        private void 取消开机自动运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //((ToolStripMenuItem)sender).Checked = true;
            ToolStripMenuItem menuItem = (ToolStripMenuItem)cms_tryMenu.Items[1];   //菜单灰度校正的子菜单
            for (int i = 0; i < menuItem.DropDownItems.Count; i++)
            {
                if (menuItem.DropDownItems[i] == (ToolStripMenuItem)sender)
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = true;
                else
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = false;

            }
        }

        private void 设置定时关机功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)cms_tryMenu.Items[1];   //菜单灰度校正的子菜单
            for (int i = 0; i < menuItem.DropDownItems.Count; i++)
            {
                if (menuItem.DropDownItems[i] == (ToolStripMenuItem)sender)
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = true;
                else
                    ((ToolStripMenuItem)menuItem.DropDownItems[i]).Checked = false;

            }
        }
    }

}
