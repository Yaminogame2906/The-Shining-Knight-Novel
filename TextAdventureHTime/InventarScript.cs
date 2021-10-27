using System;
using System.Collections.Generic;
using System.Text;
using TextAdventure;

namespace TextAdventure
{
    [Serializable]
    public class InventarScript
    {
        public List<string> Inventory { get; set; } = new List<string>();
        public Player_Stats.Player Inventar()
        {
            Console.Clear();
            Console.WriteLine("Inventar:");
            foreach (string item in Inventory)
            {
                Console.WriteLine("|      " + item + "   ");
                Console.WriteLine("======================");
                Console.WriteLine("|      " + item + "   ");
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("(B)uch der Wesen lesen");
            Console.WriteLine("(E)xit");
            string input = Console.ReadLine();

            if (input.ToLower() == "e" || input.ToLower() == "exit")
            {
                MainStory.Menü();
            }
            else if (input.ToLower() == "b" || input.ToLower() == "buch")
            {
                BookOfCreatures.DasBuchDerWesenEinband();
            }
            Console.ReadLine();
            MainStory.Save();
            return MainStory.currentPlayer;
        }
    }
}
