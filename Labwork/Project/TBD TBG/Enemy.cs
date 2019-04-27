using System;

namespace TBD_TBG
{
    public class Enemy
    {
        //TODO: MAKE GETTERS AND SETTERS FOR ENEMY CLASS

        //CLASS ATTRIBUTES
        public string name = ""; //the name of the enemy
        public string description = ""; //description of the enemy
        public Stats enemyStats;//= new Stats(0,0,0) //the enemies' stats (agi, attack, and HP)
        //all the chances must be between 0 and 1, and add to 1
        public double chanceToLightAttack; 
        public double chanceToHeavyAttack;
        public double chanceToDodge;

        //CLASS CONTRUCTOR
        public Enemy(string _name, int _attack, int _agility, int _HP)
        {
            name = _name;
            enemyStats = new Stats(_agility, _attack, _HP);
        }

        //CLASS METHODS
            //setters
        public void SetAttackChance(double _lchance, double _hchance, double _dchance)
        {
            chanceToLightAttack = _lchance;
            chanceToHeavyAttack = _hchance;
            chanceToDodge = _dchance;
        }

            //ATTACKS
            //light attack
        public void LightAttack()
        {
            int damage = enemyStats.Attack;
            Player.Damage(damage);
        }
            //heavy attack
        public void HeavyAttack(Enemy _enem)
        {
            int damage = Convert.ToInt32(2.5 * enemyStats.Attack);
            Player.Damage(damage);
        }
        //dodge
        //no method needed, player doesn't take damage
        public void Damage(int _dmg)
        {
           enemyStats.CurrentHP -= _dmg;
        }
        public string ChooseRandomAttack()
        {
            Random random = new Random();
            double randomNum = random.NextDouble(); //random number between 0 and 1

            if(randomNum >=0 && randomNum <= chanceToLightAttack) //ex: 0->.25
            {
                return "lightAttack";
            }
            else if(randomNum >chanceToLightAttack && randomNum <= chanceToLightAttack + chanceToHeavyAttack) //ex .25->(.25+.25)
            {
                return "heavyAttack";
            }
            else
            {
                return "dodge";
            }
        }
    }
}