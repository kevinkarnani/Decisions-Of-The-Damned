using System;

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

        static readonly string battleColor = "yellow";
        static readonly string choiceColor = "cyan";

        public Combat(Enemy _enem)
        {
            enemy = _enem;
            enemyInitialEvasion = enemy.enemyStats.Evasion;

        }

        public void StartCombatLoop()
        {
            //header of the battle
            Utility.Write(">>>>>----------> BATTLE START <----------<<<<<", battleColor);
            Utility.Write("You face a " + enemy.name + "!", battleColor);
            Utility.Write("Description: " + enemy.description, battleColor);
            Console.WriteLine();

            int turnNumber = 1;
            var pressAnyKey ="";
            //start loop until someone dies
            while (Player.playerStats.CurrentHP >= 0 && enemy.enemyStats.CurrentHP > 0)
            {              
                Utility.Write("=====TURN #" + turnNumber + "=====", battleColor);

                //determine who goes first
                if (Player.playerStats.Agility > enemy.enemyStats.Agility) //the player goes first
                {
                    PlayerTurn(); //the player chooses an attack
                    if (enemy.enemyStats.CurrentHP == 0) //if you kill the enemy before they can attack back
                    {
                        break;
                    }  
                    pressAnyKey = Console.ReadLine();  //make the player press any key to continue

                    EnemyTurn(); //the enemy chooses an attack
                    pressAnyKey = Console.ReadLine();
                }
                else //the enemy goes first
                {
                    EnemyTurn(); //the enemy chooses an attack
                    if (Player.playerStats.CurrentHP == 0) //if the enemy kills you before you can attack back
                    {
                        break;
                    }
                    pressAnyKey = Console.ReadLine();
                    
                    PlayerTurn(); //the player chooses an attack                    
                    pressAnyKey = Console.ReadLine();
                }
                turnNumber++;
            }

            //determines who won the battle
            if (enemy.enemyStats.CurrentHP == 0) //you win
            {
                Utility.Write("You defeated the " + enemy.name + "!", battleColor);
                Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", battleColor);
            }
            else //you lose
            {
                Utility.Write("You lost to the " +  enemy.name + "!", battleColor);
                Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", battleColor);
                Utility.Write("GAME OVER", "red");
                Game.End();
            }
        }

        //the player's turn
        private void PlayerTurn()
        {
            //PLAYER TURN
            Utility.Write("---PLAYER TURN---", battleColor);
            
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
                    Utility.Write("You hit for " + Player.playerStats.HeavyAttack + " damage!", battleColor);
                }
                else //miss
                {
                    Utility.Write(enemy.name + " evaded your attack!", battleColor);
                }                
                playerPreparingHeavyAttack = false;
            }
            else //if you didn't prepare a heavy attack last turn you can attack
            {
                //the player's combat choices
                //TODO: Make sure this input is a number between 1 and 3                
                Utility.Write("Options:", choiceColor);
                Utility.Write("1) Light attack", choiceColor);
                Utility.Write("2) Heavy attack", choiceColor);
                Utility.Write("3) Dodge", choiceColor);
                //Utility.Write("4) Display Stats");
                //Utility.Write("5) Use an item");
                //Utility.Write("6) Flee?");
                string attackChoice = Console.ReadLine();

                //make attack choice
                switch (attackChoice)
                {
                    case "1"://light attack
                        if (enemy.CheckIfHit()) //hit
                        {
                            Player.LightAttack(enemy); // do light attack on enemy
                            Utility.Write("You hit for " + Player.playerStats.Attack + " damage!", battleColor);
                        }
                        else //miss
                        {
                            Utility.Write(enemy.name + " evaded your attack!", battleColor);
                        }                        
                        break;

                    case "2"://heavy attack
                        Utility.Write("You charge up for a powerful attack...", battleColor);
                        playerPreparingHeavyAttack = true; //sets up for a heavy attack next turn
                        break;
                    case "3"://dodge
                        Utility.Write("You prepare to dodge the enemy's attack...", battleColor);
                        Player.playerStats.Evasion += .65; 
                        playerDodgingAttack = true;
                        break;
                }                
            }
            //display health of enemy            
            Utility.Write("Enemy HP:" + enemy.enemyStats.CurrentHP + "/" + enemy.enemyStats.MaxHP, battleColor);
            //Console.WriteLine();
        }


        private void EnemyTurn()
        {
            //ENEMY TURN              
            Utility.Write("---ENEMY TURN---", battleColor);
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
                    Utility.Write(enemy.name + " hit for " + enemy.enemyStats.HeavyAttack + " damage!", battleColor);
                }
                else //miss
                {
                    Utility.Write("You evaded their attack!", battleColor);
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
                            Utility.Write(enemy.name + " hit for " + enemy.enemyStats.Attack + " damage!", battleColor);
                        }
                        else //miss
                        {
                            Utility.Write("You evaded their attack!", battleColor);
                        }

                        break;
                    case "heavyAttack":
                            Utility.Write("The " + enemy.name + " charges up for a powerful attack...", battleColor);
                            enemyPreparingHeavyAttack = true;
                            break;
                    case "dodge": 
                        Utility.Write("The " + enemy.name + " prepares to dodge your attack...", battleColor);
                        enemy.enemyStats.Evasion += .65;
                        enemyDodgingAttack = true;
                        break;
                }
            }
            
            //display health of player         
            Utility.Write("Player HP: " + Player.playerStats.CurrentHP + "/" + Player.playerStats.MaxHP, battleColor);
            //Console.WriteLine();
        }

    }

}
