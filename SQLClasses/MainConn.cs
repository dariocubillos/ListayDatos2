using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace ListayDatos2.SQLClasses
{
    class MainConn
    {
        string MysqlServerHost = string.Empty;
        string MysqlServerUserName = string.Empty;
        string MysqlServerPassword = string.Empty;
        string MysqlServerDataBase = string.Empty;
        MySqlConnection conn = null;
        string filebackup = "C:\\resp\\backup_no_borrar.sql";


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
        public void ExecuteQuery( string query)
        {
            try
            {
                conn = new MySqlConnection(ConnString());
                MySqlCommand ComandDelete = new MySqlCommand(query, conn);
                MySqlDataReader ComandReader;
                conn.Open();
                ComandReader = ComandDelete.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                    MessageBox.Show("Error en la base de datos posible duplicado o " +
                        "dato invalido cambie los valores que esta operando.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }

        }

        public MySqlDataAdapter ExecuteQueryAndGetData(string query)
        {
            MySqlDataAdapter dataGet = new MySqlDataAdapter();

            try
            {
                conn = new MySqlConnection(ConnString());
                conn.Open();
                dataGet = new MySqlDataAdapter(query, conn);
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

            return dataGet;
        }

        public DataTable DataMySqlToDataTable(MySqlDataAdapter ObjectMysql,string TableName )
        {
            DataSet Result = new DataSet();
            DataTable dt = new DataTable();

            ObjectMysql.Fill(Result, TableName);
            dt = Result.Tables[TableName];
            return dt;
        }

        public void exportDatabase()
        {
            try
            {
                conn = new MySqlConnection(ConnString());

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {

                        DialogResult yesnobackup = MessageBox.Show
                            ("Desea exportar su respaldo y sobre escribir su respaldo previo?", "Respaldo", MessageBoxButtons.YesNo);

                        if (yesnobackup == DialogResult.Yes)
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(this.filebackup);
                            conn.Close();
                            MessageBox.Show("Respaldo creado correctamente.", "Informacion");
                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada.", "Informacion");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show("Error exportando posiblemente no exista la carpeta o permisos de escritura.", "Error");
            }
        }

        public void importDatabase()
        {
            try
            {
                conn = new MySqlConnection(ConnString());

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {

                        DialogResult yesnobackup = MessageBox.Show
                            ("Desea importar su respaldo y remplazar su base de datos?","Respaldo", MessageBoxButtons.YesNo);

                        if (yesnobackup == DialogResult.Yes)
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.CommandText = "SET GLOBAL  max_allowed_packet=1024*1024*1024;";
                            cmd.ExecuteNonQuery();
                            mb.ImportFromFile(this.filebackup);
                            conn.Close();
                            MessageBox.Show("Respaldo recuperado correctamente.", "Informacion");

                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada." , "Informacion");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show("Error importando posiblemente no exista respaldo creado.", "Error");
            }
        }

    }
}
