using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace DesktopReminder
{
    partial class Form1
    {
        /// <summary>
        /// 点击托盘图标，显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            nfi_trayMenu.Visible = false;         
            Environment.Exit(Environment.ExitCode);    //结束进程              
        }
        
        private void 开机自动运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAutoOn(true);
            //设置当前菜单项被选中，上一个菜单项取消选中
            //item是ToolStripItem类型的，需要强制转换为ToolStripMenuItem，否则没有.checked选项
            ToolStripMenuItem menuItem = (ToolStripMenuItem)cms_tryMenu.Items[1];   //系统设置菜单的子菜单
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
            isAutoOn(false);       //取消自动刚开机
            ToolStripMenuItem menuItem = (ToolStripMenuItem)cms_tryMenu.Items[1];   //系统设置菜单的子菜单
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

        /// <summary>
        /// 根据参数onOff设置是否自动开机
        /// </summary>
        /// <param name="onOff">true:自动开机，false:非自动开机</param>
        private void isAutoOn(bool onOff)
        {
            //系统自动系统的目录
            string systemStartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            //程序完整路径
            string appAllPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string quickName = "任务提醒器";       //需要创建的快捷方式名称
            bool isExsits = QueryQuickFolder(systemStartPath, quickName);
            if (onOff)
            {
                if (isExsits)
                    //创建快捷方式，快捷方式文件名中不显示后缀.lnk
                    CreateQuickName(systemStartPath, quickName, appAllPath);
                else
                    MessageBox.Show("软件已设置开启自启动");
            }
            //设置开机不自启动
            else
            {
                if (isExsits)
                    Delete(systemStartPath, quickName);
                else
                    MessageBox.Show("软件已设置开机不自启动");
            }
        }

      

        /// <summary>
        /// 在系统文件夹中的所有快捷方式中查找需要创建的快捷方式是否存在
        /// </summary>
        /// <param name="directory">系统启动文件夹</param>
        /// <param name="quickName">快捷方式的名称，没有后缀名</param>
        /// <returns>true:存在，false：不存在</returns>
        private bool QueryQuickFolder(string directory,string quickName)
        {
            List<string> tempStrs = new List<string>();
            string[] files = System.IO.Directory.GetFiles(directory);  //获取指定目录下的所有快捷方式的路径,带后缀
            if(files.Length < 1)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string filesname = files[i].Substring(files[i].LastIndexOf("\\") + 1);
                    if (filesname == quickName + ".lnk")
                        break;
                }
                return true;
            }
        }

        /// <summary>
        /// 删除系统刚启动目录中，指定的快捷方式
        /// </summary>
        /// <param name="quickNames">所有符合条件的快捷方式</param>
        private void Delete(string directory,string quickName)
        {

            System.IO.File.Delete(System.IO.Path.Combine(directory, string.Format("{0}.lnk", quickName))) ;
        }

        /// <summary>
        /// 向指定的文件夹内创建指定文件的快捷方式
        /// </summary>
        /// <param name="directory">系统启动目录</param>
        /// <param name="quickName">快捷方式名称</param>
        /// <param name="appAllPath">程序的完整路径</param>
        /// <returns></returns>
        private bool CreateQuickName(string directory,string quickName,string appAllPath)
        {
            try
            {
                //获取快捷方式的完整路径
                //在实际创建快捷方式中.lnk没有显示
                string quickPath = System.IO.Path.Combine(directory, string.Format("{0}.lnk", quickName));
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut shortcut = shell.CreateShortcut(quickPath);
                shortcut.TargetPath = appAllPath;
                shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(appAllPath);
                shortcut.WindowStyle = 1;
                
                shortcut.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


      
    }

}
