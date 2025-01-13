using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace _21_tehtävä
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Hi, welcome");
            Console.WriteLine("Give a number");
            string numermerkkijono= Console.ReadLine();
            int numero = Convert.ToInt32(numermerkkijono);
            string luku = "5";
            bool vastaus;
            if (vastaus = numermerkkijono.Contains(luku) && numero < 100)
            {
                Console.WriteLine("yees");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}