using System;

namespace TBD_TBG
{
    public static class Player
    {
        /*
         * This class contains everything to do with the player character.
         * Includes information about the player, stats, attacks, etc.
         */

        public static int honor = 0; //the player's honor value
        public static string archetype = "default"; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
        public static Stats playerStats; //their stats
        public static bool inCombat = false; //whether they're in combat or not

        public static string Name = "Faust"; //the name of the player

        //CLASS METHODS
        //getters & setters
        public static string Archetype
        {
            get
            {
                return archetype;
            }
            set
            {
                switch (value)
                {
                    case "1": //balanced
                        archetype = "Adventurer";
                        break;
                    case "2": //focus on hp
                        archetype = "Paladin";
                        break;
                    case "3": //focus on attack
                        archetype = "Brawler";
                        break;
                    case "4": //focus on agility
                        archetype = "Rogue";
                        break;
                    default:
                        throw new ArgumentException();
                }
                playerStats = new Stats(archetype);
            }
        }
        //displays all information about the player
        public static void PrintPlayerOverview()
        {
            string color = Game.inventoryColor;
            Utility.Write("Name: " + Name, color);
            Utility.Write("Archetype: " + Archetype, color);
            Utility.Write("Honor: " + honor, color);
            playerStats.PrintStatOverview();
            Console.WriteLine();
        }
            //ATTACKS
                //light attack
        public static void LightAttack(Enemy enemy)
        {
            int damage = playerStats.Attack;
            enemy.Damage(damage);
        }
                //heavy attack
        public static void HeavyAttack(Enemy enemy)
        {
            int damage = playerStats.HeavyAttack;
            enemy.Damage(damage);
        }
                //dodge
                    //no method needed, enemy doesn't take damage
        public static void Damage(int damage)
        {
            Player.playerStats.CurrentHP -= damage; 
        }
        public static bool CheckIfHit() //checks whether you evaded an attack or not
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1

            if (randomNum <= playerStats.Evasion) //miss
            {
                return false;
            }
            else //hit
            {
                return true;
            }
        }
    }

}
