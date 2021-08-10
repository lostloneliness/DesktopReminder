using SQLiteDataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SQLiteDataBase.Paramenters;

namespace DesktopReminder
{
    public partial class Form1
    {


        private int days = 0;
        private bool isAutoCheck = false;       //开机自检查
        /// <summary>
        /// 初始化 提醒设置 界面
        /// </summary>
        private void InitReminderSettings()
        {
            settingTable settingtable = DataBase.ReadSetData(sqliteName, path, settableName);
            nud_ReminderDays.Value = Convert.ToInt32(settingtable.reminderDay);
            nud_RemindersIntervals.Value = (decimal)(Convert.ToSingle(settingtable.reminderTime));
            chk_AutoCheck.Checked = settingtable.isAutoCheck == true ? true : false;
            chk_isTimeCue.Checked = settingtable.isTimeCue == true ? true : false;

        }
        /// <summary>
        /// 确定button，将界面的设置数据存储到数据库中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Determine_Click(object sender, EventArgs e)
        {
            settingTable settingtable = new settingTable();
            settingtable.reminderDay = nud_ReminderDays.Value.ToString();
            settingtable.reminderTime = nud_RemindersIntervals.Value.ToString();
            settingtable.isAutoCheck = chk_AutoCheck.Checked == true ? true : false;
            settingtable.isTimeCue = chk_isTimeCue.Checked == true ? true : false;
            bool flag = DataBase.InsertData(sqliteName, path, settableName, settingtable, true);  //替换旧的数据而不是插入新的行
            if (flag)
            {
                MessageBox.Show("设置成功");
                if (chk_isTimeCue.Checked == true)
                {
                    days = Convert.ToInt32(nud_ReminderDays.Value) + 1;//存储提前天数
                    timer1.Interval = Convert.ToInt32(nud_RemindersIntervals.Value * 60 * 60 * 1000);
                    timer1.Enabled = true;
                }
                else
                {
                    timer1.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("设置失败" + DataBase.Information);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReminderThread));
            thread.IsBackground = true;
            thread.Start();

        }
        //后台线程 查找符合条件的计划，并气泡显示
        private void ReminderThread()
        {
            //读取数据库中所有的计划
            List<Paramenters.planTable> planDatas = DataBase.ReadData(sqliteName, tableName, path);
            string plan = string.Empty;
            for (int j = 0; j < days; j++)
            {
                //查找符合条件的计划
                List<Paramenters.planTable> list = QueryDays(planDatas, j);
                for (int i = 0; i < list.Count; i++)
                {
                    plan += list[i].planTitle + "\r\n";    //符合条件的计划标题
                }
            }
            //气泡显示
            DisplayBubble(days, plan);                
        }

        /// <summary>
        /// 气泡显示
        /// </summary>
        /// <param name="days">天数</param>
        /// <param name="plan">待显示的计划</param>
        private void DisplayBubble(int days,string plan)
        {
            string strTemp = string.Empty;
            if (days == 0) //即提请当天的计划
            {
                strTemp = plan == "" ? "今天无未执行计划" : "今天有以下未执行计划:\r\n"; //plan == ""表示没有符合条件的计划
            }
            else
            {
                strTemp = plan == "" ? "未来" + days + "天没有未执行的计划:\r\n" : "未来" + days + "天有以下未执行的计划任务:\r\n";
            }
            nfi_trayMenu.ShowBalloonTip(2000, "计划提示:", strTemp + plan + "详情请单击托盘图标！", ToolTipIcon.Info); //提示显示时间1s          
        }

    }
}
