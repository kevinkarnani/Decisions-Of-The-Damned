using System;

namespace TBD_TBG.Combat_system
{
    public class Enemy
    {
        public string ID { get; set; }//the id of the enemy
        public string Name { get; set; }//the name of the enemy
        public Stats EnemyStat { get; set; }
        public double ChanceToLightAttack;
        public double ChanceToHeavyAttack;
        public double ChanceToDodge;

        EnemyStats EnemyStats = new EnemyStats();
        //Constructor
        public Enemy(string id, string name)
        {
            ID = id;
            Name = name;
            EnemyStat = new Stats(EnemyStats.GetAgility(), EnemyStats.GetAttack(), EnemyStats.GetHP());
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
        public void Damage(int dmg)
        {
            EnemyStat.CurrentHP -= dmg;
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
