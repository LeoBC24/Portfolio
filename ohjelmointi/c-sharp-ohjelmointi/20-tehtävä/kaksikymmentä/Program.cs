using System;


namespace yhdeksäntoista{
    class Program{
        static void Main(string[]args)
        {
            Console.WriteLine("Anna numero: ");
            int number;
            number = Int32.Parse(Console.ReadLine());
            if (number >= 1 && number <= 10|| number % 3 == 0 || number > 100 || number < 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
}
}