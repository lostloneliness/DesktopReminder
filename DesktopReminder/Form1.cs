using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            InitPlanInputForm();    //初始化计划录入界面
            InitReminderSettings(); //初始化提醒设置界面
            InitPlanQueryModel();   //初始化计划查询界面
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;  //取消当前的操作，即取消关闭窗体的操作
            //this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Thread thread = new Thread(new ThreadStart(ReminderThread));
            //thread.Start();
        }

        //后天线程 显示 气泡提醒
        private void ReminderThread()
        {
            int days;//存储提前天数
            nfi_trayMenu.ShowBalloonTip(1000, "计划提示", "提示信息", ToolTipIcon.Info);
        }


    }
}
