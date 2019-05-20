using System;

namespace TBD_TBG
{
    public class Equipable : Item
    {
        public int plusAgility;
        public int plusHP; 
        public int plusAttack;
        public bool isEquipped;
        public bool isWeapon;

        public Equipable(string Identification, string Name, string Description, bool isWeapon) : base(Identification, Name, Description)
        {
            //TODO: fix this init? it doesnt look right ^^^
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
            this.isEquipped = false;
            this.isWeapon = isWeapon; 
        }
        public void SetStats(int attack, int agility, int HP)
        {
            plusAgility = agility;
            plusHP = HP;
            plusAttack = attack; 
        }
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
