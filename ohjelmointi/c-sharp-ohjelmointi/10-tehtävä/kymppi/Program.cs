using System;
using System.Net.NetworkInformation;

namespace kymppi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] luvut = {1,2,3,5,6,7,9,6,5,4,3};
            int summa = 0;
            Console.WriteLine("Ohjelman alku");
            Console.WriteLine("Tänään on, " + DateTime.Now);
            foreach (int numero in luvut)
            {
                summa += numero;
            }
            Console.WriteLine("Summa on, " + summa);
        }
    }
}