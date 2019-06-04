using System;

namespace TBD_TBG
{
    public class Enemy
    {
        public string Name { get; set; }//the name of the enemy
        public Stats EnemyStat { get; set; }
        public string Description { get; set; } //description of the enemy
        public string ID { get; set; }
        public string DeathDescription { get; set; }
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

        public void SetEnemyStat(int Agility, int Attack, int HP)
        {
            EnemyStat = new Stats(Agility, Attack, HP);
        }

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
            int damage = EnemyStat.Attack;
            Player.Damage(damage);
        }

        //heavy attack
        public void HeavyAttack()
        {
            int damage = Convert.ToInt32(2.5 * EnemyStat.Attack);
            Player.Damage(damage);
        }

        //dodge
        //no method needed, player doesn't take damage
        public void Damage(int damage)
        {
            EnemyStat.CurrentHP -= damage;
        }

        public string ChooseRandomAttack()
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1

            if(randomNum <= ChanceToLightAttack) //ex: 0->.25
            {
                return "lightAttack";
            }
            else if(randomNum > ChanceToLightAttack && randomNum <= ChanceToLightAttack + ChanceToHeavyAttack) //ex .25->(.25+.25)
            {
                return "heavyAttack";
            }
            else
            {
                return "dodge";
            }
        }
        public bool CheckIfHit() //checks whether you evaded an attack or not
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1
            return randomNum > EnemyStat.Evasion;
        }
    }
}
