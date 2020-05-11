#region Riferimenti
//Interni
using System;
using System.Drawing;
using System.Windows.Forms;
using veicoliDLLProject;

//Esterni

#endregion Riferimenti

namespace WindowsFormsAppProject
{
    public partial class AddNewVeicolo : Form
    {
        private SerialBindList<Veicolo> listaVeicoli;//Riferimento alla lista "vera", contenente tutti i veicoli
        private KnownColor color = KnownColor.Black;//colore del veicolo scelto dall'utente
        private string imgPath = @".\img/noPhoto.jpg";

        /// <summary>
        /// Costruttore vuoto
        /// </summary>
        public AddNewVeicolo()
        {
            InitializeComponent();
            provaBackground.BorderStyle = BorderStyle.None;
            cmbTipoVeicolo.SelectedIndex = 0;
        }

        /// <summary>
        /// Crea un riferimento alla lista con tutti i veicoli,
        /// imposta a none il valore del bordo della textbox di pre-view a none in maniera
        /// da renderla presente ma non visibile fino a quando non si sceglie un colore,
        /// autoseleziona come veicolo una moto
        /// </summary>
        /// <param name="listaVeicoli">Riferimento alla lista contenente tutti i dati ed i veicoli</param>
        public AddNewVeicolo(SerialBindList<Veicolo> listaVeicoli)
        {
            InitializeComponent();
            this.listaVeicoli = listaVeicoli;
            provaBackground.BorderStyle = BorderStyle.None;
            cmbTipoVeicolo.SelectedIndex = 0;
        }

        /// <summary>
        /// Al premere del bottone colore avvia una dialog form e fa scegliere il colore all'utente;
        /// successivamente salca il colore scelto e lo imposta come colore di sfondo della textBox di pre-view
        /// </summary>
        private void btnColore_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.ShowDialog();
            color = (c.Color).ToKnownColor();
            provaBackground.BackColor = c.Color;//Imposta lo sfondo di una textBox al colore selezionato, da intendersi come "pre-view"
        }

        /// <summary>
        /// A seconda del checked su nuova viene abilitato/disabilitato il groupBox per il Km0
        /// </summary>
        private void rdbNoNuova_CheckedChanged(object sender, EventArgs e)
        {
            grpKm0.Enabled = rdbNoNuova.Checked;
        }

        /// <summary>
        /// Ogni volta che l'indice della combobox di scelta del veicolo cambia aggiorna la form per aggiungere o togliere i campi specifici di uno o dell'altro
        /// </summary>
        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoVeicolo.SelectedIndex == 0)
            {
                lblMarcaSella.Visible = txtMarcaSella.Visible = true;
                lblNAirbag.Visible = numAirbag.Visible = false;
            }
            else
            {
                lblNAirbag.Visible = numAirbag.Visible = true;
                lblMarcaSella.Visible = txtMarcaSella.Visible = false;
            }
        }

        /// <summary>
        /// Sul click del btn annulla chiudo la form
        /// </summary>
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Dopo aver agginto il veicolo, evitando errori chiudo la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            string targa = txtTarga.Text;
            if (Utils.checkTarga(ref targa, listaVeicoli))
            {
                if (cmbTipoVeicolo.SelectedIndex == 0)
                {
                    listaVeicoli.Add(new Moto(targa, txtMarca.Text, txtModello.Text, color.ToString(), Convert.ToDouble(numCilindrata.Value), Convert.ToDouble(numPotenza), dtpImmatricolazione.Value, rdbSiNuova.Checked, rdbSiKm0.Checked, Convert.ToInt32(numKmPercorsi.Value), txtMarcaSella.Text, Convert.ToDouble(txtPrezzo.Text), imgPath));
                }
                else
                {
                    listaVeicoli.Add(new Automobili(targa, txtMarca.Text, txtModello.Text, color.ToString(), Convert.ToDouble(numCilindrata.Value), Convert.ToDouble(numPotenza), dtpImmatricolazione.Value, rdbSiNuova.Checked, rdbSiKm0.Checked, Convert.ToInt32(numKmPercorsi.Value), Convert.ToInt32(numAirbag.Value), Convert.ToDouble(txtPrezzo.Text), imgPath));
                }
                Close();
            }
            else
            {
                MessageBox.Show("Targa non valida. Se la macchina non è immatricolata lasciare libero il campo.", "Autosalone Nico");
            }
        }

        /// <summary>
        /// Apre una file dialog che permette di scegliere l'immagine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImmagine_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            imgPath = ofd.FileName;
            if (!imgPath.Contains(".png") || !imgPath.Contains(".jpg") || !imgPath.Contains(".jpeg"))
            {
                MessageBox.Show("Estensioni accettate .png, .jpg, .jpeg.", "Autosalone Nico");
                imgPath = @".\img/noPhoto.jpg";
            }
        }

        private void txtPrezzo_TextChanged(object sender, EventArgs e)
        {
            double _;
            if (!double.TryParse(txtPrezzo.Text, out _))
            {
                MessageBox.Show("Il prezzo deve essere un numero.", "Autosalone Nico");
            }
        }
    }
}