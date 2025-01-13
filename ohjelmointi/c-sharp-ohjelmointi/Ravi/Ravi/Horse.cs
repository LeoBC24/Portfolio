namespace Ravi
{
    /// <summary>
    /// Tämä luokka esittää ravihevosta joka
    /// juoksee ympäri rataa
    /// </summary>
    class Horse
    {
        public string lempiruoka;
        public float nopeus;
        public int kilpailunumero;
        public string nimi;
        private float kyllaisyys;
        /// <summary>
        /// //Luo uuden hevosen joka on valmis kilpailemaan
        /// </summary>
        /// <param name="ruoka">Hevosen lempiruoka</param>
        /// <param name="nimi">Hevosen kilpailunimi</param>
        /// <param name="kilpailunumero">Hevosen kilpailunumero</param>
        /// <param name="nopeus">Hevosen nopeusyksikkö on kilometrejä tunnissa km/h</param>
        // Luokan konstruktori määrittää mitä
        // tietoja pitää antaa kun luodaan 
        // uusi olio
        // Konstruktorin nimi on sama kuin
        // luokan nimi
        public Horse(string ruoka, string nimi, int kilpailunumero,float nopeus)
        {
            if(nopeus > 0)
            {
                this.nopeus = nopeus;
            }
            this.nimi = nimi;
            this.kilpailunumero = kilpailunumero;
            this.lempiruoka = ruoka;
        }

        public void AnnaRuoka(int annoksia)
        {
            if (annoksia > 0)
            {
            kyllaisyys += 0.1f * annoksia;
            if(kyllaisyys > 100)
            {
            kyllaisyys = 100.0f;
            }
            }
        }
        public Horse()
        {
        
        }
        // Luokan funktiot
        // huom: ei static määrettä

        public void TulostaTiedot()
        {
            // Luokan funktio voi käyttää
            // Luokan muuttujia.
            Console.WriteLine($"Nimi: {this.nimi} Kilpailunumero: {kilpailunumero}");
        }
    }
}