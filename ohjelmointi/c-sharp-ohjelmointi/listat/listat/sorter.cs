namespace listat
{
    // Luokka Sorter sisältää järjestämiseen liittyviä
    // funktioita
    class Sorter
    {
        /// <summary>
        /// Tarkistaa onko annettu taulukko järjestyksessä. Jos on, niin palauttaa true. Jos ei ole, palauttaa false.
        /// </summary>
        /// <param name="taulukko">taulukko jossa on lukuja</param>
        /// <returns>true jos taulukko on järjestyksessä</returns>
        public bool Tarkista(int[] taulukko)
        {
            // Jos kaikki luvut ovat suuruusjärjestykssä
            // palauta true
            // jos yksikin luku on väärässä paikassa
            // palauta false
            bool jarjestyksessa = true; // Oleta että kunnossa
            for(int i = 0; i < taulukko.Length -1 ; i+=1)
            {
                // saa olla pienempi tai sama
                if (taulukko[i] <= taulukko[i+1] )
                {
                    // OK
                    // ei tarvitse tehdä mitään
                }
                else
                {
                    // Ei saa olla suurempi!
                    jarjestyksessa =  false;
                    // Muita lukuja ei tarvitse enää tarkistaa, lopeta luuppi.
                    break;
                }
            }
            // Lopulta palauta lopputulos
            return jarjestyksessa;
        }
        /// <summary>
        /// Järjestää annetun taulukon ja palauttaa sen
        /// </summary>
        /// <param name="taulukko">Taulukko joka pitää järjestää suuruusjärjestykseen</param>
        /// <returns>Taulukko joka on järjestetty</returns>
        public int[] JarjestaTaulukko(int[] taulukko)
        {
            // Käy kaikki luvut läpi
            // Jokaisen luvun kohdalla:
            // Vertaa lukua seuraavaan lukuun.
            // Jos luku on suurempi kuin seuraava, vaihda
            // sen ja seuraavan luvun paikkoja keskenään
            // Jos ollaan viimeisessä luvussa, lopeta luuppi, koska
            // seuraavaa lukua ei ole
            for(int i = 0; i < taulukko.Length; i+=1)
            {
                // Lopeta kun olet viimeisen luvun kohdalla
                if(i == taulukko.Length-1)
                {
                    break;
                }
                // Vertaa ja vaihda:
                // [2, 1]
                // Vertaa kahta lukua A ja B keskenään:
                // Jos A > B : vaihda lukujen paikat
                // Jos A == B : Älä tee mitään
                // Jos A < B : Älä tee mitään
                if (taulukko[i] > taulukko[i+1])
                {
                    // Tee muuttuja vara, johon tallennetaan
                    // seuraava luku vaihtamisen ajaksi
                    int vara = taulukko[i+1];
                    taulukko[i+1] = taulukko[i];
                    taulukko[i] = vara;
                }
            }

            // Palauta käsitelty taulukko
            return taulukko;
        }
    }
}