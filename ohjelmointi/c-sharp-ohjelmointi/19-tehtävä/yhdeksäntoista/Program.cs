using System;


namespace yhdeksäntoista{
    class Program{
        static void Main(string[]args)
        {
            Console.WriteLine("Anna numero");

            int numero1;
            int numero2;
        

            numero1 = Int32.Parse(Console.ReadLine());
            numero2 = Int32.Parse(Console.ReadLine());


            int result1 = Math.Abs(1000 - numero1);
            int result2 = Math.Abs(1000 - numero2);

            if(result1 == result2)
            {
                Console.WriteLine("numerot samat: ");
            }
            else{
                if(result1 < result2)
                {
                    Console.WriteLine("Lähin luku " + numero1);
                }
                else
                {
                    Console.WriteLine("Lähin luku " + numero2);
                }
            }

        }
    }
}