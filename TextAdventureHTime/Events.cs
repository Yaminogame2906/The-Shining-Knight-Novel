using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Events
    {
        #region Events

        #region Events Tage
        public static bool IsChristmas()
        {
            DateTime time = DateTime.Now;
            if (time.Month == 12 && time.Day == 24)
            {
                return true;
            }
            return false;
        }
        public static bool DevelopersBirthday()
        {
            DateTime time = DateTime.Now;
            if (time.Month == 6 && time.Day >= 29)
            {
                return true;
            } 
            return false;
        }
        public static bool NewYear()
        {
            DateTime time = DateTime.Now;
            if(time.Month == 1 && time.Day == 1)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Events Minuten & Stunden
        public static bool BossEvent()
        {
            DateTime time = DateTime.Now;
            if(time.Hour == 2 && time.Minute == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Lootchest Events
        public static bool LootChestChristmas()
        {
            DateTime time = DateTime.Now;
            if (time.Month == 12 && time.Day == 24)
                return true;
            return false;
        }
        #endregion
        public static bool TestEvent()
        {
            DateTime time = DateTime.Now;
            if (time.Month == 5 && time.Day >= 4)
            {
                Console.WriteLine("Fuktioniert");
                return true;
            }
            return false;
        }
        #endregion

        #region CharEigenschaften
        public static void CharEigenschaften()
        {
            /*if (MainStory.currentPlayer.heroPoints > 0)
            {

            }
            else if (MainStory.currentPlayer.heroPoints < 0)
            {

            }
            else if (MainStory.currentPlayer.heroPoints == 0)
            {

            }*/
        }
        #endregion
    }
}
