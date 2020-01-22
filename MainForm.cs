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
using System.Threading.Tasks;

namespace ListayDatos2
{
    public partial class MainForm : Form
    {
        string[] HiddenColumns = new string[] { "idZapato", "Color", "idProveedor", "Foto", "Medios", "idUbicacion" };
        

        public MainForm()
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
            this.StartRowsView();
            this.AddItemsShow();
            this.AddSerachByCombo();

        }       

        protected void StartRowsView()
        {
            MainConn NewConObj = new MainConn();
            MySqlDataAdapter ObjAdapterZapatos = NewConObj.ExecuteQueryAndGetData("SELECT * FROM zapatosyexists");
            this.MainGrid.Visible = true;
            this.MainGrid.AutoGenerateColumns = true;
            // 'zapatos' All Shoes whitout number of shoes , 'tallas' Table numbers of Shoes
            this.MainGrid.DataSource = NewConObj.DataMySqlToDataTable(ObjAdapterZapatos, "zapatosyexists");
            this.HideColumnsMainTable();
            this.AutoSizeColums();
        }

        protected void AutoSizeColums()
        {
            MainGrid.Width =
            MainGrid.Columns.Cast<DataGridViewColumn>().Sum(x => x.Width)
            + (MainGrid.RowHeadersVisible ? MainGrid.RowHeadersWidth : 0) + 3;
        }

        protected void AddSerachByCombo()
        {
            SearchBy.Items.Add("Codigo");
            SearchBy.Items.Add("Marca");
            SearchBy.Items.Add("Modelo");
            SearchBy.Items.Add("Tacon");
            SearchBy.Items.Add("Existencia");
            SearchBy.SelectedIndex = 0;
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

        private void MainGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < MainGrid.Rows.Count - 1; i++)
            {
                if (int.Parse(MainGrid.Rows[i].Cells["Existencia"].Value.ToString()) == 0)
                {
                    MainGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (int.Parse(MainGrid.Rows[i].Cells["Existencia"].Value.ToString()) <= 2)
                {
                    MainGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }

            }

            this.SetCountersLabels();
        }

        protected void SetCountersLabels()
        {
            this.ShoesCount.Text = GetNumberShoes();
            this.CodeCount.Text = this.MainGrid.Rows.Count.ToString();
        }
        
