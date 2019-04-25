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
            enemyStats.setAttack(_attack);
            enemyStats.setAgilty(_agility);
            enemyStats.setMaxHP(_HP);
            enemyStats.setCurrentHP(_HP);
        }

        //CLASS METHODS
            //setters
        public void setLightChance(double _chance)
        {
            chanceToLightAttack = _chance;
        }
        public void setHeavyChance(double _chance)
        {
            chanceToHeavyAttack = _chance;
        }
        public void setDodgeChance(double _chance)
        {
            chanceToDodge = _chance;
        }

            //ATTACKS
                //light attack
                //NEED HELP!!
        /*
        public static void lightAttack()
        {
            int playerHP = Player.playerStats.getCurrentHP();
            int damage = Enemy.enemyStats.getCurrentHP(); //<< I don't know why this line doesn't work
            Player.playerStats.setCurrentHP(playerHP - damage);
        }
        */
                //heavy attack

                //dodge
                    //no method needed, player doesn't take damage

    }
}