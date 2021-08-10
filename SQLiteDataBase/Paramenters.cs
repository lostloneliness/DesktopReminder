using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDataBase
{
    public class Paramenters
    {
        static public string planTableStruct = @"计划标题 TEXT PRIMARY KEY NOT NULL,
                                                 计划种类 TEXT NOT NULL,
                                                 执行时间 TEXT NOT NULL,
                                                 计划内容 TEXT NOT NULL,
                                                 按时执行 TEXT NOT NULL,
                                                 执行说明 TEXT NOT NULL";
        static public string setTableStruct = @"提前提醒天数 TEXT PRIMARY KEY NOT NULL,
                                                 实时提醒时间 TEXT NOT NULL,
                                                 自动检查 BOOLEAN NOT NULL,
                                                 实时提醒标志 BOOLEAN NOT NULL";
        public struct planTable
        {
            public string planTitle;
            public string planKind;
            public string executionTime;
            public string planContent;
            public string executionOnime;
            public string executionInstruction;

            public object this[int 索引]
            {
                get
                {
                    switch (索引)
                    {
                        case 0: return planTitle;
                        case 1: return planKind;
                        case 2: return executionTime;
                        case 3: return planContent;
                        case 4: return executionOnime;
                        case 5: return executionInstruction;
                        default: throw new AccessViolationException();
                    }
                }
            }

            ////初始化的值
            //public planTable(bool Ontime)
            //{

            //}
        }


        public struct settingTable
        {
            public string reminderDay;       //提前提醒天数
            public string reminderTime;      //实时提醒时间
            public bool isAutoCheck;
            public bool isTimeCue;
            public object this[int 索引]
            {
                get
                {
                    switch(索引)
                    {
                        case 0:return reminderDay;
                        case 1:return reminderTime;
                        case 2:return isAutoCheck;
                        case 3:return isTimeCue;
                        default:throw new AccessViolationException();
                    }
                }
            }

            /// <summary>
            /// 初始化值
            /// </summary>
            /// <param name="reminderDay"></param>
            /// <param name="reminderTime"></param>
            /// <param name="isAutoCheck"></param>
            /// <param name="isTimeCue"></param>
            public settingTable(string reminderDay, string reminderTime,bool isAutoCheck,bool isTimeCue)
            {
                this.reminderDay = reminderDay;
                this.reminderTime = reminderTime;
                this.isAutoCheck = isAutoCheck;
                this.isTimeCue = isTimeCue;
            }
        }

    }
}
