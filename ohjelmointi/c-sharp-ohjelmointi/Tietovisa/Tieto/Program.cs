using System;



namespace Tieto
{

class Program
{
    static void Main (string[] args)
    
    {
        int pisteet = 0;
        bool oikein;


        Console.WriteLine("Hi, would you like to play a game? [Y/N]");
        
        ConsoleKey ConsoleKey = Console.ReadKey().Key;
        if (ConsoleKey == ConsoleKey.Y)
        {
            Console.WriteLine("Let's begin!");
        }
        else if(ConsoleKey == ConsoleKey.N)
        {
            Console.WriteLine("Too bad for you!");
            Console.WriteLine("You are already playing the game!");
        }
        else
        {
            Console.WriteLine("You couldn't even press the correct KEY!!!");
        }

        do
        {
        Console.WriteLine("How many months are there in a year?");

        int vastaus;

        string mjono = Console.ReadLine();

        oikein = int.TryParse(mjono,out vastaus);
        {
            if(vastaus == 12)
            {
                pisteet = pisteet +1;
                Console.WriteLine("Correct, points: " + pisteet);
                
            }
            else{

                Console.WriteLine("Wrong, points: " + pisteet);
                break;
            }
        }
        }while(oikein == false);
        do{
        Console.WriteLine("What is the capital city of Finland?");
        string kaupunki = Console.ReadLine();
        if (kaupunki == "Helsinki"|| kaupunki == "helsinki")
        {
            pisteet = pisteet +1;
            Console.WriteLine("Correct, points: " + pisteet);
        }
        else{
            Console.WriteLine("Wrong, points: " + pisteet);
        }
        }while(oikein == false);
        int yrityksiä = 3;
        bool tarkoitusoikein = false;

        do{
        Console.WriteLine("Mikä on elämän tarkoitus?");
        string tarkoitusvastaus = Console.ReadLine();

        tarkoitusoikein = tarkoitusvastaus == "42";
        if (tarkoitusoikein)
        {
            pisteet += 3;
        }
        else{
            Console.WriteLine("Väärin, yritä uudestaan");
            yrityksiä -= 1;
        }
        }while
            ( !tarkoitusoikein && yrityksiä > 0);

        {
            Console.WriteLine("This is the end");
        }
    }
}
}