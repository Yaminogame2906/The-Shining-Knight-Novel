using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Player_Stats;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using TextAdventure;
using System.Media;
using System.Text.Json;
using System.Text.Json.Serialization;
using NAudio;
using System.Diagnostics;

namespace TextAdventure
{
    public class MainStory
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        #region SoundPlayer
        public static SoundPlayer soundStore = new SoundPlayer(@"C:\Users\mueller\Documents\GitHub\The-Shining-Knight-Novel\TextAdventureHTime\bin\Debug\netcoreapp3.1\sounds\hm.wav"); //by AntHorny91
        public static SoundPlayer soundStory1;
        public static SoundPlayer soundStory2;
        public static SoundPlayer soundStory3;
        public static SoundPlayer soundDungeon = new SoundPlayer(@"C:\Users\mueller\Documents\GitHub\The-Shining-Knight-Novel\TextAdventureHTime\bin\Debug\netcoreapp3.1\sounds\DungeonMusic.wav"); //by Zane Again
        public static SoundPlayer soundPlayerStats;

        #region ActionSounds
        public static SoundPlayer soundDungeonGate = new SoundPlayer(@"C:\Users\mueller\Documents\GitHub\The-Shining-Knight-Novel\TextAdventureHTime\bin\Debug\netcoreapp3.1\sounds\ObjektSounds\Dungeon Door sound effect.wav");
        #endregion
        #endregion


