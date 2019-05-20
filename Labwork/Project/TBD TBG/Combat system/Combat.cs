﻿using System;

namespace TBD_TBG
{
    public class Combat
    {
        /*
         * TODO:
         * add in evasion (chance to hit)
         * add in dodge for player
         * add in heavy attack for enemy
         * add in dodge for enemy
         */
        private Enemy enemy;

        private double playerInitialEvasion = Player.playerStats.Evasion;
        private bool playerPreparingHeavyAttack = false;
        private bool playerDodgingAttack = false;

        private double enemyInitialEvasion; 
        private bool enemyPreparingHeavyAttack = false;
        private bool enemyDodgingAttack = false;

        public Combat(Enemy _enem)
        {
            enemy = _enem;
            enemyInitialEvasion = enemy.enemyStats.Evasion;

        }

        public void StartCombatLoop()
        {
            //header of the battle
            Utility.Write(">>>>>----------> BATTLE START <----------<<<<<", Game.combatColor);
            Utility.Write("You face a " + enemy.name + "!", Game.combatColor);
            Utility.Write("Description: " + enemy.description, Game.combatColor);
            Console.WriteLine();

            int turnNumber = 1;
            var pressAnyKey = "";
            //start loop until someone dies
            while (Player.playerStats.CurrentHP > 0 && enemy.enemyStats.CurrentHP > 0)
            {
                Utility.Write("=====TURN #" + turnNumber + "=====", Game.combatColor);
                //determine who goes first
                if (Player.playerStats.Agility > enemy.enemyStats.Agility) //the player goes first
                {
                    try
                    {
                        PlayerTurn();
                        if (enemy.enemyStats.CurrentHP <= 0) //if you kill the enemy before they can attack back
                        {
                            break;
                        }
                        pressAnyKey = Console.ReadLine();  //make the player press any key to continue
                        EnemyTurn(); //the enemy chooses an attack
                        pressAnyKey = Console.ReadLine();
                        turnNumber++;
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentException)
                        {
                            Utility.Write("Invalid Choice Selection", "red");
                        }
                    }
                }
                else //the enemy goes first
                {
                    EnemyTurn(); //the enemy chooses an attack
                    if (Player.playerStats.CurrentHP <= 0) //if the enemy kills you before you can attack back
                    {
                        break;
                    }
                    pressAnyKey = Console.ReadLine();

                    PlayerTurn(); //the player chooses an attack                    
                    pressAnyKey = Console.ReadLine();
                    turnNumber++;
                }
            }
            //determines who won the battle
            if (enemy.enemyStats.CurrentHP <= 0) //you win
            {
                Utility.Write("You defeated the " + enemy.name + "!", Game.combatColor);
                Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", Game.combatColor);
            }
            else if (Player.playerStats.CurrentHP <= 0)//you lose
            {
                Utility.Write("You lost to the " + enemy.name + "!", Game.combatColor);
                Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", Game.combatColor);
                Utility.Write("GAME OVER", "red");
                Game.End();
            }
        }

        //the player's turn
        private void PlayerTurn()
        {
            //PLAYER TURN
            Utility.Write("---PLAYER TURN---", Game.combatColor);
            
            if (playerDodgingAttack) //if you dodged an attack last turn
            {
                playerDodgingAttack = false;
                Player.playerStats.Evasion = playerInitialEvasion; //resets evasion
            }

            if (playerPreparingHeavyAttack) //if you chose a heavy attack last turn
            {
                if (enemy.CheckIfHit()) //hit
                {
                    Player.HeavyAttack(enemy); //do heavy attack on enemy
                    Utility.Write("You hit for " + Player.playerStats.HeavyAttack + " damage!", Game.combatColor);
                }
                else //miss
                {
                    Utility.Write(enemy.name + " evaded your attack!", Game.combatColor);
                }                
                playerPreparingHeavyAttack = false;
            }
            else //if you didn't prepare a heavy attack last turn you can attack
            {
                //the player's combat choices
                //TODO: ERROR CHECKING           
                Utility.Write("Options:", Game.choiceColor);
                Utility.Write("1) Light attack", Game.choiceColor);
                Utility.Write("2) Heavy attack", Game.choiceColor);
                Utility.Write("3) Dodge", Game.choiceColor);
                //Utility.Write("4) Display Stats");
                //Utility.Write("5) Use an item");
                //Utility.Write("6) Flee?");

                //make attack choice
                string attackChoice = Utility.Input();                
                try
                {
                    switch (attackChoice)
                    {
                        case "1"://light attack
                            if (enemy.CheckIfHit()) //hit
                            {
                                Player.LightAttack(enemy); // do light attack on enemy
                                Utility.Write("You hit for " + Player.playerStats.Attack + " damage!", Game.combatColor);
                            }
                            else //miss
                            {
                                Utility.Write(enemy.name + " evaded your attack!", Game.combatColor);
                            }
                            break;
                        case "2"://heavy attack
                            Utility.Write("You charge up for a powerful attack...", Game.combatColor);
                            playerPreparingHeavyAttack = true; //sets up for a heavy attack next turn
                            break;
                        case "3"://dodge
                            Utility.Write("You prepare to dodge the enemy's attack...", Game.combatColor);
                            Player.playerStats.Evasion += .65;
                            playerDodgingAttack = true;
                            break;
                        default://bad input
                            throw new ArgumentException();
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is FormatException)
                    {
                        Utility.Write("Invalid Choice Selection. Try Again.", "red");
                    }
                }
            }
            //display health of enemy            
            Utility.Write("Enemy HP:" + enemy.enemyStats.CurrentHP + "/" + enemy.enemyStats.MaxHP, Game.combatColor);
            //Console.WriteLine();
        }
        
        private void EnemyTurn()
        {
            //ENEMY TURN              
            Utility.Write("---ENEMY TURN---", Game.combatColor);
            if (enemyDodgingAttack) //if you dodged an attack last turn
            {
                enemyDodgingAttack = false;
                enemy.enemyStats.Evasion = playerInitialEvasion; //resets evasion
            }

            if (enemyPreparingHeavyAttack) //if you chose a heavy attack last turn
            {
                if (Player.CheckIfHit()) //hit
                {
                    enemy.HeavyAttack(); 
                    Utility.Write(enemy.name + " hit for " + enemy.enemyStats.HeavyAttack + " damage!", Game.combatColor);
                }
                else //miss
                {
                    Utility.Write("You evaded their attack!", Game.combatColor);
                }
                enemyPreparingHeavyAttack = false;
            }
            else //if you didn't prepare a heavy attack last turn you can attack
            {
                switch (enemy.ChooseRandomAttack())
                {
                    case "lightAttack":
                        if (Player.CheckIfHit()) //hit
                        {
                            enemy.LightAttack();
                            Utility.Write(enemy.name + " hit for " + enemy.enemyStats.Attack + " damage!", Game.combatColor);
                        }
                        else //miss
                        {
                            Utility.Write("You evaded their attack!", Game.combatColor);
                        }

                        break;
                    case "heavyAttack":
                            Utility.Write("The " + enemy.name + " charges up for a powerful attack...", Game.combatColor);
                            enemyPreparingHeavyAttack = true;
                            break;
                    case "dodge": 
                        Utility.Write("The " + enemy.name + " prepares to dodge your attack...", Game.combatColor);
                        enemy.enemyStats.Evasion += .65;
                        enemyDodgingAttack = true;
                        break;
                }
            }
            //display health of player         
            Utility.Write("Player HP: " + Player.playerStats.CurrentHP + "/" + Player.playerStats.MaxHP, Game.combatColor);
            //Console.WriteLine();
        }
    }
}