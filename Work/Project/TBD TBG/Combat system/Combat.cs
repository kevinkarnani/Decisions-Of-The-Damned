using System;
namespace TBD_TBG
{
    public class Combat
    {
        /*
         * This class is used for combat interactions with enemies. 
         * It includes functions for starting a battle, the main combat loop,
         * the player turn, the enemy turn, a turn counter, and funcions for 
         * when the player wins or loses.
         */
        //the enemy to be fought
        private Enemy enemy;

        //the initial evasion of the player at the start of the battle before it's boosted by dodges
        private double playerInitialEvasion = Player.playerStats.Evasion;

        //the inital attack and agility of the player at the start of the battle before it's boosted by consumable items
        private int[] initialPlayerStats = new int[2] { Player.playerStats.Attack, Player.playerStats.Agility };

        //whether or not the player is preparing a heavy attack or dodge from the previous turn
        private bool playerPreparingHeavyAttack = false;
        private bool playerDodgingAttack = false;

        //the initial stats of the enemy at the start of the battle before they're boosted by dodges
        private double enemyInitialEvasion;

        //whether or not the enemy is preparing a heavy attack or dodge from the previous turn
        private bool enemyPreparingHeavyAttack = false;
        private bool enemyDodgingAttack = false;

        //the turn number of the battle. After the player and enemy make an action, it increments
        private int turnNumber;

        //whether or not the player won the battle
        public static bool PlayerWon { get; set; }
        

        //initialises combat object. All that's needed is an enemy to fight
        public Combat(Enemy enemy)
        {
            this.enemy = enemy;
            enemyInitialEvasion = enemy.EnemyStat.Evasion;

        }

