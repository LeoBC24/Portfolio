using System;




namespace seiska
{

class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("Anna ensimmäinen numero:");

        int ensimmainen = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Anna toinen numero");

        int toinen = int.Parse(Console.ReadLine());
        
        if(ensimmainen == toinen)
        {
            Console.WriteLine("Antamasi luvut plussattuna ovat, " + (ensimmainen + toinen));
        }
        else
        {
            Console.WriteLine("Antamasi luvut kerrottuna ovat, " + (ensimmainen * toinen));
        }
    }
    }
    }