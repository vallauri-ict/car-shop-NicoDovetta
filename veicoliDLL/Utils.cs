#region Riferimenti
//Interni
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//Esterni
//Per la conversione in json e viceversa
using Newtonsoft.Json;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing.Charts;

#endregion Riferimenti

namespace veicoliDLLProject
{
    [Serializable]

    public class SerialBindList<T> : BindingList<T> { }

    public class Utils
    {
        #region pathVariables

        private static string backupDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi\\Backup";//Percorso della cartella "resources".
        private static string jsonSave = Path.Combine(backupDirectoryPath, Properties.Resources.JSON_Save);//Percorso del file contenente il dsalvataggio in formato json.
        private static string imgDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\img";//Percorso della cartella "resources".
        private static string noImgPath = Path.Combine(imgDirectoryPath, Properties.Resources.NO_Img);//Percorso del file contenente il database.

		#endregion pathVariables

		#region salvataggi

		/// <summary>
		/// Crea dei dati statici per effettuare un test delle funzionalità.
		/// Aggiornato: 14/12/2019.
		/// </summary>
		/// <where>Main riga:35</where>
		public static void caricaDatiDiTest(SerialBindList<Veicolo> listaVeicoli)
        {
            Moto m = new Moto("exp0", "Honda", "Tsunami", "Rosso", 1000, 120, DateTime.Now, false, false, 0, "Quintino", 1035);
            listaVeicoli.Add(m);
            Automobili a = new Automobili("exp1", "Jeep", "Compass", "Blue", 1600, 90, DateTime.Now, false, false, 0, 8, 1235);
            listaVeicoli.Add(a);
        }

        /// <summary>
        /// Controlla che si sia un file con i dati dei veicoli. In caso non ci sia può creare un file con dati di test, annullare e quindi chiudere l'applicazione o
        /// caricare il progetto senza dati.
        /// </summary>
        /// <param name="listaVeicoli">Contiene/Conterrà i dati presenti nel file Veicoli.json</param>
        public static void loadData(SerialBindList<Veicolo> listaVeicoli)
        {
            if (File.Exists(jsonSave))
            {
                DialogResult result = MessageBox.Show("Nessun dato all'interno del database. Caricare salvataggio di backup?", "Autosalone Nico", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        apriSalvataggi(listaVeicoli, jsonSave);
                        break;
                    default:
                        break;
                }
            }
            /*
            else
            {
                DialogResult result = MessageBox.Show("Carcare dati di test?", "Autosalone Nico", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Cancel:
                        Application.Exit();
                        break;
                    case DialogResult.Yes:
                        caricaDatiDiTest(listaVeicoli);
                        break;
                    default:
                        break;
                }
            }
            */
        }

        /// <summary>
        /// Da un file orignie ".json", carico la lista con i dati presenti nel file.
        /// </summary>
        /// <param name="listaVeicoli">Lista di destinazione degi oggetti del file ".json".</param>
        /// <param name="path">Path di provenienza del file ".json".</param>
        public static void apriSalvataggi(SerialBindList<Veicolo> listaVeicoli, string path)
        {
            string json = File.ReadAllText(path);
            object[] veicoli = JsonConvert.DeserializeObject<object[]>(json);
            for (int i = 0; i < veicoli.Length; i++)
            {
                Moto moto = new Moto();
                Automobili auto = new Automobili();
                string veicolo = veicoli[i].ToString();
                if (veicolo.Contains("MarcaSella"))
                {
                    JsonConvert.PopulateObject(veicolo, moto);
                    listaVeicoli.Add(moto);
                }
                else
                {
                    JsonConvert.PopulateObject(veicolo, auto);
                    listaVeicoli.Add(auto);
                }
            }
        }

        #endregion salvataggi

        #region formatojson

        /// <summary>
        /// Con qualunque tipo crea un file di estensione ".json" con tutte le variabili. Se usato più volte, con lo stesso path, sovrascrive il file.
        /// </summary>
        /// <typeparam name="T">
        /// *** Tipo Generico ***
        /// Accetta qualunque oggetto di qualuncque tipo.
        /// </typeparam>
        /// <param name="objectlist">Lista source.</param>
        /// <param name="pathName">Indirizzo di destinazione del file ".json".</param>
        public static void serializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(pathName, json);
        }

        public static void parseJsonToObject(string pathName, SerialBindList<Veicolo> objectlist)
        {
            string json = File.ReadAllText(pathName);

            object[] veicoli = JsonConvert.DeserializeObject<object[]>(json);
            for (int i = 0; i < veicoli.Length; i++)
            {
                Moto moto = new Moto();
                Automobili auto = new Automobili();
                string veicolo = veicoli[i].ToString();
                if (veicolo.Contains("MarcaSella"))
                {
                    JsonConvert.PopulateObject(veicolo, moto);
                    objectlist.Add(moto);
                }
                else
                {
                    JsonConvert.PopulateObject(veicolo, auto);
                    objectlist.Add(auto);
                }
            }
        }

