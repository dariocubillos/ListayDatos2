using ListayDatos2.SQLClasses;
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
    public partial class AddConfigShoe : Form
    {
        MainConn NewConObj = new MainConn();
        int IdShoe;

        public AddConfigShoe(int IdShoe)
        {
            InitializeComponent();
            this.IdShoe = IdShoe;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string code = this.CodeIDBigLabel.Text;
            
            string mark = this.MarkLabel.Text;  // select  marca

            // check if exists or new


            string model = this.ModelLabel.Text;
            string tacon = this.TaconLabel.Text;
            int exists = int.Parse(this.numericUpDown1.Value.ToString());

            string query = "UPDATE zapatos  " +
                "set codigo ='"+code+"', " +
                "idMarca = " +mark+ ", tacon ='"+tacon+"', existencia ="+exists +" WHERE idZapato = "+ IdShoe;  // id marca select new 
            NewConObj.ExecuteQuery(query);

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
