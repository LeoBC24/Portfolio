using System;

namespace kertaus
{
    
    class Program
    {
        static void Main (string[] args)
        {
            bool onnistui;
            do
            {
            string vastaus = Console.ReadLine();
            int luku;
            
            onnistui = int.TryParse(vastaus, out luku);
            if (onnistui)
            {
                Console.WriteLine("Annoit luvun " + luku);
            }
            else
            {
                Console.WriteLine("Virhe! Anna kunnollinen luku:");
            }
            } while(onnistui == false);

            Console.WriteLine("Loppu");
        }
    }
}
