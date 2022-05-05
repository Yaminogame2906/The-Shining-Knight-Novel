using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Player_Stats;
using TextAdventure;

namespace TextAdventure
{
    public class Shop
    {
        //public static Random rand = new Random();

        #region LoadShop
        public static void LoadShop(Player p)
        {
            //MainStory.soundStore.PlayLooping();
            Console.Clear();
            Console.WriteLine("   ");
            Console.WriteLine("Welchen Shop möchtest du betreten?");
            Console.WriteLine("  ");
            Console.WriteLine("=========================");
            Console.WriteLine("(K)aufen");
            Console.WriteLine("(V)erkaufen");
            Console.WriteLine("(T)auschen");
            Console.WriteLine("=========================");
            Console.WriteLine("   ");
            Console.WriteLine("(E)xit");
            string input = Console.ReadLine().ToLower();

            if (input == "k")
            {
                RunShop(p);
            }
            else if (input == "v")
            {
                RunSellShop(p);
            }
            else if (input == "t")
            {
                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("Wie möchtest du Tauschen?");
                Console.WriteLine("=========================");
                Console.WriteLine("(A) | Von Bronze zu Gold");
                Console.WriteLine("(B) | Von Gold zu Bronze");
                string inputtrade = Console.ReadLine().ToLower();

                if (inputtrade == "a")
                {
                    MünztauschBronzezuGold();
                }
                else if (inputtrade == "b")
                {
                    MünztauschGoldzuBronze();
                }
            }
            else if (input == "e")
            {
                Console.Clear();
                MainStory.soundStore.Stop();
                MainStory.Menü();
            }
            
        }
        #endregion

