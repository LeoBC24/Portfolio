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
        int width = dnaPattern[0].Length;

        Console.CursorVisible = false;

        try
        {
            while (true)
            {
                for (int i = 0; i < lines; i++)
                {
                    Console.Clear();
                    PrintPattern(i);
                    Thread.Sleep(60);
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
        for (int i = 0; i < dnaPattern.Length; i++)
        {
            int index = (i + offset) % dnaPattern.Length;
            Console.WriteLine(dnaPattern[index]);
        }
    }
}
