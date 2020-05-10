#region Riferimenti

//Interni
using System;

//Esterni

#endregion Riferimenti

namespace veicoliDLLProject
{
    [Serializable()]

    public class Automobili : Veicolo
    {
        #region PrivateVariablesOfAutomobili

        private int numAirbag; //Indica il numero di airbag presenti nel veicolo

        #endregion PrivateVariablesOfAutomobili

        /// <summary>
        /// Usato solamente per creare dati di test, i dati sono statici.
        /// </summary>
        public Automobili() : base("", "Mercedes", "GLX", "Nero", 2100, 175.20, DateTime.Now, false, false, 0, 1235489, @".\img/noPhoto.jpg")
        {
            NumAirbag = 6;
        }

        /// <summary>
        /// Costruttore "vero" della classe Automobili, i parametri sono caricati dinamicamente.
        /// </summary>
        /// <param>Spiegati in Veicolo.cs</param>
        public Automobili(string targa, string marca, string modello, string colore, double cilindrata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, float kmPercorsi, int numAirbag, double prezzo, string imgPath = @".\img/genericAuto.jpg" /*Path dell'immagine, se omesso dalla dichiarazione si prende l'immagine generale*/)
            : base(targa, marca, modello, colore, cilindrata, potenzaKw, immatricolazione, isUsato, isKmZero, kmPercorsi, prezzo, imgPath)
        {
            this.NumAirbag = numAirbag;
        }

        #region PropertyOfAutomobili
        /*
         * Property delle Automobili
         */

        public int NumAirbag
        {
            get => numAirbag;
            set => numAirbag = value;
        }

        #endregion PropertyOfMoto

        #region OverrideOfAutomobili

        /// <summary>
        /// Override funzione .ToString();
        /// </summary>
        /// <returns>Base + variabili selezionate e univoche delle automobili</returns>
        public override string ToString()
        {
            return $"Auto: {base.ToString()} - {this.NumAirbag} Airbag";
        }

        #endregion OverrideOfAutomobili
    }
}