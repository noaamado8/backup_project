namespace backup_project
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.backup_button = new System.Windows.Forms.Button();
            this.source_button = new System.Windows.Forms.Button();
            this.destination_button = new System.Windows.Forms.Button();
            this.source_label = new System.Windows.Forms.Label();
            this.destination_label = new System.Windows.Forms.Label();
            this.input_folder_name = new System.Windows.Forms.TextBox();
            this.add_date_button = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folder_name_label = new System.Windows.Forms.Label();
            this.empty_destination = new System.Windows.Forms.CheckBox();
            this.shutdown = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // backup_button
            // 
            this.backup_button.Location = new System.Drawing.Point(24, 396);
            this.backup_button.Name = "backup_button";
            this.backup_button.Size = new System.Drawing.Size(75, 23);
            this.backup_button.TabIndex = 0;
            this.backup_button.Text = "Backup";
            this.backup_button.UseVisualStyleBackColor = true;
            this.backup_button.Click += new System.EventHandler(this.backup_button_Click);
            // 
            // source_button
            // 
            this.source_button.Location = new System.Drawing.Point(12, 63);
            this.source_button.Name = "source_button";
            this.source_button.Size = new System.Drawing.Size(109, 48);
            this.source_button.TabIndex = 3;
            this.source_button.Text = "Select Source Folder ";
            this.source_button.UseVisualStyleBackColor = true;
            this.source_button.Click += new System.EventHandler(this.source_button_Click);
            // 
            // destination_button
            // 
            this.destination_button.Location = new System.Drawing.Point(12, 118);
            this.destination_button.Name = "destination_button";
            this.destination_button.Size = new System.Drawing.Size(109, 48);
            this.destination_button.TabIndex = 4;
            this.destination_button.Text = "Select Destination Folder";
            this.destination_button.UseVisualStyleBackColor = true;
            this.destination_button.Click += new System.EventHandler(this.destination_button_Click);
            // 
            // source_label
            // 
            this.source_label.AutoSize = true;
            this.source_label.Location = new System.Drawing.Point(131, 81);
            this.source_label.Name = "source_label";
            this.source_label.Size = new System.Drawing.Size(0, 13);
            this.source_label.TabIndex = 5;
            // 
            // destination_label
            // 
            this.destination_label.AutoSize = true;
            this.destination_label.Location = new System.Drawing.Point(131, 136);
            this.destination_label.Name = "destination_label";
            this.destination_label.Size = new System.Drawing.Size(0, 13);
            this.destination_label.TabIndex = 6;
            // 
            // input_folder_name
            // 
            this.input_folder_name.Location = new System.Drawing.Point(24, 244);
            this.input_folder_name.Name = "input_folder_name";
            this.input_folder_name.Size = new System.Drawing.Size(185, 20);
            this.input_folder_name.TabIndex = 7;
            this.input_folder_name.TextChanged += new System.EventHandler(this.input_folder_name_TextChanged);
            // 
            // add_date_button
            // 
            this.add_date_button.AutoSize = true;
            this.add_date_button.Location = new System.Drawing.Point(242, 244);
            this.add_date_button.Name = "add_date_button";
            this.add_date_button.Size = new System.Drawing.Size(214, 17);
            this.add_date_button.TabIndex = 8;
            this.add_date_button.Text = "Add date ( foldername_YYYY/MM/DD )";
            this.add_date_button.UseVisualStyleBackColor = true;
            this.add_date_button.CheckedChanged += new System.EventHandler(this.add_date_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "New folder name:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 38);
            this.label4.TabIndex = 10;
            this.label4.Text = "Backup";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // folder_name_label
            // 
            this.folder_name_label.AutoSize = true;
            this.folder_name_label.Location = new System.Drawing.Point(24, 284);
            this.folder_name_label.Name = "folder_name_label";
            this.folder_name_label.Size = new System.Drawing.Size(0, 13);
            this.folder_name_label.TabIndex = 11;
            // 
            // empty_destination
            // 
            this.empty_destination.AutoSize = true;
            this.empty_destination.Location = new System.Drawing.Point(24, 320);
            this.empty_destination.Name = "empty_destination";
            this.empty_destination.Size = new System.Drawing.Size(138, 17);
            this.empty_destination.TabIndex = 12;
            this.empty_destination.Text = "Empty destination folder";
            this.empty_destination.UseVisualStyleBackColor = true;
            // 
            // shutdown
            // 
            this.shutdown.AutoSize = true;
            this.shutdown.Location = new System.Drawing.Point(24, 358);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(152, 17);
            this.shutdown.TabIndex = 13;
            this.shutdown.Text = "Shutdown pc after backup";
            this.shutdown.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 482);
            this.Controls.Add(this.shutdown);
            this.Controls.Add(this.empty_destination);
            this.Controls.Add(this.folder_name_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.add_date_button);
            this.Controls.Add(this.input_folder_name);
            this.Controls.Add(this.destination_label);
            this.Controls.Add(this.source_label);
            this.Controls.Add(this.destination_button);
            this.Controls.Add(this.source_button);
            this.Controls.Add(this.backup_button);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backup_button;
        private System.Windows.Forms.Button source_button;
        private System.Windows.Forms.Button destination_button;
        private System.Windows.Forms.Label source_label;
        private System.Windows.Forms.Label destination_label;
        private System.Windows.Forms.TextBox input_folder_name;
        private System.Windows.Forms.CheckBox add_date_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label folder_name_label;
        private System.Windows.Forms.CheckBox empty_destination;
        private System.Windows.Forms.CheckBox shutdown;
    }
}

