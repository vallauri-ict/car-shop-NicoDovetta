using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace database_instruction
{
    public class Car
    {
        private string name;
        private int price;

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
    }

    public class Utils
    {
        private static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CarShop.accdb";

        public static void CreateTableCars(string tableName = "cars")
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    // cmd.CommandText = "DROP TABLE IF EXISTS cars";
                    // cmd.ExecuteNonQuery();

                    try
                    {
                        cmd.CommandText = @"CREATE TABLE @table(id int identity(1,1) NOT NULL PRIMARY KEY, name VARCHAR(255) NOT NULL, price INT)";
                        cmd.CommandText = cmd.CommandText.Replace("@table", tableName);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    loadTestData(tableName);

                    Console.WriteLine($"\nTable \"{tableName}\" created with test data!");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public static void DropTable(string tableName = "cars")
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
                        cmd.CommandText = @"DROP TABLE @table";
                        cmd.CommandText = cmd.CommandText.Replace("@table", tableName);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                    Console.WriteLine($"\nTable \"{tableName}\" dropped.");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public static void AddNewCar(List<Car> lstM, string tableName = "cars")
        {
            foreach (Car c in lstM)
            {
                AddCar(c.Name, c.Price, "", tableName);
            }
        }

        public static void AddNewCar(string tableName = "cars")
        {
            string n = "";
            int p = 0;

            while (n != "exit")
            {
                Console.Clear();
                Console.Write("\nInserisci il nome della macchina (exit per uscire): ");
                n = Console.ReadLine();
                if (n != "exit")
                {
                    Console.Write("Inserisci il prezzo della macchina: ");
                    int.TryParse(Console.ReadLine(), out p);
                    AddCar(n, p, "Car insert!", tableName);
                }
            }
        }

        private static void AddCar(string carName, int carPrice, string msg = "", string tableName = "cars")
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;


                    // string badQuery = "INSERT INTO cars(name, price) VALUES('" + carName + "'," + carPrice + ")";
                    string query = "INSERT INTO @table(name, price) VALUES(@name, @price)";
                    cmd.CommandText = query;
                    cmd.CommandText = cmd.CommandText.Replace("@table", tableName);

                    cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255)).Value = carName;
                    cmd.Parameters.Add("@price", OleDbType.Integer).Value = carPrice;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    if (msg != "")
                    {
                        Console.WriteLine($"\n{msg}");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
        }

        public static void ListCars(string tableName = "cars")
        {
            if (connStr != null)
            {
                OleDbConnection connection = new OleDbConnection(connStr);
                using (connection)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * FROM @table", connection);
                    command.CommandText = command.CommandText.Replace("@table", tableName);

                    try
                    {
                        OleDbDataReader rdr = command.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            Console.WriteLine("\n");
                            while (rdr.Read())
                            {
                                Console.WriteLine("{0} - {1}: € {2}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nNo rows found.");
                        }
                        rdr.Close();
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


        private static void loadTestData(string tableName = "cars")
        {
            List<Car> lstM = new List<Car>();
            lstM.Add(new Car("Audi", 52642));
            lstM.Add(new Car("Mercedes", 57127));
            lstM.Add(new Car("Skoda", 9000));
            lstM.Add(new Car("Volvo", 29000));
            lstM.Add(new Car("Bentley", 350000));
            lstM.Add(new Car("Citroen", 21000));
            lstM.Add(new Car("Hummer", 41400));
            lstM.Add(new Car("Volkswagen", 21600));
            AddNewCar(lstM, tableName);
        }
    }
}