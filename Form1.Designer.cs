namespace ListayDatos2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.DeleteShoe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BuscarLabel = new System.Windows.Forms.Label();
            this.showby = new System.Windows.Forms.Label();
            this.ShowByItems = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddShoe = new System.Windows.Forms.Button();
            this.RemoveShoe = new System.Windows.Forms.Button();
            this.ConfigShoe = new System.Windows.Forms.Button();
            this.FastButtons = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGrid
            // 
            this.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGrid.Location = new System.Drawing.Point(12, 32);
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.Size = new System.Drawing.Size(644, 344);
            this.MainGrid.TabIndex = 0;
            // 
            // DeleteShoe
            // 
            this.DeleteShoe.Location = new System.Drawing.Point(671, 32);
            this.DeleteShoe.Name = "DeleteShoe";
            this.DeleteShoe.Size = new System.Drawing.Size(215, 64);
            this.DeleteShoe.TabIndex = 1;
            this.DeleteShoe.Text = "BORRAR ZAPATO";
            this.DeleteShoe.UseVisualStyleBackColor = true;
            this.DeleteShoe.Click += new System.EventHandler(this.DeleteShoe_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.SearchModel);
            // 
            // BuscarLabel
            // 
            this.BuscarLabel.AutoSize = true;
            this.BuscarLabel.Location = new System.Drawing.Point(9, 9);
            this.BuscarLabel.Name = "BuscarLabel";
            this.BuscarLabel.Size = new System.Drawing.Size(98, 13);
            this.BuscarLabel.Size = new System.Drawing.Size(97, 13);
            this.BuscarLabel.TabIndex = 3;
            this.BuscarLabel.Text = "Buscar por modelo:";
            this.BuscarLabel.Text = "Buscar por Codigo:";
            // 
            // showby
            // 
            this.showby.AutoSize = true;
            this.showby.Location = new System.Drawing.Point(325, 8);
            this.showby.Name = "showby";
            this.showby.Size = new System.Drawing.Size(26, 13);
            this.showby.TabIndex = 4;
            this.showby.Text = "Ver:";
            // 
            // ShowByItems
            // 
            this.ShowByItems.FormattingEnabled = true;
            this.ShowByItems.Location = new System.Drawing.Point(357, 5);
            this.ShowByItems.Name = "ShowByItems";
            this.ShowByItems.Size = new System.Drawing.Size(299, 21);
            this.ShowByItems.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 64);
            this.button1.TabIndex = 6;
            this.button1.Text = "AÑADIR UN ZAPATO";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(671, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 64);
            this.button2.TabIndex = 7;
            this.button2.Text = "QUITAR UN ZAPATO";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(671, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 64);
            this.button3.TabIndex = 8;
            this.button3.Text = "EDITAR ZAPATO";
            this.button3.UseVisualStyleBackColor = true;
            this.ShowByItems.SelectedIndexChanged += new System.EventHandler(this.SelectFilter);
            // 
            // AddShoe
            // 
            this.AddShoe.Location = new System.Drawing.Point(671, 102);
            this.AddShoe.Name = "AddShoe";
            this.AddShoe.Size = new System.Drawing.Size(215, 64);
            this.AddShoe.TabIndex = 6;
            this.AddShoe.Text = "AÑADIR UN ZAPATO";
            this.AddShoe.UseVisualStyleBackColor = true;
            this.AddShoe.Click += new System.EventHandler(this.AddShoe_Click);
            // 
            // RemoveShoe
            // 
            this.RemoveShoe.Location = new System.Drawing.Point(671, 172);
            this.RemoveShoe.Name = "RemoveShoe";
            this.RemoveShoe.Size = new System.Drawing.Size(215, 64);
            this.RemoveShoe.TabIndex = 7;
            this.RemoveShoe.Text = "QUITAR UN ZAPATO";
            this.RemoveShoe.UseVisualStyleBackColor = true;
            this.RemoveShoe.Click += new System.EventHandler(this.RemoveShoe_Click);
            // 
            // ConfigShoe
            // 
            this.ConfigShoe.Location = new System.Drawing.Point(671, 242);
            this.ConfigShoe.Name = "ConfigShoe";
            this.ConfigShoe.Size = new System.Drawing.Size(215, 64);
            this.ConfigShoe.TabIndex = 8;
            this.ConfigShoe.Text = "EDITAR ZAPATO";
            this.ConfigShoe.UseVisualStyleBackColor = true;
            this.ConfigShoe.Click += new System.EventHandler(this.ConfigShoe_Click);
            // 
            // FastButtons
            // 
            this.FastButtons.AutoSize = true;
            this.FastButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FastButtons.Location = new System.Drawing.Point(702, 6);
            this.FastButtons.Name = "FastButtons";
            this.FastButtons.Size = new System.Drawing.Size(153, 20);
            this.FastButtons.TabIndex = 9;
            this.FastButtons.Text = "Acciónes Rapidas";
            // 
            // button4
            // OptionsButton
            // 
            this.button4.Location = new System.Drawing.Point(671, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 64);
            this.button4.TabIndex = 10;
            this.button4.Text = "OPCIÓNES";
            this.button4.UseVisualStyleBackColor = true;
            this.OptionsButton.Location = new System.Drawing.Point(671, 312);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(215, 64);
            this.OptionsButton.TabIndex = 10;
            this.OptionsButton.Text = "OPCIÓNES";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 389);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.FastButtons);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ConfigShoe);
            this.Controls.Add(this.RemoveShoe);
            this.Controls.Add(this.AddShoe);
            this.Controls.Add(this.ShowByItems);
            this.Controls.Add(this.showby);
            this.Controls.Add(this.BuscarLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DeleteShoe);
            this.Controls.Add(this.MainGrid);
            this.Name = "Form1";
            this.Text = "Lista y Datos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.Button DeleteShoe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label BuscarLabel;
        private System.Windows.Forms.Label showby;
        private System.Windows.Forms.ComboBox ShowByItems;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AddShoe;
        private System.Windows.Forms.Button RemoveShoe;
        private System.Windows.Forms.Button ConfigShoe;
        private System.Windows.Forms.Label FastButtons;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button OptionsButton;
    }
}