        protected string GetNumberShoes()
        {
            int result = 0;

            for (int i = 0; i < MainGrid.Rows.Count-1; i++)
            {                
               result += int.Parse( MainGrid.Rows[i].Cells["Existencia"].Value.ToString());                  
            }

            return result.ToString();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void SearchModel(object sender, EventArgs e)
        {
            TextBox model = (TextBox)sender;
            BindingSource bs = new BindingSource();
            bs.DataSource = MainGrid.DataSource;

            if (model.Text != string.Empty)
            {
                if (this.SearchBy.SelectedItem.ToString() == "Existencia")
                {
                    int val;
                    if (!int.TryParse(model.Text, out val))
                    {
                        this.AlertGenericOK("Solo puede Introducir numeros.", "Alerta");
                        model.Text = string.Empty;
                        this.GenericMainGridReload();
                        model.Undo();
                    }
                    else
                    {
                        bs.Filter = this.SearchBy.SelectedItem.ToString() + " = " + model.Text;

                    }
                }
                else
                {
                    bs.Filter = this.SearchBy.SelectedItem.ToString() + " like '%" + model.Text + "%'";
                }


                MainGrid.DataSource = bs;
            }
            else
            {
                this.GenericMainGridReload();
            }
            
        }

        private void GenericMainGridReload()
        {
            this.StartRowsView();
            this.MainGrid.Update();
            this.MainGrid.Refresh();
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
            MainConn NewConObj = new MainConn();

            string code = string.Empty;
            int numshoes = selectionCol.Count;

            if (selectionCol.Count == 1)
            {
                 code = GetIDSelectedOneRowTableView().ToString();

                //get one items for delete one row

                DialogResult dr = AlertGenericYesNo("Desea eliminar el el zapato " +
                                                    "con el codigo: "+ code + " ?","Confirmar");
                if (dr == DialogResult.Yes)
                {
                    //delete one shoe
                    NewConObj.ExecuteQuery("DELETE FROM zapateria.zapatos WHERE idZapato = "
                               + int.Parse(GetIDZapatoSelectedOneRowTableView().ToString()));
                    this.GenericMainGridReload();
                }
            }
            else if (selectionCol.Count > 1)
            {
                 //get all items in this par for all rows and columns  and for delete

                DialogResult dr = AlertGenericYesNo("Desea eliminar los " + numshoes + " zapatos ?", "Confirmar");

                if (dr == DialogResult.Yes)
                {
                    // delete multiple shoes
                    for (int i = 0; i < selectionCol.Count; i++)
                    {
                        NewConObj.ExecuteQuery("DELETE FROM zapateria.zapatos WHERE idZapato = "
                               + int.Parse(selectionCol[i].Cells[0].Value.ToString()));
                    }
                    this.GenericMainGridReload();
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

        protected int GetIDZapatoSelectedOneRowTableView()
        {
            int selectedrowindex = MainGrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = MainGrid.Rows[selectedrowindex];
            return int.Parse(selectedRow.Cells["idZapato"].Value.ToString());
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

        private  void NoExistsButton_Click(object sender, EventArgs e)
        {
            MainConn NewConObj = new MainConn();

            NoExistsButton.Enabled = false;

            for (int i = 0; i < MainGrid.Rows.Count - 1; i++)
            {
                if (int.Parse(MainGrid.Rows[i].Cells["Existencia"].Value.ToString()) == 0)
                {
                    //Delete items whit zero exists
                    NewConObj.ExecuteQuery("DELETE FROM zapateria.zapatos WHERE idZapato = "
                               + int.Parse(MainGrid.Rows[i].Cells["idZapato"].Value.ToString()));
                }
            }
            for (int i = 0; i < this.MainGrid.Rows.Count - 1; i++)
            {
                if (int.Parse(MainGrid.Rows[i].Cells["Existencia"].Value.ToString()) == 0)
                {
                    //Delete items whit zero exists
                    NewConObj.ExecuteQuery("DELETE FROM zapateria.zapatos WHERE idZapato = "
                               + int.Parse(MainGrid.Rows[i].Cells["idZapato"].Value.ToString()));
                }
            }
            this.StartRowsView();
            NoExistsButton.Enabled = true;           
           
        }        


        protected int getselectedrowmodelorid(string option)
        {

            int optselect;

            switch (option)
            {
                case "id":
                    optselect = 0;
                    break;

                case "code":
                    optselect = 1;
                    break;

                default:
                    optselect = 0;
                    break;
            }


            if (MainGrid.SelectedCells.Count > 0)
            {
                return int.Parse(MainGrid.SelectedCells[optselect].Value.ToString());
            }
            else
            {
                return -1;
            }

        }

        private void ConfigShoe_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selection = (DataGridViewSelectedRowCollection)MainGrid.SelectedRows;
            DataGridViewRow Selectedrow = selection[0];
            

            AddConfigShoe AddConfigShoeObject = new AddConfigShoe(int.Parse(GetIDZapatoSelectedOneRowTableView().ToString()), Selectedrow.Cells[2].Value.ToString());
            AddConfigShoeObject.Text = "Confgurar : " + getselectedrowmodelorid("code");
            AddConfigShoeObject.Show();

            AddConfigShoeObject.setCodeSelectLabel(Selectedrow.Cells[1].Value.ToString());
            AddConfigShoeObject.setCodeConfigSelectLabel(Selectedrow.Cells[1].Value.ToString());
            AddConfigShoeObject.setModelSelectLabel(Selectedrow.Cells[3].Value.ToString());
            AddConfigShoeObject.setTaconSelectLabel(Selectedrow.Cells[4].Value.ToString());
            AddConfigShoeObject.setExistSelectLabel(Int32.Parse(Selectedrow.Cells[5].Value.ToString()));

        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm OptionObjectForm = new OptionsForm();
            OptionObjectForm.Show();
        }

        private void UpdateTableShoes_Click(object sender, EventArgs e)
        {
            this.StartRowsView();
        }
    }
}
