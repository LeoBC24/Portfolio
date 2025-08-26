using System;
using System.Threading;

class Program
{
    static string[] dnaPattern = {
        "     ##",
        "    #G-C#",
        "   #C---G#",
        "  #T-----A#",
        " #T------A#",
        "#A------T#",
        "#G-----C#",
        " #G---C#",
        " #C-G#",
        "  ##",
        " #T-A#",
        " #C---G#",
        "#G-----C#",
        "#G------C#",
        " #T------A#",
        "  #A-----T#",
        "   #C---G#",
        "    #G-C#",
    };

    static void Main()
    {
        int lines = dnaPattern.Length;
        Console.CursorVisible = false;

        try
        {
            while (true)
            {
                for (int i = 0; i < lines; i++)
                {
                    Console.Clear();
                    PrintPattern(i);
                    Thread.Sleep(60); // Täältä voi säätää nopeuden
                }
            }
        }
        catch (ThreadInterruptedException)
        {
            Console.CursorVisible = true;
            Console.WriteLine("\nProgram interrupted.");
        }
    }

    static void PrintPattern(int offset)
    {
        int consoleWidth = Console.WindowWidth;
        int patternWidth = GetMaxPatternWidth();

        int padding = (consoleWidth - patternWidth) / 2;

        for (int i = 0; i < dnaPattern.Length; i++)
        {
            int index = (i + offset) % dnaPattern.Length;
            string line = dnaPattern[index];

            Console.Write(new string(' ', padding));

            foreach (char ch in line)
            {
                Console.ForegroundColor = CharacterColor(ch);
                Console.Write(ch);
            }

            Console.WriteLine();
        }
    }

    static int GetMaxPatternWidth()
    {
        int maxWidth = 0;

        foreach (string line in dnaPattern)
        {
            if (line.Length > maxWidth)
            {
                maxWidth = line.Length;
            }
        }

        return maxWidth;
    }

    static ConsoleColor CharacterColor(char ch) // lisäsin väriä kirjaimiin
    {
        switch (ch)
        {
            case 'G':
                return ConsoleColor.DarkGreen;
            case 'C':
                return ConsoleColor.DarkBlue;
            case 'T':
                return ConsoleColor.DarkYellow;
            case 'A':
                return ConsoleColor.DarkRed;
            default:
                return ConsoleColor.Black;
        }
    }
}
