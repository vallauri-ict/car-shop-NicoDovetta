using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopConsoleProject
{
    class Program
    {
        public static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CarShop.accdb";

        static void Main(string[] args)
        {
            char scelta;
            do
            {
                menu();
                Console.Write("DIGITA LA TUA SCELTA ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        CreateTableCars();
                        break;
                    case '2':
                        AddNewCar("BMW", 36600);
                        break;
                    case '3':
                        ListCars();
                        break;
                    default:
                        break;
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("*** CAR SHOP - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - CREATE TABLE: Cars");
            Console.WriteLine("2 - ADD NEW ITEM: Cars");
            Console.WriteLine("3 - LIST: Cars");
            Console.WriteLine("4 - ...");
            Console.WriteLine("5 - ...");
            Console.WriteLine("\nX - FINE LAVORO\n\n");
        }

        private static void CreateTableCars()
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
                        cmd.CommandText = @"CREATE TABLE cars(
                                            id int identity(1,1) NOT NULL PRIMARY KEY,
                                            name VARCHAR(255) NOT NULL,
                                            price INT
                                          )";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\nCars created with test data!");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        private static void AddNewCar(string carName, int carPrice)
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
                    string query = "INSERT INTO cars(name, price) VALUES(@name, @price)";
                    cmd.CommandText = query;

                    cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255)).Value = carName;
                    cmd.Parameters.Add("@price", OleDbType.Integer).Value = carPrice;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\nCar inserted!");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        private static void ListCars()
        {
            if (connStr != null)
            {
                OleDbConnection connection = new OleDbConnection(connStr);
                using (connection)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * FROM cars", connection);

                    OleDbDataReader rdr = command.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        Console.WriteLine("\n");
                        while (rdr.Read())
                        {
                            Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
                                rdr.GetInt32(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nNo rows found.");
                    }
                    rdr.Close();
                }
                Console.WriteLine("\nCars listed!");
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
