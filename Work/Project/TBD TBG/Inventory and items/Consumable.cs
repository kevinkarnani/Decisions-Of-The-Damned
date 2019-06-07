using System;

namespace TBD_TBG
{
    public class Consumable : Item
    {
        /*
         * Inherits from item class. 
         * Used for consumable items like potions.
         */
        public int plusAgility = 0;//additional agility stat
        public int plusHP = 0;//additional HP stat
        public int plusAttack = 0;//additional attack stat
        public bool isUsableOutsideOfCombat = false; //whether or not the item can be used 

        public bool isActive = false; //whether or not the player is currently effected by the consumbable buff
        
        public Consumable(string ID, string Name, string Description) : base(ID, Name, Description)
        {
            //TODO: fix this init? it doesnt look right ^^^
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
        }

        //sets whether the item is usable out of combat or not
        public void SetUsability(bool OutOfCombat)
        {
            isUsableOutsideOfCombat = OutOfCombat;
        }

        //sets stat of item
        public void SetStats(int attack, int agility, int HP)
        {
            plusAgility = agility;
            plusHP = HP;
            plusAttack = attack;

            /* Only hp potions should be usable outside of combat
             * Ex: You can use potions outside of combat in pokemon,
             * but not xattacks or xdefenses
             */
            if (plusAgility == 0 && plusAttack == 0)
            {
                isUsableOutsideOfCombat = true;
            }
        }

        //displays the stats of the consumable
        public void PrintStats()
        {
            string color = "darkcyan";
            if (plusAttack != 0)
            {
                Utility.Write("+Attack: " + plusAttack, color);
            }
            if (plusAgility != 0)
            {
                Utility.Write("+Agility: " + plusAgility, color);
            }
            if (plusHP != 0)
            {
                Utility.Write("+HP: " + plusHP, color);
            }
            Console.WriteLine();
        }

        //consumes an item by adding its stats to the player's stats
        public void UseEffect()
        {
            isActive = true;
            Inventory.ConsumableList.Remove(this);
            

            //adds stats of equipable to the players stats
            Player.playerStats.Attack += plusAttack;
            //Player.playerStats.MaxHP += plusHP; //Only adds hp to current hp, not max
            Player.playerStats.CurrentHP += plusHP;
            Player.playerStats.Agility += plusAgility;
        }

        //clears effects of item from player
        public void ClearEffect()
        {
            if (isActive) //you can only clear the effects if it's active
            {
                isActive = false;
                //subtracts the stats of consumable from the players stats
                Player.playerStats.Attack -= plusAttack;
                Player.playerStats.MaxHP -= plusHP;
                Player.playerStats.CurrentHP -= plusHP;
                Player.playerStats.Agility -= plusAgility;
            }
        }
    }
}
