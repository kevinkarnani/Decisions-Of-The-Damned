using System;

namespace TBD_TBG
{
    public class Equipable : Item
    {
        public int plusAgility; //additional agility stat
        public int plusHP; //additional HP stat
        public int plusAttack; //additional attack stat
        public bool isEquipped; //whether the equipable is equiped or not
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
        public void PrintEquipableStats()
        {
            string color = "darkcyan";
            Utility.Write("+Attack: " + plusAttack, color);
            Utility.Write("+Agility: " + plusAgility, color);
            Utility.Write("+HP: " + plusHP, color);
            Console.WriteLine();
        }

        
    }
}