        #region Main
        public static void Main(string[] args)
        {
            if (!Directory.Exists("Saves"))
            {
                Directory.CreateDirectory("Saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
                Encounters.FirstEncounter();
            while (mainLoop)
            {
                Menü();
            }
            NewChar(1);
        }
        #endregion

        #region Char
        public static Player NewChar(int i)
        {
            //Instruction ist gleich hier Mit drinnen.
            Player p = new Player();

            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("Willkommen zu diesem TextAdventure!. " +
                "Bevor du Starten kannst musst du dir einen Namen geben.");
            Console.WriteLine("  ");
            Console.WriteLine("==========================");
            Console.WriteLine("Name:");
            currentPlayer.Name = Console.ReadLine();
            currentPlayer.Id = i;
            currentPlayer.Weaponname = "Bob";
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("....Es ist dunkel,..... und feucht..... ");
            Console.WriteLine("Du spürst nasses Laub unter dir und hörst den Wind pfeifen.");
            Console.WriteLine("Es ist kalt und in der Feuerstelle glüht nur noch ein kleines bisschen Kohle.");
            Console.WriteLine("Nicht viel, aber es reicht um dich ein wenig zu wärmen.");
            Console.WriteLine("Nachdem sich deine Augen an die Dunkelheit gewöhnt haben, erkennst du, dass du in einem Wald bist.");

            if (currentPlayer.Name == "")
                Console.WriteLine("Du versuchst dich an irgendwas zu erinnern, aber nichts. Nicht mal an deinen Namen kannst dich erinnern....");
            else
                Console.WriteLine("Du versuchst dich zu Erinnern an das was passiert ist aber.... du weißt nur noch das du, " + currentPlayer.Name + " heißt");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Es wird Tag und du machst dich nach einer kalten Nacht auf und läufst ein Stück bis du an einen Weg ankommst.");
            Console.WriteLine("Auf dem Weg findest du eine Tasche. In ihr befindet sich....");
            Console.WriteLine("  ");
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("5 Tränke");
            currentPlayer.Potion += 5;
            Console.ResetColor();
            Console.WriteLine("&");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("30 Münzen");
            Console.WriteLine("  ");
            currentPlayer.GoldMuenzen += 30;
            Console.ResetColor();
            Console.WriteLine("Du schaust dich um ob jemand in der nähe ist. Du siehst niemanden und erkennst stattdessen ein Schild am wegesrand");
            Console.WriteLine("Die Schrift ist aber so verwischt, dass du nichts lesen kannst.");
            return currentPlayer;
        }
        #endregion
        
        #region Menü
        public static void Menü()
        {
            if(MainStory.currentPlayer.Level >= 5)
            {
                MainStory.currentPlayer.SkilltreeUse = true;
            }
            MainStory.currentPlayer.HealthNow = MainStory.currentPlayer.Absolutehealth;
            //soundMenu.Play();
            Console.Clear();
            Console.WriteLine("///////////////////");
            Console.WriteLine("||    Taverne    ||");
            Console.WriteLine("///////////////////");
            Console.WriteLine("                   ");
            Console.WriteLine("===================");
            Console.WriteLine("||  (F)ortzetzen ||");
            Console.WriteLine("===================");
            Console.WriteLine("||   (D)ungeon   ||");
            Console.WriteLine("===================");
            Console.WriteLine("||   (A)usruhen  ||");
            Console.WriteLine("===================");
            Console.WriteLine("||     (S)hop    ||");
            Console.WriteLine("===================");
            Console.WriteLine("||   (I)nventar  ||");
            Console.WriteLine("===================");
            Console.WriteLine("||    (W)erte    ||");
            Console.WriteLine("===================");
            Console.WriteLine("||   (C)redits   ||");
            Console.WriteLine("===================");
            Console.WriteLine("||    (H)ilfe    ||");
            Console.WriteLine("===================");
            Console.WriteLine("||  (P)assword   ||");
            Console.WriteLine("===================");
            Console.WriteLine("||     (Q)uit    ||");
            Console.WriteLine("===================");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            if (currentPlayer.HealthNow < 0)
            {
                Console.WriteLine("Du solltest dich heilen gehen bevor du mit der Story oder dem Dungeon fortfährst.");
            }
            else if (currentPlayer.HealthNow == 0)
            {
                Console.WriteLine("   ");
                Console.WriteLine("Du solltest dich heilen gehen bevor du mit der Story oder dem Dungeon fortfährst.");
            }
            else if (Events.IsChristmas())
            {
                Console.WriteLine("   ");
                Console.WriteLine("   ");
                Console.WriteLine("Es ist Weinachten schau dich um. Vielleicht gibt es ja besondere Items und Gegner.");
            }
            else if (currentPlayer.DemoGame == true)
            {
                Console.WriteLine("Dies ist die Demoversion. Du kannst im Dungeon Kämpfen und Leveln.");
                Console.WriteLine("Die fortsetzung der Story ist in der Vollversion des Spiel enthalten!");
            }
            string input = Console.ReadLine();
            //soundMenu.Stop();

            if (input.ToLower() == "f" || input.ToLower() == "fortsetzen")
            {
                //Story
                //DemoGame
                if (currentPlayer.DemoGame == true)
                {
                    DemoGame();

                    //Fertiges Game
                    if (currentPlayer.StoryKapitel2 == false)
                    {
                        Kapitel2.Kapitel2Vorhang();
                    }
                    else
                    {
                        if (currentPlayer.StoryKapitel3 == false)
                        {
                            Kapitel3.Kapitel3Vorhang();
                        }
                        else
                        {
                            if (currentPlayer.StoryKapitel4 == false)
                            {
                                Kapitel4.Kapitel4Vorhang();
                            }
                        }
                    }
                }   
            }
            else if (input.ToLower() == "d" || input.ToLower() == "dungeon")
            {
                //Dungeon
                Dungeon.DungeonEintritt();
            }
            else if (input.ToLower() == "a")
            {
                currentPlayer.HealthNow = currentPlayer.Absolutehealth;
                currentPlayer.ManaNow = currentPlayer.AbsoluteMana;

                Console.WriteLine("Du Ruhst dich aus! Dein Leben und Mana wurde aufgefüllt");
                Console.ReadLine().ToLower();
                Menü();
            }
            else if (input.ToLower() == "s" || input.ToLower() == "shop")
            {
                //Shop
                Shop.LoadShop(currentPlayer);
            }
            else if (input.ToLower() == "i" || input.ToLower() == "inventar")
            {
                //Spielerinventar
                Console.Clear();
                currentPlayer.Inventar();
            }
            else if (input.ToLower() == "w" || input.ToLower() == "werte")
            {
                //Spielerübersicht
                PlayerStats();
            }
            else if (input.ToLower() == "c" || input.ToLower() == "credits")
            {
                //Spielerübersicht
                Credits();
            }
            else if (input.ToLower() == "h" || input.ToLower() == "hilfe")
            {
                //Spielerübersicht
                Hilfe();
            }
            else if (input.ToLower() == "p" || input.ToLower()== "passwort") 
            {
                Console.WriteLine("Tragen sie bitte eine Kombination ein.");
                string inputcode = Console.ReadLine();

                if (inputcode.ToLower() == "adventurestart")
                {
                    currentPlayer.DemoGame = false;
                }
                else
                {
                    Console.WriteLine("Der Code stimmt nicht mit der Datenbank überein!!!!!!");
                }
            }
            else if (input.ToLower() == "q" || input.ToLower() == "quit")
            {
                //Spielerübersicht
                Quit();
            }
        }
        #endregion

        #region Prolog
        public static void StoryTeil1Cover()
        {
            Console.WriteLine("  ");
            Console.WriteLine("Nachdem du das Gold verstaut und dich von diesem Kampf erholt hast durchsuchst du den Wagen.");
            currentPlayer.HealthNow = currentPlayer.Absolutehealth;
            Console.WriteLine("Im Wagen findest du ein Buch.");
            Console.WriteLine("  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("->Das Buch der Wesen<-");
            Console.ResetColor();
            Console.WriteLine("  ");
            currentPlayer.Inventory.Add("Das Buch der Wesen");
            Console.WriteLine("Du steckst das Buch in deine Tasche und suchst weiter.");
            Console.WriteLine("Beim weitersuchen siehst du jemanden hinter ein paar Kisten liegen.......eine Frau");
            Console.WriteLine("Sie sieht zwar aus wie ein gewöhnlicher Mensch, Aber sie hat lange spitze Ohren und ist sehr Blass.");
            Console.WriteLine("Sie ist gefesselt worden und liegt auf einer kleinen Schicht aus Stroh.");
            Console.WriteLine("Du befreist sie von ihren fesseln und gibst ihr einen Heiltrank");
            //currentPlayer.heroPoints += 1;
            //heiltrank abziehen
            Console.WriteLine("Sie versucht aufzustehen. Aber die fesseln hatten ihre Beine sehr zugesetzt.");
            Console.WriteLine("Sie hat Angst. Du setzt dich etwas weiter weg hin und starrt ins leere. Nach ein paar Minuten des Schweigens erklärst du ihr was passiert ist.");
            Console.WriteLine("Nach der Erzählung stehst du auf und hältst ihr die Hand hin. Sie greift nach ihr..., wenn auch zögerlich.");
            Console.WriteLine("Mit der Frau und dem Karren fährst du in die nächste Stadt.");
            Console.ReadKey();
            Console.Clear();
            Kapitel1Vorhang();
        }
        #endregion

        #region Kapitel 1 Vorhang
        public static void Kapitel1Vorhang()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  ");
            Console.WriteLine("===================KAPITEL 1===================");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("------------!Das Abenteuer beginnt!------------");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Kapitel1();
        }
        #endregion

        #region Kapitel 1
        public static void Kapitel1()
        {
            Console.WriteLine("  ");
            Console.WriteLine("In der Stadt angekommen fährst du zum nächsten Arzt, der sich ihre Verletzungen anschaut.");
            Console.WriteLine("Du fragst den Arzt was sie ist. Der Arzt sagt nur kurz und knapp, das es sich hier um eine Elfin handelt.");
            Console.WriteLine("Du schaust sie an. Sie versucht deinem Blick auszuweichen... aber das funktionierte nur halb. Immer wieder schaut sie dich an.");
            Console.WriteLine("Nach dem sich der Arzt um die Verletzungen gekümmert hat und auch nichts weiter feststellen konnte, ließ er uns wieder gehen.");
            Console.WriteLine("Er sagt auch noch, das sie sich erholen und nicht überanstrengen solle.");
            Console.WriteLine("Du fragst sie ob sie Hunger hat. Sie sagt nichts, sondern nickt nur mit dem Kopf.");
            Console.WriteLine("Auf dem weg zur Taverne fällt dir eine Gestalt in einer Seitengasse auf.");
            Console.WriteLine("");
            Console.WriteLine("In der Taverne angekommen, Setzt ihr euch in eine Ecke und Bestellt euch was.");
            Console.WriteLine("Nach ein paar Minuten steht vor euch eine Große platte mit allem Möglichen. Geflügel, Salate und vielem mehr.");
            Console.WriteLine("Sie aß viel. Sie hat wohl seit ihre gefangenschaft kaum Essen bekommen.");
            Console.WriteLine("");
            Console.WriteLine("Nachdem die Platte leer ist bezahlst du und fragst ob du ihr ein paar fragen stellen darfst.");
            currentPlayer.GoldMuenzen -= 15;
            Console.WriteLine("Sie nickte leicht.");
            Console.WriteLine("Du fragst sie nach ihrem Namen.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Ihr Name ist.....");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            currentPlayer.GirlName1 = Console.ReadLine();
            currentPlayer.Begleiterinnen.Add(currentPlayer.GirlName1);
            Console.Clear();
            Console.ResetColor();
            Menü();
        }
        #endregion

        #region Playerstats
        public static void PlayerStats()
        {
            //Spielerübersicht
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("Spielername: " + currentPlayer.Name);
            Console.WriteLine("============================================");
            Console.WriteLine("Leben:       " + currentPlayer.HealthNow + "/" + currentPlayer.Absolutehealth);
            Console.WriteLine("============================================");
            Console.WriteLine("Mana:        " + currentPlayer.ManaNow + "/" + currentPlayer.AbsoluteMana);
            Console.WriteLine("============================================");
            Console.WriteLine("Level:       " + currentPlayer.Level);
            Console.WriteLine("============================================");
            Console.WriteLine(" Xp:");
            Console.Write("[");
            ProgressBar("+", " ", ((decimal)currentPlayer.Xp / (decimal)currentPlayer.GetLevelUpValue()), 25);
            Console.Write("]");
            Console.WriteLine("  ");
            Console.WriteLine("============================================");
            Console.WriteLine("Waffenname:  " + currentPlayer.Weaponname);
            Console.WriteLine("============================================");
            Console.WriteLine("Geld:        " + currentPlayer.GoldMuenzen + "G/" + currentPlayer.SilberMuenzen + "S/" + currentPlayer.BronzeMuenzen + "B");
            Console.WriteLine("============================================");
            Console.WriteLine("Begleiter 1:   " + currentPlayer.GirlName1 + "");
            Console.WriteLine("---------------------");
            Console.WriteLine("Begleiter 2:   " + currentPlayer.GirlName2 + "");
            Console.WriteLine("---------------------");
            Console.WriteLine("Begleiter 3:   " + currentPlayer.GirlName3 + "");
            //Console.WriteLine("---------------------");
            //Console.WriteLine("Begleiter 4:   " + currentPlayer.GirlName4 + "");
            Console.WriteLine("============================================");
            Console.WriteLine("  ");
            Console.WriteLine("(W)affe wechseln");
            Console.WriteLine("(L)ootboxen");
            Console.WriteLine("(S)killbaum");
            //Console.WriteLine("(S)chwert Umbenennen");
            Console.WriteLine("(B)egleiter Umbenennen (bx)(x = der Nummer des Begleiters)");
            Console.WriteLine("(E)xit");
            string input = Console.ReadLine();
    
            /*if (input.ToLower() == "s" || input.ToLower() == "schwert")
            {
                Console.Clear();
                Console.WriteLine("  ");
                Console.WriteLine("Wie soll deine Waffe heißen?");
                Console.WriteLine("Waffenname eingeben und zum bestätigen 'Enter' drücken.");
                Console.WriteLine("  ");
                currentPlayer.Weaponname = Console.ReadLine();
                Console.Clear();
                PlayerStats();
            }*/
            if (input.ToLower() == "l")
            {
                Console.Clear();
                Player.Lootboxen();
            }
            else if (input.ToLower() == "w") 
            {
                Console.Clear();
                Waffenwechsel();
            }
            else if (input.ToLower() == "e" || input.ToLower() == "exit")
            {
                Console.Clear();
                Menü();
            }
            else if (input.ToLower() == "s")
            {
                Console.Clear();
                Player.Skilltree();
            }
            else if (input.ToLower() == "b1")
            {
                Console.Clear();
                Console.WriteLine("  ");
                Console.WriteLine("Wie soll " +currentPlayer.GirlName1 +" heißen.");
                Console.WriteLine("Namen eingeben und zum bestätigen 'Enter' drücken.");
                Console.WriteLine("  ");
                currentPlayer.GirlName1 = Console.ReadLine();
                currentPlayer.Begleiterinnen.Remove(currentPlayer.GirlName1);
                currentPlayer.Begleiterinnen.Add(currentPlayer.GirlName1);
                Console.Clear();
                PlayerStats();
            }
            else if (input.ToLower() == "b2")
            {
                if (currentPlayer.Begleiterinnen.Contains(currentPlayer.GirlName2))
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Wie soll " + currentPlayer.GirlName2 + " heißen.");
                    Console.WriteLine("Namen eingeben und zum bestätigen 'Enter' drücken.");
                    Console.WriteLine("  ");
                    currentPlayer.GirlName2 = Console.ReadLine();
                    currentPlayer.Begleiterinnen.Remove(currentPlayer.GirlName2);
                    currentPlayer.Begleiterinnen.Add(currentPlayer.GirlName2);
                    Console.Clear();
                    PlayerStats();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du hast diesen Begleiter nicht im Team");
                    Console.ReadLine();
                    Console.Clear();
                    PlayerStats();
                }    
            }
            else if (input.ToLower() == "b3")
            {
                if (currentPlayer.Begleiterinnen.Contains(currentPlayer.GirlName3))
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Wie soll " + currentPlayer.GirlName3 + " heißen.");
                    Console.WriteLine("Namen eingeben und zum bestätigen 'Enter' drücken.");
                    Console.WriteLine("  ");
                    currentPlayer.GirlName3 = Console.ReadLine();
                    currentPlayer.Begleiterinnen.Remove(currentPlayer.GirlName3);
                    currentPlayer.Begleiterinnen.Add(currentPlayer.GirlName3);
                    Console.Clear();
                    PlayerStats();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du hast diesen Begleiter nicht im Team");
                    Console.ReadLine();
                    Console.Clear();
                    PlayerStats();
                }
            }
        }
        #endregion

