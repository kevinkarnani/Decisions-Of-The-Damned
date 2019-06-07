using System;

namespace TBD_TBG
{
    public class EnemyStats
    {

        //CLASS ATTRIBUTES
        public string ID { get; set; }//the id of the enemy
        public string Name { get; set; }//the name of the enemy
        public string Attack { get; set; }
        public string Agility { get; set; }
        public string HP { get; set; }
        public string ChanceToLightAttack { get; set; } 
        public string ChanceToHeavyAttack { get; set; }
        public string ChanceToDodge { get; set; }
        public string Description { get; set; } //description of the enemy
        public string DeathDescription { get; set; }

        //getters
        public string GetID()
        {
            return ID;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetAttack()
        {
            return Int32.Parse(Attack);
        }

        public int GetAgility()
        {
            return Int32.Parse(Agility);
        }

        public int GetHP()
        {
            return Int32.Parse(HP);
        }

        public double GetChanceToLightAttack()
        {
            return Double.Parse(ChanceToLightAttack);
        }

        public double GetChanceToHeavyAttack()
        {
            return Double.Parse(ChanceToHeavyAttack);
        }

        public double GetChanceToDodge()
        {
            return Double.Parse(ChanceToDodge);
        }

        public string GetDescription()
        {
            return Description;
        }
        public string GetDeathDescription()
        {
            return DeathDescription;
        }
    }
}