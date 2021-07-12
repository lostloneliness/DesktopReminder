﻿using System;
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
        private void InitPlanQueryModel()
        {
            //初始化dataGridView控件中每一列的宽度
            dgv_ShowPlan.Columns[0].Width = dgv_ShowPlan.Width / 5;
            dgv_ShowPlan.Columns[1].Width = dgv_ShowPlan.Width / 5;
            dgv_ShowPlan.Columns[2].Width = dgv_ShowPlan.Width / 5;
            dgv_ShowPlan.Columns[3].Width = dgv_ShowPlan.Width / 5;
            dgv_ShowPlan.Columns[4].Width = dgv_ShowPlan.Width / 5;

            
        }

        //按计划内容查询,区分大小写
        private List<planTable> QueryContent(List<planTable> planDatas)
        {
            List<planTable> list = (from a in planDatas
                                    where a.planContent.Contains(txt_keyword.Text)
                                    orderby a.executionTime descending
                                    select a).ToList();
            return list;
        }
        private List<planTable> QueryDays(List<planTable> planDatas,int days)
        {
            List<planTable> list = (from a in planDatas
                                    where a.planContent.Contains(txt_keyword.Text)
                                    orderby a.executionTime descending
                                    select a).ToList();
            return list;
        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            //读取数据库中的数据，返回list
            List<Paramenters.planTable> planDatas = DataBase.ReadDatabase(sqliteName, tableName, path);
            List<planTable> list = new List<planTable>();
            int days = (int)nud_ReminderDays.Value;
            if (chk_QueryContent.Checked == true)
            {
                list = QueryContent(planDatas);
            }
            else if (chk_QueryDays.Checked == true)
            {
                //string str = DateTime.Now.ToLongDateString();
                //list = QueryDays(days);
            }
            else
                MessageBox.Show("请选择查询方式");

            //将查询后的结果显示在dataGridView上
            UpdateDataGridView(dgv_ShowPlan, list,true);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}