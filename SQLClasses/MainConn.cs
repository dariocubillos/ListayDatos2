using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ListayDatos2.SQLClasses
{
    class MainConn
    {
        string MysqlServerHost = string.Empty;
        string MysqlServerUserName = string.Empty;
        string MysqlServerPassword = string.Empty;
        string MysqlServerDataBase = string.Empty;
        MySqlConnection conn = null;


        public MainConn()
        {
            
            MysqlServerHost = ConfigurationManager.AppSettings["MysqlServerHost"];
            MysqlServerUserName = ConfigurationManager.AppSettings["MysqlServerUserName"];
            MysqlServerPassword = ConfigurationManager.AppSettings["MysqlServerPassword"];
            MysqlServerDataBase = ConfigurationManager.AppSettings["MysqlServerDataBase"];
            conn = new MySqlConnection(ConnString());

        }

        public string ConnString()
        {
            return @"server=" + MysqlServerHost + ";userid=" + MysqlServerUserName + ";password=" + MysqlServerPassword + ";database=" + MysqlServerDataBase + "";
        }


        public string GetHost()
        {
            return MysqlServerHost;
        }

        public string GetUserName()
        {

            return MysqlServerUserName;
        }

        public string GetPassWord()
        {
            return MysqlServerPassword;
        }

        public string GetDataBase()
        {
            return MysqlServerDataBase;
        }

        public void ChangeDataAppConfig(string Key, string Value)
        {
            System.Configuration.Configuration ConfigManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigManager.AppSettings.Settings[Key].Value = Value;
            ConfigManager.Save(ConfigurationSaveMode.Modified);
        }

        public bool TestCon()
        {
            try
            {
                conn = new MySqlConnection(ConnString());
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error Conn "+ ex);
                return false;
            }
        }
        public bool ExecuteQuery( string query)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                conn = new MySqlConnection(ConnString());
                conn.Open();
                da = new MySqlDataAdapter(query, conn);
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

                return false;
            }


            return true;
        }


        public MySqlDataAdapter ExecuteQueryAndGetData(string query)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                conn = new MySqlConnection(ConnString());
                conn.Open();
                da = new MySqlDataAdapter(query, conn);
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

            return da;
        }

        public DataTable DataMySqlToDataTable(MySqlDataAdapter ObjectMysql,string TableName )
        {
            DataSet Result = new DataSet();
            DataTable dt = new DataTable();

            ObjectMysql.Fill(Result, TableName);
            dt = Result.Tables[TableName];
            return dt;
        }



    }
}
