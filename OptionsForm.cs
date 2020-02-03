using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ListayDatos2.SQLClasses;


namespace ListayDatos2
{
    public partial class OptionsForm : Form
    {

        MainConn NewConObj = new MainConn();

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            if (NewConObj.TestCon())
            {
                this.NewConObj.exportDatabase();
            }
            else
            {
                MessageBox.Show("Error en la conexion a la base de datos.");
            }
        }

        private void importBackup_Click(object sender, EventArgs e)
        {
            if (NewConObj.TestCon())
            {
                this.NewConObj.importDatabase();
            }
            else
            {
                MessageBox.Show("Error en la conexion a la base de datos o no existe el respaldo en C:\resp\\");
            }
        }
    }
}
