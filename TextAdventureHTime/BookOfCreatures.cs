using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure;
using Player_Stats;

namespace TextAdventure
{
    public class BookOfCreatures
    {
        public static void DasBuchDerWesenEinband()
        {
            Console.WriteLine("  ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|_____________________________________________|");
            Console.WriteLine("  ");
            Console.WriteLine("              (Z)urück    (W)eiter             ");

            string input = Console.ReadLine().ToLower();

            if (input == "z" || input == "zurück")
            {
                //Player.Inventar();
            }
            if (input == "w" || input == "weiter")
            {
                Instruction();
            }
        }
        static void Instruction()
        {
            Console.WriteLine("  ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|_____________________________________________|");
            Console.WriteLine("  ");
            Console.WriteLine("              (Z)urück    (W)eiter             ");

            string input = Console.ReadLine().ToLower();

            if (input == "z" || input == "zurück")
            {
                DasBuchDerWesenEinband();
            }
            if (input == "w" || input == "weiter")
            {
                Inhaltsverzeichnis();
            }
        }

        static void Inhaltsverzeichnis()
        {
            Console.WriteLine("  ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|_____________________________________________|");
            Console.WriteLine("  ");
            Console.WriteLine("              (Z)urück    (W)eiter             ");

            string input = Console.ReadLine().ToLower();
            if (input == "z" || input == "zurück")
            {
                Instruction();
            }
            if (input == "i" || input == "inhaltsverzeichnis")
            {
                Seite1();
            }

        }

        static void Seite1()
        {

        }



    }

}