		#endregion formatojson

		#region visualizza

		/// <summary>
		/// Richiamato tutte le volte che devo cambiare i veicoli all'interno della dgv.
		/// </summary>
		/// <param name="dgv">Elemento della form dove carico i dati.</param>
		/// <param name="listaVeicoli">Lista che contiene i veicoli.</param>
		/// <param name="visual">Campo che mi indica quale tipo di veicolo devo inserire nella form.</param>
		public static void visualNew(DataGridView dgv, SerialBindList<Veicolo> listaVeicoli, int visual)
        {
            settaDgv(dgv, visual);
            foreach (Veicolo item in listaVeicoli)
            {
                if (visual == 0)
                {
                    if ((item.GetType().ToString()).Contains("Automobili"))
                    {
                        dgv.Rows.Add(item.ToString().Split('£'));
                    }
                }
                else
                {
                    if ((item.GetType().ToString()).Contains("Moto"))
                    {
                        dgv.Rows.Add(item.ToString().Split('£'));
                    }
                }
            }
            dgv.ClearSelection();
        }

        /// <summary>
        /// Imposta l'intestazione delle colonne per la visualizzazione dei dati.
        /// </summary>
        /// <param name="dgv">Elemento della form dove carico i dati.</param>
        /// <param name="visual">Campo che mi indica quali veicoli devo caricare.</param>
        private static void settaDgv(DataGridView dgv, int visual)
        {
            //Cancella tutte le righe che contengono dati della vecchia visualizzazione.
            dgv.Rows.Clear();
            //Per evitare di avere delle grandezze diverse.
            dgv.Columns.Clear();

            dgv.ColumnCount = 12;
            dgv.Columns[0].HeaderText = "Targa";
            dgv.Columns[1].HeaderText = "Marca";
            dgv.Columns[2].HeaderText = "Modello";
            dgv.Columns[3].HeaderText = "Colore";
            dgv.Columns[4].HeaderText = "Cilindrata";
            dgv.Columns[5].HeaderText = "Potenza";
            dgv.Columns[6].HeaderText = "Immatricolazione";
            dgv.Columns[7].HeaderText = "Usato?";
            dgv.Columns[8].HeaderText = "Km Zero?";
            dgv.Columns[9].HeaderText = "Km Percorsi";
            if (visual == 0)
            {
                dgv.Columns[10].HeaderText = "Numero Airbag";
            }
            else
            {
                dgv.Columns[10].HeaderText = "Marca sella";
            }
            dgv.Columns[11].HeaderText = "Prezzo";
            dgv.RowHeadersVisible = false;
            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ClearSelection();
        }

		#endregion visualizza

		#region controlloTarga

		/// <summary>
		/// Crea una targa che possa funzionare da id e non vada in errore
		/// </summary>
		/// <param name="listaVeicoli">Per selezionare l'ultima targa "non immatricolata"</param>
		/// <returns></returns>
		public static string makeTarga(SerialBindList<Veicolo> listaVeicoli)
        {
            int numTarga = 0;
            foreach (Veicolo item in listaVeicoli)
            {
                if (item.Targa.Contains("EXP"))
                {
                    int aus = Convert.ToInt32(item.Targa.Substring(3));
                    if (aus > numTarga)
                    {
                        numTarga = aus;
                    }
                }
            }
            return $"EXP{numTarga + 1}";
        }

