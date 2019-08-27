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
        string[] HiddenColumns = new string[] { "idZapato", "Color", "idProveedor", "Foto", "Medios", "idUbicacion" };

        public Form1()
        {
            InitializeComponent();


            MainConn NewConObj = new MainConn();

            MySqlDataAdapter ObjAdapterZapatos = NewConObj.ExecuteQueryAndGetData("SELECT * FROM zapatos");
            MySqlDataAdapter ObjAdapterTallas = NewConObj.ExecuteQueryAndGetData("SELECT * FROM tallas");

            this.MainGrid.Visible = true;
            this.MainGrid.AutoGenerateColumns = true;
            
            // 'zapatos' All Shoes whitout number of shoes , 'tallas' Table numbers of Shoes
            this.MainGrid.DataSource = GetDataTableMain(NewConObj.DataMySqlToDataTable(ObjAdapterZapatos , 
                                       "zapatos"), NewConObj.DataMySqlToDataTable(ObjAdapterTallas, "tallas"));

            this.HideColumnsMainTable();


        }

        protected DataTable GetDataTableMain(DataTable Zapatos, DataTable Tallas)
        {
            Zapatos.Columns.Add("Existencia", typeof(int));


            foreach (DataRow DataRowZapato in Zapatos.Rows)
            {
                int countexist = 0;

                foreach (DataRow DataRowZapatoTallas in Tallas.Rows)
                {
                    if (Int32.Parse(DataRowZapatoTallas["idZapato"].ToString()) == Int32.Parse(DataRowZapato["idZapato"].ToString()) && Int32.Parse(DataRowZapatoTallas["Existencia"].ToString()) != 0)
                    {
                        countexist += Int32.Parse(DataRowZapatoTallas["Existencia"].ToString());
                    }

                }

                DataRowZapato["Existencia"] = countexist;

            }

            return Zapatos;
        }


        protected  void HideColumnsMainTable()
        {
            for (int i = 0; i < MainGrid.Columns.Count; i++)
            {
                for (int j = 0; j < HiddenColumns.Length; j++)
                {
                    if (this.MainGrid.Columns[i].Name == HiddenColumns[j])
                    {
                        this.MainGrid.Columns[i].Visible = false;
                    }
                }

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
