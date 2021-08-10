using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLiteDataBase.Paramenters;

namespace SQLiteDataBase
{
    public class DataBase
    {
        //数据库的增、删、改、查
        static private SQLiteConnection myConnection = null;
        static private SQLiteCommand myCommand = new SQLiteCommand();    
        static string information = null;  //异常信息

        static public string Information
        {
            get
            {
                return information;
            }
        }
        #region 内部方法
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="path">数据库路径</param>
        /// <returns></returns>
        static private bool connectionSqlite(string sqliteName, string path)
        {
            string absolutePath = path + "\\" + sqliteName + ".db";              //绝对路径
            try
            {
                myConnection = new SQLiteConnection("data source =" + absolutePath);
                myConnection.Open();
                return true;

            }
            catch (Exception ex)
            {
                information = "连接数据库异常；\r\n" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="tableStruct">数据表结构</param>
        /// <returns></returns>
        static private bool createTable(string tableName, string tableStruct)
        {
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"CREATE TABLE IF NOT EXISTS {tableName}({tableStruct})";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                information = "创建数据表异常；\r\n" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="planDate">待插入的数据</param>
        /// <param name="replace">true：插入数据，false：替换数据</param>
        /// <returns></returns>
        static private bool insertData(string tableName, Paramenters.planTable planDate, bool replace = false)
        {
            string instruction = "INSERT INTO";
            if (replace == true)
                instruction = "REPLACE INTO";
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"{instruction} {tableName} VALUES(:param0,:param1,:param2,:param3,:param4,:param5)";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                //添加参数
                myCommand.Parameters.Add("param0", DbType.String);
                myCommand.Parameters.Add("param1", DbType.String);
                myCommand.Parameters.Add("param2", DbType.String);
                myCommand.Parameters.Add("param3", DbType.String);
                myCommand.Parameters.Add("param4", DbType.String);
                myCommand.Parameters.Add("param5", DbType.String);
                for (int i = 0; i < 6; i++)
                {
                    myCommand.Parameters[i].Value = planDate[i];
                }
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                information = "插入数据失败" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="condition">选择条件</param>
        /// <param name="filed">读取字段</param>
        /// <returns></returns>
        static private List<Paramenters.planTable> readData(string tableName, string condition = "", string filed = "*")
        {
            List<Paramenters.planTable> planDatas = new List<Paramenters.planTable>();
            if (condition != "")
                condition = "WHERE " + condition;
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"SELECT {filed} FROM {tableName} {condition}";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                SQLiteDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Paramenters.planTable planTable = new Paramenters.planTable();
                    planTable.planTitle = myReader.GetString(0);
                    planTable.planKind = myReader.GetString(1);
                    planTable.executionTime = myReader.GetString(2);
                    planTable.planContent = myReader.GetString(3);
                    planTable.executionOnime = myReader.GetString(4);
                    planTable.executionInstruction = myReader.GetString(5);
                    planDatas.Add(planTable);
                }
                myReader.Close();
                return planDatas;
            }
            catch (Exception ex)
            {
                information = "读取数据失败；\r\n" + ex.Message;
                return new List<Paramenters.planTable>();
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="data">带删除的数据</param>
        /// <returns></returns>
        static private bool deleteData(string tableName,string data)
        {
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"DELETE FROM {tableName} WHERE 计划标题='{data}'";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                information = "删除数据失败；\r\n" + ex.Message;
                return false;
            }

        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="executionOntime">“按时执行”字段</param>
        /// <param name="executionInstruction">“执行说明”字段</param>
        /// <param name="planTitle">“计划标题字段”</param>
        /// <returns></returns>
        static private bool updataDara(string tableName,string executionOntime,string executionInstruction,string planTitle)
        {
            Paramenters.planTable planData = new Paramenters.planTable();
            if (myConnection.State != ConnectionState.Open)
                myConnection.Open();
            try
            {
                string SQL = $"UPDATE {tableName} set 按时执行 = '{executionOntime}',执行说明 = '{executionInstruction}' where 计划标题 = '{planTitle}'";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                myCommand.ExecuteNonQuery();
                return true;
               
            }
            catch(Exception ex)
            {
                information = "更新数据库失败" + ex.Message;
                return true;
            }
           
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        static private bool closeConnection()
        {
            try
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
                else if (myConnection.State == ConnectionState.Broken)
                    myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                information = "关闭数据库失败；\r\n" + ex.Message;
                return false;
            }
        }



        #endregion
        #region 外部调用
        /// <summary>
        /// 初始化数据库，创建空的数据表
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库存储路径</param>
        /// <returns></returns>
        static public bool InitDatabase(string sqliteName, string palntableName,string settingtableName, string path)
        {
            string absolutePath = path + "\\" + sqliteName + ".db";
            if (File.Exists(absolutePath))
                return true;
            try
            {
                connectionSqlite(sqliteName, path);
                createTable(palntableName, Paramenters.planTableStruct);      //创建计划数据表
                createTable(settingtableName, Paramenters.setTableStruct);   //创建空的提醒设置数据表
                insertData(settingtableName, new settingTable("0", "1", true,true));                                //给提醒设置数据表中插入初始值
                closeConnection();
                return true;
            }
            catch (Exception ex)
            {
                information = "初始化数据失败；\r\n" + ex;
                return false;
            }
        }

        /// <summary>
        /// 读取计划表中的数据
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库存储路径</param>
        /// <param name="condition">读取条件（WHERE）</param>
        /// <param name="filed">读取字段</param>
        /// <returns>计划表结构数据</returns>
        static public List<Paramenters.planTable> ReadData(string sqliteName, string tableName, string path, string condition = "", string filed = "*")
        {
            List<Paramenters.planTable> planDatas = new List<Paramenters.planTable>();
            try
            {
                connectionSqlite(sqliteName, path);
                planDatas = readData(tableName, condition, filed);
                closeConnection();
                return planDatas;
            }
            catch (Exception ex)
            {
                information = "读取数据库失败;\r\n" + ex.Message;
                return new List<Paramenters.planTable>();
            }
        }
        /// <summary>
        /// 给数据表插入数据
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库存储路径</param>
        /// <param name="planData">插入的数据</param>
        /// <param name="replace"></param>
        /// <returns></returns>
        static public bool InsertData(string sqliteName, string tableName, string path, Paramenters.planTable planData, bool replace = false)
        {
            try
            {
                connectionSqlite(sqliteName, path);
                insertData(tableName, planData, replace);
                closeConnection();
                return true;
            }
            catch (Exception ex)
            {
                information = "插入数据失败；\r\n" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除数据，连接数据库，删除数据，关闭数据库连接
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库路径</param>
        /// <param name="data">待删除的数据</param>
        /// <returns></returns>
        static public bool DeleteData(string sqliteName,string tableName,string path,string data)
        {
            try
            {
                connectionSqlite(sqliteName, path);
                deleteData(tableName, data);
                closeConnection();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库路径</param>
        /// <param name="executionOntime">“按时执行”字段</param>
        /// <param name="executionInstruction">“执行说明”字段</param>
        /// <param name="planTitle">“计划标题”字段</param>
        /// <returns></returns>
        static public bool UpdataData(string sqliteName,string tableName,string path, string executionOntime, string executionInstruction, string planTitle)
        {
            try
            {
                
                connectionSqlite(sqliteName, path);
                updataDara(tableName, executionOntime, executionInstruction, planTitle);
                closeConnection();
                return true;
            }
            catch(Exception ex)
            {
                information = "更新数据库失败" + ex.Message;
                return false;
            }
            
        }
        #endregion


        #region  提醒设置表
        private static bool insertData(string tableName,settingTable settingtable,bool replace = false)
        {
            string instruction = "INSERT INTO";
            if (replace)
                instruction = "REPLACE INTO";
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"{instruction} {tableName} VALUES(:param0,:param1,:param2,:param3)";
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                myCommand.Parameters.Add("param0", DbType.String);
                myCommand.Parameters.Add("param1", DbType.String);      //字符
                myCommand.Parameters.Add("param2", DbType.Boolean);     //布尔值
                myCommand.Parameters.Add("param3", DbType.Boolean);     //布尔值

                for(int i = 0;i<4;i++)
                {
                    myCommand.Parameters[i].Value = settingtable[i];
                }

                myCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                information = "插入设置数据失败" + ex.Message;
                return false;
            }
        }
       
        private static settingTable readSetData(string tableName)
        {
            settingTable settingtable = new settingTable();
            try
            {
                if (myConnection.State != ConnectionState.Open)
                    myConnection.Open();
                string SQL = $"SELECT * FROM {tableName}"; //SELECT * FROM 数据表名 WHERE 条件
                myCommand.CommandText = SQL;
                myCommand.Connection = myConnection;
                SQLiteDataReader myreader = myCommand.ExecuteReader();
                while(myreader.Read())
                {
                    settingtable.reminderDay = myreader.GetString(0);
                    settingtable.reminderTime = myreader.GetString(1);
                    settingtable.isAutoCheck = myreader.GetBoolean(2);
                    settingtable.isTimeCue = myreader.GetBoolean(3);
                }
                myreader.Close();
                return settingtable;
            }
            catch(Exception ex)
            {
                return new settingTable();
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sqlitename">数据库名称</param>
        /// <param name="path">数据库路径</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="settingtable">设置表数据</param>
        /// <param name="replace">true:替换数据，false：插入数据</param>
        /// <returns></returns>
        public static bool InsertData(string sqlitename,string path ,string tableName,settingTable settingtable,bool replace = false)
        {
            try
            {
                connectionSqlite(sqlitename,path);
                insertData(tableName,settingtable,replace);
                closeConnection();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取设置表中的数据
        /// </summary>
        /// <param name="sqlitename">数据库名称</param>
        /// <param name="path">数据库路径</param>
        /// <param name="tableName">数据表名称</param>
        /// <returns></returns>
        public static settingTable ReadSetData(string sqlitename,string path,string tableName)
        {
            settingTable settingtable = new settingTable();
            try
            {
                connectionSqlite(sqlitename, path);
                settingtable = readSetData(tableName);
                closeConnection();
                return settingtable;
            }
            catch(Exception ex)
            {
                return settingtable;
            }
        }
        #endregion
    }
}
