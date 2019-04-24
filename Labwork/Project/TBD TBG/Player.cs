using System;

namespace TBD_TBG
{
    class Player
    {
        //CLASS ATTRIBUTES
        public string name; //the name of the player
        public int honor; //the player's honor value
        public string archetype; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
        public Stats playerStats;

        //CLASS CONSTRUCTORS
        public Player(string _name, string _arch)
        {
            this.name = _name;
            this.archetype = _arch;
            this.honor = 0;
            this.playerStats = new Stats(_arch);

        }
       
        
        //CLASS METHODS

    }

}

