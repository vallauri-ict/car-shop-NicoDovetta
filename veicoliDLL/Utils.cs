#region Riferimenti
//Interni
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// Crea dei dati statici per effettuare un test delle funzionalità.
        /// Aggiornato: 14/12/2019.
        /// </summary>
        /// <where>Main riga:35</where>
        public static void caricaDatiDiTest(SerialBindList<Veicolo> listaVeicoli)
        {
            Moto m = new Moto();
            listaVeicoli.Add(m);
            m = new Moto("Honda", "Tsunami", "Rosso", 1000, 120, DateTime.Now, false, false, 0, "Quintino");
            listaVeicoli.Add(m);
            Automobili a = new Automobili("Jeep", "Compass", "Blue", 1600, 90, DateTime.Now, false, false, 0, 8);
            listaVeicoli.Add(a);
        }

        /// <summary>
        /// Controlla che si sia un file con i dati dei veicoli. In caso non ci sia può creare un file con dati di test, annullare e quindi chiudere l'applicazione o
        /// caricare il progetto senza dati.
        /// </summary>
        /// <param name="listaVeicoli">Contiene/Conterrà i dati presenti nel file Veicoli.json</param>
        public static void loadData(SerialBindList<Veicolo> listaVeicoli)
        {
            if (File.Exists(@".\Veicoli.json"))
            {
                apriSalvataggi(listaVeicoli, @".\Veicoli.json");
            }
            else
            {
                DialogResult result = MessageBox.Show("Carcare dati di test?", "Autosalone Vallauti", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        /// Da un file orignie ".json", carico la lista con i dati presenti nel file
        /// </summary>
        /// <param name="listaVeicoli">Lista di destinazione degi oggetti del file ".json"</param>
        /// <param name="path">Path di provenienza del file ".json"</param>
        public static void apriSalvataggi(SerialBindList<Veicolo> listaVeicoli, string path)
        {
            listaVeicoli.Clear();
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
        /// <param name="objectlist">Lista source</param>
        /// <param name="pathName">Indirizzo di destinazione del file ".json"</param>
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

        public static void visualNew(Form Main, BindingList<Veicolo> lstVeicoli)
        {
            orderListbyImmatricolazione(lstVeicoli);
        }

        private static void orderListbyImmatricolazione(BindingList<Veicolo> lstVeicoli)
        {
            for (int i = 0; i < lstVeicoli.Count; i++)
            {
                int posmin = i;
                for (int j = i + 1; j < lstVeicoli.Count; j++)
                {
                    if (lstVeicoli[posmin].Immatricolazione < lstVeicoli[j].Immatricolazione)
                    {
                        posmin = j;
                    }
                }
                if (posmin != i)
                {
                    
                }
            }
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
            html = html.Replace("({head-title})", "AUTOVALLAURI");
            html = html.Replace("({body-title})", "SALONE AUTOVALLAURI - VEICOLI NUOVI E USATI");
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
    }
}