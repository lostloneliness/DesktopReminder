using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteDataBase;
using static SQLiteDataBase.Paramenters;

namespace DesktopReminder
{
    public partial class Form1
    {
        //对应12个月的天数
        private List<byte> daysofMomth = new List<byte>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        /// <summary>
        /// 初始化“计划查询”tabpage
        /// </summary>
        private void InitPlanQueryModel()
        {
            //初始化dataGridView控件中每一列的宽度
            dgv_ShowPlan.Columns[0].Width = dgv_ShowPlan.Width / 6;
            dgv_ShowPlan.Columns[1].Width = dgv_ShowPlan.Width / 6;
            dgv_ShowPlan.Columns[2].Width = dgv_ShowPlan.Width / 6;
            dgv_ShowPlan.Columns[3].Width = dgv_ShowPlan.Width / 6;
            dgv_ShowPlan.Columns[4].Width = dgv_ShowPlan.Width / 6;
            dgv_ShowPlan.Columns[5].Width = dgv_ShowPlan.Width / 6;            
        }

        /// <summary>
        /// 按照提前日期查找，考虑大小月和闰年的情况
        /// 闰年，条件1，能被闰年整除
        /// 条件2，能被4整除，但是不能被100整除
        /// 例如，当前日期是2021年7月13日，提前日期是10天，那么就查询2021年7月23日的日期
        /// </summary>
        /// <param name="planDatas"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private List<planTable> QueryDays(List<planTable> planDatas,int Advancedays)
        {
            List<planTable> list = new List<planTable>();
            int planYear = 0, planMonth = 0, planDay = 0;
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;
            if ((currentYear % 400 == 0) || (currentYear % 4 == 0 && currentYear % 100 != 0))  //判断是否是闰年
            {
                daysofMomth[1] = 29;       //闰年2月份有29天
            }
            else
                daysofMomth[1] = 28;

            //未考虑提前了2个月，3个月情况
            //未考虑跨年的情况
            if(currentDay + Advancedays <= daysofMomth[currentMonth - 1])
            {
                planYear = currentYear;
                planMonth = currentMonth;
                planDay = currentDay + Advancedays;
            }
            else 
            {
                planYear = currentYear;
                planMonth = currentMonth + 1;
                planDay = currentDay + Advancedays - daysofMomth[currentMonth - 1];
            }
            list = (from a in planDatas
                    where a.executionTime == planYear + "/" + planMonth + "/" + planDay
                    orderby a.executionTime descending
                   select a).ToList();
            return list;
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_query_Click(object sender, EventArgs e)
        {
            //读取数据库中的数据，返回list
            List<Paramenters.planTable> planDatas = DataBase.ReadData(sqliteName, tableName, path);
            List<planTable> list = new List<planTable>();
            
            //按照内容关键字查询
            if (chk_QueryContent.Checked == true)
            {
                if (txt_keyword.Text == "")      //关键字为空，则查询全部
                    list = planDatas;
                else
                    list = (from a in planDatas
                            where a.planContent.Contains(txt_keyword.Text)
                            orderby a.executionTime descending
                            select a).ToList();
            }
            //按照提前时间查询
            else if (chk_QueryDays.Checked == true)
            {
                if (txt_Days.Text == "")      //提前天数为空，则查询全部
                    list = planDatas;
                else
                {
                    int advancedays = Convert.ToInt32(txt_Days.Text);
                    list = QueryDays(planDatas, advancedays);
                }
            }
            else
                MessageBox.Show("请选择查询方式");

            //将查询后的结果显示在dataGridView上
            UpdateDataGridView(dgv_ShowPlan, list,true);
        }


        /// <summary>
        /// DataGridView控件双击单元格时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ShowPlan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //将双击行的plantitle显示在新界面上
            TreatmentPlanForm treatmentPlanForm = new TreatmentPlanForm(dgv_ShowPlan,sqliteName,tableName,path);
            treatmentPlanForm.Show();        
        }
    }
}
