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
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            MainConn NewConObj = new MainConn();
            if (NewConObj.TestCon())
            {
                this.StartMainTable();
            }
            else
            {   
                while (!NewConObj.TestCon())
                {
                    DialogResult dr = MessageBox.Show("Error no se encuentra la base de datos desea volver " +
                                      "¿Desea volver a intentar conectarse?", "Error", MessageBoxButtons.YesNo
                                      ,MessageBoxIcon.Exclamation , MessageBoxDefaultButton.Button1);

                    if (dr == DialogResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                }

                this.StartMainTable();

            }

        }

        protected void StartMainTable()
        {
            MainConn NewConObj = new MainConn();
            MySqlDataAdapter ObjAdapterZapatos = NewConObj.ExecuteQueryAndGetData("SELECT * FROM zapatosyexists");
            this.MainGrid.Visible = true;
            this.MainGrid.AutoGenerateColumns = true;
            // 'zapatos' All Shoes whitout number of shoes , 'tallas' Table numbers of Shoes
            this.MainGrid.DataSource = NewConObj.DataMySqlToDataTable(ObjAdapterZapatos, "zapatosyexists");
            this.HideColumnsMainTable();
            this.AutoSizeColums();
            this.AddItemsShow();
        }

        protected void AddItemsShow()
        {
            ShowByItems.Items.Add("Todos");
            ShowByItems.Items.Add("Sin Existencia");
            ShowByItems.Items.Add("Baja existencia");
            ShowByItems.SelectedIndex = 0;
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

        protected void AutoSizeColums()
        {
            MainGrid.Width =
            MainGrid.Columns.Cast<DataGridViewColumn>().Sum(x => x.Width)
            + (MainGrid.RowHeadersVisible ? MainGrid.RowHeadersWidth : 0) + 3;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
