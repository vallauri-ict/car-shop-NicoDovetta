# OpenXML dll "simplified"
## Dovetta Nicolas, 4^B Informatica - I.I.S. "G. Vallauri" Fossano

Repository with a solution with the most important acces database command and an example of how to use it.

To use this method you have to add the reference to database_instruction dll, because those are implemented inside the class Utils.

### CREATE TABLE
```C#
con.Open();
OleDbCommand cmd = new OleDbCommand();
cmd.Connection = con;
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
```
After have open the connection we use a class call OleDbCommand and declare an object "cmd" were we put the command anb then execute it. Here we use the command **"CREATE TABLE"**, from "CreateTableCars(string tableName = "cars")"
method, and create a table with the name passed as parameter, having "cars" as the default name. If already exist a table with the same name it throw an exception.


### DROP TABLE
```C#
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
```
With the command **"DROP TABLE"** we cancel a table with that name.


### INSERT INTO
Then we have 2 method for add car:
 1. AddNewCar(string tableName): the cars have to be writed on the cli to be added;
 2. AddNewCar(List<Car> lstM, string tableName): that add athe car from a list. The cars have to be object of car class that contains car's name and price.

All the two method call  "private void AddCar(string tableName)" that it add the car (using **"INSERT TO"** command) to that table (specified in the parameters in the parameter "tableName").
```C#
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
```


### QUERY EXECUTION
Than with the method "public static void ListCars(string tableName = "cars")" we list the cars from the table specified in the "tableName" parameter.
```C#
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
```
Using the query **"SELECT * FROM @table"** and replacing @table with the content of "tableName" parameter using this formula (also valid for other method):

```C#
command.CommandText = @"SELECT * FROM @table";
command.CommandText = command.CommandText.Replace("@table", tableName);
command.Prepare();
```