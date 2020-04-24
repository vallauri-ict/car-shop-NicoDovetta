#region Riferimenti
//Interni
using System;
using System.ComponentModel;
using veicoliDLLProject;

//Esterni

#endregion Riferimenti

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t*** SALONE VENDITA VEICOLI NUOVI E USATI ***");
            Moto m = new Moto();
            Console.WriteLine(m);
            Automobili a = new Automobili();
            Console.WriteLine(a);
        }
    }
}