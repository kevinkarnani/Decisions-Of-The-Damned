using System;

namespace TBD_TBG
{
    public class Stats
    {
        //CLASS ATTRIBUTES

            //STATS
        private int agility; //affects evasion and who goes first (if you have greater agi then your opponent you go first)
        private double evasion; //chance of an enemy hitting you
        private int attack; //damage done in combat
        private int currentHP; //current health. You lose when this reaches zero.
        private int maxHP; //maximum health

        //CLASS CONSTRUCTORS
        //for the player (pass in archetype string)
        public Stats(string _arch)
        {
            SetInitialArchStats(_arch);

        }       
            //for enemies (pass in all the stats)
        public Stats(int _agi, int _att, int _maxHP)
        {
            Agility = _agi;
            Attack = _att;
            MaxHP = _maxHP;
            CurrentHP = MaxHP;
            SetEvasionStat();
        }
        private void SetInitialArchStats(string _arch)
        {
            //we can always rebalance the archetype stats later
            //TODO: Change to lists to set stats in one line
            switch (_arch)
            {
                case "Adventurer": //balanced
                    Agility = 20;
                    Attack = 40;
                    MaxHP = 100;
                    break;
                case "Paladin": //focus on hp
                    Agility = 15;
                    Attack = 30;
                    MaxHP = 130;
                    break;
                case "Brawler": //focus on attack
                    Agility = 25;
                    Attack = 50;
                    MaxHP = 80;
                    break;
                case "Rogue": //focus on agility
                    Agility = 35;
                    Attack = 45;
                    MaxHP = 75;
                    break;
            }
            CurrentHP = MaxHP;
            SetEvasionStat();
        }
        //CLASS METHODS
            //determines the evasion stat based off of the playe's agility stat
            //evasion should never be greater than 100% 
        private void SetEvasionStat()
        {
            Evasion = (0.01*(Agility))/(1+(0.01)*(Agility));//chance to be hit by an enemy attack
            //evasion should be greater than 0 and less than 1
            //EX: 0 agi = 0 eva, 20 agi = .28 eva, 50 agi = 50 eva, 100 agi = 60 eva
            //diminishing returns on evasion with more agility            
        }
            //prints a general overview of all the stats
        public void PrintStatOverview()
        {
            string color = "cyan";
            Utility.Write("Agility: " + Agility, color);
            Utility.Write("Evasion: " + (100 * Evasion).ToString("#.00") + "%", color);
            Utility.Write("Attack: " + Attack, color);
            Utility.Write("Current HP: " + CurrentHP, color);
            Utility.Write("Maximum HP: " + MaxHP, color);
        }

        //getters & setters
        public int Agility
        {
            get
            {
                return agility;
            }
            set
            {
                if (value < 0) //attack cannot be lower than zero
                {
                    agility = 0;
                }
                else
                {
                    agility = value;
                }
            }
        }
        public double Evasion
        {
            get
            {
                return evasion;
            }
            set
            {
                if (value > 1.0) //evasion cannot be higher than 100%
                {
                    evasion = 1.0;
                }
                else if (value < 0)
                { //evasion cannot be lower than 0%
                    evasion = 0;
                }
                else
                {
                    evasion = value;
                }
            }
        }
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                if (value < 0) //attack cannot be lower than zero
                {
                    attack = 0;
                }
                else
                {
                    attack = value;
                }
            }
        }
        public int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                if (value < 0) //Max HP cannot be lower than zero
                {
                    maxHP = 0;
                }
                else
                {
                    maxHP = value;
                }
            }
        }
        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
            set
            {
                if (value <= 0)
                { //cannot have hp lower than 0 
                    currentHP = 0;
                }
                else if (value >= maxHP)
                { //cannot have current hp > max hp
                    currentHP = maxHP;
                }
                else
                {
                    currentHP = value;
                }
            }
        }
    }

}

