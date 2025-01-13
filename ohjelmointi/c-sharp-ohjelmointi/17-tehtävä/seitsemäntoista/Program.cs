using System;


namespace seitsemäntoista
{
class Program
{
static void Main(string[]args)
{
    Console.WriteLine("Kirjoita nimi");
    string nimi = Console.ReadLine();
    if(char.IsUpper(nimi[0]))
    {
        Console.WriteLine(nimi);
    }
    else
    {
        Console.WriteLine("Ei ollut isolla");
        Console.WriteLine("Muutetaan isoksi");
        Console.WriteLine(char.ToUpper(nimi[0]) + nimi.Substring(1));
    }
}
}
}