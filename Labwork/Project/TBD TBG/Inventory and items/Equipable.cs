using System;

namespace TBD_TBG
{
    public class Equipable : Item
    {
        public int plusAgility = 0; //additional agility stat
        public int plusHP = 0; //additional HP stat
        public int plusAttack = 0; //additional attack stat
        public bool isEquipped = false; //whether the equipable is equiped or not
        public bool isWeapon; //whether the equipable is a weapon or armor (T = weapon, F = armor)

        public Equipable(string Identification, string Name, string Description, bool isWeapon) : base(Identification, Name, Description)
        {
            //TODO: fix this init? it doesnt look right ^^^
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
            this.isEquipped = false;
            this.isWeapon = isWeapon; 
        }
        //sets the stats of the equipable
        public void SetStats(int attack, int agility, int HP)
        {
            plusAgility = agility;
            plusHP = HP;
            plusAttack = attack; 
        }
        //displays the stats of the equipable
        public void PrintStats()
        {
            string color = "darkcyan";
            if(plusAttack != 0)
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
        //equips an item to the player by adding its stats to the player's stats
        public void Equip()
        {
            if (isWeapon) //if the item you're equiping is a weapon
            {
                Inventory.equippedWeapon.Unequip(); //unequips current weapon
                Inventory.equippedWeapon = this; //equips new weapon
            }
            else //if the item you're equiping is a weapon
            {
                Inventory.equippedArmor.Unequip(); //unequips current armor
                Inventory.equippedArmor = this; //equips new armor
            }

            isEquipped = true;
            //adds stats of equipable to the players stats
            Player.playerStats.Attack += plusAttack;
            Player.playerStats.MaxHP += plusHP;
            Player.playerStats.CurrentHP += plusHP;
            Player.playerStats.Agility += plusAgility;
        }
        public void Unequip()
        {
            if (isEquipped) //you can only unequip an equipped item
            {
                isEquipped = false;
                //subtracts the stats of equipale from the players stats
                Player.playerStats.Attack -= plusAttack;
                Player.playerStats.MaxHP -= plusHP;
                Player.playerStats.CurrentHP -= plusHP;
                Player.playerStats.Agility -= plusAgility;
            }
        }


    }
}
