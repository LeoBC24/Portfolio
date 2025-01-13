using System;

namespace _4_luento
{
    class Program
    
    {
        static void Main(string[]args)
        {
           // Esimerkki funktioiden ja luuppien yhdistämisestä

// Funktio joka piirtää suorakulmion annettuun kohtaan
// annetulla värillä
// Parametrit: sarake, rivi, leveys, korkeus, väri
void Suorakulmio(int sarake, int rivi, int leveys, int korkeus, ConsoleColor väri)
{
    // Vaihda taustaväri: suorakulmio piirretään välilyönneillä
    Console.BackgroundColor = väri;
    // Siirrä kursori suorakulmion vasempaan ylänurkkaan
    Console.SetCursorPosition(sarake, rivi);
    // Jokaisella rivillä...
    for(int piirtoRivi = 0; piirtoRivi < korkeus; piirtoRivi+=1)
    {
        // ... siirry takaisin alkusarakkeeseen,
        // ja aseta oikea rivi.
        // (ensimmäisellä kierroksella piirtoRivi on 0)
        Console.SetCursorPosition(sarake, rivi+piirtoRivi);

        // ... piirrä leveyden verran välilyöntejä
        for(int piirtoSarake = 0; piirtoSarake < leveys; piirtoSarake +=1)
        {
            Console.Write(" ");
        }
        // Rivi loppuu
    }
    // Suorakulmio on piirretty
    // Funktion tyyppi on void; ei tarvita return käskyä
}

// Funktio joka piirtää pallon annettuun kohtaan annetulla värillä
// Pallo rakentuu kahdesta päällekkäin olevasta suorakulmiosta
/*
XX XX
XX + XXXX = XXXX
XX + XXXX XXXX
XX XX
*/
void Pallo(int sarake, int rivi, ConsoleColor väri)
{
    Suorakulmio(sarake+2,rivi, 8, 4, väri);
    Suorakulmio(sarake, rivi+1, 12, 2, väri);
}

// Ohjelma alkaa tästä

// Piilota kursori, täytä ruutu sinisellä värillä
Console.CursorVisible = false;
Console.BackgroundColor = ConsoleColor.Blue;  //#00 00 FF
Console.Clear();


// Kutsu funktiota Suorakulmio
// for loopin sisällä. Piirrä rivi Suorakulmioita
for(int paikka=0; paikka < 6; paikka +=1)
{
    // muuttuja 'paikka' saa arvot 0, 1, 2, 3, 4, 5
    // Eli suorakulmiot tulevat kohtiin (0,3) (10,3) (20,3) jne...
    Suorakulmio(paikka*10, 3, 8, 4, ConsoleColor.Yellow);
}

// Odota että käyttäjä painaa jotain näppäintä
Console.ReadKey();

// Tyhjennä ruutu
Console.Clear();

// Kutsu Pallo funktiota kahden For loopin sisällä.
// Palloja on monta riviä ruudulla

// 4 riviä palloja
for (int pallorivi=0; pallorivi < 4; pallorivi+=1)
{
    // jokaisella rivillä 4 palloa
    for(int pallosarake=0; pallosarake<4;pallosarake+=1)
    {
        int rivi = pallorivi * 6; // Sarakkeen leveys on 6
        int sarake = pallosarake * 14; // Rivin korkeus on 14
        Pallo(sarake, rivi, ConsoleColor.Green);
        // Piirrä lisäksi pallon rivi ja sarake sen päälle
        Console.SetCursorPosition(sarake+2, rivi+2);
        Console.Write("P: " + pallosarake + "," + pallorivi);
    }
}

// Näytä pallot kunnes käyttäjä painaa jotain näppäintä
Console.ReadKey();

// Animaatiotesti: Piirrä kirjain X joka liikkuu oikealle
Console.Clear();
int animaatioSarake = 0; // sarake johon X piirrtään
while(true)
{
    System.Threading.Thread.Sleep(100); // Odota 0,1 sekuntia.

    // Poista edellinen X: Kirjoita välilyönti siihen missä X on nyt
    Console.SetCursorPosition(animaatioSarake, 1);
    Console.Write(" ");

    // Siirry eteenpäin ja piirrä X
    animaatioSarake += 1;
    Console.SetCursorPosition(animaatioSarake, 1);
    Console.Write("X");

    // Pysähdy kun ollaan saavutettu oikea reuna
    // Viimeinen sallittu paikka piirtää on WindoWidth-1
    if (animaatioSarake == Console.WindowWidth-1)
    {
        break;
    }
}
// Näytä että animaatio on loppunut
Console.WriteLine();
Console.Write("Loppu");

// Ohjelma loppuu kun käyttäjä painaa näppäintä
Console.ReadKey();
// Palauta alkuperäiset värit
Console.ResetColor();
 
        }
    }
}