        #region Waffenwechsel
        public static void Waffenwechsel()
        {

        }
        #endregion

        #region Save&Load
        public static void Save()
        {
            string jsonString = JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText($"saves/{currentPlayer.Id}{currentPlayer.Name}.json", jsonString);

            /*BinaryFormatter binForm = new BinaryFormatter();
            string path = "Saves/" + currentPlayer.id.ToString() + ".save";
            FileStream file = File.Open(path,FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();*/
        }

        public static Player Load(out bool newP)
        {
            

            newP = false;

            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 1;

           // BinaryFormatter binForm = new BinaryFormatter();
            foreach (string saveFile in paths)
            {
                //FileStream file = File.Open(p, FileMode.Open);
                //Player player = (Player)binForm.Deserialize(file);
                string jsonString = File.ReadAllText(saveFile);
                Player player = JsonSerializer.Deserialize<Player>(jsonString);
                //file.Close();
                players.Add(player);
            }
            idCount = players.Count;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  ");
                Print("Wähle deinen Spielstand:", 40);
                Console.WriteLine("  ");

                foreach (Player p in players)
                {
                    Print(p.Id + ": " + p.Name);
                }

                Console.WriteLine("  ");
                Print("Bitte SpielerId eintragen. (id:#).", 30);
                Print("'Neu' erstellt einen neuen Spielstand!", 40);
                Console.WriteLine("   ");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if(data[0] == "id")
                    {
                        if(int.TryParse(data[1],out int id))
                        {
                            foreach  (Player player in players)
                            {
                                if(player.Id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("Es existiert kein Spielstand mit dieser Id");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Die Id muss eine Nummer enthalten! Drücke eine belibige Taste zum fortfahren.");
                            Console.ReadKey();
                        }
                    }
                    else if(data[0] == "Neu")
                    {
                        Player newPlayer = NewChar(idCount);
                        newP = true;
                        Encounters.FirstEncounter();
                    }
                    else
                    {
                        foreach  (Player player in players)
                        {
                            if(player.Name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("Es existiert kein Spielstand mit dieser Id");
                        Console.ReadKey();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Die Id muss eine Nummer enthalten! Drücke eine belibige Taste zum fortfahren.");
                    Console.ReadKey();
                }
            }
        }
        #endregion

        #region Print
        public static void Print(string text, int speed = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
        #endregion

        #region ProgressBar
        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for(int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }
        #endregion

        #region Credits
        public static void Credits()
        {
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("Game Designer:");
            Console.WriteLine("YamiKevin");
            Console.WriteLine("  ");
            Console.WriteLine("Game Programmer:");
            Console.WriteLine("YamiKevin");
            Console.WriteLine("  ");
            Console.WriteLine("Beastionary Maker:");
            Console.WriteLine("Shino");
            Console.WriteLine("  ");
            Console.WriteLine("Musik Creator:");
            Console.WriteLine("AntHorny91 | #2705");
            Console.WriteLine("Zane Again | #7149");
            Console.WriteLine("Bei Tipps und Anregungen:");
            Console.WriteLine("EMail: ");
            Console.WriteLine("  ");
            Console.WriteLine("(Y)ouTube");
            Console.WriteLine("(E)xit");
            string input = Console.ReadLine().ToLower();

            if(input == "e")
            {
                Console.Clear();
                Menü();
            }
            else if(input == "y")
            {
                Console.Clear();
                Console.WriteLine("   ");
                Console.WriteLine("(Z)ane Again");
                Console.WriteLine("()");

                string inputyt = Console.ReadLine().ToLower();

                if(inputyt == "z")
                {
                    Process.Start("https://youtube.com/channel/UCbgtKSyMVtgR-cLkfq-bA");
                }
            }
        }
        #endregion

        #region Hilfe
        public static void Hilfe()
        {

        }
        #endregion

        #region Quit
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }
        #endregion

        






















        #region DemoGame
        public static void DemoGame()
        {
            Console.Clear();
            Console.WriteLine("   ");
            Console.WriteLine("Dies ist die Demoversion des Spiels. Fragen, Anregungen, Verbesserungsvorschläge und Bugs,");
            Console.WriteLine("per Mail schreiben/melden!");
            
            Console.ReadLine();
            Menü();
        }
        #endregion

        #region Konzepte
        #region Konzept Waffenwechsel
        /*if (input.ToLower() == "w" || input.ToLower() == "waffe")
            {
                Console.WriteLine("Welche Waffe möchtest du Ausrüsten?");

                if (Player.Inventory.Contains("Developerwaffe"))
                {
                    Console.WriteLine("(D)eveloperwaffe");
                }
                else if (Player.Inventory.Contains("Weinachtsklinge"))
                {
                    Console.WriteLine("(W)einachtsklinge");
                }
                else
                {
                    Console.WriteLine("Du hast noch keine Waffe zum wechseln.");
                }

                if(input.ToLower() == "d")
                {

                }
            }*/
        #endregion

        #region Konzept Hauptmenü
        /*
                public static void Hauptmenü()
                {
                    string choice;
                    Console.WriteLine("   ");
                    Console.WriteLine("   ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("==========H-Adventure==========");
                    Console.WriteLine("   ");
                    Console.WriteLine("   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("_________________________________");
                    Console.WriteLine("   ");
                    Console.WriteLine("-----------HAUPTMENÜ-------------");
                    Console.WriteLine("_________________________________");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("1   Start");
                    Console.WriteLine(" ");
                    Console.WriteLine("2   Credits");
                    Console.WriteLine(" ");
                    Console.WriteLine("3   Exit");

                    choice = Console.ReadLine().ToLower();
                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                        case "Start":
                            {
                                Char();
                                break;
                            }
                    }
                    switch (choice)
                    {
                        case "2":
                        case "Credits":
                            {
                                Credits();
                                break;
                            }
                    }
                    switch (choice)
                    {
                        case "3":
                        case "Exit":
                            {
                                ConsoleKeyInfo cki;

                                Console.WriteLine("Press the Escape (Esc) key to quit! \n");
                                do
                                {
                                    cki = Console.ReadKey();
                                    // do something with each key press until escape key is pressed
                                } while (cki.Key != ConsoleKey.Escape);
                                break;
                            }
                    }
                }
        */
        #endregion
        #endregion
    }
}
