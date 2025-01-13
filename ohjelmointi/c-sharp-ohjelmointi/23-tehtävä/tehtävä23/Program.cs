using System;
using System.Globalization;
namespace tehtävä23
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Hi");
            int[] numerot = { 6, 9, 23, 55, 12};

            for(int i = 0; i < numerot.Length; i++)
            {
                numerot[i] *=3;
            }
            foreach(int numero in numerot)
            {
                Console.WriteLine(numero);
            }
            /*
            int i = 0;
            foreach(int numero in numerot)
            {
                Console.Write(numero);
                int uusinumero = numero * 3;                
                Console.WriteLine(" Kerrotaan se kolmella " + uusinumero);
                numerot[i] = uusinumero;
                i++;
            }
            foreach(int numero in numerot)
            {
                Console.WriteLine(numero);
            }
            */
        }
    }
}