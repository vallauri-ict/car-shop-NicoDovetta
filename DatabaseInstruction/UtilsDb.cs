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
        public void createTableCars()
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
                            "KmPercorsi int, NumAirbag int, Prezzo double, ImgPath VARCHAR(255));";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Automobili\" creata correttamente.");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// Crea la tabella "Moto".
        /// </summary>
        public void createTableMoto()
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
                            "KmPercorsi int, MarcaSella VARCHAR(255), Prezzo double, ImgPath varchar(255));";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Moto\" creata correttamente.");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// Crea la tabella "Report_Vendite".
        /// </summary>
        public void createTableReport()
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
                        cmd.CommandText = @"CREATE TABLE Report_Vendite(Targa VARCHAR(255) identity(1,1) NOT NULL PRIMARY KEY, Tipo VARCHAR(255)," +
                            "Marca VARCHAR(255), Modello VARCHAR(255)," +
                            "Colore VARCHAR(255), Cilindrata double," +
                            "Potenza double, Immatricolazione VARCHAR(255)," +
                            "Usato bit, Km0 bit," +
                            "KmPercorsi int, MarcaSella VARCHAR(255), NumAirbag int, Prezzo double);";
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    Console.WriteLine("\nTabella \"Report_Vendite\" creata correttamente.");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        #endregion createTable

        /// <summary>
        /// Aggiunge un veicolo automaticamente a una delle 2 tabelle (Moto o Automobili) a seconda del tipo del veicolo.
        /// </summary>
        /// <param name="v">Veicolo da aggiungere alla tabella del tipo rispettivo.</param>
        public void addNewVeicol(Veicolo v)
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
                    cmd.Parameters.Add("@KmPercorsi", OleDbType.Integer).Value = v.KmPercorsi;
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
                        Console.WriteLine("\n" + exc.Message);
                        System.Threading.Thread.Sleep(5000);
                        return;
                    }
                    Console.WriteLine("\nVeicolo inserito correttamente.");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        #region dropTable

        public void dropMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Moto";
            execDropTable(cmd, "Moto");
        }

        public void dropAutomobili()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Automobili";
            execDropTable(cmd, "Automobili");
        }

        public void dropReport()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Report_Vendite";
            execDropTable(cmd, "Report_Vendite");
        }

        private static void execDropTable(OleDbCommand cmd, string tableName)
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
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                    Console.WriteLine($"\nTabella \"{tableName}\" cancellata.");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        #endregion dropTable

        #region listTable

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Automobili" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void listMacchine()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Automobili";
            execListTable(cmd, "Automobili");
        }

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Moto" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void listMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Moto";
            execListTable(cmd, "Moto");
        }

        /// <summary>
        /// Imposta la query per prendere tutti i dati della tabella "Report_Vendite" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
        /// </summary>
        public void listReport()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Report_Vendite";
            execListTable(cmd, "ReportVendite");
        }

        /// <summary>
        /// Si occupa di visualizzare i record di una tabella eseguendo la query contenuta nel parametro cmd.
        /// </summary>
        /// <param name="cmd">Comando che contiene la query. Impostato in un metodo per ogni tabella per impedire la sql injection.</param>
        /// <param name="tableName">Nome della tabella della quale si vogliono visualizzare i record.</param>
        private static void execListTable(OleDbCommand cmd, string tableName)
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
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                }
                Console.WriteLine($"\nVeicoli della tabella \"{tableName}\" riportati a video. Premere un tasto per continuare.");
                Console.ReadKey();
                //System.Threading.Thread.Sleep(5000);
            }
        }

        #endregion listTable
    }
}