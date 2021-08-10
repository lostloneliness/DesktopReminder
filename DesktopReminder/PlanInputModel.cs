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
        /// <summary>
        /// 应用程序.exe所在的路径
        /// </summary>
        static private string path = Environment.CurrentDirectory;         
        /// <summary>
        /// 数据库名称
        /// </summary>
        static private string sqliteName = "plan";
        /// <summary>
        /// 数据表名称
        /// </summary>
        static private string tableName = "planTable";
        /// <summary>
        /// 设置表名称
        /// </summary>
        static private string settableName = "settingTable";
        /// <summary>
        /// 保存旧计划的标题
        /// </summary>
        static private string oldTitle = null;

        /// <summary>
        /// 初始化“计划录入”tabpage
        /// </summary>
        private void InitPlanInputForm()
        {
            //初始化dataGridView控件列的大小
            dgv_AddPlan.Columns[0].Width = dgv_AddPlan.Width / 4 ;
            dgv_AddPlan.Columns[1].Width = dgv_AddPlan.Width / 4 ;
            dgv_AddPlan.Columns[2].Width = dgv_AddPlan.Width / 4 - 1;
            dgv_AddPlan.Columns[3].Width = dgv_AddPlan.Width / 4 - 1;
           
            //读取数据库的数据
            List<Paramenters.planTable> planDatas = DataBase.ReadData(sqliteName, tableName, path);
            //将数据更新到dataGridView
            UpdateDataGridView(dgv_AddPlan, planDatas, false) ;
        }
        
        /// <summary>
        /// 将数据显示在DataGridView控件上
        /// </summary>
        /// <param name="dgv">DataGridView控件</param>
        /// <param name="planDatas">待显示的计划</param>
        /// <param name="Query">显示“是否按时执行计划”列和“执行说明”列</param>
        private void UpdateDataGridView(DataGridView dgv, List<Paramenters.planTable> planDatas,bool Query)
        {

            dgv.Rows.Clear();         
            for(int i = 0;i<planDatas.Count;i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = planDatas[i].planTitle;         //计划标题
                dgv.Rows[i].Cells[1].Value = planDatas[i].planKind;          //计划种类
                dgv.Rows[i].Cells[2].Value = planDatas[i].executionTime;     //执行时间
                dgv.Rows[i].Cells[3].Value = planDatas[i].planContent;       //计划内容
                if (Query == true)
                {
                    dgv.Rows[i].Cells[4].Value = planDatas[i].executionOnime;//是否按时执行计划
                    dgv.Rows[i].Cells[5].Value = planDatas[i].executionInstruction;   //执行说明
                }
            }

        }

        #region DataGridView的右键事件，增加、修改、删除计划
        private void 添加计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //使能界面右侧的panel控件
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
            txt_PlanTitle.Text = dgv_AddPlan.SelectedRows[0].Cells[0].Value.ToString();
            cbox_PlanKind.Text = dgv_AddPlan.SelectedRows[0].Cells[1].Value.ToString();
            dtp_ExecutionTime.Text = dgv_AddPlan.SelectedRows[0].Cells[2].Value.ToString();
            txt_PlanContent.Text = dgv_AddPlan.SelectedRows[0].Cells[3].Value.ToString();
            oldTitle = txt_PlanTitle.Text;
        }

        private void 删除计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //从数据库中删除
            DataBase.DeleteData(sqliteName, tableName, path, dgv_AddPlan.SelectedRows[0].Cells[0].Value.ToString().Trim());
            //从dataGridView中删除
            dgv_AddPlan.Rows.Remove(dgv_AddPlan.SelectedRows[0]);
            if (DataBase.Information == null)
                MessageBox.Show("删除计划成功");
            else
                MessageBox.Show("删除计划失败" + DataBase.Information);
        }
        #endregion

        /// <summary>
        /// 添加计划按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddPlan_Click(object sender, EventArgs e)
        {
           
            if (txt_PlanTitle.Text == "" && txt_PlanContent.Text == "" && cbox_PlanKind.Text == "")
            {
                MessageBox.Show("请输入完整计划");
                return;
            }
            //获取界面控件数据
            Paramenters.planTable planData = GetFormData();
            planData.executionOnime = "";         //新计划的 按时完成 一列的值
            planData.executionInstruction = "";         //新计划的 执行说明 一列的值
            //将数据存储到数据库中
            DataBase.InsertData(sqliteName, tableName, path, planData);
            if (DataBase.Information == null)  //保存数据成功
            {
                //将添加的数据加载到dataGridView中的去
                dgv_AddPlan.Rows.Add();
                dgv_AddPlan.Rows[dgv_AddPlan.Rows.Count - 1].Cells[0].Value = planData.planTitle;
                dgv_AddPlan.Rows[dgv_AddPlan.Rows.Count - 1].Cells[1].Value = planData.planKind;
                dgv_AddPlan.Rows[dgv_AddPlan.Rows.Count - 1].Cells[2].Value = planData.executionTime;
                dgv_AddPlan.Rows[dgv_AddPlan.Rows.Count - 1].Cells[3].Value = planData.planContent;
                MessageBox.Show("添加计划成功");
            }
            else
                MessageBox.Show(DataBase.Information);
        }
        /// <summary>
        /// 修改计划按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModifyPlan_Click(object sender, EventArgs e)
        {
            //获取修改后textBox中的数据
            Paramenters.planTable planData = GetFormData();

            //更新dataGrid控件
            dgv_AddPlan.SelectedRows[0].Cells[0].Value = txt_PlanTitle.Text;
            dgv_AddPlan.SelectedRows[0].Cells[1].Value = cbox_PlanKind.Text;
            dgv_AddPlan.SelectedRows[0].Cells[2].Value = dtp_ExecutionTime.Text;
            dgv_AddPlan.SelectedRows[0].Cells[3].Value = txt_PlanContent.Text;
            
            DataBase.DeleteData(sqliteName, tableName, path, oldTitle);   //删除旧的数据,这里的txt_PlamTitle.Text是修改后的值
            DataBase.InsertData(sqliteName, tableName, path, planData);    //添加新的数据
        }

        /// <summary>
        /// 获取界面右侧panel控件中的数据
        /// </summary>
        /// <returns></returns>
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
