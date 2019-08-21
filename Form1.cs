using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ListayDatos2.SQLClasses;
using System.Configuration;

namespace ListayDatos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            MainConn NewConObj = new MainConn();

            MySqlDataAdapter ObjAdapter = NewConObj.ExecuteQueryAndGetData("SELECT * FROM zapatos");

            this.MainGrid.Visible = true;
            this.MainGrid.AutoGenerateColumns = true;

            this.MainGrid.DataSource = NewConObj.DataMySqlToDataTable(ObjAdapter, "zapatos");

            



        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
