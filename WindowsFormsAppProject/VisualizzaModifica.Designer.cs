namespace WindowsFormsAppProject
{
	partial class VisualizzaModifica
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizzaModifica));
			this.pcbImg = new System.Windows.Forms.PictureBox();
			this.lblTarga = new System.Windows.Forms.Label();
			this.txtTarga = new System.Windows.Forms.TextBox();
			this.txtModello = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMarca = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCilindrata = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtColore = new System.Windows.Forms.TextBox();
			this.btnCambiaColore = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpImmatricolazione = new System.Windows.Forms.DateTimePicker();
			this.txtPotenza = new System.Windows.Forms.TextBox();
			this.txtPrezzo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numAirbag = new System.Windows.Forms.NumericUpDown();
			this.lblNAirbag = new System.Windows.Forms.Label();
			this.txtMarcaSella = new System.Windows.Forms.TextBox();
			this.lblMarcaSella = new System.Windows.Forms.Label();
			this.txtKmPercorsi = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkUsato = new System.Windows.Forms.CheckBox();
			this.chkKmZ = new System.Windows.Forms.CheckBox();
			this.btnChangeImg = new System.Windows.Forms.Button();
			this.ofdImg = new System.Windows.Forms.OpenFileDialog();
			this.label8 = new System.Windows.Forms.Label();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnVendi = new System.Windows.Forms.Button();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pcbImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numAirbag)).BeginInit();
			this.SuspendLayout();
			// 
			// pcbImg
			// 
			this.pcbImg.Location = new System.Drawing.Point(0, 0);
			this.pcbImg.Name = "pcbImg";
			this.pcbImg.Size = new System.Drawing.Size(278, 215);
			this.pcbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pcbImg.TabIndex = 0;
			this.pcbImg.TabStop = false;
			// 
			// lblTarga
			// 
			this.lblTarga.AutoSize = true;
			this.lblTarga.Location = new System.Drawing.Point(284, 9);
			this.lblTarga.Name = "lblTarga";
			this.lblTarga.Size = new System.Drawing.Size(41, 13);
			this.lblTarga.TabIndex = 1;
			this.lblTarga.Text = "Targa: ";
			// 
			// txtTarga
			// 
			this.txtTarga.Location = new System.Drawing.Point(331, 6);
			this.txtTarga.Name = "txtTarga";
			this.txtTarga.Size = new System.Drawing.Size(100, 20);
			this.txtTarga.TabIndex = 2;
			// 
			// txtModello
			// 
			this.txtModello.Location = new System.Drawing.Point(649, 6);
			this.txtModello.Name = "txtModello";
			this.txtModello.Size = new System.Drawing.Size(100, 20);
			this.txtModello.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(602, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Modello:";
			// 
			// txtMarca
			// 
			this.txtMarca.Location = new System.Drawing.Point(492, 6);
			this.txtMarca.Name = "txtMarca";
			this.txtMarca.Size = new System.Drawing.Size(100, 20);
			this.txtMarca.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(445, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Marca:";
			// 
			// txtCilindrata
			// 
			this.txtCilindrata.Location = new System.Drawing.Point(492, 46);
			this.txtCilindrata.Name = "txtCilindrata";
			this.txtCilindrata.Size = new System.Drawing.Size(100, 20);
			this.txtCilindrata.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(437, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Cilindrata:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(602, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Potenza: ";
			// 
			// txtColore
			// 
			this.txtColore.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtColore.Location = new System.Drawing.Point(400, 49);
			this.txtColore.Name = "txtColore";
			this.txtColore.ReadOnly = true;
			this.txtColore.Size = new System.Drawing.Size(31, 13);
			this.txtColore.TabIndex = 8;
			// 
			// btnCambiaColore
			// 
			this.btnCambiaColore.Location = new System.Drawing.Point(287, 44);
			this.btnCambiaColore.Name = "btnCambiaColore";
			this.btnCambiaColore.Size = new System.Drawing.Size(107, 23);
			this.btnCambiaColore.TabIndex = 13;
			this.btnCambiaColore.Text = "Cambia colore";
			this.btnCambiaColore.UseVisualStyleBackColor = true;
			this.btnCambiaColore.Click += new System.EventHandler(this.btnCambiaColore_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(287, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Data di immatricolazione:";
			// 
			// dtpImmatricolazione
			// 
			this.dtpImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpImmatricolazione.Location = new System.Drawing.Point(417, 85);
			this.dtpImmatricolazione.MaxDate = new System.DateTime(2019, 12, 13, 0, 0, 0, 0);
			this.dtpImmatricolazione.Name = "dtpImmatricolazione";
			this.dtpImmatricolazione.Size = new System.Drawing.Size(90, 20);
			this.dtpImmatricolazione.TabIndex = 15;
			this.dtpImmatricolazione.Value = new System.DateTime(2019, 12, 4, 0, 0, 0, 0);
			// 
			// txtPotenza
			// 
			this.txtPotenza.Location = new System.Drawing.Point(649, 46);
			this.txtPotenza.Name = "txtPotenza";
			this.txtPotenza.Size = new System.Drawing.Size(100, 20);
			this.txtPotenza.TabIndex = 10;
			// 
			// txtPrezzo
			// 
			this.txtPrezzo.Location = new System.Drawing.Point(649, 125);
			this.txtPrezzo.Name = "txtPrezzo";
			this.txtPrezzo.Size = new System.Drawing.Size(100, 20);
			this.txtPrezzo.TabIndex = 17;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(602, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Prezzo:";
			// 
			// numAirbag
			// 
			this.numAirbag.Location = new System.Drawing.Point(368, 122);
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
			this.numAirbag.TabIndex = 20;
			this.numAirbag.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lblNAirbag
			// 
			this.lblNAirbag.AutoSize = true;
			this.lblNAirbag.Location = new System.Drawing.Point(291, 124);
			this.lblNAirbag.Name = "lblNAirbag";
			this.lblNAirbag.Size = new System.Drawing.Size(80, 13);
			this.lblNAirbag.TabIndex = 18;
			this.lblNAirbag.Text = "Numero Airbag:";
			// 
			// txtMarcaSella
			// 
			this.txtMarcaSella.Location = new System.Drawing.Point(357, 122);
			this.txtMarcaSella.Name = "txtMarcaSella";
			this.txtMarcaSella.Size = new System.Drawing.Size(100, 20);
			this.txtMarcaSella.TabIndex = 21;
			// 
			// lblMarcaSella
			// 
			this.lblMarcaSella.AutoSize = true;
			this.lblMarcaSella.Location = new System.Drawing.Point(291, 125);
			this.lblMarcaSella.Name = "lblMarcaSella";
			this.lblMarcaSella.Size = new System.Drawing.Size(64, 13);
			this.lblMarcaSella.TabIndex = 19;
			this.lblMarcaSella.Text = "Marca sella:";
			// 
			// txtKmPercorsi
			// 
			this.txtKmPercorsi.Location = new System.Drawing.Point(739, 89);
			this.txtKmPercorsi.Name = "txtKmPercorsi";
			this.txtKmPercorsi.Size = new System.Drawing.Size(48, 20);
			this.txtKmPercorsi.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(668, 92);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Km percorsi:";
			// 
			// chkUsato
			// 
			this.chkUsato.AutoSize = true;
			this.chkUsato.Location = new System.Drawing.Point(524, 90);
			this.chkUsato.Name = "chkUsato";
			this.chkUsato.Size = new System.Drawing.Size(60, 17);
			this.chkUsato.TabIndex = 24;
			this.chkUsato.Text = "Usato?";
			this.chkUsato.UseVisualStyleBackColor = true;
			// 
			// chkKmZ
			// 
			this.chkKmZ.AutoSize = true;
			this.chkKmZ.Location = new System.Drawing.Point(590, 90);
			this.chkKmZ.Name = "chkKmZ";
			this.chkKmZ.Size = new System.Drawing.Size(72, 17);
			this.chkKmZ.TabIndex = 25;
			this.chkKmZ.Text = "Km Zero?";
			this.chkKmZ.UseVisualStyleBackColor = true;
			// 
			// btnChangeImg
			// 
			this.btnChangeImg.Location = new System.Drawing.Point(477, 120);
			this.btnChangeImg.Name = "btnChangeImg";
			this.btnChangeImg.Size = new System.Drawing.Size(107, 23);
			this.btnChangeImg.TabIndex = 26;
			this.btnChangeImg.Text = "Cambia immagine";
			this.btnChangeImg.UseVisualStyleBackColor = true;
			this.btnChangeImg.Click += new System.EventHandler(this.btnChangeImg_Click);
			// 
			// ofdImg
			// 
			this.ofdImg.FileName = "openFileDialog1";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(755, 129);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "€";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(290, 187);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(75, 23);
			this.btnModifica.TabIndex = 28;
			this.btnModifica.Text = "Modifica";
			this.btnModifica.UseVisualStyleBackColor = true;
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			// 
			// btnVendi
			// 
			this.btnVendi.Location = new System.Drawing.Point(477, 187);
			this.btnVendi.Name = "btnVendi";
			this.btnVendi.Size = new System.Drawing.Size(75, 23);
			this.btnVendi.TabIndex = 29;
			this.btnVendi.Text = "Vendi";
			this.btnVendi.UseVisualStyleBackColor = true;
			this.btnVendi.Click += new System.EventHandler(this.btnVendi_Click);
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(382, 187);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(75, 23);
			this.btnElimina.TabIndex = 30;
			this.btnElimina.Text = "Elimina";
			this.btnElimina.UseVisualStyleBackColor = true;
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.Location = new System.Drawing.Point(569, 187);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(75, 23);
			this.btnChiudi.TabIndex = 31;
			this.btnChiudi.Text = "Chiudi";
			this.btnChiudi.UseVisualStyleBackColor = true;
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// VisualizzaModifica
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 222);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnElimina);
			this.Controls.Add(this.btnVendi);
			this.Controls.Add(this.btnModifica);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnChangeImg);
			this.Controls.Add(this.chkKmZ);
			this.Controls.Add(this.chkUsato);
			this.Controls.Add(this.txtKmPercorsi);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.numAirbag);
			this.Controls.Add(this.lblNAirbag);
			this.Controls.Add(this.txtMarcaSella);
			this.Controls.Add(this.lblMarcaSella);
			this.Controls.Add(this.txtPrezzo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtpImmatricolazione);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnCambiaColore);
			this.Controls.Add(this.txtCilindrata);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPotenza);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtColore);
			this.Controls.Add(this.txtMarca);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtModello);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtTarga);
			this.Controls.Add(this.lblTarga);
			this.Controls.Add(this.pcbImg);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VisualizzaModifica";
			this.Text = "Autosalone Nico - Visualizza o modifica";
			this.Load += new System.EventHandler(this.VisualizzaModifica_Load);
			((System.ComponentModel.ISupportInitialize)(this.pcbImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numAirbag)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pcbImg;
		private System.Windows.Forms.Label lblTarga;
		private System.Windows.Forms.TextBox txtTarga;
		private System.Windows.Forms.TextBox txtModello;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMarca;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCilindrata;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtColore;
		private System.Windows.Forms.Button btnCambiaColore;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpImmatricolazione;
		private System.Windows.Forms.TextBox txtPotenza;
		private System.Windows.Forms.TextBox txtPrezzo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numAirbag;
		private System.Windows.Forms.Label lblNAirbag;
		private System.Windows.Forms.TextBox txtMarcaSella;
		private System.Windows.Forms.Label lblMarcaSella;
		private System.Windows.Forms.TextBox txtKmPercorsi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkUsato;
		private System.Windows.Forms.CheckBox chkKmZ;
		private System.Windows.Forms.Button btnChangeImg;
		private System.Windows.Forms.OpenFileDialog ofdImg;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnVendi;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnChiudi;
	}
}