using SQLiteDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLiteDataBase.Paramenters;

namespace DesktopReminder
{
    public partial class Form1
    {
        /// <summary>
        /// 初始化“计划统计”tabpage
        /// </summary>
        private void InitPlanStatistics()
        {
            dgv_statisticsPlan.Columns[0].Width = dgv_ShowPlan.Width / 6;
            dgv_statisticsPlan.Columns[1].Width = dgv_ShowPlan.Width / 6;
            dgv_statisticsPlan.Columns[2].Width = dgv_ShowPlan.Width / 6;
            dgv_statisticsPlan.Columns[3].Width = dgv_ShowPlan.Width / 6;
            dgv_statisticsPlan.Columns[4].Width = dgv_ShowPlan.Width / 6;
            dgv_statisticsPlan.Columns[5].Width = dgv_ShowPlan.Width / 6;
        }
        /// <summary>
        /// 查询button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StatisticsQuery_Click(object sender, EventArgs e)
        {
            string condition = "按时执行=";
            List<planTable> planDatas = new List<planTable>();
            if (rdo_Ontime.Checked == true)
                condition += "'是'";
            else if (rdo_NotOntime.Checked == true)
                condition += "'否'";
            planDatas = DataBase.ReadData(sqliteName, tableName, path, condition);
            if (planDatas.Count != 0)
                //更新dataGridView
                UpdateDataGridView(dgv_statisticsPlan, planDatas, true);     //true，显示按时执行和执行说明列
        }
    }
}