        /// <summary>
        /// Tramite una regular expression controlla la targa
        /// </summary>
        /// <returns>True se la targa va bene, false se la targa non è accettabile.</returns>
        public static bool checkTarga(ref string targa, SerialBindList<Veicolo> listaVeicoli)
        {
            Regex rgx = new Regex(@"[A - Za - z]{ 2}[0-9]{3}[A-Za-z]{2}");
            if (targa == "")
            {
                targa = makeTarga(listaVeicoli);
                return true;
            }
            else if (rgx.IsMatch(targa))
            {
                foreach (Veicolo v in listaVeicoli)
                {
                    if (v.Targa == targa.ToUpper())
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion controlloTarga

        /// <summary>
        /// Ci restirtuisce il percorso dove si vuole salvare il documento.
        /// </summary>
        /// <param name="fbd">Oggetto dei windows form che si occupa di trovare il path.</param>
        /// <returns>Ritorna il path dove vogliamo che sia salvato il documento</returns>
        public static string SelectPath(FolderBrowserDialog fbd)
        {
            string path = string.Empty;

            if (fbd.ShowDialog() == DialogResult.OK)
                path = fbd.SelectedPath;

            return path;
        }

        /// <summary>
        /// Combina il nome e il path del file, in maniera che si possa salvare.
        /// </summary>
        /// <param name="OutputFileDirectory">Directory preferenziale dove salvare il file.</param>
        /// <param name="fileExtension">Estensione del file.</param>
        /// <returns>Restituisce la directory dove si salva il file</returns>
        public static string OutputFileName(string OutputFileDirectory, string fileExtension)
        {
            var datetime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_");

            string fileFullname = Path.Combine(OutputFileDirectory, $"Fattura.{fileExtension}");

            if (File.Exists(fileFullname))
                fileFullname = Path.Combine(OutputFileDirectory, $"Fattura{datetime}.{fileExtension}");

            return fileFullname;
        }

        /// <summary>
        /// Genera un messaggio e poi avvia un documento o un'altro tipo di file.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="filepath"></param>
        public static void ProcedureCompleted(string msg, string filepath)
        {
            MessageBox.Show(msg, "Autosalone Nico");
            System.Diagnostics.Process.Start(filepath);
        }

        /// <summary>
        /// Aggiunge il testo al paragrafo.
        /// </summary>
        /// <param name="mainPart">Parte principale del documento.</param>
        /// <returns>Il paragrado con testo e stili.</returns>
        public static Paragraph WordPotentialTest(MainDocumentPart mainPart)
        {
            Paragraph p = WordUtilities.CreateParagraphWithStyle("Titolo1", JustificationValues.Center);

            WordUtilities.AddTextToParagraph(p, "Pellentesque ", SpaceProcessingModeValues.Preserve);

            RunProperties rpr = WordUtilities.AddStyle(mainPart, true, false, false, true);
            WordUtilities.AddTextToParagraph(p, "commodo ", SpaceProcessingModeValues.Preserve, rpr);

            WordUtilities.AddTextToParagraph(p, "rhoncus ", SpaceProcessingModeValues.Preserve);

            rpr = WordUtilities.AddStyle(mainPart, false, true, false, true);
            WordUtilities.AddTextToParagraph(p, "mauris ", SpaceProcessingModeValues.Preserve, rpr);


            rpr = WordUtilities.AddStyle(mainPart, true, true, true, true, "00", "Default", "Calibri", 12, "000000", UnderlineValues.WavyDouble);
            WordUtilities.AddTextToParagraph(p, "amet ", SpaceProcessingModeValues.Preserve, rpr);

            WordUtilities.AddTextToParagraph(p, "faucibus arcu ", SpaceProcessingModeValues.Preserve);

            rpr = WordUtilities.AddStyle(mainPart, false, false, false, true, "00", "Default", "Calibri", 12, "FF0000");
            WordUtilities.AddTextToParagraph(p, "porttitor ", SpaceProcessingModeValues.Preserve, rpr);

            WordUtilities.AddTextToParagraph(p, "pharetra. Maecenas quis erat quis eros iaculis placerat ut at mauris. ", SpaceProcessingModeValues.Preserve);

            return p;
        }

        /// <summary>
        /// Crea e avvia, con il browser predefinito, una pagina HTML con tutti i veicoli e alcune variabili; pronto per l'esportazione.
        /// </summary>
        /// <param name="listaVeicoli">Source dei veicoli</param>
        /// <param name="pathName">Path destinazione di "index.html"</param>
        /// <param name="skeletonPathName">Path del modello html</param>
        public static void createHtml(BindingList<Veicolo> listaVeicoli, string pathName)
        {
            string sitoDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\www";
            string indexPath = Path.Combine(sitoDirectoryPath, Properties.Resources.Sito);
            File.Copy(pathName, indexPath, true);
            string html = File.ReadAllText(pathName), nuovo = "", usato = "";
            html = html.Replace("({head-title})", "AUTOSALONE NICO");
            html = html.Replace("({body-title})", "AUTOSALONE NICO - VEICOLI NUOVI E USATI");
            html = html.Replace("({body-subtitle})", "Le migliori occasioni al miglior prezzo");
            foreach (Veicolo item in listaVeicoli)
            {
                if (!item.IsUsato)
                {
                    nuovo += $"<div><img src='img/noPhoto.jpg' class='rounded'/>Marca: {item.Marca}, Modello: {item.Modello}, NUOVO al przzo di soli: €{item.Prezzo}</div><br>";
                }
                else
                {
                    usato += $"<div><img src='img/noPhoto.jpg' class='rounded'/>Marca: {item.Marca}, Modello: {item.Modello}, USATO al prezzo di soli €{item.Prezzo}</div><br>";
                }
            }
            html = html.Replace("nuovo", nuovo);
            html = html.Replace("usato", usato);
            File.WriteAllText(indexPath, html);
            System.Diagnostics.Process.Start(indexPath);
        }
    }
}