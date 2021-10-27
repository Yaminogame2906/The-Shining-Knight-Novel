using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Kapitel2
    {
        public static void Kapitel2Vorhang()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  ");
            Console.WriteLine("===================KAPITEL 2===================");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("------------!Die zwei Geschwister!-------------");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Kapitel2Story();
        }

        public static void Kapitel2Story()
        {
            MainStory.currentPlayer.StoryKapitel2 = true;
            MainStory.Menü();
        }
    }
}
