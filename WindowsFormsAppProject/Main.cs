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
        #region resourcePathSetting

        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, Properties.Resources.DB_Name);//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0;Data Source={DbPath};";//Stringa di connessione completa al database access.

        private static string backupDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi\\Backup";//Percorso della cartella "resources".
        private static string jsonSave = Path.Combine(backupDirectoryPath, Properties.Resources.JSON_Save);//Percorso del file contenente il dsalvataggio in formato json.

        private static string sitoDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\www";//Percorso della cartella "resources".
        private static string indexPath = Path.Combine(sitoDirectoryPath, Properties.Resources.Sito);//Percorso del file contenente il database.

        #endregion resourcePathSetting

        #region globalVariables

        UtilsDb dbManagement;//Evita che 2 o più persone modifichino contemporaneamente il database.
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
                dbManagement = new UtilsDb(connStr);
                if (dbManagement.PresTabella("Automobili"))
                {
                    dbManagement.GetVeicolListAuto(ref listaVeicoli);
                }
                if (dbManagement.PresTabella("Moto"))
                {
                    dbManagement.GetVeicolListMoto(ref listaVeicoli);
                }
                /*
                 * Il cambio della proprietà SelectedIndex, anche da codice, genera un'evento automatico.
                 */
                cmbVisual.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Impossibile trovare il database, caricamento dei dati dal salvataggio di backup. Contattare l'amministratore del database.", "Autosalone Nico");
                Utils.loadData(listaVeicoli);
                cmbVisual.SelectedIndex = 0;
            }
            if (!(listaVeicoli.Count > 0))
            {
                Utils.loadData(listaVeicoli);
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
            Utils.visualNew(dgvVisual, listaVeicoli, cmbVisual.SelectedIndex);
        }

        /// <summary>
        /// Dopo aver aggiunto o tolti veicoli, alla pressione dell'apposito tasto o alla chiusura del programma i dati presenti nella lista
        /// verranno salvati in un file json.
        /// </summary>
        private void SalvaTSB_Click(object sender, EventArgs e)
        {
            salva();
        }

        /// <summary>
        /// Si occupa di creare il file in json e di caricare i dati sul database. Nel caso riscontrasse un errore i dati ci sono ancora sul file in json.
        /// </summary>
        private void salva()
        {
            Utils.serializeToJson(listaVeicoli, jsonSave);
            if (File.Exists(DbPath))
            {
                dbManagement.DropAutomobili();
                dbManagement.DropMoto();
                dbManagement.CreateTableCars();
                dbManagement.CreateTableMoto();
            }
            try
            {
                foreach (Veicolo item in listaVeicoli)
                {
                    dbManagement.AddNewVeicol(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossibile salvare i dati sul database, contattare l'amministratore del database.");
            }
        }

        /// <summary>
        /// Crea un documento HTML di preview che potrà poi essere esportato su un server.
        /// </summary>
        private void StampaHtmlTSB_Click(object sender, EventArgs e)
        {
            if (listaVeicoli.Count > 0)
            {
                //string homepagePath = @".\www\pagine\index.html";
                Utils.createHtml(listaVeicoli, indexPath);
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
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            salva();
        }

        /// <summary>
        /// Evento generato automaticamente sul cambio della proprietà SelectedIndex della combobox cmbVisual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVisual_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVisual.SelectedIndex != 2)
            {
                rtbReport.Visible = false;
                dgvVisual.Visible = true;
                Utils.visualNew(dgvVisual, listaVeicoli, cmbVisual.SelectedIndex);
            }
            else
            {
                SerialBindList<Veicolo> listReport = new SerialBindList<Veicolo>();
                try
                {
                    dbManagement.GetVeicolListReport(ref listReport);
                    if (listReport.Count > 0)
                    {
                        rtbReport.Visible = true;
                        dgvVisual.Visible = false;
                        foreach (Veicolo item in listReport)
                        {
                            rtbReport.Text = $"{(item is Moto ? "Moto" : "Automobile")}: {item.ToString().Replace("£", " ")}";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Non ci sono report da visualizzare.","Autosalone Nico");
                        cmbVisual.SelectedIndex = 0;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Impossibile accedere ai report delle vendite. Contattare l'amministratore del database.", "Autosalone Nico");
                    cmbVisual.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Richiama la form per la visualizzazione dettagliata del veicolo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVisual_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVisual.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    string targa = dgvVisual.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Veicolo v = new Automobili();
                    foreach (Veicolo item in listaVeicoli)
                    {
                        if (item.Targa == targa)
                        {
                            v = item;
                        }
                    }
                    if (v.Targa == targa)
                    {
                        VisualizzaModifica frm = new VisualizzaModifica(v, ref listaVeicoli);
                        frm.ShowDialog();
                        Utils.visualNew(dgvVisual, listaVeicoli, cmbVisual.SelectedIndex);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossibile effettuare la visualizzazione di questo elemento.", "Autosalone Nico");
            }
        }
    }
}