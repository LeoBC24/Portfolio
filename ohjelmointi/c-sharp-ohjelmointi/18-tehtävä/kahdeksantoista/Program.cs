using System;
using System.IO.Compression;


namespace kahdeksantoista
{
class Program
{
static void Main(string[]args)
{
    Console.WriteLine("Anna kolme numeroa:");
    int numero1, numero2, numero3;
    numero1 = Int32.Parse(Console.ReadLine());
    numero2 = Int32.Parse(Console.ReadLine());
    numero3 = Int32.Parse(Console.ReadLine());

    int[] numerot = {numero1, numero2, numero3};
    Array.Sort(numerot);

    Console.WriteLine("Suurin " + numerot.Last());
}
}
}