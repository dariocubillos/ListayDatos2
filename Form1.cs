﻿using MySql.Data.MySqlClient;
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
                    DialogResult dr = AlertGenericYesNo("Error no se encuentra la base de datos desea volver " +
                                                        "¿Desea volver a intentar conectarse?", "Error");

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

        private void SearchModel(object sender, EventArgs e)
        {
            TextBox model = (TextBox)sender;
            BindingSource bs = new BindingSource();
            bs.DataSource = MainGrid.DataSource;
            bs.Filter = "Codigo like '%" + model.Text + "%'";
            MainGrid.DataSource = bs;
        }

        private void SelectFilter(object sender, EventArgs e)
        {
            ComboBox filter = (ComboBox)sender;
            BindingSource bs = new BindingSource();
            bs.DataSource = MainGrid.DataSource;
            bs.Filter = ComboFilterText(filter.SelectedItem.ToString());
            MainGrid.DataSource = bs;
        }

        private string ComboFilterText(string FilterBox)
        {
            //string filter = "Existencia  '%" "%'";
            switch (FilterBox)
            {
                case "Todos":
                    return string.Empty;

                case "Sin Existencia":
                    return "Existencia = 0";

                case "Baja existencia":
                    return "Existencia < 3 AND Existencia > 0";

                default:
                    return string.Empty;
            }


        }

        private void DeleteShoe_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectionCol = (DataGridViewSelectedRowCollection)MainGrid.SelectedRows;

            string code = string.Empty;
            int numshoes = -1;

            if (selectionCol.Count == 1)
            {
                 code = GetIDSelectedOneRowTableView().ToString();

                //get one items for delete one row

                DialogResult dr = AlertGenericYesNo("Desea eliminar el el zapato " +
                                                    "con el codigo: "+ code + " ?","Confirmar");
                if (dr == DialogResult.Yes)
                {
                }
            }
            else if (selectionCol.Count > 1)
            {
                 //get all items in this par for all rows and columns  and for delete

                DialogResult dr = AlertGenericYesNo("Desea eliminar los " + numshoes + " ?", "Confirmar");

                if (dr == DialogResult.Yes)
                {
                }
            }
            else
            {
              AlertGenericOK("Ningun zapato seleccionado ", "Alerta");
            }

        }

        protected int GetIDSelectedOneRowTableView()
        {
             int selectedrowindex = MainGrid.SelectedCells[0].RowIndex;
             DataGridViewRow selectedRow = MainGrid.Rows[selectedrowindex];
             return int.Parse(selectedRow.Cells["Codigo"].Value.ToString());          
        }        

        protected DialogResult AlertGenericYesNo(string MainMessage, string Title)
        {
            return  MessageBox.Show(MainMessage, Title, MessageBoxButtons.YesNo
                                    ,MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        protected DialogResult AlertGenericOK(string MainMessage, string Title)
        {
            return MessageBox.Show(MainMessage, Title, MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void AddShoe_Click(object sender, EventArgs e)
        {

        }

        private void NoExistsButton_Click(object sender, EventArgs e)
        {

        }

        private void ConfigShoe_Click(object sender, EventArgs e)
        {

        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}
