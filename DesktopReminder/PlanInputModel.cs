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
        static private string oldTitle = null;
        static private bool status = true;


        private void InitPlanInputForm()
        {
            //初始化dataGridView控件列的大小
            dgv_Plan.Columns[0].Width = dgv_Plan.Width / 4 ;
            dgv_Plan.Columns[1].Width = dgv_Plan.Width / 4 ;
            dgv_Plan.Columns[2].Width = dgv_Plan.Width / 4 - 1;
            dgv_Plan.Columns[3].Width = dgv_Plan.Width / 4 - 1;
            //初始化数据库，创建一个空的数据表
            DataBase.InitDatabase(sqliteName,tableName,path);
            //读取数据库的数据
            List<Paramenters.planTable> planDatas = DataBase.ReadDatabase(sqliteName, tableName, path);
            //将数据更新到dataGridView
            UpdateDataGridView(dgv_Plan, planDatas, false) ;
        }
        /// <summary>
        /// 将数据在dateGridView显示
        /// </summary>
        private void UpdateDataGridView(DataGridView dgv, List<Paramenters.planTable> planDatas,bool Query)
        {

            dgv.Rows.Clear();
            //使用BindingList绑定数据的时候，只显示多少行，但是不显示内容
            //BindingList<Paramenters.planTable> Blist = new BindingList<Paramenters.planTable>(planDatas);
            //dgv_Plan.AutoGenerateColumns = true;         //允许dataGridView自动创建列
            //dgv_Plan.DataSource = Blist;
           
            for(int i = 0;i<planDatas.Count;i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = planDatas[i].planTitle;
                dgv.Rows[i].Cells[1].Value = planDatas[i].planKind;
                dgv.Rows[i].Cells[2].Value = planDatas[i].executionTime;
                dgv.Rows[i].Cells[3].Value = planDatas[i].planContent;
                if (Query == true)
                    dgv.Rows[i].Cells[4].Value = planDatas[i].executionOnime;
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
            oldTitle = txt_PlanTitle.Text;
        }

        private void 删除计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //从数据库中删除
            DataBase.DeleteDatabase(sqliteName, tableName, path, dgv_Plan.SelectedRows[0].Cells[0].Value.ToString().Trim());
            //从dataGridView中删除
            dgv_Plan.Rows.Remove(dgv_Plan.SelectedRows[0]);
            if (DataBase.Information == null)
                MessageBox.Show("删除计划成功");
            else
                MessageBox.Show("删除计划失败" + DataBase.Information);
        }
        #endregion

        private void btn_AddPlan_Click(object sender, EventArgs e)
        {
           
            if (txt_PlanTitle.Text == "" && txt_PlanContent.Text == "" && cbox_PlanKind.Text == "")
            {
                MessageBox.Show("请输入完整计划");
                return;
            }
            //获取界面控件数据
            Paramenters.planTable planData = GetFormData();
            //planData.planTitle = txt_PlanTitle.Text;
            //planData.planKind = cbox_PlanKind.Text;
            //planData.executionTime = dtp_ExecutionTime.Text;
            //planData.planContent = txt_PlanContent.Text;
            planData.executionOnime = "";         //新计划的 按时完成 一列的值
            //将数据存储到数据库中
            DataBase.InserDatabase(sqliteName, tableName, path, planData);
            if (DataBase.Information == null)  //保存数据成功
            {
                //将添加的数据加载到dataGridView中的去
                dgv_Plan.Rows.Add();
                dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[0].Value = planData.planTitle;
                dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[1].Value = planData.planKind;
                dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[2].Value = planData.executionTime;
                dgv_Plan.Rows[dgv_Plan.Rows.Count - 1].Cells[3].Value = planData.planContent;
                MessageBox.Show("添加计划成功");
            }
            else
                MessageBox.Show(DataBase.Information);
        }
        private void btn_ModifyPlan_Click(object sender, EventArgs e)
        {
            //获取修改后textBox中的数据
            Paramenters.planTable planData = GetFormData();

            //更新dataGrid控件
            dgv_Plan.SelectedRows[0].Cells[0].Value = txt_PlanTitle.Text;
            dgv_Plan.SelectedRows[0].Cells[1].Value = cbox_PlanKind.Text;
            dgv_Plan.SelectedRows[0].Cells[2].Value = dtp_ExecutionTime.Text;
            dgv_Plan.SelectedRows[0].Cells[3].Value = txt_PlanContent.Text;
            //dataGridView中的行是从0开始的，数据库中的行数从1开始的
            //Paramenters.planTable planData2 = DataBase.UpdataDatabase(sqliteName, tableName, planData, path, (dgv_Plan.CurrentCell.RowIndex+1).ToString());

            DataBase.DeleteDatabase(sqliteName, tableName, path, oldTitle);   //删除旧的数据,这里的txt_PlamTitle.Text是修改后的值
            DataBase.InserDatabase(sqliteName, tableName, path, planData);    //添加新的数据
        }

        //获取界面的数据
        private Paramenters.planTable GetFormData()
        {
            Paramenters.planTable planData = new Paramenters.planTable();
            //获取界面控件数据
            planData.planTitle = txt_PlanTitle.Text;
            planData.planKind = cbox_PlanKind.Text;
            planData.executionTime = dtp_ExecutionTime.Text;
            planData.planContent = txt_PlanContent.Text;
            return planData;
        }
    }
}
