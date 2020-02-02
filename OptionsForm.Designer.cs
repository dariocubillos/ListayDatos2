namespace ListayDatos2
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.databaseLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.backupLabel = new System.Windows.Forms.Label();
            this.guardarConn = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.importBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseLabel.Location = new System.Drawing.Point(12, 26);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(167, 29);
            this.databaseLabel.TabIndex = 0;
            this.databaseLabel.Text = "Base de datos";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(14, 79);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(49, 13);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "Servidor:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(175, 79);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(46, 13);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(227, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(403, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // backupLabel
            // 
            this.backupLabel.AutoSize = true;
            this.backupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupLabel.Location = new System.Drawing.Point(12, 122);
            this.backupLabel.Name = "backupLabel";
            this.backupLabel.Size = new System.Drawing.Size(275, 29);
            this.backupLabel.TabIndex = 7;
            this.backupLabel.Text = "Respaldo base de datos";
            // 
            // guardarConn
            // 
            this.guardarConn.Location = new System.Drawing.Point(526, 74);
            this.guardarConn.Name = "guardarConn";
            this.guardarConn.Size = new System.Drawing.Size(75, 23);
            this.guardarConn.TabIndex = 8;
            this.guardarConn.Text = "Guardar";
            this.guardarConn.UseVisualStyleBackColor = true;
            this.guardarConn.Click += new System.EventHandler(this.guardarConn_Click);
            // 
            // backupButton
            // 
            this.backupButton.Location = new System.Drawing.Point(17, 167);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(179, 23);
            this.backupButton.TabIndex = 9;
            this.backupButton.Text = "Exportar Respaldo";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // importBackup
            // 
            this.importBackup.Location = new System.Drawing.Point(227, 167);
            this.importBackup.Name = "importBackup";
            this.importBackup.Size = new System.Drawing.Size(179, 23);
            this.importBackup.TabIndex = 10;
            this.importBackup.Text = "Importar Respaldo";
            this.importBackup.UseVisualStyleBackColor = true;
            this.importBackup.Click += new System.EventHandler(this.importBackup_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 223);
            this.Controls.Add(this.importBackup);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.guardarConn);
            this.Controls.Add(this.backupLabel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.databaseLabel);
            this.Name = "OptionsForm";
            this.Text = "Opciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label backupLabel;
        private System.Windows.Forms.Button guardarConn;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Button importBackup;
    }
}