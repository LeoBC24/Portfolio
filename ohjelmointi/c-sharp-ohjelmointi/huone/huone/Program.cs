using System;

class PyramidProgram
{
    static void Main()
    {
        int height = 5;  // Pyramiidin korkeus

        // Piirrä tavallinen pyramiidi
        DrawPyramid(height);

        // Piirrä käänteinen pyramiidi
        DrawInversePyramid(height);
    }

    // Funktio tavallisen pyramiidin piirtämiseen
    static void DrawPyramid(int height)
    {
        for (int i = 1; i <= height; i++)
        {
            // Piirretään tyhjiä paikkoja vasemmalle
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write(" ");
            }

            // Piirretään tähtiä
            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            // Siirrytään seuraavalle riville
            Console.WriteLine();
        }
    }

    // Funktio käänteisen pyramiidin piirtämiseen
    static void DrawInversePyramid(int height)
    {
        for (int i = height; i >= 1; i--)
        {
            // Piirretään tyhjiä paikkoja vasemmalle
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write(" ");
            }

            // Piirretään tähtiä
            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            // Siirrytään seuraavalle riville
            Console.WriteLine();
        }
    }
}