        //prints the title for the start of a combat event
        private void BattleStart()
        {
            Utility.Write(">>>>>----------> BATTLE START <----------<<<<<", Game.combatColor);
            Utility.Write("You face " + enemy.Name + "!", Game.combatColor);
            Utility.Write("Description: " + enemy.Description, Game.combatColor);
            Console.WriteLine();
        }
        /*
         * The main loop for combat. 
         * Determines who goes first based off of agility, then alternates between 
         * the playerturn and enemy turn. 
         * If either drops below 0 health, the loop end and it determines the winner.
         */
        public void StartCombatLoop()
        {
            Player.inCombat = true;
            //header of the battle
            BattleStart();
            turnNumber = 1;
            var pressAnyKey = "";
            //start loop until someone dies
            while (Player.playerStats.CurrentHP > 0 && enemy.EnemyStat.CurrentHP > 0)
            {
                TurnNumber(); //prints turn number
                //determine who goes first
                if (Player.playerStats.Agility > enemy.EnemyStat.Agility) //the player goes first
                {
                    try
                    {
                        PlayerTurn();
                        if (enemy.EnemyStat.CurrentHP <= 0) //if you kill the enemy before they cant attack back
                        {
                            break;
                        }
                        pressAnyKey = Console.ReadLine();  //make the player press any key to continue
                        EnemyTurn(); //the enemy chooses an attack
                        pressAnyKey = Console.ReadLine(); //make the player press any key to continue
                        turnNumber++; //incrememnt turn number
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentException)
                        {
                            Utility.Write("Invalid Choice Selection", Game.errorColor);
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
                    pressAnyKey = Console.ReadLine(); //make the player press any key to continue
                    turnNumber++; //incrememnt turn number
                }
            }
            
            //clear consumable item buffs
            Player.playerStats.Attack = initialPlayerStats[0];
            Player.playerStats.Agility = initialPlayerStats[1];

            //determines who won the battle
            if (enemy.EnemyStat.CurrentHP <= 0) //you win
            {
                PlayerWin();
            }
            else if (Player.playerStats.CurrentHP <= 0)//you lose
            {
                EnemyWin();
            }
            Player.inCombat = false;
        }

        //prints the turn number
        private void TurnNumber()
        {
            Utility.Write("=====TURN #" + turnNumber + "=====", Game.combatColor);
        }

        //prints if the player wins
        private void PlayerWin()
        {
            Utility.Write("You defeated the " + enemy.Name + "!", Game.combatColor);
            Utility.Write(enemy.DeathDescription);
            Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", Game.combatColor);
            PlayerWon = true;
        }

        //prints if the player loses
        private void EnemyWin()
        {
            Utility.Write("You lost to the " + enemy.Name + "!", Game.combatColor);
            Utility.Write(">>>>>----------> BATTLE FINISH <----------<<<<<", Game.combatColor);
            PlayerWon = false;
        }

        /*
         * The player turn. 
         * You have options to attack, heavy attack, and dodge
         * Attack does your attack stat damage to the enemy
         * Heavy attack does 1.5x your attack stat damae to the enemy and takes a turn to charge
         * Dodge boosts your evasion for one turn
         */
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
                    Utility.Write(enemy.Name + " evaded your attack!", Game.combatColor);
                }                
                playerPreparingHeavyAttack = false;
            }
            else //if you didn't prepare a heavy attack last turn you can make an action
            {
                //the player's combat choices    
                DisplayCombatOptions();

                //make attack choice
                string attackChoice = (Utility.Input()).ToLower();

                //inventory and overview can't end your turn bc they arent attacks, so they loop infinitely
                while (attackChoice != "1" && attackChoice != "2" && attackChoice != "3") //choosing an attack option stops the loop
                {
                    if (attackChoice == "o") //print yours stop
                    {
                        Player.playerStats.PrintStatOverview();
                        Console.WriteLine();
                    }
                    else if (attackChoice == "i") //opens inventory. You can only access consumable items, not equipables
                    {
                        Inventory.ConsumeItemSubmenu();
                        Console.WriteLine();
                    }
                    else
                    {
                        Utility.Write("Invalid Choice Selection. Try Again.", Game.errorColor);
                    }

                    DisplayCombatOptions();
                    //make attack choice
                    attackChoice = (Utility.Input()).ToLower();
                }                    

                //only a attack can end your turn
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
                                Utility.Write(enemy.Name + " evaded your attack!", Game.combatColor);
                            }
                            break;
                        case "2"://heavy attack
                            Utility.Write("You charge up for a powerful attack...", Game.combatColor);
                            playerPreparingHeavyAttack = true; //sets up for a heavy attack next turn
                            break;
                        case "3"://dodge
                            Utility.Write("You prepare to dodge the enemy's attack...", Game.combatColor);
                            Player.playerStats.Evasion += .65; //boosts your evasion stat
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
                        Utility.Write("Invalid Choice Selection. Try Again.", Game.errorColor);
                    }
                }
            }
            //display health of enemy            
            Utility.Write("Enemy HP:" + enemy.EnemyStat.CurrentHP + "/" + enemy.EnemyStat.MaxHP, Game.combatColor);
        }
        //prints the options for the player in combat
        private void DisplayCombatOptions()
        {
            Utility.Write("Options:", Game.combatColor);
            Menu.OutputIndent("1", new Menu("Light attack"));
            Menu.OutputIndent("2", new Menu("Heavy attack"));
            Menu.OutputIndent("3", new Menu("Dodge"));
            Menu.OutputIndent("I", new Menu("Use an item"));
            Menu.OutputIndent("O", new Menu("Display stats"));
        }

        /*
         * The enemy turn. 
         * they have options to attack, heavy attack, and dodge (behaves the same as the player)
         * they choose their attacks randomly based on their predetermined chances 
         */
        private void EnemyTurn()
        {
            //ENEMY TURN              
            Utility.Write("---ENEMY TURN---", Game.combatColor);
            if (enemyDodgingAttack) //if you dodged an attack last turn
            {
                enemyDodgingAttack = false;
                enemy.EnemyStat.Evasion = enemyInitialEvasion; //resets evasion
            }

            if (enemyPreparingHeavyAttack) //if you chose a heavy attack last turn
            {
                if (Player.CheckIfHit()) //hit
                {
                    enemy.HeavyAttack(); 
                    Utility.Write(enemy.Name + " hit for " + enemy.EnemyStat.HeavyAttack + " damage!", Game.combatColor);
                }
                else //miss
                {
                    Utility.Write("You evaded their attack!", Game.combatColor);
                }
                enemyPreparingHeavyAttack = false;
            }
            else //if you didn't prepare a heavy attack last turn you can attack
            {
                switch (enemy.ChooseRandomAttack())//randomly chooses an attack
                {
                    case "lightAttack":
                        if (Player.CheckIfHit()) //hit
                        {
                            enemy.LightAttack();
                            Utility.Write(enemy.Name + " hit for " + enemy.EnemyStat.Attack + " damage!", Game.combatColor);
                        }
                        else //miss
                        {
                            Utility.Write("You evaded their attack!", Game.combatColor);
                        }

                        break;
                    case "heavyAttack":
                            Utility.Write("The " + enemy.Name + " charges up for a powerful attack...", Game.combatColor);
                            enemyPreparingHeavyAttack = true;
                            break;
                    case "dodge": 
                        Utility.Write("The " + enemy.Name + " prepares to dodge your attack...", Game.combatColor);
                        enemy.EnemyStat.Evasion += .65;
                        enemyDodgingAttack = true;
                        break;
                }
            }
            //display health of player         
            Utility.Write("Player HP: " + Player.playerStats.CurrentHP + "/" + Player.playerStats.MaxHP, Game.combatColor);
        }
    }
}
