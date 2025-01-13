using System;
namespace tehtävä22
{
    class Program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Write some text with more that 10 letters");
            string input = Console.ReadLine();
            if(input.Length < 10)
            {
                Console.WriteLine("Too short input " + input);;
            }
            else
            {
            Console.WriteLine(input.Substring(0,10));
            }
        }
    }
}