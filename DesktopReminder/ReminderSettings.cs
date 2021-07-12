using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopReminder
{
    public partial class Form1
    {
        /// <summary>
        /// 初始化 提醒设置 界面
        /// </summary>
        private void InitReminderSettings()
        {
            Graphics g = tabPage5.CreateGraphics();
            int heigth = tabPage5.Height / 4;
            int width = tabPage5.Width;
            g.DrawLine(new Pen(Color.Red,5), 50, 100, 200, 100);
            g.DrawLine(new Pen(Color.Black, 1), new Point(heigth, 0), new Point(heigth, width));
            g.DrawLine(new Pen(Color.Black, 1), new Point(heigth, 0), new Point(heigth * 2, width));
            g.DrawLine(new Pen(Color.Black, 1), new Point(heigth, 0), new Point(heigth * 3, width));
            g.Dispose();
        }
    }
}
