using System;

namespace TBD_TBG
{
    public static class Player
    {
        //TODO: Add attacks for the player

        //CLASS ATTRIBUTES
        public static string name = ""; //the name of the player
        public static int honor = 0; //the player's honor value
        public static string archetype = ""; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
        public static Stats playerStats;

        //CLASS METHODS
        public static void setName(string _name)
        {
            name = _name;
        }   
        public static void setArchetype(string _arch)
        {
            if(_arch == "1")
            {
                archetype = "Adventurer";                
            }                
            else if (_arch == "2")
            {
                archetype = "Paladin";
            }
            else if (_arch == "3")
            {
                archetype = "Brawler";
            }
            else if (_arch == "4")
            {
                archetype = "Rogue";
            }
            playerStats = new Stats(archetype);
        }


    }

}

