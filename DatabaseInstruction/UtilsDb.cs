#region Riferimenti
//Interni
using System;
using System.Data.OleDb;
using veicoliDLLProject;

//Esterni

#endregion Riferimenti

namespace DatabaseInstruction
{
    public class UtilsDb
    {
        private static string connStr;

        /// <summary>
        /// Viene usato un costruttore per evitare che 2 o più persone agiscano assieme sul database, dato che potrebbe portare a perdite o modifiche di dati indesiderate.
        /// </summary>
        /// <param name="conn">Stringa di connessione al database.</param>
        public UtilsDb(string conn)
        {
            connStr = conn;
        }

        #region createTable

        /// <summary>
        /// Crea la tabella "Automobili".
        /// </summary>
        public void CreateTableCars()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    try
                    {
                        cmd.CommandText = @"CREATE TABLE Automobili(Targa VARCHAR(255) identity(1,1) NOT NULL PRIMARY KEY," +
                            "Marca VARCHAR(255), Modello VARCHAR(255),"+
                            "Colore VARCHAR(255), Cilindrata double,"+
                            "Potenza double, Immatricolazione date,"+
                            "Usato bit, Km0 bit,"+
                            "KmPercorsi double, NumAirbag int, Prezzo double, ImgPath VARCHAR(255));";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Automobili\" creata correttamente.");
                }
            }
        }

        /// <summary>
        /// Crea la tabella "Moto".
        /// </summary>
        public void CreateTableMoto()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    try
                    {
                        cmd.CommandText = @"CREATE TABLE Moto(Targa VARCHAR(255) identity(1,1) NOT NULL PRIMARY KEY," +
                            "Marca VARCHAR(255), Modello VARCHAR(255)," +
                            "Colore VARCHAR(255), Cilindrata double," +
                            "Potenza double, Immatricolazione date," +
                            "Usato bit, Km0 bit," +
                            "KmPercorsi double, MarcaSella VARCHAR(255), Prezzo double, ImgPath varchar(255));";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Moto\" creata correttamente.");
                }
            }
        }

        /// <summary>
        /// Crea la tabella "Report_Vendite".
        /// </summary>
        public void CreateTableReport()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    try
                    {
                        cmd.CommandText = @"CREATE TABLE Report_Vendite(Targa VARCHAR(255) identity(1,1) NOT NULL PRIMARY KEY," +
                            "Marca VARCHAR(255), Modello VARCHAR(255)," +
                            "Colore VARCHAR(255), Cilindrata double," +
                            "Potenza double, Immatricolazione VARCHAR(255)," +
                            "Usato bit, Km0 bit," +
                            "KmPercorsi double, MarcaSella VARCHAR(255), NumAirbag int, Prezzo double, Tipo VARCHAR(255));";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Report_Vendite\" creata correttamente.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        #endregion createTable

        /// <summary>
        /// Aggiunge un veicolo automaticamente a una delle 2 tabelle (Moto o Automobili) a seconda del tipo del veicolo.
        /// </summary>
        /// <param name="v">Veicolo da aggiungere alla tabella del tipo rispettivo.</param>
        public void AddNewVeicol(Veicolo v)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    if (v is Moto)
                    {
                        cmd.CommandText = "INSERT INTO Moto(Targa, Marca, Modello, Colore, Cilindrata, Potenza, Immatricolazione, Usato, Km0, KmPercorsi, MarcaSella, Prezzo, ImgPath)" +
                            " VALUES(@Targa, @Marca, @Modello, @Colore, @Cilindrata, @Potenza, @Immatricolazione, @Usato, @Km0, @KmPercorsi, @MarcaSella, @Prezzo, @ImgPath);";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Automobili(Targa, Marca, Modello, Colore, Cilindrata, Potenza, Immatricolazione, Usato, Km0, KmPercorsi, NumAirbag, Prezzo, ImgPath)" +
                            " VALUES(@Targa, @Marca, @Modello, @Colore, @Cilindrata, @Potenza, @Immatricolazione, @Usato, @Km0, @KmPercorsi, @NumAirbag, @Prezzo, @ImgPath);";
                    }

                    //Sostituzione parametri
                    cmd.Parameters.Add(new OleDbParameter("@Targa", OleDbType.VarChar, 255)).Value = v.Targa;
                    cmd.Parameters.Add(new OleDbParameter("@Marca", OleDbType.VarChar, 255)).Value = v.Marca;
                    cmd.Parameters.Add(new OleDbParameter("@Modello", OleDbType.VarChar, 255)).Value = v.Modello;
                    cmd.Parameters.Add(new OleDbParameter("@Colore", OleDbType.VarChar, 255)).Value = v.Colore;
                    cmd.Parameters.Add("@Cilindrata", OleDbType.Double).Value = v.Cilindrata;
                    cmd.Parameters.Add("@Potenza", OleDbType.Double).Value = v.PotenzaKw;
                    cmd.Parameters.Add("@Immatricolazione", OleDbType.Date).Value = v.Immatricolazione;
                    cmd.Parameters.Add("@Usato", OleDbType.Boolean).Value = v.IsUsato;
                    cmd.Parameters.Add("@Km0", OleDbType.Boolean).Value = v.IsKmZero;
                    cmd.Parameters.Add("@KmPercorsi", OleDbType.Double).Value = v.KmPercorsi;
                    if (v is Moto)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@MarcaSella", OleDbType.VarChar, 255)).Value = (v as Moto).MarcaSella;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumAirbag", OleDbType.Integer).Value = (v as Automobili).NumAirbag;
                    }
                    cmd.Parameters.Add("@Prezzo", OleDbType.Double).Value = v.Prezzo;
                    cmd.Parameters.Add(new OleDbParameter("@ImgPath", OleDbType.VarChar, 255)).Value = v.ImgPath;

                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        public void AggiungiVendita(Veicolo v)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Report_Vendite(Targa, Marca, Modello, Colore, Cilindrata, Potenza, Immatricolazione, Usato, Km0, KmPercorsi, MarcaSella, NumAirbag, Prezzo, Tipo)" +
                            " VALUES(@Targa, @Marca, @Modello, @Colore, @Cilindrata, @Potenza, @Immatricolazione, @Usato, @Km0, @KmPercorsi, @MarcaSella, @NumAirbag, @Prezzo, @Tipo);";

                    //Sostituzione parametri
                    cmd.Parameters.Add(new OleDbParameter("@Targa", OleDbType.VarChar, 255)).Value = v.Targa;
                    cmd.Parameters.Add(new OleDbParameter("@Marca", OleDbType.VarChar, 255)).Value = v.Marca;
                    cmd.Parameters.Add(new OleDbParameter("@Modello", OleDbType.VarChar, 255)).Value = v.Modello;
                    cmd.Parameters.Add(new OleDbParameter("@Colore", OleDbType.VarChar, 255)).Value = v.Colore;
                    cmd.Parameters.Add("@Cilindrata", OleDbType.Double).Value = v.Cilindrata;
                    cmd.Parameters.Add("@Potenza", OleDbType.Double).Value = v.PotenzaKw;
                    cmd.Parameters.Add("@Immatricolazione", OleDbType.Date).Value = v.Immatricolazione;
                    cmd.Parameters.Add("@Usato", OleDbType.Boolean).Value = v.IsUsato;
                    cmd.Parameters.Add("@Km0", OleDbType.Boolean).Value = v.IsKmZero;
                    cmd.Parameters.Add("@KmPercorsi", OleDbType.Double).Value = v.KmPercorsi;
                    if (v is Moto)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@MarcaSella", OleDbType.VarChar, 255)).Value = (v as Moto).MarcaSella;
                        cmd.Parameters.Add("@NumAirbag", OleDbType.Integer).Value = 0;
                    }
                    else
                    {
                        cmd.Parameters.Add(new OleDbParameter("@MarcaSella", OleDbType.VarChar, 255)).Value = "-";
                        cmd.Parameters.Add("@NumAirbag", OleDbType.Integer).Value = (v as Automobili).NumAirbag;
                    }
                    cmd.Parameters.Add("@Prezzo", OleDbType.Double).Value = v.Prezzo;
                    if (v is Moto)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@Tipo", OleDbType.VarChar, 255)).Value = "Moto";
                    }
                    else
                    {
                        cmd.Parameters.Add(new OleDbParameter("@Tipo", OleDbType.VarChar, 255)).Value = "Automobili";
                    }

                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        #region dropTable

        /// <summary>
        /// Imposta il nome della tabella "Moto" per evitare che si possano cancellare più tabelle al posto di una sola.
        /// </summary>
        public void DropMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Moto";
            ExecDropTable(cmd, "Moto");
        }

        /// <summary>
        /// Imposta il nome della tabella "Automobili" per evitare che si possano cancellare più tabelle al posto di una sola.
        /// </summary>
        public void DropAutomobili()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Automobili";
            ExecDropTable(cmd, "Automobili");
        }

        /// <summary>
        /// Imposta il nome della tabella "Report_Vendite" per evitare che si possano cancellare più tabelle al posto di una sola.
        /// </summary>
        public void DropReport()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Report_Vendite";
            ExecDropTable(cmd, "Report_Vendite");
        }

        /// <summary>
        /// Esegue la non query e cancella la tabella.
        /// </summary>
        /// <param name="cmd">Contiene il comando</param>
        /// <param name="tableName">Contiene il nome della tabella della quale si da il messaggio finale nel caso la query sia andata a buon fine.</param>
        private static void ExecDropTable(OleDbCommand cmd, string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    cmd.Connection = con;
                    try
                    {
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine($"\nTabella \"{tableName}\" cancellata.");
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        #endregion dropTable

        #region listTable

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Automobili" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void ListMacchine()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Automobili";
            ExecListTable(cmd, "Automobili");
        }

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Moto" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void ListMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Moto";
            ExecListTable(cmd, "Moto");
        }

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Report_Vendite" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void ListReport()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Report_Vendite";
            ExecListTable(cmd, "ReportVendite");
        }

        /// <summary>
        /// Si occupa di visualizzare i record di una tabella eseguendo la query contenuta nel parametro cmd.
        /// </summary>
        /// <param name="cmd">Comando che contiene la query. Impostato in un metodo per ogni tabella per impedire la sql injection.</param>
        /// <param name="tableName">Nome della tabella della quale si vogliono visualizzare i record.</param>
        private static void ExecListTable(OleDbCommand cmd, string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    cmd.Connection = con;
                    try
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Console.Clear();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString() + " " + reader[7].ToString() + " " + reader[8].ToString() + " " + reader[9].ToString() + " " + reader[10].ToString() + " " + reader[11].ToString() + " " + reader[12].ToString());
                        }
                        reader.Close();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
                Console.WriteLine($"\nVeicoli della tabella \"{tableName}\" riportati a video. Premere un tasto per continuare.");
                Console.ReadKey();
                //System.Threading.Thread.Sleep(5000);
            }
        }

		#endregion listTable

		/// <summary>
		/// Metodo di modifica dei dati.
		/// </summary>
		/// <param name="query">Stringa che contiene il comando sql per modificare i dati.</param>
		public void ModificaDati(string query)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        #region GetVeicoli

        /// <summary>
        /// Prende dal database tutti i veicoli appartenenti alle tabella "Automobili" e gli restituisce in una lista.
        /// </summary>
        /// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
        public void GetVeicolListAuto(ref SerialBindList<Veicolo> list)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    try
                    {
                        con.Open();

                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Automobili;", con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                float f;
                                float.TryParse(reader[9].ToString(), out f);
                                list.Add(new Automobili(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToDouble(reader[4].ToString()), Convert.ToDouble(reader[5].ToString()), Convert.ToDateTime(reader[6].ToString()), Convert.ToBoolean(reader[7].ToString()), Convert.ToBoolean(reader[8].ToString()), f, Convert.ToInt32(reader[10].ToString()), Convert.ToDouble(reader[11].ToString()), reader[12].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                    
                }
            }
        }

        /// <summary>
        /// Prende dal database tutti i veicoli appartenenti alle tabella "Moto" e gli restituisce in una lista.
        /// </summary>
        /// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
        public void GetVeicolListMoto(ref SerialBindList<Veicolo> list)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    try
                    {
                        con.Open();

                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Moto;", con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                float f;
                                float.TryParse(reader[9].ToString(), out f);
                                list.Add(new Moto(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToDouble(reader[4].ToString()), Convert.ToDouble(reader[5].ToString()), Convert.ToDateTime(reader[6].ToString()), Convert.ToBoolean(reader[7].ToString()), Convert.ToBoolean(reader[8].ToString()), f, reader[10].ToString(), Convert.ToDouble(reader[11].ToString()), reader[12].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Prende dal database tutti i veicoli appartenenti alle tabella "Report_Vendite" e gli restituisce in una lista.
        /// </summary>
        /// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
        public void GetVeicolListReport(ref SerialBindList<Veicolo> list)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    try
                    {
                        con.Open();

                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Report_Vendite;", con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                float f;
                                float.TryParse(reader[9].ToString(), out f);
                                if (reader[13].ToString() == "Moto")
                                {
                                    list.Add(new Moto(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToDouble(reader[4].ToString()), Convert.ToDouble(reader[5].ToString()), Convert.ToDateTime(reader[6].ToString()), Convert.ToBoolean(reader[7].ToString()), Convert.ToBoolean(reader[8].ToString()), f, reader[10].ToString(), Convert.ToDouble(reader[11].ToString()), reader[12].ToString()));
                                }
                                else
                                {
                                    list.Add(new Automobili(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToDouble(reader[4].ToString()), Convert.ToDouble(reader[5].ToString()), Convert.ToDateTime(reader[6].ToString()), Convert.ToBoolean(reader[7].ToString()), Convert.ToBoolean(reader[8].ToString()), f, Convert.ToInt32(reader[10].ToString()), Convert.ToDouble(reader[11].ToString()), reader[12].ToString()));
                                }
                            }
                            reader.Close();
                        }
                    }
                    catch (OleDbException exc)
                    {
                        Error(exc);
                        return;
                    }
                }
            }
        }

        #endregion GetVeicoli

        /// <summary>
        /// Per evitare di andare a fare delle query a una tabella inesistente controllo che esista.
        /// </summary>
        /// <param name="tableName">Nome della tabella da verificare.</param>
        /// <returns>True se esiste la tabella false se non esiste.</returns>
        public bool PresTabella(string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand($"SELECT * FROM {tableName};", con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Procedura standard di gestione dell'errore su un'istruzione al database.
        /// </summary>
        /// <param name="exc">Variabile contenente l'errore.</param>
        private static void Error(OleDbException exc)
        {
            Console.WriteLine($"\n{exc.Message}\n");
        }
    }
}