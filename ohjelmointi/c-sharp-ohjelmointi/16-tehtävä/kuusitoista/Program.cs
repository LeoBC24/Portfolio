using System;


namespace kuusitoista
{
class Program
{
static void Main(string[]args)
{
    Console.WriteLine("Anna ensimmäinen numero: ");
    int numero1 = Int32.Parse(Console.ReadLine());

    Console.WriteLine("Anna toinen numero: ");
    int numero2 = Int32.Parse(Console.ReadLine());

    if(numero1 == 30 || numero1 == 30 || numero1 + numero2 == 30){
        Console.WriteLine(true);
    }
    else{
        Console.WriteLine(false);
    }
}
}
}