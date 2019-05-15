using System;

namespace TBD_TBG
{
    public class Equipable : Item
    {
        public int plusAgility;
        public int plusHP; 
        public int plusAttack;
        public bool isEquipped;

        public Equipable(string Identification, string Name, string Description) : base(Identification, Name, Description)
        {
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
            this.isEquipped = false;
        }
        public void SetStats(int attack, int HP, int agility)
        {
            plusAgility = agility;
            plusHP = HP;
            plusAttack = attack; 
        }
        public void PrintEquipableStats()
        {
            string color = "darkcyan";
            Utility.Write("Attack: " + plusAttack, color);
            Utility.Write("Agility: " + plusAgility, color);
            Utility.Write("HP: " + plusHP, color);
            Console.WriteLine();
        }

        public void EquipItem()
        {
            //if it is not equipped
            if (!isEquipped)
            {
                isEquipped = true;
                Player.playerStats.Attack += plusAttack;
                Player.playerStats.CurrentHP += plusHP;
                Player.playerStats.MaxHP += plusHP;
                Player.playerStats.Agility += plusAgility;
            }
            else
            {
                //TODO: throw an error?
                Utility.Write("The item is already equipped.", "red");
            }
        }
        public void UnequipItem()
        {
            //if it is equipped
            if (isEquipped)
            {
                isEquipped = false;
                Player.playerStats.Attack -= plusAttack;
                Player.playerStats.CurrentHP -= plusHP;
                Player.playerStats.MaxHP -= plusHP;
                Player.playerStats.Agility -= plusAgility;
            }
            else
            {
                //TODO: throw an error?
                Utility.Write("The item is already unequipped.", "red");
            }            
        }
    }
}
