using SQLiteDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopReminder
{
    public partial class TreatmentPlanForm : Form
    {
        private string sqliteName;
        private string tableName;
        private string path;
        private DataGridView dgv;
        public TreatmentPlanForm(DataGridView dgv, string sqliteName, string tableName, string path)
        {
            InitializeComponent();

            //初始化界面
            txt_PlanTitle.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();

            this.sqliteName = sqliteName;
            this.tableName = tableName;
            this.path = path;
            this.dgv = dgv;
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //保存，将计划说明和是否按时执行保存到数据库中，实则是更新选中行的计划说明列和按时执行列
            string executionOntime = "";
            if (chk_CompleteOntime.Checked == true)
                executionOntime = "是";
            else
                executionOntime = "否";

            string executionInstruction = txt_Description.Text;
            bool updataResult = false;
            //将数据更新到数据库中
            updataResult = DataBase.UpdataDatabase(sqliteName, tableName, path, executionOntime, executionInstruction, txt_PlanTitle.Text);
            if (updataResult)
            {
                //更新dataGridView
                dgv.SelectedRows[0].Cells[4].Value = executionOntime;
                dgv.SelectedRows[0].Cells[5].Value = executionInstruction;
                this.Close();
            }

            
        }
    }
}
