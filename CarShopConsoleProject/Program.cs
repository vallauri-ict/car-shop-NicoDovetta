using database_instruction;
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
        private static List<string> lstTabelle = new List<string>();

        static void Main(string[] args)
        {
            char scelta;
            string tableName;
            do
            {
                menu();
                Console.Write("DIGITA LA TUA SCELTA ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.Title = "*** CAR SHOP - DB MANAGEMENT, CREATE TABLE ***\n";
                            Console.Write("Inserisci il nome della tabella (per il default - cars - premere enter): ");
                            tableName = Console.ReadLine();
                            if (tableName == "")
                            {
                                Utils.CreateTableCars();
                            }
                            else
                            {
                                Utils.CreateTableCars(tableName);
                            }
                            lstTabelle.Add(tableName);
                            break;
                        }
                    case '2':
                        Console.Clear();
                        Console.Title = "*** CAR SHOP - DB MANAGEMENT, ADD ITEM ***\n";
                        Console.Write("Inserisci il nome della tabella (per il default - cars - premere enter): ");
                        tableName = Console.ReadLine();
                        if (tableName == "")
                        {
                            Utils.AddNewCar();
                        }
                        else
                        {
                            Utils.AddNewCar(tableName);
                        }
                        break;
                    case '3':
                        Console.Clear();
                        Console.Title = "*** CAR SHOP - DB MANAGEMENT, LIST ***\n";
                        Console.Write("Inserisci il nome della tabella (per il default - cars - premere enter, - all - per vederle tutte): ");
                        tableName = Console.ReadLine();
                        if (tableName == "")
                        {
                            Utils.ListCars();
                        }
                        else if (tableName == "all")
                        {
                            foreach(string table in lstTabelle)
                            {
                                Utils.ListCars(tableName);
                            }
                        }
                        else
                        {
                            Utils.ListCars(tableName);
                        }
                        break;
                    case 'd':
                        Console.Clear();
                        Console.Title = "*** CAR SHOP - DB MANAGEMENT, DROP TABLE ***\n";
                        Console.Write("Inserisci il nome della tabella (per il default - cars - premere enter): ");
                        tableName = Console.ReadLine();
                        if (tableName == "")
                        {
                            Utils.DropTable();
                        }
                        else
                        {
                            Utils.DropTable(tableName);
                        }
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
            Console.Title = "*** CAR SHOP - DB MANAGEMENT ***\n";
            Console.WriteLine("1 - CREATE TABLE;");
            Console.WriteLine("2 - ADD NEW ITEM;");
            Console.WriteLine("3 - LIST;");
            Console.WriteLine("4 - (not written yet);");
            Console.WriteLine("5 - (not written yet);");
            Console.WriteLine("D - DROPTABLE;");
            Console.WriteLine("\nX - FINE LAVORO\n\n");
        }
    }
}
