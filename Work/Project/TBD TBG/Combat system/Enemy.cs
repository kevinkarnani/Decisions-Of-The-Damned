using System;

namespace TBD_TBG
{
    public class Enemy
    {

        /*
         * Enemies to be fought in combat
         * Has a name and various descriptions,
         * stats, and chances to light attack, heavy atack, and dodge 
         */
        public string Name { get; set; }//the name of the enemy
        public Stats EnemyStat { get; set; } //stats of the enemy (attack, agility, health)
        public string Description { get; set; } //description of the enemy
        public string ID { get; set; } //ID # for the enemy
        public string DeathDescription { get; set; } //description of how the enemy died
        //chances to do each attack
        public double ChanceToLightAttack; 
        public double ChanceToHeavyAttack;
        public double ChanceToDodge;

        //Constructor
        public Enemy(string ID, string Name, string Description, string Death)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            DeathDescription = Death;
        }
        //sets the stats of the enemy
        public void SetEnemyStat(int Agility, int Attack, int HP)
        {
            EnemyStat = new Stats(Agility, Attack, HP);
        }
        //sets the attack chances
        public void SetAttackChance(double lchance, double hchance, double dchance)
        {
            ChanceToLightAttack = lchance;
            ChanceToHeavyAttack = hchance;
            ChanceToDodge = dchance;
        }

        //ATTACKS
        //light attack
        public void LightAttack()
        {
            int damage = EnemyStat.Attack; //does base attack as damage
            Player.Damage(damage);
        }

        //heavy attack
        public void HeavyAttack()
        {
            int damage = Convert.ToInt32(2.5 * EnemyStat.Attack); //does 1.5x base attack as damage
            Player.Damage(damage);
        }

        //dodge
        //no method needed, player doesn't take damage

        //damages the enemy by reducing their currentHP stat
        public void Damage(int damage)
        {
            EnemyStat.CurrentHP -= damage;
        }

        //Randomly chooses an attack based on its chances
        public string ChooseRandomAttack()
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1

            if(randomNum <= ChanceToLightAttack) //ex: 0->.25
            {
                return "lightAttack";
            }
            else if(randomNum > ChanceToLightAttack && randomNum <= ChanceToLightAttack + ChanceToHeavyAttack) //ex .25->.5
            {
                return "heavyAttack";
            }
            else //ex .5 -> 1
            {
                return "dodge";
            }
        }

        //checks whether you evaded an attack or not
        public bool CheckIfHit() 
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1
            return randomNum > EnemyStat.Evasion;
        }
    }
}
