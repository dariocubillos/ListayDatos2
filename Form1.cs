using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListayDatos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            string connstring = @"server=localhost;userid=root;password=;database=zapateria";

            MySqlConnection conn = null;
            DataTable dt = new DataTable();

            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM zapatos;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "zapatos");
                dt = ds.Tables["zapatos"];




            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }



            this.MainGrid.Visible = true;
            this.MainGrid.AutoGenerateColumns = true;

            //foreach (DataColumn ColumnItem in dt.Columns)
            //{
            //    this.MainGrid.Columns.Add(ColumnItem.ColumnName, ColumnItem.ColumnName);

            //}

            this.MainGrid.DataSource = dt;

            


            //this.MainGrid.Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
