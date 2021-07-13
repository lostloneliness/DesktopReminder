using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        static private bool connectionSqlite(string sqliteName, string path)
        {
            string absolutePath = path + "\\" + sqliteName + ".db";              //绝对路径
            ////判断数据库是否存在
            //if (!File.Exists(absolutePath))
            //    File.Create(absolutePath);
            //不需要判断文件是否存在，连接时，如果.db文件不存在，会自动创建
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
        static public bool InitDatabase(string sqliteName, string tableName, string path)
        {
            string absolutePath = path + "\\" + sqliteName + ".db";
            if (File.Exists(absolutePath))
                return true;
            try
            {
                connectionSqlite(sqliteName, path);
                createTable(tableName, Paramenters.planTableStruct);
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
        /// 连接数据路，读取数据表中的数据
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库存储路径</param>
        /// <param name="condition">读取条件（WHERE）</param>
        /// <param name="filed">读取字段</param>
        /// <returns></returns>
        static public List<Paramenters.planTable> ReadDatabase(string sqliteName, string tableName, string path, string condition = "", string filed = "*")
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
        static public bool InserDatabase(string sqliteName, string tableName, string path, Paramenters.planTable planData, bool replace = false)
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
        /// 保存数据，即替换数据，replace == true
        /// </summary>
        /// <param name="sqliteName">数据库名称</param>
        /// <param name="tableName">数据表名称</param>
        /// <param name="path">数据库存储路径</param>
        /// <param name="planData">替换的数据</param>
        /// <param name="replace">bool值，是否替换，true替换，false插入</param>
        /// <returns></returns>
        static public bool SaveDatabase(string sqliteName, string tableName, string path, Paramenters.planTable planData, bool replace = true)
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
                information = "保存数据失败；\r\n" + ex.Message;
                return false;
            }
        }

        static public bool DeleteDatabase(string sqliteName,string tableName,string path,string data)
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

        static public bool UpdataDatabase(string sqliteName,string tableName,string path, string executionOntime, string executionInstruction, string planTitle)
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
    }
}
