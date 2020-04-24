﻿namespace WindowsFormsAppProject
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
            this.apriTSB = new System.Windows.Forms.ToolStripButton();
            this.stampaHtmlTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNuovoVeicoloTSB,
            this.salvaTSB,
            this.apriTSB,
            this.stampaHtmlTSB,
            this.toolStripSeparator});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
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
            // apriTSB
            // 
            this.apriTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.apriTSB.Image = ((System.Drawing.Image)(resources.GetObject("apriTSB.Image")));
            this.apriTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriTSB.Name = "apriTSB";
            this.apriTSB.Size = new System.Drawing.Size(23, 22);
            this.apriTSB.Text = "&Apri";
            this.apriTSB.Click += new System.EventHandler(this.ApriTSB_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Autosalone Vallauri - Vendita veicoli nuovi e usati";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addNuovoVeicoloTSB;
        private System.Windows.Forms.ToolStripButton salvaTSB;
        private System.Windows.Forms.ToolStripButton apriTSB;
        private System.Windows.Forms.ToolStripButton stampaHtmlTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

