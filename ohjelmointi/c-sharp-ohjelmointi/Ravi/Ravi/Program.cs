namespace Ravi
{
    class Program
    {
        public static void Main()
        {
            // Jokaisella hevosella on
            // - lempiruoka : string
            // - nopeus : float
            // - kilpailunumero : int
            // - nimi : string

            Horse[] hevoset;

            // Luo 3 hevosta
            hevoset = new Horse[3];
            
            

            hevoset[0] = new Horse("Omena","Kallion keisari",1234, 19.1f);
        
        
            Horse h0 = hevoset[0];
            h0.TulostaTiedot();

            hevoset[1] = new Horse("Peruna", "Kekkonen", 6435, 12.0f);
        
            hevoset[2] = new Horse("Sokeripala", "Mansikka", 523, 1.0f);

            // hevoset[2].kyllaisyys = 300.0f; ei voi koska private
            hevoset[2].AnnaRuoka(3);

            Veikkauslippu v1 = new Veikkauslippu(124, 50.0f);
            Veikkauslippu v2 = v1;
            v2.Lunasta();

            Horse kekkonen = hevoset[1];
            Horse kakkonen = kekkonen;
            kakkonen.AnnaRuoka(100);

            v1.TulostaTiedot();
            v2.TulostaTiedot();

            while(true)
            {
                Console.WriteLine("Valitse toiminto");
                Console.WriteLine("1. Näytä hevosten tiedot");
                Console.WriteLine("2. Ruoki hevosta");
                Console.WriteLine("3. Järjestä kilpailu");
                Console.WriteLine("4. Lopeta peli");
            
            int vastaus = Int32.Parse(Console.ReadLine());
            switch(vastaus)
            {
                case 1:
                for(int i = 0; i < hevoset.Length; i +=1)
            {
                hevoset[i].TulostaTiedot();
            }
            break;

            case 2:
            Console.WriteLine("Anna hevosen numero 1-3");
            int heppa = Int32.Parse(Console.ReadLine());
            hevoset[heppa-1].AnnaRuoka(1);
            break;
            }
            }
        }
    }
}