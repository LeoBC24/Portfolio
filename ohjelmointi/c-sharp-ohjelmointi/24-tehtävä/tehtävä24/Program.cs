using System;
using System.Globalization;
namespace tehtävä24
{
    class Program
    {
        static void Main(string[]args)
        {
            int numero = 4;
            for(int i = 1; i <= numero; i++)
            {
                string tuloste = "";
                for(int j = 1; j <= i; j++)
                {
                    tuloste += " " + j;
                }
                Console.WriteLine(tuloste);
            }
        }
    }
}