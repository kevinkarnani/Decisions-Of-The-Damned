using System;

namespace TBD_TBG
{
    public class Enemy
    {
        //CLASS ATTRIBUTES
        public string name = ""; //the name of the enemy
        public string description = ""; //description of the enemy
        public Stats enemyStats; //the enemies' stats (agi, attack, and HP)
        //all the chances must be between 0 and 1, and add to 1
        public double chanceToLightAttack; 
        public double chanceToHeavyAttack;
        public double chanceToDodge;

        //CLASS CONTRUCTOR
        public Enemy(string _name, int _attack, int _agility, int _HP)
        {
            name = _name;
            enemyStats.SetAttack(_attack);
            enemyStats.SetAgilty(_agility);
            enemyStats.SetMaxHP(_HP);
            enemyStats.SetCurrentHP(_HP);
        }

        //CLASS METHODS
            //setters
        public void SetLightChance(double _chance)
        {
            chanceToLightAttack = _chance;
        }
        public void SetHeavyChance(double _chance)
        {
            chanceToHeavyAttack = _chance;
        }
        public void SetDodgeChance(double _chance)
        {
            chanceToDodge = _chance;
        }

            //ATTACKS
            //light attack
        public void LightAttack()
        {
            int playerHP = Player.playerStats.GetCurrentHP();
            int damage = enemyStats.GetCurrentHP(); 
            Player.playerStats.SetCurrentHP(playerHP - damage);
        }
            //heavy attack
        public void HeavyAttack(Enemy _enem)
        {
            int playerHP = Player.playerStats.GetCurrentHP();
            int damage = Convert.ToInt32(2.5 * enemyStats.GetCurrentHP()); 
            Player.playerStats.SetCurrentHP(playerHP - damage);
        }
            //dodge
                //no method needed, player doesn't take damage

    }
}