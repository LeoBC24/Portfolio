using System;




namespace _6tehtävä
{

class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("Anna numero:");
        int numero = Convert.ToInt32(Console.ReadLine());
        if(numero >= 25 && numero <= 100 )
        {
            Console.WriteLine("OK");
        }
        else if (numero < 25)
        {
            Console.WriteLine("Liian pieni");
        }
        else
        {
            Console.WriteLine("Liian suuri");
        }
    }
    }
    }
    