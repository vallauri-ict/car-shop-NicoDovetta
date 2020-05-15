namespace WindowsFormsAppProject
{
    partial class AddNewVeicolo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewVeicolo));
			this.numKmPercorsi = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.numAirbag = new System.Windows.Forms.NumericUpDown();
			this.lblNAirbag = new System.Windows.Forms.Label();
			this.txtMarcaSella = new System.Windows.Forms.TextBox();
			this.lblMarcaSella = new System.Windows.Forms.Label();
			this.dtpImmatricolazione = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.numPotenza = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.numCilindrata = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtModello = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMarca = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTipoVeicolo = new System.Windows.Forms.ComboBox();
			this.btnColore = new System.Windows.Forms.Button();
			this.provaBackground = new System.Windows.Forms.TextBox();
			this.rdbSiNuova = new System.Windows.Forms.RadioButton();
			this.grpNuova = new System.Windows.Forms.GroupBox();
			this.rdbNoNuova = new System.Windows.Forms.RadioButton();
			this.grpKm0 = new System.Windows.Forms.GroupBox();
			this.rdbNoKm0 = new System.Windows.Forms.RadioButton();
			this.rdbSiKm0 = new System.Windows.Forms.RadioButton();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnAggiungi = new System.Windows.Forms.Button();
			this.btnImmagine = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPrezzo = new System.Windows.Forms.TextBox();
			this.txtTarga = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.ofdImg = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.numKmPercorsi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numAirbag)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPotenza)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCilindrata)).BeginInit();
			this.grpNuova.SuspendLayout();
			this.grpKm0.SuspendLayout();
			this.SuspendLayout();
			// 
			// numKmPercorsi
			// 
			this.numKmPercorsi.Location = new System.Drawing.Point(110, 120);
			this.numKmPercorsi.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numKmPercorsi.Name = "numKmPercorsi";
			this.numKmPercorsi.Size = new System.Drawing.Size(44, 20);
			this.numKmPercorsi.TabIndex = 12;
			this.numKmPercorsi.ValueChanged += new System.EventHandler(this.numKmPercorsi_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Chilometri percorsi:";
			// 
			// numAirbag
			// 
			this.numAirbag.Location = new System.Drawing.Point(389, 120);
			this.numAirbag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numAirbag.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numAirbag.Name = "numAirbag";
			this.numAirbag.Size = new System.Drawing.Size(33, 20);
			this.numAirbag.TabIndex = 15;
			this.numAirbag.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lblNAirbag
			// 
			this.lblNAirbag.AutoSize = true;
			this.lblNAirbag.Location = new System.Drawing.Point(312, 122);
			this.lblNAirbag.Name = "lblNAirbag";
			this.lblNAirbag.Size = new System.Drawing.Size(80, 13);
			this.lblNAirbag.TabIndex = 14;
			this.lblNAirbag.Text = "Numero Airbag:";
			// 
			// txtMarcaSella
			// 
			this.txtMarcaSella.Location = new System.Drawing.Point(378, 120);
			this.txtMarcaSella.Name = "txtMarcaSella";
			this.txtMarcaSella.Size = new System.Drawing.Size(100, 20);
			this.txtMarcaSella.TabIndex = 15;
			// 
			// lblMarcaSella
			// 
			this.lblMarcaSella.AutoSize = true;
			this.lblMarcaSella.Location = new System.Drawing.Point(312, 123);
			this.lblMarcaSella.Name = "lblMarcaSella";
			this.lblMarcaSella.Size = new System.Drawing.Size(64, 13);
			this.lblMarcaSella.TabIndex = 14;
			this.lblMarcaSella.Text = "Marca sella:";
			// 
			// dtpImmatricolazione
			// 
			this.dtpImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpImmatricolazione.Location = new System.Drawing.Point(573, 40);
			this.dtpImmatricolazione.MaxDate = new System.DateTime(2019, 12, 13, 0, 0, 0, 0);
			this.dtpImmatricolazione.Name = "dtpImmatricolazione";
			this.dtpImmatricolazione.Size = new System.Drawing.Size(90, 20);
			this.dtpImmatricolazione.TabIndex = 4;
			this.dtpImmatricolazione.Value = new System.DateTime(2019, 12, 4, 0, 0, 0, 0);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(477, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Immatricolazione:";
			// 
			// numPotenza
			// 
			this.numPotenza.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numPotenza.Location = new System.Drawing.Point(175, 82);
			this.numPotenza.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numPotenza.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numPotenza.Name = "numPotenza";
			this.numPotenza.Size = new System.Drawing.Size(40, 20);
			this.numPotenza.TabIndex = 6;
			this.numPotenza.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(123, 85);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Potenza:";
			// 
			// numCilindrata
			// 
			this.numCilindrata.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numCilindrata.Location = new System.Drawing.Point(62, 83);
			this.numCilindrata.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numCilindrata.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numCilindrata.Name = "numCilindrata";
			this.numCilindrata.Size = new System.Drawing.Size(42, 20);
			this.numCilindrata.TabIndex = 5;
			this.numCilindrata.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Cilindrata:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(235, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Colore:";
			// 
			// txtModello
			// 
			this.txtModello.Location = new System.Drawing.Point(288, 40);
			this.txtModello.Name = "txtModello";
			this.txtModello.Size = new System.Drawing.Size(153, 20);
			this.txtModello.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(235, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Modello:";
			// 
			// txtMarca
			// 
			this.txtMarca.Location = new System.Drawing.Point(55, 40);
			this.txtMarca.Name = "txtMarca";
			this.txtMarca.Size = new System.Drawing.Size(152, 20);
			this.txtMarca.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Marca:";
			// 
			// cmbTipoVeicolo
			// 
			this.cmbTipoVeicolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoVeicolo.FormattingEnabled = true;
			this.cmbTipoVeicolo.Items.AddRange(new object[] {
            "Moto",
            "Automobili"});
			this.cmbTipoVeicolo.Location = new System.Drawing.Point(238, 13);
			this.cmbTipoVeicolo.Name = "cmbTipoVeicolo";
			this.cmbTipoVeicolo.Size = new System.Drawing.Size(130, 21);
			this.cmbTipoVeicolo.TabIndex = 1;
			this.cmbTipoVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVeicolo_SelectedIndexChanged);
			// 
			// btnColore
			// 
			this.btnColore.Location = new System.Drawing.Point(281, 83);
			this.btnColore.Name = "btnColore";
			this.btnColore.Size = new System.Drawing.Size(126, 20);
			this.btnColore.TabIndex = 7;
			this.btnColore.Text = "Scegli colore";
			this.btnColore.UseVisualStyleBackColor = true;
			this.btnColore.Click += new System.EventHandler(this.btnColore_Click);
			// 
			// provaBackground
			// 
			this.provaBackground.Location = new System.Drawing.Point(410, 84);
			this.provaBackground.Margin = new System.Windows.Forms.Padding(0);
			this.provaBackground.Name = "provaBackground";
			this.provaBackground.ReadOnly = true;
			this.provaBackground.Size = new System.Drawing.Size(33, 20);
			this.provaBackground.TabIndex = 0;
			// 
			// rdbSiNuova
			// 
			this.rdbSiNuova.AutoSize = true;
			this.rdbSiNuova.Checked = true;
			this.rdbSiNuova.Location = new System.Drawing.Point(6, 11);
			this.rdbSiNuova.Name = "rdbSiNuova";
			this.rdbSiNuova.Size = new System.Drawing.Size(34, 17);
			this.rdbSiNuova.TabIndex = 8;
			this.rdbSiNuova.TabStop = true;
			this.rdbSiNuova.Text = "Si";
			this.rdbSiNuova.UseVisualStyleBackColor = true;
			// 
			// grpNuova
			// 
			this.grpNuova.Controls.Add(this.rdbNoNuova);
			this.grpNuova.Controls.Add(this.rdbSiNuova);
			this.grpNuova.Location = new System.Drawing.Point(456, 72);
			this.grpNuova.Name = "grpNuova";
			this.grpNuova.Size = new System.Drawing.Size(97, 34);
			this.grpNuova.TabIndex = 0;
			this.grpNuova.TabStop = false;
			this.grpNuova.Text = "Nuova?";
			// 
			// rdbNoNuova
			// 
			this.rdbNoNuova.AutoSize = true;
			this.rdbNoNuova.Location = new System.Drawing.Point(57, 11);
			this.rdbNoNuova.Name = "rdbNoNuova";
			this.rdbNoNuova.Size = new System.Drawing.Size(39, 17);
			this.rdbNoNuova.TabIndex = 9;
			this.rdbNoNuova.Text = "No";
			this.rdbNoNuova.UseVisualStyleBackColor = true;
			this.rdbNoNuova.CheckedChanged += new System.EventHandler(this.rdbNoNuova_CheckedChanged);
			// 
			// grpKm0
			// 
			this.grpKm0.Controls.Add(this.rdbNoKm0);
			this.grpKm0.Controls.Add(this.rdbSiKm0);
			this.grpKm0.Enabled = false;
			this.grpKm0.Location = new System.Drawing.Point(567, 72);
			this.grpKm0.Name = "grpKm0";
			this.grpKm0.Size = new System.Drawing.Size(97, 34);
			this.grpKm0.TabIndex = 0;
			this.grpKm0.TabStop = false;
			this.grpKm0.Text = "Km0?";
			// 
			// rdbNoKm0
			// 
			this.rdbNoKm0.AutoSize = true;
			this.rdbNoKm0.Checked = true;
			this.rdbNoKm0.Location = new System.Drawing.Point(57, 11);
			this.rdbNoKm0.Name = "rdbNoKm0";
			this.rdbNoKm0.Size = new System.Drawing.Size(39, 17);
			this.rdbNoKm0.TabIndex = 11;
			this.rdbNoKm0.TabStop = true;
			this.rdbNoKm0.Text = "No";
			this.rdbNoKm0.UseVisualStyleBackColor = true;
			// 
			// rdbSiKm0
			// 
			this.rdbSiKm0.AutoSize = true;
			this.rdbSiKm0.Location = new System.Drawing.Point(6, 11);
			this.rdbSiKm0.Name = "rdbSiKm0";
			this.rdbSiKm0.Size = new System.Drawing.Size(34, 17);
			this.rdbSiKm0.TabIndex = 10;
			this.rdbSiKm0.Text = "Si";
			this.rdbSiKm0.UseVisualStyleBackColor = true;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(12, 174);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 18;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnAggiungi
			// 
			this.btnAggiungi.Location = new System.Drawing.Point(97, 174);
			this.btnAggiungi.Name = "btnAggiungi";
			this.btnAggiungi.Size = new System.Drawing.Size(75, 23);
			this.btnAggiungi.TabIndex = 19;
			this.btnAggiungi.Text = "Aggiungi";
			this.btnAggiungi.UseVisualStyleBackColor = true;
			this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
			// 
			// btnImmagine
			// 
			this.btnImmagine.Location = new System.Drawing.Point(175, 119);
			this.btnImmagine.Name = "btnImmagine";
			this.btnImmagine.Size = new System.Drawing.Size(115, 20);
			this.btnImmagine.TabIndex = 13;
			this.btnImmagine.Text = "Carica immagine";
			this.btnImmagine.UseVisualStyleBackColor = true;
			this.btnImmagine.Click += new System.EventHandler(this.btnImmagine_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(505, 123);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Prezzo:";
			// 
			// txtPrezzo
			// 
			this.txtPrezzo.Location = new System.Drawing.Point(553, 120);
			this.txtPrezzo.Name = "txtPrezzo";
			this.txtPrezzo.Size = new System.Drawing.Size(111, 20);
			this.txtPrezzo.TabIndex = 16;
			this.txtPrezzo.TextChanged += new System.EventHandler(this.txtPrezzo_TextChanged);
			// 
			// txtTarga
			// 
			this.txtTarga.Location = new System.Drawing.Point(57, 148);
			this.txtTarga.Name = "txtTarga";
			this.txtTarga.Size = new System.Drawing.Size(111, 20);
			this.txtTarga.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 151);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(38, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Targa:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(187, 151);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(359, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "La targa deve rispettare le regole comunemente in uso sulle targhe italiane.";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(187, 164);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(275, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Per applicare una targa di default lasciare libero il campo.";
			// 
			// ofdImg
			// 
			this.ofdImg.FileName = "openFileDialog1";
			// 
			// AddNewVeicolo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 205);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtTarga);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtPrezzo);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnImmagine);
			this.Controls.Add(this.btnAggiungi);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.grpKm0);
			this.Controls.Add(this.grpNuova);
			this.Controls.Add(this.provaBackground);
			this.Controls.Add(this.btnColore);
			this.Controls.Add(this.numKmPercorsi);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numAirbag);
			this.Controls.Add(this.lblNAirbag);
			this.Controls.Add(this.txtMarcaSella);
			this.Controls.Add(this.lblMarcaSella);
			this.Controls.Add(this.dtpImmatricolazione);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numPotenza);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numCilindrata);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtModello);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMarca);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbTipoVeicolo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddNewVeicolo";
			this.Text = "Autosalone Nico - Aggiungi veicolo";
			this.Load += new System.EventHandler(this.AddNewVeicolo_Load);
			((System.ComponentModel.ISupportInitialize)(this.numKmPercorsi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numAirbag)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPotenza)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCilindrata)).EndInit();
			this.grpNuova.ResumeLayout(false);
			this.grpNuova.PerformLayout();
			this.grpKm0.ResumeLayout(false);
			this.grpKm0.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numKmPercorsi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numAirbag;
        private System.Windows.Forms.Label lblNAirbag;
        private System.Windows.Forms.TextBox txtMarcaSella;
        private System.Windows.Forms.Label lblMarcaSella;
        private System.Windows.Forms.DateTimePicker dtpImmatricolazione;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numPotenza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCilindrata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoVeicolo;
        private System.Windows.Forms.Button btnColore;
        private System.Windows.Forms.TextBox provaBackground;
        private System.Windows.Forms.RadioButton rdbSiNuova;
        private System.Windows.Forms.GroupBox grpNuova;
        private System.Windows.Forms.RadioButton rdbNoNuova;
        private System.Windows.Forms.GroupBox grpKm0;
        private System.Windows.Forms.RadioButton rdbNoKm0;
        private System.Windows.Forms.RadioButton rdbSiKm0;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnImmagine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrezzo;
        private System.Windows.Forms.TextBox txtTarga;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog ofdImg;
    }
}