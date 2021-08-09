using SQLiteDataBase;
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
            //初始化数据库，创建一个空的计划数据表和提醒设置表
            DataBase.InitDatabase(sqliteName, tableName, settableName, path);

            InitPlanInputForm();    //初始化计划录入界面
            InitReminderSettings(); //初始化提醒设置界面
            InitPlanQueryModel();   //初始化计划查询界面
            InitPlanStatistics();   //初始化计划统计界面
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;  //取消当前的操作，即取消关闭窗体的操作
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //判断CheckBox控件是否选中
            if(chk_AutoCheck.Checked == true)
            {
                //提示近3天的任务
                days = 3;
                Thread thread = new Thread(() =>
                {
                    //读取数据库中所有的计划
                    List<Paramenters.planTable> planDatas = DataBase.ReadDatabase(sqliteName, tableName, path);
                    string plan = string.Empty;
                    for (int j = 0; j < days; j++)                    {
                        List<Paramenters.planTable> list = QueryDays(planDatas, j);                        
                        for (int i = 0; i < list.Count; i++)
                        {
                            plan += list[i].planTitle + "\r\n";    //符合条件的计划标题
                        }                      
                    }
                    DisplayBubble(days, plan);
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }
    }
}
