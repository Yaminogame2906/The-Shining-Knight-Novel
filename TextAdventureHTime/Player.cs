using System;
using System.Collections.Generic;
using TextAdventure;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Player_Stats
{
    [Serializable]
    public class Player
    {   
        #region SpielerWerte
        //Namen, id's und anzahl von Gegenständen
        public string Name { get; set; }
        public int Id { get; set; }
        #endregion

        #region Währung
        public int GoldMuenzen { get; set; } = 0;
        public int SilberMuenzen { get; set; } = 0;
        public int BronzeMuenzen { get; set; } = 0;
        #endregion

        #region Lootboxen
        public int Lootboxenanzahl { get; set; }
        public int EinfacheLootbox { get; set; } = 50;
        public int GlitzerndeLootbox { get; set; } = 2;
        public int LeuchtendeLootbox { get; set; } = 6;
        public int ChristmasLootboxenanzahl { get; set; } = 0;
        #endregion

        #region LevelUpWerte
        //LevelUp
        public int Level { get; set; } = 1; //Magenta
        public int Xp { get; set; } = 0;
        public int Skillpoints { get; set; } = 0;
        #endregion

        #region KampfWerte
        //Ang, Def, Mag, muss alles neu berschnet werden und Skilltree und Waffen werte müssen mit eingebunden werden
        public int Potion { get; set; } = 0;
        public int PotionAdvanced { get; set; } = 0;
        public int PotionMaster { get; set; } = 0;

        public int AttackPoints { get; set; } = 1;
        public int MagicDamage { get; set; } = 1;
        public int ArmorPoints { get; set; } = 0;

        public int Absolutehealth { get; set; } = 10;
        public int HealthNow { get; set; } = 10;
        public int AbsoluteMana { get; set; } = 10;
        public int ManaNow { get; set; } = 10;
        public int ManaCost { get; set; }
        #endregion

        #region Skillbaum
        //für die berechnung die summe aller upgrades eines Skillbereichs zusammenrechnen. z.b. Ang upgrade +1, erneut upgrade +1 ist public int AngGes = 2;
        public bool SkilltreeUse { get; set; } = false;


        public bool SkillAngriff { get; set; } = true;
        public bool SkillDefense { get; set; } = true;
        public bool SkillMagie { get; set; } = true;


        public int SkillAngLevel { get; set; } = 1;
        public int SkillDefLevel { get; set; } = 1;
        public int SkillMagLevel { get; set; } = 1;


        public int AngGes { get; set; } = 0;
        public int DefGes { get; set; } = 0;
        public int MagGes { get; set; } = 0;


        public bool Skill1 { get; set; } = false;
        public bool Skill2 { get; set; } = false;
        public bool Skill3 { get; set; } = false;


        public int Skill1Level { get; set; } = 1;
        public int Skill2Level { get; set; } = 2;
        public int Skill3Level { get; set; } = 3;


        public int Skill1Ges { get; set; } = 0;
        public int Skill2Ges { get; set; } = 0;
        public int Skill3Ges { get; set; } = 0;

        #endregion

        //Für die Story relevant
        //public int heroPoints { get; set; } = 0; //zum treffen von Guten(Points > 0) &/o. Schlechten(Points < 0) Entscheidungen

        #region Storyswitch und Save
        //Storyswitch und Save
        public bool DemoGame { get; set; } = true; //wenn true wird bei Fortsetzen der Demobildschirm abgespielt
        public bool StoryKapitel2 { get; set; } = false;
        public bool Save1Kapitel2 { get; set; } = false;
        public bool Save2Kapitel2 { get; set; } = false;
        public bool StoryKapitel3 { get; set; } = false;
        public bool Save1Kapitel3 { get; set; } = false;
        public bool Save2Kapitel3 { get; set; } = false;
        public bool StoryKapitel4 { get; set; } = false;
        public bool Save1Kapitel4 { get; set; } = false;
        public bool Save2Kapitel4 { get; set; } = false;
        #endregion

        #region Waffennamen
        //Waffenname
        public string Weaponname { get; set; } //generischer code für den Waffennamen 
        public string StarterWeaponName { get; set; } = "Eisenschwert";
        public string DevWeaponName { get; set; } = "Klinge des Admins";
        public string WeinachtsWeaponName { get; set; } = "X-Mas Schwert";
        #endregion

        #region Waffenwerte
        //Waffenwerte
        public int StarterWeaponValue { get; set; } = 2;
        public int DevWeaponValue { get; set; } = 10;
        public int WeinachtsWeaponValue { get; set; } = 5;
        //in dungeon muss für jede waffe der wert berechnet werden (oder rumfragen ob es einfacher geht)
        #endregion

        #region Begleiter
        public List<string> Begleiterinnen { get; set; } = new List<string>();
        public Player Begleiter()
        {
            Console.Clear();
            Console.WriteLine("   ");
            Console.WriteLine("Begleiter:");

            foreach (string mädchen in Begleiterinnen)
            {
                Console.WriteLine(mädchen);
            }
            return MainStory.currentPlayer;
        }
        public string GirlName1 { get; set; } //Klassen festlegen
        public string GirlName2 { get; set; }
        public string GirlName3 { get; set; }
        public string GirlName4 { get; set; }
        public string GirlName5 { get; set; }
        #endregion

        #region Vertraute/Familiar
        public List<string> Vertraute { get; set; } = new List<string>();
        public Player Familiar()
        {
            Console.Clear();
            Console.WriteLine("   ");
            Console.WriteLine("Vertraute:");

            foreach (string familiar in Vertraute)
            {
                Console.WriteLine(familiar);
            }
            return MainStory.currentPlayer;
        }
        public string Vertrauter1 { get; set; } //Fähigkeiten festlegen
        public string Vertrauter2 { get; set; }
        public string Vertrauter3 { get; set; }
        public string Vertrauter4 { get; set; }

        public string Vertrauter1Kategorie = ""; //Fähigkeit: Regeneration pro Runde 
        public string Vertrauter2Kategorie = ""; //Fähigkeit: wird für die Story benötigt um unter Wasser zu Atmen(keine derzeitigen weiteren Fähigkeiten)
        public string Vertrauter3Kategorie = "Tiger"; //Fähigkeit:
        public string Vertrauter4Kategorie = "Drache"; //Fähigkeit:
        #endregion

        #region LevelUp
        public int GetLevelUpValue()
        {
            return 20 * Level + 50;
        }
        public bool CanLevelUp()
        {
            if (Xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }
        public void LevelUp()
        {
            while (CanLevelUp())
            {
                Xp -= GetLevelUpValue();
                Level += 1;

                AttackPoints += 1;
                ArmorPoints += 1;
                MagicDamage += 1;
                Absolutehealth += 3;
                HealthNow += 3;
                ManaNow += 4;
                AbsoluteMana += 4;
                Skillpoints += 1;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            MainStory.Print("Super du hast Level " + Level + " erreicht.");
            Console.ResetColor();
        }
        #endregion

        #region Inventar
        public List<string> Inventory { get; set; } = new List<string>();
        public Player Inventar()
        {
            Console.Clear();
            Console.WriteLine("   ");
            Console.WriteLine("Inventar:");
            Console.WriteLine("====================");

            foreach (string item in Inventory)
            {
                Console.WriteLine("|" + item);
                Console.WriteLine("====================");
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
        #endregion

        #region Lootboxen
        public static void Lootboxen()
        {
            while (MainStory.currentPlayer.Lootboxenanzahl > 0)
            {
                Console.Clear();
                Console.WriteLine("Lootboxen Menge:          " + MainStory.currentPlayer.Lootboxenanzahl);
                Console.WriteLine("Weinachtslootboxen Menge: " + MainStory.currentPlayer.ChristmasLootboxenanzahl);
                Console.WriteLine("  ");
                Console.WriteLine("===================");
                Console.WriteLine("(Ö)ffnen");
                Console.WriteLine("(E)xit");
                string input = Console.ReadLine().ToLower();

                if (input == "ö")
                {

                }
                else if (input == "e")
                {
                    Console.Clear();
                    MainStory.PlayerStats();
                }
            }
        }
        #endregion

        #region Skilltree
        public static void Skilltree()
        {
            if (MainStory.currentPlayer.SkilltreeUse == true)
            {

            }
            else
            {

            }
        }
        #endregion
    }
}
