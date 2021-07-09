
namespace DesktopReminder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nfi_trayMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_tryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开机自动运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消开机自动运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置定时关机功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_ModifyPlan = new System.Windows.Forms.Button();
            this.btn_AddPlan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbox_PlanKind = new System.Windows.Forms.ComboBox();
            this.dtp_ExecutionTime = new System.Windows.Forms.DateTimePicker();
            this.txt_PlanContent = new System.Windows.Forms.TextBox();
            this.txt_PlanTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Plan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms_PlanInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cms_tryMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Plan)).BeginInit();
            this.cms_PlanInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // nfi_trayMenu
            // 
            this.nfi_trayMenu.ContextMenuStrip = this.cms_tryMenu;
            this.nfi_trayMenu.Icon = ((System.Drawing.Icon)(resources.GetObject("nfi_trayMenu.Icon")));
            this.nfi_trayMenu.Text = "DesktopReminder";
            this.nfi_trayMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nfi_trayMenu_MouseClick);
            // 
            // cms_tryMenu
            // 
            this.cms_tryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开窗口ToolStripMenuItem,
            this.系统设置ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.cms_tryMenu.Name = "cms_tryMenu";
            this.cms_tryMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // 打开窗口ToolStripMenuItem
            // 
            this.打开窗口ToolStripMenuItem.Name = "打开窗口ToolStripMenuItem";
            this.打开窗口ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开窗口ToolStripMenuItem.Text = "打开窗口";
            this.打开窗口ToolStripMenuItem.Click += new System.EventHandler(this.打开窗口ToolStripMenuItem_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开机自动运行ToolStripMenuItem,
            this.取消开机自动运行ToolStripMenuItem,
            this.设置定时关机功能ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 开机自动运行ToolStripMenuItem
            // 
            this.开机自动运行ToolStripMenuItem.Name = "开机自动运行ToolStripMenuItem";
            this.开机自动运行ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.开机自动运行ToolStripMenuItem.Text = "开机自动运行";
            this.开机自动运行ToolStripMenuItem.Click += new System.EventHandler(this.开机自动运行ToolStripMenuItem_Click);
            // 
            // 取消开机自动运行ToolStripMenuItem
            // 
            this.取消开机自动运行ToolStripMenuItem.Name = "取消开机自动运行ToolStripMenuItem";
            this.取消开机自动运行ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.取消开机自动运行ToolStripMenuItem.Text = "取消开机自动运行";
            this.取消开机自动运行ToolStripMenuItem.Click += new System.EventHandler(this.取消开机自动运行ToolStripMenuItem_Click);
            // 
            // 设置定时关机功能ToolStripMenuItem
            // 
            this.设置定时关机功能ToolStripMenuItem.Name = "设置定时关机功能ToolStripMenuItem";
            this.设置定时关机功能ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.设置定时关机功能ToolStripMenuItem.Text = "设置定时关机功能";
            this.设置定时关机功能ToolStripMenuItem.Click += new System.EventHandler(this.设置定时关机功能ToolStripMenuItem_Click);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 485);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计划查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "计划统计";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(789, 459);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "历史查询";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Controls.Add(this.dgv_Plan);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(789, 459);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "计划录入";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_ModifyPlan
            // 
            this.btn_ModifyPlan.Location = new System.Drawing.Point(6, 407);
            this.btn_ModifyPlan.Name = "btn_ModifyPlan";
            this.btn_ModifyPlan.Size = new System.Drawing.Size(234, 41);
            this.btn_ModifyPlan.TabIndex = 9;
            this.btn_ModifyPlan.Text = "修改";
            this.btn_ModifyPlan.UseVisualStyleBackColor = true;
            this.btn_ModifyPlan.Click += new System.EventHandler(this.btn_ModifyPlan_Click);
            // 
            // btn_AddPlan
            // 
            this.btn_AddPlan.Location = new System.Drawing.Point(6, 365);
            this.btn_AddPlan.Name = "btn_AddPlan";
            this.btn_AddPlan.Size = new System.Drawing.Size(234, 41);
            this.btn_AddPlan.TabIndex = 8;
            this.btn_AddPlan.Text = "添加";
            this.btn_AddPlan.UseVisualStyleBackColor = true;
            this.btn_AddPlan.Click += new System.EventHandler(this.btn_AddPlan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ModifyPlan);
            this.panel1.Controls.Add(this.cbox_PlanKind);
            this.panel1.Controls.Add(this.btn_AddPlan);
            this.panel1.Controls.Add(this.dtp_ExecutionTime);
            this.panel1.Controls.Add(this.txt_PlanContent);
            this.panel1.Controls.Add(this.txt_PlanTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(540, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 450);
            this.panel1.TabIndex = 6;
            // 
            // cbox_PlanKind
            // 
            this.cbox_PlanKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_PlanKind.FormattingEnabled = true;
            this.cbox_PlanKind.Items.AddRange(new object[] {
            "十分重要",
            "比较重要",
            "一般计划"});
            this.cbox_PlanKind.Location = new System.Drawing.Point(64, 57);
            this.cbox_PlanKind.Name = "cbox_PlanKind";
            this.cbox_PlanKind.Size = new System.Drawing.Size(167, 20);
            this.cbox_PlanKind.TabIndex = 7;
            // 
            // dtp_ExecutionTime
            // 
            this.dtp_ExecutionTime.Location = new System.Drawing.Point(64, 97);
            this.dtp_ExecutionTime.Name = "dtp_ExecutionTime";
            this.dtp_ExecutionTime.Size = new System.Drawing.Size(167, 21);
            this.dtp_ExecutionTime.TabIndex = 6;
            // 
            // txt_PlanContent
            // 
            this.txt_PlanContent.Location = new System.Drawing.Point(6, 162);
            this.txt_PlanContent.Multiline = true;
            this.txt_PlanContent.Name = "txt_PlanContent";
            this.txt_PlanContent.Size = new System.Drawing.Size(234, 199);
            this.txt_PlanContent.TabIndex = 5;
            // 
            // txt_PlanTitle
            // 
            this.txt_PlanTitle.Location = new System.Drawing.Point(64, 10);
            this.txt_PlanTitle.Name = "txt_PlanTitle";
            this.txt_PlanTitle.Size = new System.Drawing.Size(167, 21);
            this.txt_PlanTitle.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "计划内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "执行日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "计划种类";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "计划标题";
            // 
            // dgv_Plan
            // 
            this.dgv_Plan.AllowUserToAddRows = false;
            this.dgv_Plan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Plan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_Plan.ContextMenuStrip = this.cms_PlanInput;
            this.dgv_Plan.Location = new System.Drawing.Point(0, 0);
            this.dgv_Plan.Name = "dgv_Plan";
            this.dgv_Plan.ReadOnly = true;
            this.dgv_Plan.RowHeadersVisible = false;
            this.dgv_Plan.RowTemplate.Height = 23;
            this.dgv_Plan.Size = new System.Drawing.Size(538, 454);
            this.dgv_Plan.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "计划标题";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "计划种类";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "执行日期";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "计划内容";
            this.Column4.Name = "Column4";
            // 
            // cms_PlanInput
            // 
            this.cms_PlanInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加计划ToolStripMenuItem,
            this.修改计划ToolStripMenuItem,
            this.删除计划ToolStripMenuItem});
            this.cms_PlanInput.Name = "cms_PlanInput";
            this.cms_PlanInput.Size = new System.Drawing.Size(125, 70);
            // 
            // 添加计划ToolStripMenuItem
            // 
            this.添加计划ToolStripMenuItem.Name = "添加计划ToolStripMenuItem";
            this.添加计划ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加计划ToolStripMenuItem.Text = "添加计划";
            this.添加计划ToolStripMenuItem.Click += new System.EventHandler(this.添加计划ToolStripMenuItem_Click);
            // 
            // 修改计划ToolStripMenuItem
            // 
            this.修改计划ToolStripMenuItem.Name = "修改计划ToolStripMenuItem";
            this.修改计划ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改计划ToolStripMenuItem.Text = "修改计划";
            this.修改计划ToolStripMenuItem.Click += new System.EventHandler(this.修改计划ToolStripMenuItem_Click);
            // 
            // 删除计划ToolStripMenuItem
            // 
            this.删除计划ToolStripMenuItem.Name = "删除计划ToolStripMenuItem";
            this.删除计划ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除计划ToolStripMenuItem.Text = "删除计划";
            this.删除计划ToolStripMenuItem.Click += new System.EventHandler(this.删除计划ToolStripMenuItem_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(789, 459);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "提醒设置";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(789, 459);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "退出";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.cms_tryMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Plan)).EndInit();
            this.cms_PlanInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nfi_trayMenu;
        private System.Windows.Forms.ContextMenuStrip cms_tryMenu;
        private System.Windows.Forms.ToolStripMenuItem 打开窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开机自动运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消开机自动运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置定时关机功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgv_Plan;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ContextMenuStrip cms_PlanInput;
        private System.Windows.Forms.ToolStripMenuItem 添加计划ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改计划ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除计划ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbox_PlanKind;
        private System.Windows.Forms.DateTimePicker dtp_ExecutionTime;
        private System.Windows.Forms.TextBox txt_PlanContent;
        private System.Windows.Forms.TextBox txt_PlanTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddPlan;
        private System.Windows.Forms.Button btn_ModifyPlan;
    }
}

