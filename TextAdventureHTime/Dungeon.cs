using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Dungeon
    {
        public static Random rand = new Random();

        #region Dungeon Enter
        public static void DungeonEintritt()
        {
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("---------------DER DUNGEON---------------");
            Console.WriteLine("In diesem Dungeon, der nahezu Endlos ist, kannst du Trainieren um stärker zu werden.");
            Console.WriteLine("Achte aber immer darauf, das du genügend Tränke hast.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("Du stehst vor einer Großen Tür! Du berührst sie und sie öffnet sich, mit einem Knarrendem Geräusch.", 30);
            //MainStory.soundDungeonGate.Play();
            Console.WriteLine("Du betrittst den Dungeon und die Tür schließt sich augenblicklich hinter dir.");
            Console.ReadLine();
            Console.WriteLine("  ");
            Console.WriteLine("Vor dir Teilt sich der Weg in Drei Richtungen auf!");
            Console.WriteLine("In welche Richtung möchtest du gehen?");
            Console.WriteLine("   ");
            Console.WriteLine("Die Level hinter den Schwierigkeitsgrad sind eine Hilfestellung, ab welchem Level du hinein gehen solltest.");
            Console.WriteLine("=====================================");
            Console.WriteLine("  ");
            Console.WriteLine("(E)infach (Lv.1-10)");
            Console.WriteLine("(S)chwer  (Lv.10-20)");
            Console.WriteLine("(B)oss    (Lv.20+)");
            //MainStory.soundDungeon.PlayLooping();
            string input = Console.ReadLine().ToLower();

            if (input == "e")
            {
                DungeonEasy(true, "", 0, 0, 0);
            }
            else if (input == "s")
            {
                DungeonHard(true, "", 0, 0, 0);
            }
            else if (input == "b")
            {
                DungeonBoss(true, "", 0, 0, 0);
            }  
        }
        #endregion

        #region DungeonEasy
        public static void DungeonEasy(bool random, string name, int power, int health, int experiencepoints)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int e = 0;
            if (random)
            {
                n = GetEnemyEasy();
                p = rand.Next(2, 3) + MainStory.currentPlayer.Level;
                h = rand.Next(4, 7) + MainStory.currentPlayer.Level;
                e = rand.Next(5, 15);
            }
            while (h > 0)
            {

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
                        damage = MainStory.currentPlayer.Level;
                    int attack = rand.Next(0, MainStory.currentPlayer.AttackPoints) + rand.Next(1, 4);
                    Console.WriteLine("Du verlierst " + damage + " Leben und fügst ihm " + attack + " schaden zu.");
                    MainStory.currentPlayer.HealthNow -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("Du machst dich bereit den Angriff vom " + n + " zu blocken.");
                    int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
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
                    if (damage < 0)
                        damage = MainStory.currentPlayer.Level;
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Du verlierst " + damage + " Leben und kannst nicht entkommen.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Du kannst erfolgreich entkommen!");
                        Console.ReadKey();
                        MainStory.Menü();
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Während du nach einer Potion suchst greift dich der " + n + " dich an und du verlierst " + damage + " Leben.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Welchen Trank möchtest du Trinken?");
                        Console.WriteLine("");
                        Console.WriteLine("(N)ormaler Trank " + MainStory.currentPlayer.Potion + "x");
                        Console.WriteLine("(S)tarker Trank " + MainStory.currentPlayer.PotionAdvanced + "x");
                        Console.WriteLine("(M)eister Trank " + MainStory.currentPlayer.PotionMaster + "x");
                        Console.WriteLine("============================================");
                        Console.WriteLine("");
                        Console.WriteLine("(Z)urück");
                        string trankTrinken = Console.ReadLine().ToLower();

                        if (trankTrinken == "n")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 5;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.Potion -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "s")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 15;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionAdvanced -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "m")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 25;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionMaster -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "z")
                        {
                            Console.WriteLine("Drücke 'Enter' um zurück zur Aktionsauswahl zu gelangen.");
                        }
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
                
                while (MainStory.currentPlayer.HealthNow < 0)
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
                while (MainStory.currentPlayer.HealthNow == 0)
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
            }
            Console.Clear();
            int c = rand.Next(1, 5);
            int s = rand.Next(5, 15);
            int b = rand.Next(30, 90);
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("Du hast die " + n + " besiegt, und durchsuchts seine Taschen nach Wertsachen.");
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
            Console.WriteLine("");
            Console.WriteLine("(W)eiter   (E)nde");
            string Input = Console.ReadLine().ToLower();

            if (Input == "w")
            {
                DungeonEasy(true, "", 0, 0, 0);
            }
            else if (Input == "e")
            {
                MainStory.soundDungeon.Stop();
                MainStory.Menü();
            }
        }
        #endregion

        #region DungeonHard
        public static void DungeonHard(bool random, string name, int power, int health, int experiencepoints)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int e = 0;
            if (random)
            {
                n = GetEnemyHard();
                p = rand.Next(10, 20) + MainStory.currentPlayer.Level;
                h = rand.Next(20, 30) + MainStory.currentPlayer.Level;
                e = rand.Next(20, 25);
            }
            while (h > 0)
            {

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
                        damage = MainStory.currentPlayer.Level;
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
                    if (damage < 0)
                        damage = MainStory.currentPlayer.Level;
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Du verlierst " + damage + " Leben und kannst nicht entkommen.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Du kannst erfolgreich entkommen!");
                        Console.ReadKey();
                        MainStory.Menü();
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Während du nach einer Potion suchst greift dich der " + n + " dich an und du verlierst " + damage + " Leben.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Welchen Trank möchtest du Trinken?");
                        Console.WriteLine("");
                        Console.WriteLine("(N)ormaler Trank " + MainStory.currentPlayer.Potion + "x");
                        Console.WriteLine("(S)tarker Trank " + MainStory.currentPlayer.PotionAdvanced + "x");
                        Console.WriteLine("(M)eister Trank " + MainStory.currentPlayer.PotionMaster + "x");
                        Console.WriteLine("============================================");
                        Console.WriteLine("");
                        Console.WriteLine("(Z)urück");
                        string trankTrinken = Console.ReadLine().ToLower();

                        if (trankTrinken == "1")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 5;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.Potion -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "2")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 15;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionAdvanced -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "3")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 25;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionMaster -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "z")
                        {
                            Console.WriteLine("Drücke 'Enter' um zurück zur Aktionsauswahl zu gelangen.");
                        }
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
                while (MainStory.currentPlayer.HealthNow < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
                while (MainStory.currentPlayer.HealthNow == 0)
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
            }
            Console.Clear();
            int c = rand.Next(10, 30);
            int s = rand.Next(20, 50);
            int b = rand.Next(30, 90);
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("Du hast die " + n + " besiegt, und durchsuchts seine Taschen nach Wertsachen.");
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
            Console.WriteLine("");
            Console.WriteLine("(W)eiter   (E)nde");
            string Input = Console.ReadLine().ToLower();

            if (Input == "w")
            {
                DungeonHard(true, "", 0, 0, 0);
            }
            else if (Input == "e")
            {
                MainStory.soundDungeon.Stop();
                MainStory.Menü();
            }
        }
        #endregion
        
        #region DungeonBoss
        public static void DungeonBoss(bool random, string name, int power, int health, int experiencepoints)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int e = 0;
            if (random)
            {
                n = GetBossEnemy();
                p = rand.Next(25, 50);
                h = rand.Next(50, 80);
                e = rand.Next(50, 60);
            }
            while (h > 0)
            {

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
                        damage = MainStory.currentPlayer.Level;
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
                    if (damage < 0)
                        damage = MainStory.currentPlayer.Level;
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Du verlierst " + damage + " Leben und kannst nicht entkommen.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Du kannst erfolgreich entkommen!");
                        Console.ReadKey();
                        MainStory.Menü();
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
                        MainStory.currentPlayer.HealthNow -= damage;
                        Console.WriteLine("Während du nach einer Potion suchst greift dich der " + n + " dich an und du verlierst " + damage + " Leben.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Welchen Trank möchtest du Trinken?");
                        Console.WriteLine("");
                        Console.WriteLine("(N)ormaler Trank " + MainStory.currentPlayer.Potion + "x");
                        Console.WriteLine("(S)tarker Trank " + MainStory.currentPlayer.PotionAdvanced + "x");
                        Console.WriteLine("(M)eister Trank " + MainStory.currentPlayer.PotionMaster + "x");
                        Console.WriteLine("============================================");
                        Console.WriteLine("");
                        Console.WriteLine("(Z)urück");
                        string trankTrinken = Console.ReadLine().ToLower();

                        if (trankTrinken == "n")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 5;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.Potion -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "s")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 15;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionAdvanced -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "m")
                        {
                            Console.WriteLine("Du greifst in deinen Rucksack und holst ein Fläschen mit blauer Flüssigkeit herraus, welches du leerst.");
                            int potionV = 25;
                            Console.WriteLine("Du erhälst " + potionV + " Leben zurück");
                            MainStory.currentPlayer.HealthNow += potionV;
                            MainStory.currentPlayer.PotionMaster -= 1;
                            Console.WriteLine("Wärend du den Trank genommen hast hat dich der Gegener angegriffen");
                            int damage = (p / 2) - MainStory.currentPlayer.ArmorPoints;
                            if (damage < 0)
                                damage = 0;
                            MainStory.currentPlayer.HealthNow -= damage;
                            Console.WriteLine("Du hast " + damage + " Leben verloren.");
                        }
                        else if (trankTrinken == "z")
                        {
                            Console.WriteLine("Drücke 'Enter' um zurück zur Aktionsauswahl zu gelangen.");
                        }
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();

                while (MainStory.currentPlayer.HealthNow < 0)
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
                while (MainStory.currentPlayer.HealthNow == 0)
                {
                    Console.Clear();
                    Console.WriteLine("  ");
                    Console.WriteLine("Dir wird Schwarz vor Augen!");
                    Console.WriteLine("Etwas später befindest du dich in der Taverne.");
                    Console.ReadLine();
                    Console.Clear();
                    MainStory.soundDungeon.Stop();
                    MainStory.Menü();
                }
            }
            Console.Clear();
            int c = rand.Next(15, 35);
            int s = rand.Next(20, 50);
            int b = rand.Next(70, 150);
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("Du hast die " + n + " besiegt, und durchsuchts seine Taschen nach Wertsachen.");
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
            Console.WriteLine("");
            Console.WriteLine("(W)eiter   (E)nde");
            string Input = Console.ReadLine().ToLower();

            if (Input == "w")
            {
                DungeonBoss(true, "", 0, 0, 0);
            }
            else if (Input == "e")
            {
                MainStory.soundDungeon.Stop();
                MainStory.Menü();
            }

        }
        #endregion

        #region Gegner
        public static string GetEnemyEasy()
        {
            switch(rand.Next(0, 3))
            {
                case 0:
                    return "Schatzräuber";
                case 1:
                    return "Zombie";
                case 2:
                    return "Mutant";
            }
            return "Schlangen Mensch";
        }
        public static string GetEnemyHard()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    return "Gepanzerter Echsenkrieger";
            }
            return "Schlangenwächter";
        }
        public static string GetBossEnemy()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    return "Drache";
                case 1:
                    return "Necromancer";
            }
            return "Lindwurm";
        }
        #endregion
    }
}
// -----------: lv1 lv2 lv3 lv4 lv5 lv6 lv7 lv8 lv9 lv10 lv11 lv12 lv13 lv14 lv15 lv16 lv17 lv18 lv19 lv20
// Hp zu Level: 10  15  20  25  30  35  40  45  50  55   60   65   70   75   80   85   90   95   100  105
// Magie angriff erst in der story erlernbar bool arbeiten true false veränderter Angriffsbildschirm