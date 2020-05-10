#region Riferimenti
//Interni
using System;
using System.IO;
using veicoliDLLProject;
using DatabaseInstruction;

//Esterni

#endregion Riferimenti

namespace ConsoleAppProject
{
    class Program
    {
        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources";
        private static string accessDbPath = Path.Combine(resourcesDirectoryPath, CLI_Database.Properties.Resources.DB_Name);
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0;Data Source={accessDbPath};";
        private static UtilsDb u;

        /// <summary>
        /// Scrive il menù principale a video
        /// </summary>
        private static void menu()
        {
            Console.Clear();
            Console.Title = "SALONE VENDITA VEICOLI NUOVI E USATI - Gestionale database";
            Console.WriteLine("1 - CREATE TABLE;");
            Console.WriteLine("2 - ADD NEW ITEM;");
            Console.WriteLine("3 - LIST;");
            Console.WriteLine("4 - (not written yet);");
            Console.WriteLine("5 - (not written yet);");
            Console.WriteLine("D - DROPTABLE;");
            Console.WriteLine("\nX - FINE LAVORO\n\n");
        }

        /// <summary>
        /// Stampa il menù delle opzioni e si occupa di smistare al sottoprogramma competente a seconda della scelta.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            u = new UtilsDb(connStr);
            char scelta;
            do
            {
                menu();
                Console.Write("La tua selezione: ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        creaTabelle();
                        break;
                    case '2':
                        aggiungiVeicolo();
                        break;
                    case '3':
                        listaTabella();
                        break;
                    case 'd':
                        cancellaTabella();
                        break;
                    default:
                        break;
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }

        /// <summary>
        /// Si interfaccia con la DLL per la gestione del database e richiama i metodi per creare le tabelle.
        /// </summary>
        private static void creaTabelle()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Creazione tabelle";
            Console.WriteLine("Quale tabella vuioi creare?");
            Console.Write("1 - Automobili;\n2 - Moto;\n3 - Report_Vendite;\nQualsiasi altro tasto per tornare al menù principale.\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    u.createTableCars();
                    break;
                case '2':
                    u.createTableMoto();
                    break;
                case '3':
                    u.createTableReport();
                    break;
                case '4':
                    {
                        u.createTableCars();
                        u.createTableMoto();
                        u.createTableReport();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nRitorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }

        /// <summary>
        /// Si interfaccia con la DLL per la gestione del database e richiama i metodi per aggingere oggetti alle tabelle "Moto" o "Automobili".
        /// </summary>
        private static void aggiungiVeicolo()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Aggiunta veicolo";
            Console.Write("Premere:\n1 - Aggiungere una macchina;\n2 - Aggiungere una moto;\nQualsiasi altro tasto per tornare al menù principale.\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (s)
            {
                case '1':
                    {
                        Console.WriteLine("Inserisci i valori dei campi separati da uno spazio.\n Lista dei campi:");
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(string) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) NumAirbag(int) Prezzo(double) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split(' ');
                        Automobili a;
                        try
                        {
                            float f;
                            float.TryParse(param[9], out f);
                            if (param.Length > 12 && param[12] != "" && param[12] != " ")
                            {
                                a = new Automobili(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, Convert.ToInt32(param[10]), Convert.ToDouble(param[11]), param[12]);
                            }
                            else
                            {
                                a = new Automobili(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, Convert.ToInt32(param[10]), Convert.ToDouble(param[11]));
                            }
                            u.addNewVeicol(a);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString());
                            System.Threading.Thread.Sleep(3000);
                            return;
                        }
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Inserisci i valori dei campi separati da uno spazio.\n Lista dei campi:");
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(string) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) MarcaSella(string) Prezzo(double) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split(' ');
                        try
                        {
                            float f;
                            float.TryParse(param[9], out f);
                            Moto m;
                            if (param.Length > 12 && param[12] != "" && param[12] != " ")
                            {
                                m = new Moto(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, param[10], Convert.ToDouble(param[11]), param[12]);
                            }
                            else
                            {
                                m = new Moto(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, param[10], Convert.ToDouble(param[11]));
                            }
                            u.addNewVeicol(m);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString());
                            System.Threading.Thread.Sleep(3000);
                            return;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nRitorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }

        /// <summary>
        /// Si interfaccia con la DLL per la gestione del database e richiama i metodi per listare le tabelle.
        /// </summary>
        private static void listaTabella()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Lista record tabella";
            Console.Write("Premere:\n1 - Lista delle macchine;\n2 - Lista delle moto;\n3 - Lista report di vendita;\n4 - Lista tutte le tabelle;\nQualsiasi altro tasto per tornare al menù principale.\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    u.listMacchine();
                    break;
                case '2':
                    u.listMoto();
                    break;
                case '3':
                    u.listReport();
                    break;
                case '4':
                    {
                        u.listMacchine();
                        u.listMoto();
                        u.listReport();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nRitorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }

        /// <summary>
        /// Si interfaccia con la DLL per la gestione del database e richiama i metodi per cancellare le tabelle.
        /// </summary>
        private static void cancellaTabella()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Cancellazione tabella";
            Console.Write("1 - Cancellazione tabella \"Automobili\";\n2 - Cancellazione tabella \"Moto\";\n3 - Cancellazione tabella \"Report_Vendite\";\n4 - Cancella tutte le tabelle;\nQualsiasi altro tasto per tornare al menù principale;\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    u.dropAutomobili();
                    break;
                case '2':
                    u.dropMoto();
                    break;
                case '3':
                    u.dropReport();
                    break;
                case '4':
                    {
                        u.dropAutomobili();
                        u.dropMoto();
                        u.dropReport();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nSelezione non valida, ritorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }
    }
}