using System;
using System.Data.OleDb;

namespace DatabaseInstruction
{
    public class UtilsDb
    {
        private static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=autoSalone.accdb";

        #region createTable

        public static void createTableCars()
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
                            "Colore VARCHAR(255), Cilindrata int,"+
                            "Potenza decimal(10,5), Immatricolazione VARCHAR(255),"+
                            "Usato bit, Km0 bit,"+
                            "KmPercorsi decimal(10,5), NumAirbag int, Price decimal(10,5), ImgPath VARCHAR(255));";
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

        public static void createTableMoto()
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
                            "Colore VARCHAR(255), Cilindrata int," +
                            "Potenza decimal, Immatricolazione VARCHAR(255)," +
                            "Usato bit, Km0 bit," +
                            "KmPercorsi decimal(10,5), MarcaSella VARCHAR(255), Price decimal(10,5), ImgPath varchar(255));";
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

        public static void createTableReport()
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
                        cmd.CommandText = @"CREATE TABLE Report_Vendite(Targa VARCHAR(255) identity(1,1) NOT NULL PRIMARY KEY, isAuto bit," +
                            "Marca VARCHAR(255), Modello VARCHAR(255)," +
                            "Colore VARCHAR(255), Cilindrata int," +
                            "Potenza decimal, Immatricolazione VARCHAR(255)," +
                            "Usato bit, Km0 bit," +
                            "KmPercorsi decimal(10,5), MarcaSella VARCHAR(255), NumAirbag int, Price decimal(10,5));";
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

        public static void addNewVeicol(string[] param, string tableName)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();
                    string query = "";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    if (tableName=="Moto")
                    {
                        query = "INSERT INTO @table(Targa, Marca, Modello, Colore, Cilindrata, Potenza, Immatricolazione," +
                            "Usato, Km0, KmPercorsi, NumAirbag, ImgPath) VALUES(@Targa, @Marca, @Modello, @Colore, @Cilindrata, @Potenza, @Immatricolazione," +
                            "@Usato, @Km0, @KmPercorsi, @NumAirbag, @Price, @ImgPath)";
                        cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255)).Value = param[10];
                    }
                    else
                    {
                        query = "INSERT INTO @table(Targa, Marca, Modello, Colore, Cilindrata, Potenza, Immatricolazione," +
                            "Usato, Km0, KmPercorsi, MarcaSella, ImgPath) VALUES(@Targa, @Marca, @Modello, @Colore, @Cilindrata, @Potenza, @Immatricolazione," +
                            "@Usato, @Km0, @KmPercorsi, @MarcaSella, @Price, @ImgPath)";
                        cmd.Parameters.Add("@price", OleDbType.Integer).Value = param[10];
                    }
                    cmd.CommandText = query;

                    //Sostituzione dei parametri
                    cmd.CommandText = cmd.CommandText.Replace("@table", tableName);
                    cmd.Parameters.Add(new OleDbParameter("@Targa", OleDbType.VarChar, 255)).Value = param[0];
                    cmd.Parameters.Add(new OleDbParameter("@Marca", OleDbType.VarChar, 255)).Value = param[1];
                    cmd.Parameters.Add(new OleDbParameter("@Modello", OleDbType.VarChar, 255)).Value = param[2];
                    cmd.Parameters.Add(new OleDbParameter("@Colore", OleDbType.VarChar, 255)).Value = param[3];
                    cmd.Parameters.Add("@Cilindrata", OleDbType.Integer).Value = Convert.ToInt32(param[4]);
                    cmd.Parameters.Add(new OleDbParameter("@Potenza", OleDbType.Decimal, 10)).Value = Convert.ToDecimal(param[5]);
                    cmd.Parameters.Add(new OleDbParameter("@Immatricolazione", OleDbType.VarChar, 255)).Value = param[5];
                    cmd.Parameters.Add("@Usato", OleDbType.Boolean).Value = Convert.ToBoolean(param[7]);
                    cmd.Parameters.Add("@Km0", OleDbType.Boolean).Value = Convert.ToBoolean(param[8]);
                    cmd.Parameters.Add(new OleDbParameter("@KmPercorsi", OleDbType.Decimal, 10)).Value = Convert.ToDecimal(param[9]);
                    cmd.Parameters.Add(new OleDbParameter("@Price", OleDbType.Decimal, 10)).Value = Convert.ToDecimal(param[11]);
                    if (param.Length < 13)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@ImgPath", OleDbType.VarChar, 255)).Value = @".\img/noPhoto.jpg";
                    }
                    else if(param[12] == "" || param[12] == " " || param[12] == "\n")
                    {
                        cmd.Parameters.Add(new OleDbParameter("@ImgPath", OleDbType.VarChar, 255)).Value = @".\img/noPhoto.jpg";
                    }
                    else
                    {
                        cmd.Parameters.Add(new OleDbParameter("@ImgPath", OleDbType.VarChar, 255)).Value = param[11];
                    }

                    cmd.Prepare();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }

        #region dropTable

        public static void dropMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Moto";
            execDropTable(cmd, "Moto");
        }

        public static void dropAutomobili()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"DROP TABLE Automobili";
            execDropTable(cmd, "Automobili");
        }

        public static void dropReport()
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

        public static void listReport()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Report_Vendite";
            execListTable(cmd, "ReportVendite");
        }

        public static void listMoto()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Moto";
            execListTable(cmd, "Moto");
        }

        public static void listMacchine()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM Automobili";
        }

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

                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToString());
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
                Console.WriteLine($"\nCars from \"{tableName}\" listed!");
                System.Threading.Thread.Sleep(5000);
            }
        }

        #endregion listTable
    }
}