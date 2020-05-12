namespace WindowsFormsAppProject
{
    partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.addNuovoVeicoloTSB = new System.Windows.Forms.ToolStripButton();
			this.salvaTSB = new System.Windows.Forms.ToolStripButton();
			this.stampaHtmlTSB = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cmbVisual = new System.Windows.Forms.ComboBox();
			this.dgvVisual = new System.Windows.Forms.DataGridView();
			this.rtbReport = new System.Windows.Forms.RichTextBox();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVisual)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNuovoVeicoloTSB,
            this.salvaTSB,
            this.stampaHtmlTSB,
            this.toolStripSeparator});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(913, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// addNuovoVeicoloTSB
			// 
			this.addNuovoVeicoloTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.addNuovoVeicoloTSB.Image = ((System.Drawing.Image)(resources.GetObject("addNuovoVeicoloTSB.Image")));
			this.addNuovoVeicoloTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addNuovoVeicoloTSB.Name = "addNuovoVeicoloTSB";
			this.addNuovoVeicoloTSB.Size = new System.Drawing.Size(23, 22);
			this.addNuovoVeicoloTSB.Text = "&Nuovo";
			this.addNuovoVeicoloTSB.Click += new System.EventHandler(this.AddNuovoVeicoloTSB_Click);
			// 
			// salvaTSB
			// 
			this.salvaTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.salvaTSB.Image = ((System.Drawing.Image)(resources.GetObject("salvaTSB.Image")));
			this.salvaTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.salvaTSB.Name = "salvaTSB";
			this.salvaTSB.Size = new System.Drawing.Size(23, 22);
			this.salvaTSB.Text = "&Salva";
			this.salvaTSB.Click += new System.EventHandler(this.SalvaTSB_Click);
			// 
			// stampaHtmlTSB
			// 
			this.stampaHtmlTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.stampaHtmlTSB.Image = ((System.Drawing.Image)(resources.GetObject("stampaHtmlTSB.Image")));
			this.stampaHtmlTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stampaHtmlTSB.Name = "stampaHtmlTSB";
			this.stampaHtmlTSB.Size = new System.Drawing.Size(23, 22);
			this.stampaHtmlTSB.Text = "&Stampa";
			this.stampaHtmlTSB.Click += new System.EventHandler(this.StampaHtmlTSB_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// cmbVisual
			// 
			this.cmbVisual.FormattingEnabled = true;
			this.cmbVisual.Items.AddRange(new object[] {
            "Automobili",
            "Moto",
            "Report Vendite"});
			this.cmbVisual.Location = new System.Drawing.Point(12, 28);
			this.cmbVisual.Name = "cmbVisual";
			this.cmbVisual.Size = new System.Drawing.Size(164, 21);
			this.cmbVisual.TabIndex = 3;
			this.cmbVisual.SelectedIndexChanged += new System.EventHandler(this.cmbVisual_SelectedIndexChanged);
			// 
			// dgvVisual
			// 
			this.dgvVisual.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dgvVisual.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvVisual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVisual.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvVisual.Location = new System.Drawing.Point(0, 55);
			this.dgvVisual.Name = "dgvVisual";
			this.dgvVisual.ReadOnly = true;
			this.dgvVisual.Size = new System.Drawing.Size(913, 431);
			this.dgvVisual.TabIndex = 4;
			this.dgvVisual.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisual_CellDoubleClick);
			// 
			// rtbReport
			// 
			this.rtbReport.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rtbReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbReport.Location = new System.Drawing.Point(8, 55);
			this.rtbReport.Name = "rtbReport";
			this.rtbReport.Size = new System.Drawing.Size(893, 407);
			this.rtbReport.TabIndex = 6;
			this.rtbReport.Text = "";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(913, 486);
			this.Controls.Add(this.dgvVisual);
			this.Controls.Add(this.cmbVisual);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.rtbReport);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.Text = "Autosalone Nico - Vendita veicoli nuovi e usati";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			this.Load += new System.EventHandler(this.Main_Load);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVisual)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addNuovoVeicoloTSB;
        private System.Windows.Forms.ToolStripButton salvaTSB;
        private System.Windows.Forms.ToolStripButton stampaHtmlTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ComboBox cmbVisual;
        private System.Windows.Forms.DataGridView dgvVisual;
        private System.Windows.Forms.RichTextBox rtbReport;
	}
}

