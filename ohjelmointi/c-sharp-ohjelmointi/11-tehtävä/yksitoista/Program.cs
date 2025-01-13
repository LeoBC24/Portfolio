using System;
using System.Runtime.InteropServices.Marshalling;

namespace yksitoista
{
class Program
{
static void Main(string[]args)
{
    Console.WriteLine("Anna nimien määrä");
    string numOfNames = Console.ReadLine();
    int namesAmount = Int32.Parse(numOfNames);

    string[] names = new string[namesAmount];
    for(int i = 0; i < namesAmount; i++)
    {
        Console.WriteLine("Anna nimi " + (i+1) + "/" + namesAmount + ": ");
        names[i] = Console.ReadLine();
    }
    Console.WriteLine("Thank you for names!");
    foreach(string name in names)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine("Tulostetaan nimet aakkosjärjestyksessä");

    Array.Sort(names);

    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
}
}
}