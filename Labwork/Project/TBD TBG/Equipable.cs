using System;

namespace TBD_TBG
{
    public class Equipable : Item
    {
        public int plusAgility;
        public int plusHP; 
        public int plusAttack;

        public Equipable(string Identification, string Name, string Description) : base(Identification, Name, Description)
        {
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
        }
        public void setStats(int attack, int HP, int agility)
        {
            plusAgility = agility;
            plusHP = HP;
            plusAttack = attack; 
        }
        public void printEquipableStats()
        {
            string color = "darkcyan";
            Utility.Write("Attack: " + plusAttack, color);
            Utility.Write("Agility: " + plusAgility, color);
            Utility.Write("HP: " + plusHP, color);
            Console.WriteLine();
        }

        public void equipItem()
        {

        }
    }
}
