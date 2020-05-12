#region Riferimenti

//Interni
using System;

//Esterni

#endregion Riferimenti

namespace veicoliDLLProject
{
    [Serializable()]

    public class Moto : Veicolo
    {
        #region PrivateVariablesofAutomobili

        private string marcaSella; //Marca della sella della moto.

        #endregion PrivateVariablesofAutomobili

        /// <summary>
        /// Crea dati di test, parametri assegnati staticamente.
        /// </summary>
        public Moto() : base("", "Ducati", "Squalo", "Nero", 1000, 75.20, DateTime.Now, false, false, 0, 12358, @".\img/noPhoto.jpg")
        {
            this.MarcaSella = "Cavallino";
        }

        /// <summary>
        /// Costruttore "vero" della classe Moto, i parametri sono assegnati dinamicamente.
        /// </summary>
        /// <param>Spiegati in Veicolo.cs</param>
        public Moto(string targa, string marca, string modello, string colore, double cilindrata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, float kmPercorsi, string marcaSella, double prezzo, string imgPath = @".\img/genericMoto.jpg" /*Path dell'immagine, se omesso dalla dichiarazione si prende l'immagine generale*/)
            : base(targa, marca, modello, colore, cilindrata, potenzaKw, immatricolazione, isUsato, isKmZero, kmPercorsi, prezzo, imgPath)
        {
            this.MarcaSella = marcaSella;
        }

        #region PropertyOfMoto
        /*
         * Elenco delle proprietà dei campi privati e univoci delle moto.
         */

        public string MarcaSella
        {
            get => marcaSella;
            set => marcaSella = value;
        }

        #endregion PrivatePropertyOfMoto

        #region Override

        /// <summary>
        /// Override della function .ToString();
        /// </summary>
        /// <returns>La stringa base + alcune variabili private e univocehe di Moto</returns>
        public override string ToString()
        {
            return $"{this.Targa}£{this.Marca}£{this.Modello}£{this.Colore}£{this.Cilindrata.ToString()}£{this.PotenzaKw.ToString()}£{this.Immatricolazione.ToShortDateString()}£{(this.IsUsato ? "Sì" : "No")}£{(this.IsKmZero ? "Sì" : "No")}£{this.KmPercorsi}£{this.MarcaSella}£€ {this.Prezzo}";
        }

        #endregion Override
    }
}