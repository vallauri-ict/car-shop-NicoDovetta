#region Riferimenti

//Interni
using System;

//Esterni

#endregion Riferimenti

namespace veicoliDLLProject
{
    [Serializable()]

    public abstract class Veicolo
    {
        #region CommonVariables
        private string marca; //Marca del veicolo.
        private string modello; //Modello del veicolo.
        private string colore; //Colore del veicolo.
        private int cilindrata; //Cilindrata del veicolo.
        private double potenzaKw; //Potenza espressa in Kw del veicolo.
        private DateTime immatricolazione; //Data di immatricolazione del veicolo.
        private bool isUsato; //True se il veicolo è usato, False se il veicolo è nuovo.
        private bool isKmZero; //True se il veicolo è Km0, False se è nuovo/usato.
        private int kmPercorsi; //KmPercorsi se il veicolo non è nuovo indica il numero di kilometri che ha percorso.
        private string imgPath = ""; //Se al veicolo si vuole aggiungere un'immagine singola e rappresentativa la si seleziona, altrimenti si aggiungerà un'immagine standard per ogni categoria di veicoli
        #endregion

        /// <summary>
        /// Costruttore base della classe Veicolo, implementato in tutte le classi derivate come ":base()" dopo la dichiarazione dei parametri del costruttore.
        /// </summary>
        /// <param>Spiegati nella dichiarazione delle variabili</param>
        protected Veicolo(string marca, string modello, string colore, int cilindrata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi, string imgPath)
        {
            this.Marca = marca;
            this.Modello = modello;
            this.Colore = colore;
            this.Cilindrata = cilindrata;
            this.PotenzaKw = potenzaKw;
            this.Immatricolazione = immatricolazione;
            this.IsUsato = isUsato;
            this.IsKmZero = isKmZero;
            this.KmPercorsi = kmPercorsi;
            this.ImgPath = imgPath;
        }

        #region CommonProperty
        /*
         * Elenco delle proprietà delle variabili elencate nella region/sezione Variables (riga 10)
         */

        public string Marca
        {
            get => marca.ToUpper();
            set => marca = value;
        }

        public string Modello
        {
            get => modello;
            set => modello = value;
        }

        public string Colore
        {
            get => colore;
            set => colore = value;
        }

        public int Cilindrata
        {
            get => cilindrata;
            set => cilindrata = value;
        }

        public double PotenzaKw
        {
            get => potenzaKw;
            set => potenzaKw = value;
        }

        public DateTime Immatricolazione
        {
            get => immatricolazione;
            set => immatricolazione = value;
        }

        public bool IsUsato
        {
            get => isUsato;
            set => isUsato = value;
        }

        public bool IsKmZero
        {
            get => isKmZero;
            set => isKmZero = value;
        }

        public int KmPercorsi
        {
            get => kmPercorsi;
            set => kmPercorsi = value;
        }

        public string ImgPath
        {
            get => imgPath;
            set => imgPath = value;
        }

        #endregion

        #region CommonOverride
        /// <summary>
        /// Ritorna solo alcune variabili specifiche della classe GENERICA veicolo
        /// </summary>
        /// <returns>Serializza le variabili preselezionate in una stringa per l'output</returns>
        public override string ToString()
        {
            return $"{this.Marca} {this.Modello} ({this.Immatricolazione.Year})";
        }
        #endregion 
    }
}