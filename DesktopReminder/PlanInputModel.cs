using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteDataBase;

namespace DesktopReminder
{
    partial class Form1
    {
        static private string path = Environment.CurrentDirectory;  //.exe文件所在的目录
        static private string sqliteName = "plan";
        static private string tableName = "planTable";


        private void InitPlanInputForm()
        {
            //初始化dataGridView控件列的大小
            dgv_Plan.Columns[0].Width = dgv_Plan.Width / 4 ;
            dgv_Plan.Columns[1].Width = dgv_Plan.Width / 4 ;
            dgv_Plan.Columns[2].Width = dgv_Plan.Width / 4 - 1;
            dgv_Plan.Columns[3].Width = dgv_Plan.Width / 4 - 1;
            //dataGridView控件选择整行
            dgv_Plan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //初始化数据库，创建一个空的数据表
            DataBase.InitDatabase(sqliteName,tableName,path);
            //读取数据库数据更新在dataGridView控件上
            UpdateDataGridView();
        }
        /// <summary>
        /// 读取数据库的值，更新dateGridView
        /// </summary>
        private void UpdateDataGridView()
        {
            List<Paramenters.planTable> planDatas = new List<Paramenters.planTable>();
            planDatas = DataBase.ReadDatabase(sqliteName,tableName,path);
            //使用BindingList绑定数据的时候，只显示多少行，但是不显示内容
            //BindingList<Paramenters.planTable> Blist = new BindingList<Paramenters.planTable>(planDatas);
            //dgv_Plan.AutoGenerateColumns = true;         //允许dataGridView自动创建列
            //dgv_Plan.DataSource = Blist;
           
            for(int i = 0;i<planDatas.Count;i++)
            {
                dgv_Plan.Rows.Add();
                dgv_Plan.Rows[i].Cells[0].Value = planDatas[i].planTitle;
                dgv_Plan.Rows[i].Cells[1].Value = planDatas[i].planKind;
                dgv_Plan.Rows[i].Cells[2].Value = planDatas[i].executionTime;
                dgv_Plan.Rows[i].Cells[3].Value = planDatas[i].planContent; ;
            }

        }

        /// <summary>
        /// 将数据添加到数据库中，并将这一条数据插入到dataGridView空间中
        /// 不采用UpdateDataGridView(),避免更新已经显示的值，造成时间浪费
        /// </summary>
        private void AddDataToDb()
        {

        }
        #region DataGridView的右键事件，增加、修改、删除计划
        private void 添加计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btn_AddPlan.Enabled = true;
            btn_ModifyPlan.Enabled = false;
        }

        private void 修改计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btn_AddPlan.Enabled = false;
            btn_ModifyPlan.Enabled = true;
            //将dataGridView控件中选中行的数据更新在右侧panle中
            txt_PlanTitle.Text = dgv_Plan.SelectedRows[0].Cells[0].Value.ToString();
            cbox_PlanKind.Text = dgv_Plan.SelectedRows[0].Cells[1].Value.ToString();
            dtp_ExecutionTime.Text = dgv_Plan.SelectedRows[0].Cells[2].Value.ToString();
            txt_PlanContent.Text = dgv_Plan.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void 删除计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btn_AddPlan_Click(object sender, EventArgs e)
        {
            Paramenters.planTable planData = new Paramenters.planTable();
            if (txt_PlanTitle.Text == "" && txt_PlanContent.Text == "" && cbox_PlanKind.Text == "")
            {
                MessageBox.Show("请输入完整计划");
                return;
            }
            //获取界面控件数据
            planData.planTitle = txt_PlanTitle.Text;
            planData.planKind = cbox_PlanKind.Text;
            planData.executionTime = dtp_ExecutionTime.Text;
            planData.planContent = txt_PlanContent.Text;

            //将数据存储到数据库中
            DataBase.InserDatabase(sqliteName, tableName, path, planData);

            //将添加的数据加载到dataGridView中的去
            dgv_Plan.Rows.Add();
            dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[0].Value = planData.planTitle;
            dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[1].Value = planData.planKind;
            dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[2].Value = planData.executionTime;
            dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[3].Value = planData.planContent;

            if (DataBase.Information == null)
                MessageBox.Show("添加计划成功");
            else
                MessageBox.Show(DataBase.Information);
        }
        private void btn_ModifyPlan_Click(object sender, EventArgs e)
        {
            //将修改后的数据更新到数据库中
            //DataBase.SaveDatabase(sqliteName,tableName,)

            //更新dataGrid控件

           
        }
    }
}
