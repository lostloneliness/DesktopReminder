
namespace DesktopReminder
{
    partial class TreatmentPlanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_CompleteOntime = new System.Windows.Forms.CheckBox();
            this.txt_PlanTitle = new System.Windows.Forms.TextBox();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Quit);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.txt_Description);
            this.groupBox1.Controls.Add(this.txt_PlanTitle);
            this.groupBox1.Controls.Add(this.chk_CompleteOntime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "计划标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "执行说明：";
            // 
            // chk_CompleteOntime
            // 
            this.chk_CompleteOntime.AutoSize = true;
            this.chk_CompleteOntime.Location = new System.Drawing.Point(9, 65);
            this.chk_CompleteOntime.Name = "chk_CompleteOntime";
            this.chk_CompleteOntime.Size = new System.Drawing.Size(132, 16);
            this.chk_CompleteOntime.TabIndex = 2;
            this.chk_CompleteOntime.Text = "该计划按期执行完毕";
            this.chk_CompleteOntime.UseVisualStyleBackColor = true;
            // 
            // txt_PlanTitle
            // 
            this.txt_PlanTitle.Location = new System.Drawing.Point(66, 16);
            this.txt_PlanTitle.Name = "txt_PlanTitle";
            this.txt_PlanTitle.ReadOnly = true;
            this.txt_PlanTitle.Size = new System.Drawing.Size(100, 21);
            this.txt_PlanTitle.TabIndex = 3;
            // 
            // txt_Description
            // 
            this.txt_Description.Location = new System.Drawing.Point(6, 118);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(274, 134);
            this.txt_Description.TabIndex = 4;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(148, 259);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(53, 23);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(227, 258);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(53, 23);
            this.btn_Quit.TabIndex = 6;
            this.btn_Quit.Text = "退出";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // TreatmentPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 306);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreatmentPlanForm";
            this.Text = "处理计划";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.TextBox txt_PlanTitle;
        private System.Windows.Forms.CheckBox chk_CompleteOntime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}