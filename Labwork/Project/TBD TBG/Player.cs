using System;

namespace TBD_TBG
{
    public static class Player
    {
        public static int honor = 0; //the player's honor value
        public static string archetype = "default"; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
        public static Stats playerStats;

        //CLASS METHODS
        //getters & setters
        public static string Name { get; set; } = "default";
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
            
        public static void PrintPlayerOverview()
        {
            string color = "darkcyan";
            Utility.Write("Name: " + Name, color);
            Utility.Write("Archetype: " + Archetype, color);
            Utility.Write("Honor: " + honor, color);
            playerStats.PrintStatOverview();
            Console.WriteLine();
        }
            //ATTACKS
                //light attack
        public static void LightAttack(Enemy _enem)
        {
            int damage = playerStats.Attack;
            _enem.Damage(damage);
        }
                //heavy attack
        public static void HeavyAttack(Enemy _enem)
        {
            int damage = playerStats.HeavyAttack;
            _enem.Damage(damage);
        }
                //dodge
                    //no method needed, enemy doesn't take damage
        public static void Damage(int _dmg)
        {
            Player.playerStats.CurrentHP -= _dmg; 
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

