#region Riferimenti
//Interni
using System;
using System.Windows.Forms;
using veicoliDLLProject;
using System.IO;
using System.Diagnostics;
using DatabaseInstruction;

//Esterni

#endregion Riferimenti

namespace WindowsFormsAppProject
{
    public partial class Main : Form
    {
        #region dbPathSetting

        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, Properties.Resources.DB_Name);//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0;Data Source={DbPath};";//Stringa di connessione completa al database access.

        #endregion dbPathSetting

        #region globalVariables

        UtilsDb dbManager;//Evita che 2 o più persone modifichino contemporaneamente il database.
        SerialBindList<Veicolo> listaVeicoli = new SerialBindList<Veicolo>();//Contiene la lista dei veicoli.

        #endregion globalVariables

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento generato automaticamente prima dell'apertura della form. Se esiste un file del salvataggio vado a prenderlo e lo apro.
        /// Se non esiste chiedo se vuole caricare dei dati di test, se non vuole (apre la form senza dati) o se vuole cancellare l'operazione (chiude la form).
        /// Carica la prima schermata di visualizzazione, includento i veicoli più recenti.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists(DbPath))
            {
                dbManager = new UtilsDb(connStr);
                dbManager.GetVeicolList(ref listaVeicoli);
            }
            else
            {
                MessageBox.Show("Impossibile trovare il database. Contattare l'amministratore.", "Autosalone Nico");
            }
            if (listaVeicoli.Count < 0)
            {
                Utils.loadData(listaVeicoli);
                Utils.visualNew(this, listaVeicoli);
            }
        }

        /// <summary>
        /// Apre una form dove è possibile definire le caratteristiche del nuovo veicolo.
        /// Al termine si preme su aggiungi e il veicolo comparirà nella visualizzazione grafica.
        /// </summary>
        private void AddNuovoVeicoloTSB_Click(object sender, EventArgs e)
        {
            AddNewVeicolo frm = new AddNewVeicolo(listaVeicoli);
            frm.ShowDialog();
        }

        /// <summary>
        /// Dopo aver aggiunto o tolti veicoli, alla pressione dell'apposito tasto o alla chiusura del programma i dati presenti nella lista.
        /// verranno salvati in un file json.
        /// </summary>
        private void SalvaTSB_Click(object sender, EventArgs e)
        {
            Utils.serializeToJson(listaVeicoli, @".\Veicoli.json");
        }

        /// <summary>
        /// Se non compaiono i dati che si vogliono visualizzare si va a selezionarli manualmente.
        /// </summary>
        private void ApriTSB_Click(object sender, EventArgs e)
        {
            Utils.parseJsonToObject(@".\Veicoli.json", listaVeicoli);
        }

        /// <summary>
        /// Crea un documento HTML di preview che potrà poi essere esportato su un server.
        /// </summary>
        private void StampaHtmlTSB_Click(object sender, EventArgs e)
        {
            if (listaVeicoli.Count > 0)
            {
                //string homepagePath = @".\www\pagine\index.html";
                Utils.createHtml(listaVeicoli, @".\www\pagine\index.html");
                Process.Start(@".\www\pagine\index.html");
            }
            else
            {
                MessageBox.Show("Devi inserire almeno un veicolo per procedere con questa operazione.", "Autosalone Nico");
            }
        }

        /// <summary>
        /// Evento automatico di windows form.
        /// A ogni chiusura del programma effettua un salvataggio dei dati, in maniera che si tengano sempre aggiornati alla versione più recente.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.serializeToJson(listaVeicoli, @".\Veicoli.json");
        }
    }
}
