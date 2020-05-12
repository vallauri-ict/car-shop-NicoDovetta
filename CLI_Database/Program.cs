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
        #region dbPathSetting

        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, CLI_Database.Properties.Resources.DB_Name);//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0;Data Source={DbPath};";//Stringa di connessione completa al database access.
        private static string jsonSave = Path.Combine($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi\\Backup", CLI_Database.Properties.Resources.JSON_Save);//Percorso del file contenente il dsalvataggio in formato json.

        #endregion dbPathSetting

        #region globalVariables

        private static UtilsDb u;//Oggetto definito dalla classe UtilsDb.cs per evitare di avere più modificatori contemporanei al database.
        private static bool doneAuto = false;//Controlla se bisogna caricare/ricaricare i veicoli all'interno della lista dei veicoli.
        private static bool doneMoto = false;//Controlla se bisogna caricare/ricaricare i veicoli all'interno della lista dei veicoli.
        private static SerialBindList<Veicolo> list = new SerialBindList<Veicolo>();//Lista dei veicoli.

        #endregion globalVariables

        /// <summary>
        /// Scrive il menù principale a video
        /// </summary>
        private static void menu()
        {
            Console.Clear();
            Console.Title = "SALONE VENDITA VEICOLI NUOVI E USATI - Gestionale database";
            if (File.Exists(DbPath))
            {
                /*
                    * Se bisogna ricaricare la lista dei veicoli lo si fa prima della creazione del menù.
                    * Lo si fa dopo l'aggiunta di un veicolo, la modifica di un veicolo.
                    */
                if (u.PresTabella("Automobili") && !doneAuto)
                {
                    u.GetVeicolListAuto(ref list);
                    doneAuto = true;
                }
                if (!doneMoto && u.PresTabella("Moto"))
                {
                    u.GetVeicolListMoto(ref list);
                    doneAuto = true;
                }
                Console.WriteLine("1 - CREATE TABLE;");
                Console.WriteLine("2 - ADD NEW ITEM;");
                Console.WriteLine("3 - LIST ALL;");
                Console.WriteLine("4 - MODIFICA VEICOLO;");
                Console.WriteLine("5 - DROP TABLE;");
                Console.WriteLine("B - CREA BACKUP;");
                Console.WriteLine("C - CREA DATABASE;");
                Console.WriteLine("D - DROP DATABASE;");
                Console.WriteLine("R - RECUPERA DATI DA JSON;");
            }
            else
            {
                Console.WriteLine("C - CREA DATABASE;");
                Console.WriteLine("B - CARICA BACKUP;");
            }
            Console.WriteLine("\nX - FINE LAVORO\n");
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
                if (File.Exists(DbPath))
                {
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
                        case '4':
                            modify();
                            break;
                        case '5':
                            cancellaTabella();
                            break;
                        case 'c':
                            creaDatabase();
                            break;
                        case 'd':
                            dropDatabase();
                            break;
                        case 'b':
                            creaBackup();
                            break;
                        case 'r':
                            prendiJson();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (scelta)
                    {
                        case 'c':
                            creaDatabase();
                            break;
                        case 'b':
                            caricaBckup();
                            break;
                        default:
                            break;
                    }
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }

        #region metodiPerEsecuzione

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
            Console.Clear();
            switch (s)
            {
                case '1':
                    u.CreateTableCars();
                    System.Threading.Thread.Sleep(2000);
                    break;
                case '2':
                    u.CreateTableMoto();
                    System.Threading.Thread.Sleep(2000);
                    break;
                case '3':
                    u.CreateTableReport();
                    System.Threading.Thread.Sleep(2000);
                    break;
                case '4':
                    {
                        u.CreateTableCars();
                        System.Threading.Thread.Sleep(2000);
                        u.CreateTableMoto();
                        System.Threading.Thread.Sleep(2000);
                        u.CreateTableReport();
                        System.Threading.Thread.Sleep(2000);
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
            Console.WriteLine("Inserisci i valori dei campi separati da un '\\'.\nLista dei campi:");
            switch (s)
            {
                case '1':
                    {
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(color) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) NumAirbag(int) Prezzo(double) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split('\\');
                        if (Utils.checkTarga(ref param[0], list))
                        {
                            Console.WriteLine("Targa già esistente.");
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            try
                            {
                                Console.Clear();
                                float f;
                                float.TryParse(param[9], out f);
                                Automobili a;
                                if (param.Length > 12 && param[12] != "" && param[12] != " ")
                                {
                                    a = new Automobili(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, Convert.ToInt32(param[10]), Convert.ToDouble(param[11]), param[12]);
                                }
                                else
                                {
                                    a = new Automobili(param[0], param[1], param[2], param[3], Convert.ToInt32(param[4]), Convert.ToDouble(param[5]), Convert.ToDateTime(param[6]), Convert.ToBoolean(param[7]), Convert.ToBoolean(param[8]), f, Convert.ToInt32(param[10]), Convert.ToDouble(param[11]));
                                }
                                u.AddNewVeicol(a);
                                doneAuto = false;
                                Console.WriteLine("Veicolo inserito correttamente.");
                                System.Threading.Thread.Sleep(2000);
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine($"\n{exc.Message}\nPremere un tasto per continuare.");
                                Console.ReadKey();
                                doneAuto = true;
                                return;
                            }
                        }
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Targa(string) Marca(string) Modello(string) Colore(string) Cilindrata(int) Potenza(double) " +
                            "Immatricolazione(Date aaaa-mm-gg) Usato(bool) KmZero(bool) KmPercorsi(float) MarcaSella(string) Prezzo(double) imgPath(string, omesso per il default)\n");
                        string[] param = Console.ReadLine().Split('\\');
                        if (Utils.checkTarga(ref param[0], list))
                        {
                            Console.WriteLine("Targa già esistente.");
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            try
                            {
                                Console.Clear();
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
                                u.AddNewVeicol(m);
                                doneMoto = false;
                                Console.WriteLine("Veicolo inserito correttamente.");
                                System.Threading.Thread.Sleep(2000);
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine($"\n{exc.Message}");
                                Console.ReadKey();
                                doneMoto = true;
                                return;
                            }
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
            Console.Clear();
            switch (s)
            {
                case '1':
                    u.ListMacchine();
                    break;
                case '2':
                    u.ListMoto();
                    break;
                case '3':
                    u.ListReport();
                    break;
                case '4':
                    {
                        u.ListMacchine();
                        u.ListMoto();
                        u.ListReport();
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

        #region modifica

        /// <summary>
        /// Sottoprogramma principale gestione modifica dati. Si occupa di chiamare i sottoprogrammi interessati.
        /// </summary>
        private static void modify()
        {
            Console.Title = "Gestionale database - Modifica veicolo";
            try
            {
                string query = makequery(list);
                if (query != "x")
                {
                    u.ModificaDati(query);
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n{exc.Message}\nPremi un tasto qualsiasi per continuare.");
                Console.ReadKey();
                return;
            }
        }

        /// <summary>
        /// Chidede se si vuole modificare ogni parametro e, in caso di assenso, lo accoda alla query.
        /// </summary>
        /// <param name="list">Lista dei veicoli compresi in 'Moto' e 'Automobili'</param>
        /// <returns>Stringa contenente la query di update o, nel caso di voler uscire la x che indica l'uscita dal sottoprogramma</returns>
        private static string makequery(SerialBindList<Veicolo> list)
        {
            string query = "", targa1;
            Veicolo v = new Automobili();
            Console.Clear();
            do
            {
                Console.Write("Inserisci la targa del veicolo da modificare(x per uscire): ");
                targa1 = Console.ReadLine().ToUpper();
            } while (existTarga(list, targa1, ref v) && targa1 != "X");
            if (targa1 != "X")
            {
                try
                {
                    string aus = $"UPDATE {(v is Moto ? "Moto" : "Automobili")} SET ";
                    string ins = "";
                    Console.Write("Inserisci la nuova targa (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                    {
                        if (Utils.checkTarga(ref ins, list))
                        {
                            aus += $"Targa = '{ins}',";
                        }
                    }

                    Console.Write("Inserisci la nuova marca (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Marca = '{ins}',";

                    Console.Write("Inserisci il nuovo modello (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Modello = '{ins}',";

                    Console.Write("Inserisci la nuova colore (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Colore = '{ins}',";

                    Console.Write("Inserisci la nuova cilindrata (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Cilindrata = {Convert.ToDouble(ins)},";

                    Console.Write("Inserisci la nuova potenza (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Potenza = {Convert.ToDouble(ins)},";

                    Console.Write("Inserisci la nuova data di immatricolazione(formato aaaa/mm/gg) (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"Immatricolazione = #{Convert.ToDateTime(ins)}#,";

                    Console.Write("Inserisci la nuova definizione di usato(true o false) (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                    {
                        aus += $"Usato = {Convert.ToBoolean(ins)}, ";
                        if (ins == "true")
                        {
                            Console.Write("Inserisci la nuova definizione di km0(true o false) (invio per non modificare): ");
                            ins = Console.ReadLine();
                            if (ins != "")
                            {
                                aus += $"Km0 = {Convert.ToBoolean(ins)}, ";
                                if (ins == "false")
                                {
                                    Console.Write("Inserisci i nuovi kmPercorsi (invio per non modificare): ");
                                    ins = Console.ReadLine();
                                    if (ins != "")
                                        aus += $"KmPercorsi = {Convert.ToDouble(ins)},";
                                }
                            }
                        }
                    }

                    if (v is Moto)
                    {
                        Console.Write("Inserisci la nuova marcaSella (invio per non modificare): ");
                        ins = Console.ReadLine();
                        if (ins != "")
                            aus += $"Marcasella = '{ins}',";
                        doneMoto = false;
                    }
                    else
                    {
                        Console.Write("Inserisci il nuovo numero di airbag (invio per non modificare): ");
                        ins = Console.ReadLine();
                        if (ins != "")
                            aus += $"NumAirbag = {Convert.ToInt32(ins)},";
                        doneAuto = false;
                    }

                    Console.Write("Inserisci il nuovo percorso dell'immagine (invio per non modificare): ");
                    ins = Console.ReadLine();
                    if (ins != "")
                        aus += $"imgPath = '{ins}',";

                    if (aus.Length > 22)
                    {
                        int i = aus.LastIndexOf(',');
                        query = aus.Substring(0, i);
                        query += $" WHERE Targa = '{targa1}';";
                    }
                    else
                    {
                        Console.WriteLine("Parametri insufficenti.");
                        query = "";
                        System.Threading.Thread.Sleep(1500);
                    }
                    return query;
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"\n{exc.Message}\nPremere un tasto qualsiasi per continuare.");
                    Console.ReadKey();
                }
            }
            return "x";
        }

        /// <summary>
        /// Cerca il veicolo con la targa corrispondente.
        /// </summary>
        /// <param name="list">Lista dei veicoli.</param>
        /// <param name="targa">Targa da controllare.</param>
        /// <param name="ve">Parametro referenziale dove vado a inserire il veicolo al quale corrisponde la targa.</param>
        /// <returns>True se esiste un veicolo con quella targa, false se non esiste.</returns>
        private static bool existTarga(SerialBindList<Veicolo> list, string targa, ref Veicolo ve)
        {
            bool exist = false;
            foreach (Veicolo v in list)
            {
                if (v.Targa == targa)
                {
                    exist = true;
                    ve = v;
                }
            }
            return !exist;
        }

        #endregion modifica

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
            Console.Clear();
            switch (s)
            {
                case '1':
                    {
                        u.DropAutomobili();
                        //Cancello le automobili che corrispondono alla tabella appena cancellata.
                        foreach (Veicolo item in list)
                        {
                            if (item is Automobili)
                            {
                                list.Remove(item);
                            }
                        }
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
                case '2':
                    {
                        u.DropMoto();
                        foreach (Veicolo item in list)
                        {
                            if (item is Moto)
                            {
                                list.Remove(item);
                            }
                        }
                        System.Threading.Thread.Sleep(3000);
                        break;
                    }
                case '3':
                    u.DropReport();
                    System.Threading.Thread.Sleep(3000);
                    break;
                case '4':
                    {
                        u.DropAutomobili();
                        System.Threading.Thread.Sleep(3000);
                        u.DropMoto();
                        System.Threading.Thread.Sleep(3000);
                        u.DropReport();
                        System.Threading.Thread.Sleep(3000);
                        list.Clear();
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

        /// <summary>
        /// Crea il file che contiene il database.
        /// </summary>
        private static void creaDatabase()
        {
            Console.Title = "Gestionale database - Creazione database";
            Console.Clear();
            try
            {
                string resources = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi";
                string DbPath = Path.Combine(resources, CLI_Database.Properties.Resources.CreateDB_Name);
                File.Copy(DbPath, Program.DbPath);
                Console.WriteLine("\nDatabase creato correttamente.");
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n{exc.Message}\nPremi un tasto per continuare.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Cancella il file che contiene il database, ne consegue la perdita dei dati.
        /// </summary>
        private static void dropDatabase()
        {
            char s;
            Console.Clear();
            Console.Title = "Gestione database - Creazione tabelle";
            do
            {
                Console.Clear();
                Console.WriteLine("Sei sicuro di voler cancellare il database (s/n)?");
                s = Console.ReadKey().KeyChar;
            } while (s != 's' && s != 'n');
            if (s == 's')
            {
                Console.Clear();
                try
                {
                    File.Delete(DbPath);
                    doneAuto = false;
                    doneMoto = false;
                    list.Clear();
                    Console.WriteLine("\nDatabase cancellato correttamente.");
                    System.Threading.Thread.Sleep(3000);
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"\n{exc.Message}\nPremi un tasto per continuare.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Copia il database e lo rinomina per crearne una copia di backup.
        /// </summary>
        private static void creaBackup()
        {
            string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi\\Backup";//Percorso della cartella "resources".
            string backup = Path.Combine(resourcesDirectoryPath, "backup.accdb");//Percorso del file contenente il database.
            if (File.Exists(backup))
            {
                File.Delete(backup);
            }
            File.Copy(DbPath, backup);
            Console.WriteLine("Copia di backup effettuata.");
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Prende il file "backup.accdb" e lo copia cambianogli il nome in "autoSalone.accdb"
        /// </summary>
        private static void caricaBckup()
        {
            string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi\\Backup";//Percorso della cartella "resources".
            string backup = Path.Combine(resourcesDirectoryPath, "backup.accdb");//Percorso del file contenente il database.
            if (File.Exists(backup))
            {
                File.Copy(backup, DbPath);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nessun Backup trovato. Creare il database?(s/n)");
                if (Console.ReadKey().KeyChar == 's')
                {
                    creaDatabase();
                }
            }
        }

        /// <summary>
        /// Prende i dati dal json e gli mette nella list, successivamente gli aggiunge alle tabelle nel database.
        /// </summary>
        private static void prendiJson()
        {
            try
            {
                Utils.apriSalvataggi(list, jsonSave);
                foreach (Veicolo item in list)
                {
                    u.AddNewVeicol(item);
                }
            }
            catch (Exception exc)
            {
                Console.Clear();
                Console.WriteLine($"{exc.Message}");
                System.Threading.Thread.Sleep(2000);
                return;
            }
        }

        #endregion metodiPerEsecuzione
    }
}