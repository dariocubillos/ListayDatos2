using ListayDatos2.SQLClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ListayDatos2
{
    public partial class AddConfigShoe : Form
    {
        MainConn NewConObj = new MainConn();
        int IdShoe;
        string mark;
        DataTable markTable;
        public AddConfigShoe(int IdShoe , string mark )
        {
            InitializeComponent();
            this.IdShoe = IdShoe;
            this.mark = mark;
            this.configureMarks();
        }

        private void configureMarks(string newMark=null)
        {
            MySqlDataAdapter objAdapterMarcas = NewConObj.ExecuteQueryAndGetData("SELECT * FROM marcas");
            this.markTable = NewConObj.DataMySqlToDataTable(objAdapterMarcas, "marcas");
            string[] arrayMarks = new string[this.markTable.Rows.Count];
            for (int i = 0; i < this.markTable.Rows.Count; i++)
            {
                arrayMarks[i] = this.markTable.Rows[i].Field<string>("Marca");
            }
            this.markSelect.DataSource = arrayMarks;
            if (newMark == null)
            {
                for (int i = 0; i < this.markSelect.Items.Count; i++)
                {
                    if (this.markSelect.Items[i].ToString() == this.mark)
                    {
                        this.markSelect.SelectedIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.markSelect.Items.Count; i++)
                {
                    if (this.markSelect.Items[i].ToString() == newMark)
                    {
                        this.markSelect.SelectedIndex = i;
                    }
                }
            }

        }

        private int getIdMark(string name) // check mark search
        {
            int result = -1;
            
            for (int i = 0; i < this.markTable.Rows.Count; i++)
            {
                if (this.markTable.Rows[i].Field<string>("Marca") == name)
                {
                    result = this.markTable.Rows[i].Field<int>("idMarca");
                }

            }

            return result;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string code = this.codeInput.Text;
            string mark = this.markSelect.Text;  // select  marca check if exists or new
            string model = this.modelInput.Text;
            string tacon = this.taconInput.Text;
            int exists = int.Parse(this.numericUpDown1.Value.ToString());
            // future prevent double queryes
            string query = 
                "UPDATE zapatos  " +
                "set codigo ='"+code+"', " +
                "idMarca = " + this.getIdMark(mark) + ", " +
                "Modelo = '"+ model + "',"+
                "tacon ='"+tacon+"' "+
                " WHERE idZapato = "+ IdShoe;  // id marca select new 
            string queryExists = 
                "UPDATE tallas set Existencia ="+ exists +
                " WHERE idZapato= "+ IdShoe + " AND "+
                "Talla = 8";
                NewConObj.ExecuteQuery(query);
                NewConObj.ExecuteQuery(queryExists);

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addMarkpopup_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox
                ("Introdusca su nueva marca a registrar.", "Nueva marca", "", -1, -1);

            if (input != null && input != "")
            {
                string query = "INSERT INTO `marcas` (`idMarca`, `Marca`) VALUES (NULL, '"+input+"')";
                NewConObj.ExecuteQuery(query);
                this.configureMarks(input);
            }

        }
    }
}
