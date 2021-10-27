using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using TextAdventure;
using Player_Stats;

namespace TextAdventure
{
    public class Encounters
    {
        public static Random rand = new Random();

        #region FirstEncounter
        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("Nach einer weile siehst du einen Schäbigen Holzkarren und davor eine Person in einem Mantel");
            Console.WriteLine("Du beobachtest die Person.");
            Console.WriteLine("Die Person bemerkte dich und zögert nicht dich anzugreifen.");
            Console.WriteLine("In wenigen Sekunden war er nur noch wenige Meter entfernt von dir.");
            Console.WriteLine("Instinktiv fässt du dir an die linke Hüfte und bekommst etwas zu greifen.....Ein Schwert!");
            MainStory.currentPlayer.Inventory.Add("Einfaches Schwert");
            Console.ReadKey();
            Combat(false, "Unbekannte Person", 2, 5, rand.Next(10, 20));
        }
        #endregion

        #region TutorialKampf
        //Encounter Tools
        static void Combat(bool random, string name, int power, int health, int experiencepoints)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int e = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
                e = experiencepoints;
            }
            while (h > 0)
            {
                if (MainStory.currentPlayer.HealthNow > MainStory.currentPlayer.Absolutehealth)
                    MainStory.currentPlayer.HealthNow = MainStory.currentPlayer.Absolutehealth;
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("====================================");
                Console.WriteLine("|         (A)ttack  (D)efend       |");
                Console.WriteLine("|   (M)agic      (R)un     (H)eal  |");
                Console.WriteLine("====================================");
                Console.WriteLine(" Potions: " + MainStory.currentPlayer.Potion + "  Health: " + MainStory.currentPlayer.HealthNow);
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Physic Attack
                    Console.WriteLine("Mit deinem Schwert gehst du ebenfalls in den Angriff und greifst den " + n + " an.");
                    int damage = p - MainStory.currentPlayer.ArmorPoints;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, MainStory.currentPlayer.AttackPoints) + rand.Next(1, 4);
                    Console.WriteLine("Du verlierst " + damage + " Leben und fügst ihm " + attack + " schaden zu.");
                    MainStory.currentPlayer.HealthNow -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("Du machst dich bereit den Angriff vom " + n + " zu blocken.");
                    int damage = (p / 4) - MainStory.currentPlayer.ArmorPoints;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, MainStory.currentPlayer.AttackPoints) / 2;
                    Console.WriteLine("Du verlierst " + damage + " Leben und fügst ihm " + attack + " Schaden zu.");
                    MainStory.currentPlayer.HealthNow -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "m" || input.ToLower() == "magic")
                {
                    //Magic Attack
                    Console.WriteLine("Du greifst den " + n + " mit Magie an.");
                    int damage = p - MainStory.currentPlayer.ArmorPoints;
                    int attack = rand.Next(0, MainStory.currentPlayer.MagicDamage) + rand.Next(1, 4);
                    Console.WriteLine("Du verlierst " + damage + " Leben und fügst ihm " + attack + " Schaden zu.");
                    MainStory.currentPlayer.HealthNow -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("Du rennst davon vom " + n + " und  er trifft dich mit seiner Waffe in den Rücken.");
                        int damage = p - MainStory.currentPlayer.ArmorPoints;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du verlierst " + damage + " Leben und kannst nicht entkommen.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Du kannst erfolgreich entkommen!");
                        Console.ReadKey();
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (MainStory.currentPlayer.Potion == 0)
                    {
                        Console.WriteLine("Du greifst nach einer Flasche in deinem Rucksack..., aber sie ist leer.");
                        int damage = p - MainStory.currentPlayer.ArmorPoints;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Während du nach einer Potion gesucht hast greift der " + n + " dich an und du verlierst " + damage + " Leben.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                        int potionV = 5;
                        Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                        MainStory.currentPlayer.HealthNow += potionV;
                        MainStory.currentPlayer.Potion -= 1;
                        Console.WriteLine("Wärend du den Trank genommen hast hat dich der " + n + " angegriffen");
                        int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Du hast " + damage + " Leben verloren.");
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
                while (MainStory.currentPlayer.HealthNow < 0)
                {
                    Console.WriteLine("Du wurdest besiegt!");
                    Console.WriteLine("Versuch es Nochmal!!!");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.NewChar(p);
                }
            }
            Console.Clear();
            int c = rand.Next(10, 30);
            int s = rand.Next(20, 50);
            int b = rand.Next(30, 90);
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("Du hast die " + n + " besiegt, und durchsuchts seine Taschen nach Wertsachen."); //leerzeichen hinter der Zahl
            Console.WriteLine("Du findest " + c + " Gold, " + s + "Silber, und " + b + "Bronzemünzen.");
            Console.WriteLine("Und du erhältst " + e + " Erfahrungspunkte.");
            if (MainStory.currentPlayer.CanLevelUp())
                MainStory.currentPlayer.LevelUp();
            Console.WriteLine("=============================================================================");
            MainStory.currentPlayer.GoldMuenzen += c;
            MainStory.currentPlayer.SilberMuenzen += s;
            MainStory.currentPlayer.BronzeMuenzen += b;
            MainStory.currentPlayer.Xp += e;
            Console.WriteLine("  ");
            Console.WriteLine("  ");

            Console.ReadKey();
            Console.Clear();
            MainStory.StoryTeil1Cover();

            
        }
        #endregion

        #region BossBattles
        public static void BossFightOne()
        {

        }

        public static void BossFightTwo()
        {

        }

        public static void BossFightThree()
        {

        }
        #endregion
    }
}