        #region RunBuyShop
        public static void RunShop(Player p)
        {
            int potionP;
            int potionPAdvanced;
            int potionPMaster;
            int christmasP;
            int christmasLP;
            int devwaffeP;

            while (true)
            {
                potionP = 10;
                potionPAdvanced = 20;
                potionPMaster = 20;
                christmasP = 5000;
                christmasLP = 100;
                devwaffeP = 100000;

                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("             Shop            ");
                Console.WriteLine("=============================");
                Console.WriteLine("(T)ränke Auswahl:     > ");
                if (Events.IsChristmas())
                {
                    if (MainStory.currentPlayer.Inventory.Contains("Weinachtsklinge"))
                    {
                        Console.WriteLine("Du hast diese Waffe bereits im Besitz!");
                    }
                    else
                    {
                        Console.WriteLine("(W)einachts-Klinge:   $ " + christmasP + "Gold");
                    }
                }
                else if (Events.IsChristmas())
                {
                    Console.WriteLine("(W)einachtslootbox:   $ " + christmasLP + "Gold");
                }
                else if (Events.DevelopersBirthday())
                {
                    if (MainStory.currentPlayer.Inventory.Contains("Developerwaffe"))
                    {
                        Console.WriteLine("Du hast diese Waffe bereits im Besitz!");
                    }
                    else
                    {
                        Console.WriteLine("(D)eveloper Waffe:    $ " + devwaffeP + "Gold");
                    }
                }
                Console.WriteLine("=============================");
                Console.WriteLine("  ");
                Console.WriteLine(p.Name + "'s Werte");
                Console.WriteLine("=============================");
                Console.WriteLine(" Derzeitige Leben: " + p.HealthNow + "/" + MainStory.currentPlayer.Absolutehealth);
                Console.WriteLine(" Geld:             " + p.GoldMuenzen + "G/" + p.SilberMuenzen + "S/" + p.BronzeMuenzen + "B");
                Console.WriteLine(" Waffen Stärke:    " + p.AttackPoints);
                Console.WriteLine(" Rüstungs Stärke:  " + p.ArmorPoints);
                Console.WriteLine(" Magie Stärke:     " + p.MagicDamage);
                Console.WriteLine(" Tränke:           " + p.Potion);
                Console.WriteLine(" Level:            " + p.Level);
                Console.WriteLine("=============================");
                Console.WriteLine("  ");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                string input = Console.ReadLine().ToLower();

                if (input == "t" || input == "tränke")
                {
                    Console.Clear();
                    Console.WriteLine("   ");
                    Console.WriteLine("Welche Art Trank möchtest du Kaufen?");
                    Console.WriteLine("   ");
                    Console.WriteLine("(E)infacher Trank:     $ " + potionP + "Bronze");
                    Console.WriteLine("(V)erstärkter Trank:   $ " + potionPAdvanced + "Silber");
                    Console.WriteLine("(M)eister Trank:       $ " + potionPMaster + "Gold");
                    Console.WriteLine("====================================");
                    Console.WriteLine("  ");
                    Console.WriteLine("Im Inventar");
                    Console.WriteLine("   ");
                    Console.WriteLine("Einfacher Trank:   " + MainStory.currentPlayer.Potion + "x");
                    Console.WriteLine("Verstärkter Trank: " + MainStory.currentPlayer.PotionAdvanced + "x");
                    Console.WriteLine("Meister Trank:     " + MainStory.currentPlayer.PotionMaster + "x");
                    Console.WriteLine("====================================");
                    Console.WriteLine("   ");
                    Console.WriteLine("(Z)urück");
                    string inputTränke = Console.ReadLine().ToLower();

                    if (inputTränke == "e")
                    {
                        TryBuy("tränke", potionP, p);
                    }
                    else if (inputTränke == "v")
                    {
                        TryBuy("tränkeAdvanced", potionPAdvanced, p);
                    }
                    else if (inputTränke == "m")
                    {
                        TryBuy("tränkeMaster", potionPMaster, p);
                    }
                    else if (inputTränke == "w")
                    {
                        if (Events.IsChristmas())
                        {
                            TryBuy("weinachtsklinge", christmasP, p);
                        }
                        else
                        {
                            Console.WriteLine("   ");
                            Console.WriteLine("Die Zeit für dieses EventItem ist noch nicht gekommen.");
                        }
                    }
                    else if (inputTränke == "d")
                    {
                        if (Events.DevelopersBirthday())
                        {
                            TryBuy("devblade", devwaffeP, p);
                        }
                        else
                        {
                            Console.WriteLine("   ");
                            Console.WriteLine("Die Zeit für dieses EventItem ist noch nicht gekommen.");
                        }
                    }
                    else if (inputTränke == "z")
                    {
                        Console.WriteLine("   ");
                        Console.WriteLine("Drücke 'Enter' um zurück zur Shopauswahl zu gelangen.");
                    }
                    
                }
                else if(input == "q" || input == "quit")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Quit();
                }
                else if (input == "e" || input == "exit")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Menü();
                }   
            }  
        }
        #endregion

        #region TryBuy
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.GoldMuenzen >= cost)
            {
                if (item == "tränke")
                    p.Potion++;
                else if (item == "tränkeAdvanced")
                    p.PotionAdvanced++;
                else if (item == "tränkeMaster")
                    p.PotionMaster++;
                else if (item == "weinachtsklinge")
                {
                    MainStory.currentPlayer.Inventory.Add("Weinachtsklinge");
                }   
                else if (item == "devblade")
                {
                    MainStory.currentPlayer.Inventory.Add("Developerwaffe");
                }
                p.GoldMuenzen -= cost;
            }
            else
            {
                Console.WriteLine("   ");
                Console.WriteLine("Du hast leider nicht genug Geld!");
                Console.ReadLine();
            }
        }
        #endregion

        #region RunSellShop
        static void RunSellShop(Player p)
        {
            p.Lootboxenanzahl = p.EinfacheLootbox + p.GlitzerndeLootbox + p.LeuchtendeLootbox;
            int lootboxenEinfachP;
            int lootboxenGlitzerndP;
            int lootboxenLeuchtendP;



            while (true)
            {
                lootboxenEinfachP = 10;
                lootboxenGlitzerndP = 25;
                lootboxenLeuchtendP = 50;

                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("           Sell Shop         ");
                Console.WriteLine("=============================");
                if (MainStory.currentPlayer.Lootboxenanzahl > 0)
                {
                    Console.WriteLine("(L)ootboxen:    " + ">");
                }
                else
                {
                    Console.WriteLine("Du hast derzeitig keine Items zum Verkaufen.");
                }
                Console.WriteLine("=============================");
                Console.WriteLine("  ");
                Console.WriteLine(p.Name + "'s Werte");
                Console.WriteLine("=============================");
                Console.WriteLine(" Derzeitige Leben: " + p.HealthNow + "/" + MainStory.currentPlayer.Absolutehealth);
                Console.WriteLine(" Geld:             " + p.GoldMuenzen + "G/" + p.SilberMuenzen + "S/" + p.BronzeMuenzen + "B");
                Console.WriteLine(" Waffen Stärke:    " + p.AttackPoints);
                Console.WriteLine(" Rüstungs Stärke:  " + p.ArmorPoints);
                Console.WriteLine(" Magie Stärke:     " + p.MagicDamage);
                Console.WriteLine(" Tränke:           " + p.Potion);
                Console.WriteLine(" Level:            " + p.Level);
                Console.WriteLine(" Lootboxen:        " + p.Lootboxenanzahl);
                Console.WriteLine("=============================");
                Console.WriteLine("  ");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                string input = Console.ReadLine().ToLower();

                if (input == "l")
                {
                    Console.Clear();
                    Console.WriteLine("   ");
                    Console.WriteLine("Welche Lootboxen Möchtest du Verkaufen?");
                    Console.WriteLine("");
                    Console.WriteLine("(E)infache Lootbox:    $ " + lootboxenEinfachP + "Bronze");
                    Console.WriteLine("(G)litzernde Lootbox   $ " + lootboxenGlitzerndP + "Silber");
                    Console.WriteLine("(L)euchtende Lootbox:  $ " + lootboxenLeuchtendP + "Gold");
                    Console.WriteLine("====================================");
                    Console.WriteLine("  ");
                    Console.WriteLine("(Z)urück");
                    string inputlootboxen = Console.ReadLine().ToLower();

                    if (inputlootboxen == "e")
                    {
                        TrySell("einfachelootbox", lootboxenEinfachP, p);
                    }
                    else if (inputlootboxen == "g")
                    {
                        TrySell("glitzerndelootbox", lootboxenGlitzerndP, p);
                    }
                    else if (inputlootboxen == "l")
                    {
                        TrySell("leuchtendelootbox", lootboxenLeuchtendP, p);
                    }
                    else if (inputlootboxen == "z")
                    {
                        
                    }
                }
                else if (input == "e")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Menü();
                }
                else if (input == "q")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Quit();
                }
                RunSellShop(p);
            }
        }
        #endregion

        #region TrySell
        static void TrySell(string item, int cost, Player p)
        {
            if (item == "einfachelootbox")
            {
                if(p.EinfacheLootbox >= 0)
                {
                    if (p.EinfacheLootbox == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("   ");
                        Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                        Console.ReadLine();
                    }
                    else
                    {
                        p.EinfacheLootbox --;
                        p.BronzeMuenzen += cost;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("   ");
                    Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                    Console.ReadLine();
                }
            }
            else if (item == "glitzerndelootbox")
            {
                if (p.GlitzerndeLootbox >= 0)
                {
                    if (p.GlitzerndeLootbox == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("   ");
                        Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                        Console.ReadLine();
                    }
                    else
                    {
                        p.GlitzerndeLootbox --;
                        p.SilberMuenzen += cost;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("   ");
                    Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                    Console.ReadLine();
                }
            }
            else if (item == "leuchtendelootbox")
            {
                if (p.LeuchtendeLootbox >= 0)
                {
                    if (p.LeuchtendeLootbox == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("   ");
                        Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                        Console.ReadLine();
                    }
                    else
                    {
                        p.LeuchtendeLootbox--;
                        p.GoldMuenzen += cost;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("   ");
                    Console.WriteLine("Du hast nicht genug Items zum Verkaufen");
                    Console.ReadLine();
                }
            }

        }
        #endregion

        #region Münztausch
        public static void MünztauschBronzezuGold()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("================================");
                Console.WriteLine("Goldmünzen:      $" + MainStory.currentPlayer.GoldMuenzen);
                Console.WriteLine("Silbermünzen:    $" + MainStory.currentPlayer.SilberMuenzen);
                Console.WriteLine("Bronzemünzen:    $" + MainStory.currentPlayer.BronzeMuenzen);
                Console.WriteLine("================================");
                Console.WriteLine("(S)ilber || 10B = 1S");
                Console.WriteLine("(G)old   || 10S = 1G");
                Console.WriteLine("================================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                string input = Console.ReadLine().ToLower();

                if (input == "s")
                {
                    if (MainStory.currentPlayer.BronzeMuenzen >= 10)
                    {
                        if (MainStory.currentPlayer.BronzeMuenzen <= 9)
                        {
                            Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                        }
                        else
                        {
                            MainStory.currentPlayer.BronzeMuenzen -= 10;
                            MainStory.currentPlayer.SilberMuenzen += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                    }
                }
                else if (input == "g")
                {
                    if (MainStory.currentPlayer.SilberMuenzen >= 10)
                    {
                        if (MainStory.currentPlayer.SilberMuenzen <= 9)
                        {
                            Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                        }
                        else
                        {
                            MainStory.currentPlayer.SilberMuenzen -= 10;
                            MainStory.currentPlayer.GoldMuenzen += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                    }
                }
                else if (input == "e")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Menü();
                }
                else if (input == "q")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Quit();
                }
            }
            
        }
        public static void MünztauschGoldzuBronze()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("================================");
                Console.WriteLine("Goldmünzen:      $" + MainStory.currentPlayer.GoldMuenzen);
                Console.WriteLine("Silbermünzen:    $" + MainStory.currentPlayer.SilberMuenzen);
                Console.WriteLine("Bronzemünzen:    $" + MainStory.currentPlayer.BronzeMuenzen);
                Console.WriteLine("================================");
                Console.WriteLine("(S)ilber || 1G = 10S");
                Console.WriteLine("(B)ronze || 1S = 10B");
                Console.WriteLine("================================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");
                string input = Console.ReadLine().ToLower();

                if (input == "s")
                {
                    if (MainStory.currentPlayer.GoldMuenzen >= 1)
                    {
                        if (MainStory.currentPlayer.GoldMuenzen <= 0)
                        {
                            Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                        }
                        else
                        {
                            MainStory.currentPlayer.GoldMuenzen -= 1;
                            MainStory.currentPlayer.SilberMuenzen += 10;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                    }
                }
                else if (input == "b")
                {
                    if (MainStory.currentPlayer.SilberMuenzen >= 1)
                    {
                        if (MainStory.currentPlayer.SilberMuenzen <= 0)
                        {
                            Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                        }
                        else
                        {
                            MainStory.currentPlayer.SilberMuenzen -= 1;
                            MainStory.currentPlayer.BronzeMuenzen += 10;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du hast nicht genügend Münzen zum Tauschen.");
                    }
                }
                else if (input == "e")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Menü();
                }
                else if (input == "q")
                {
                    MainStory.soundStore.Stop();
                    MainStory.Quit();
                }
            }
        }
        #endregion
    }
}
