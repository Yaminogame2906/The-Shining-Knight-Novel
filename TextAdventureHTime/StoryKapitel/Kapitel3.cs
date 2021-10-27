using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Kapitel3
    {
        public static void Kapitel3Vorhang()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  ");
            Console.WriteLine("===================KAPITEL 3===================");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("------------______------------");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Kapitel3Story();
        }

        public static void Kapitel3Story()
        {
            MainStory.Menü();
        }

    }
}
