using System;


namespace kaksitoista
{
class Program
{
static void Main(string[]args)
{
    bool summa = false;
    Console.WriteLine("Anna ensimmäinen numero");
    int numero1 = Int32.Parse(Console.ReadLine());

    Console.WriteLine("Anna toinen numero");
    int numero2 = Int32.Parse(Console.ReadLine());

    if (numero1 * numero2 > 87)
    {
        summa  = true;
    }
Console.WriteLine(summa);

}
}
}