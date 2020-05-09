#region Riferimenti
//Interni
using System;
using System.ComponentModel;
using veicoliDLLProject;
using DatabaseInstruction;

//Esterni

#endregion Riferimenti

namespace ConsoleAppProject
{
    class Program
    {
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

        static void Main(string[] args)
        {
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
                    UtilsDb.createTableCars();
                    break;
                case '2':
                    UtilsDb.createTableMoto();
                    break;
                case '3':
                    UtilsDb.createTableReport();
                    break;
                default:
                    {
                        Console.WriteLine("\nRitorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }

        private static void aggiungiVeicolo()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Aggiunta veicolo";
            Console.Write("Premere:\n1 - Aggiungere una macchina;\n2 - Aggiungere una moto;\nQualsiasi altro tasto per tornare al menù principale.\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    {
                        Console.WriteLine("Inserisci i valori dei campi separati da uno spazio.\n Lista dei campi:");
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(string) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) NumAirbag(int) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split(' ');
                        UtilsDb.addNewVeicol(param, "Automobili");
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Inserisci i valori dei campi separati da uno spazio.\n Lista dei campi:");
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(string) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) MarcaSella(string) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split(' ');
                        UtilsDb.addNewVeicol(param, "Moto");
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

        private static void listaTabella()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Lista record tabella";
            Console.WriteLine("Premere:\n1 - Lista delle macchine;\n2 - Lista delle moto;3 - Lista report di vendita;\nQualsiasi altro tasto per tornare al menù principale.\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    UtilsDb.listMacchine();
                    break;
                case '2':
                    UtilsDb.listMoto();
                    break;
                case '3':
                    UtilsDb.listReport();
                    break;
                default:
                    {
                        Console.WriteLine("\nRitorno al menù principale.");
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
            }
        }

        private static void cancellaTabella()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestionale database - Cancellazione tabella";
            Console.WriteLine("1 - Cancellazione tabella \"Automobili\";\n2 - Cancellazione tabella \"Moto\";\n3 - Cancellazione tabella \"Report_Vendite\";\nQualsiasi altro tasto per tornare al menù principale;\nSelezione: ");
            s = Console.ReadKey().KeyChar;
            switch (s)
            {
                case '1':
                    UtilsDb.dropAutomobili();
                    break;
                case '2':
                    UtilsDb.dropMoto();
                    break;
                case '3':
                    UtilsDb.dropReport();
                    break;
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