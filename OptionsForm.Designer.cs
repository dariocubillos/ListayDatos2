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
            this.backupLabel = new System.Windows.Forms.Label();
            this.backupButton = new System.Windows.Forms.Button();
            this.importBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backupLabel
            // 
            this.backupLabel.AutoSize = true;
            this.backupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupLabel.Location = new System.Drawing.Point(67, 9);
            this.backupLabel.Name = "backupLabel";
            this.backupLabel.Size = new System.Drawing.Size(275, 29);
            this.backupLabel.TabIndex = 7;
            this.backupLabel.Text = "Respaldo base de datos";
            // 
            // backupButton
            // 
            this.backupButton.Location = new System.Drawing.Point(17, 60);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(179, 23);
            this.backupButton.TabIndex = 9;
            this.backupButton.Text = "Exportar Respaldo";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // importBackup
            // 
            this.importBackup.Location = new System.Drawing.Point(218, 60);
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
            this.ClientSize = new System.Drawing.Size(406, 104);
            this.Controls.Add(this.importBackup);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.backupLabel);
            this.Name = "OptionsForm";
            this.Text = "Opciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label backupLabel;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.Button importBackup;
    }
}