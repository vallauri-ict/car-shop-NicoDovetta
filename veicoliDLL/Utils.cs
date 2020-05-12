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
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
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
                    if (item is Automobili)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[dgv.RowCount - 1].Cells[0].Value = item.Targa;
                        dgv.Rows[dgv.RowCount - 1].Cells[1].Value = item.Marca;
                        dgv.Rows[dgv.RowCount - 1].Cells[2].Value = item.Modello;
                        dgv.Rows[dgv.RowCount - 1].Cells[3].Value = item.Colore;
                        dgv.Rows[dgv.RowCount - 1].Cells[4].Value = item.Cilindrata.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[5].Value = item.PotenzaKw.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[6].Value = item.Immatricolazione.ToString("####/##/##");
                        dgv.Rows[dgv.RowCount - 1].Cells[7].Value = (item.IsUsato ? "Sì" : "No");
                        dgv.Rows[dgv.RowCount - 1].Cells[8].Value = (item.IsKmZero ? "Sì" : "No");
                        dgv.Rows[dgv.RowCount - 1].Cells[9].Value = item.KmPercorsi.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[10].Value = (item as Automobili).NumAirbag.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[11].Value = $"€ {item.Prezzo.ToString()}";
                    }
                }
                else
                {
                    if (item is Moto)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[dgv.RowCount - 1].Cells[0].Value = item.Targa;
                        dgv.Rows[dgv.RowCount - 1].Cells[1].Value = item.Marca;
                        dgv.Rows[dgv.RowCount - 1].Cells[2].Value = item.Modello;
                        dgv.Rows[dgv.RowCount - 1].Cells[3].Value = item.Colore;
                        dgv.Rows[dgv.RowCount - 1].Cells[4].Value = item.Cilindrata.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[5].Value = item.PotenzaKw.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[6].Value = item.Immatricolazione.ToString("####/##/##");
                        dgv.Rows[dgv.RowCount - 1].Cells[7].Value = (item.IsUsato ? "Sì" : "No");
                        dgv.Rows[dgv.RowCount - 1].Cells[8].Value = (item.IsKmZero ? "Sì" : "No");
                        dgv.Rows[dgv.RowCount - 1].Cells[9].Value = item.KmPercorsi.ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[10].Value = (item as Moto).MarcaSella;
                        dgv.Rows[dgv.RowCount - 1].Cells[11].Value = $"€ {item.Prezzo.ToString()}";
                    }
                }
            }
        }

        /// <summary>
        /// Imposta l'intestazione delle colonne per la visualizzazione dei dati.
        /// </summary>
        /// <param name="dgv">Elemento della form dove carico i dati.</param>
        /// <param name="visual">Campo che mi indica quali veicoli devo caricare.</param>
        private static void settaDgv(DataGridView dgv, int visual)
        {
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
                if (item.Targa.Contains("exp"))
                {
                    int aus = Convert.ToInt32(item.Targa.Substring(2));
                    if (aus > numTarga)
                    {
                        numTarga = aus;
                    }
                }
            }
            return $"exp{numTarga + 1}";
        }

        /// <summary>
        /// Crea e avvia, con il browser predefinito, una pagina HTML con tutti i veicoli e alcune variabili; pronto per l'esportazione.
        /// </summary>
        /// <param name="listaVeicoli">Source dei veicoli</param>
        /// <param name="pathName">Path destinazione di "index.html"</param>
        /// <param name="skeletonPathName">Path del modello html</param>
        public static void createHtml(BindingList<Veicolo> listaVeicoli, string pathName, string skeletonPathName = @".\www\pagine\index-skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName), nuovo = "", usato = "";
            html = html.Replace("({head-title})", "AUTOSALONE NICO");
            html = html.Replace("({body-title})", "AUTOSALONE NICO - VEICOLI NUOVI E USATI");
            html = html.Replace("({body-subtitle})", "Le migliori occasioni al miglior prezzo");
            foreach (Veicolo item in listaVeicoli)
            {
                if (!item.IsUsato)
                {
                    nuovo += $"<div style='background-image:url({item.ImgPath});'></div>";
                }
            }
            html = html.Replace("c#_automatic_substitution;", (nuovo + usato));
            File.WriteAllText(pathName, html);
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
    }
}