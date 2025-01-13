using System.Diagnostics.Tracing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
namespace Random
{
    class Program
        {
        static int TeeKysymys(string kysymys, string oikeavastaus)
        {
            Console.WriteLine(kysymys);
            string vastaus = Console.ReadLine();
            if (vastaus.ToLower() == oikeavastaus.ToLower())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static int TeeKysymys(string kysymys, int oikeavastaus)
        {
            Console.Write(kysymys);
            bool oikeatyyppi;
            do{

                string vastaus = Console.ReadLine();
                int vastausluku;
                oikeatyyppi = int.TryParse(vastaus, out int vastausluku);
                if (oikeatyyppi)
                {
                {
                    if (vastausluku == 12){return 1;}
                }

                {
                    else
                    {return 0;}
                }
                }
            }
            }while( ! oikeatyyppi);
            return 0;
        public static void Main(string[]args)
        {
            int pisteet = 0;
            pisteet += TeeKysymys("Mikä on Ruotsin pääkaupunki?", "Tukholma");
            pisteet += TeeKysymys("Mikä on elämän tarkoitus", "42");
            pisteet += TeeKysymys("Montako kuukautta on vuodessa?", 12);

            Console.WriteLine(pisteet);
        }
        }
}
