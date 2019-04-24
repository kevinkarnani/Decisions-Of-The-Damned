using System;

namespace TBD_TBG
{
    class Stats
    {
        //CLASS ATTRIBUTES
        public string archetype; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
            //stats
        public int agility; //affects evasion and who goes first
        public double evasion; //chance of an enemy hitting you
        public int attack; //damage done with attacks
        public int totalHP; //maximum health
        public int currentHP; //curent health. You lose when this reaches zero.

        //CLASS CONSTRUCTORS
        public Stats(string _arch)
        {
            this.archetype = _arch;
            SetInitialStats();

        }
        private void SetInitialStats()
        {
            //we can always rebalance the archetype stats later
            if (archetype == "Adventurer")
            { //balanced stats
                agility = 20;
                attack = 40;
                totalHP = 100;
                currentHP = totalHP;
            }
            else if (archetype == "Paladin") //focus on hp
            {
                agility = 15;
                attack = 30;
                totalHP = 150;
                currentHP = totalHP;
            }
            else if (archetype == "Brawler") //focus on attack
            {
                agility = 20;
                attack = 50;
                totalHP = 80;
                currentHP = totalHP;
            }
            else if (archetype == "Rogue") //focus on agility
            {
                agility = 35;
                attack = 45;
                totalHP = 70;
                currentHP = totalHP;
            }
        }
        //CLASS METHODS

        //determines the evasion stat based off of the playe's agility stat
        //evasion should never be greater than 100% 
        private void setEvasionStat()
        {
            evasion = (0.02*(agility))/(1+(0.02)*(agility));//chance to be hit by an enemy attack
            //evasion should be greater than 0 and less than 1
            //EX: 0 agi = 0 eva, 20 agi = .28 eva, 50 agi = 50 eva, 100 agi = 60 eva
            //diminishing returns on more agility
            
        }
        
        //TO DO: Getters and setters


    }

}

