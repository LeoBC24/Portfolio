using System;


namespace viisitoista
{
class Program
{
static void Main(string[]args)
{

    Console.WriteLine("Anna numero");
    bool isNumberGiven = false;
    int number1 = 0;
    while(isNumberGiven == false)
    {
    string mjono = Console.ReadLine();
    isNumberGiven = int.TryParse(mjono, out number1);

    if(isNumberGiven == false)
    {
        Console.WriteLine("Anna numero");
    }
    }
Console.WriteLine("Hienoa! Annoit numeron: " + number1);
}
}
}