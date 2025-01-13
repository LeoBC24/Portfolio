// namespace (nimiavaruus) saman niminen kuin Projekti
namespace listat
{
    // class (luokka) saman niminen kuin tiedosto
    class Program
    {
        public static int[]? KopioiTaulukko(int[]taulukko)
        {
            int koko = taulukko.Length;
            int [] kopio = new int [koko];
            
            if(kopio == null)
            {
                Console.WriteLine("Ei tarpeeksi muistia");
                return null;
            }
            for(int i = 0; i < taulukko.Length; i+=1)
            {
                kopio[i] = taulukko[i];
            }
            return kopio;
        }
        public static void Main()
        {
            // Ohjelma alkaa tästä

            // luo uusi kokonaislukutaulukko,
            // jossa luvut menevät suuresta pieneen.
            // Kun saat helpon taulukon toimimaan oikein,
            // kokeile pidempiä ja vaikeampia taulukoita
            int[] luvut = new int[]{3,2,1};
            
            int[] kopio = luvut;

            int[] aitoKopio = KopioiTaulukko(luvut);

            kopio[0] = 500;
            aitoKopio[0] = 4512;

            int A = 5;
            int B = 4;

            B = A;
            B += 1;

            Console.WriteLine($"A on {A} ja on {B}");
            // Lähetä taulukko järjesttäväksi niin että
            // pienin luku on ensin
            
            // Luo uusi Sorter tyyppinen olio ja anna sen nimeksi jarjestaja
            Sorter jarjestaja = new Sorter();

            // Kutsu jarjestaja olion funktiota JarjestaTaulukko
            int[] jarjestetty = jarjestaja.JarjestaTaulukko(luvut);

            // Tarkista että kaikki meni oikein käyttämällä
            // jarjestaja olion funktiota OnkoJarjestyksessa
            if (jarjestaja.OnkoJarjestyksessa(jarjestetty))
            {
                Console.WriteLine("Järjestäminen onnistui");
            }
            else
            {
                Console.WriteLine("Järjestäminen meni pieleen :(");
            }

            // Lopuksi tulosta järjestetyn taulukon luvut
            for(int i = 0; i < jarjestetty.Length; i+=1)
            {
                // Jos merkkijonon edessä on $, (Option + 4)
                // se tarkoittaa että merkkijonon sisälle voi laittaa
                // aaltosulkuihin muuttujien nimiä ja muuta koodia ja
                // C# osaa laittaa ne osaksi merkkijonoa
                Console.WriteLine($"Luku {i} on {jarjestetty[i]}");

                // Tämän voisi kirjoittaa myös näin:
                Console.WriteLine("Luku " + i + " on " + jarjestetty[i]);
            }
        }
    }
}
 