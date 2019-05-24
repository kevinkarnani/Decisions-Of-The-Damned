using System;

namespace TBD_TBG
{
    public static class Game
    {
        //colors for type of text
        public static readonly string choiceColor = "cyan";
        public static readonly string combatColor = "yellow";
        public static readonly string statsColor = "darkcyan";
        public static readonly string inventoryColor = "green";
        public static readonly string errorColor = "red";

        static Choice CurrentScenario; //Choice object that is associated with certain paths in the branching narrative        

        /* 
         * This function is meant to start the game. It outputs the title, the ASCII ART, the authors, creates the player,
         * sets player archetypes, deals with the branching narrative, *deals with combat*, and ends the game.
         */
        public static void Start()
        {
            GameTitle();
            Console.WriteLine(Utility.Center("                    ████████╗ ██████╗     ██████╗ ███████╗                       "));
            Console.WriteLine(Utility.Center("                    ╚══██╔══╝██╔═══██╗    ██╔══██╗██╔════╝                       "));
            Console.WriteLine(Utility.Center("                       ██║   ██║   ██║    ██████╔╝█████╗                         "));
            Console.WriteLine(Utility.Center("                       ██║   ██║   ██║    ██╔══██╗██╔══╝                         "));
            Console.WriteLine(Utility.Center("                       ██║   ╚██████╔╝    ██████╔╝███████╗                       "));
            Console.WriteLine(Utility.Center("                       ╚═╝    ╚═════╝     ╚═════╝ ╚══════╝                       "));
            Console.WriteLine(Utility.Center("██████╗ ███████╗████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗███████╗██████╗ "));
            Console.WriteLine(Utility.Center("██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔════╝██╔══██╗"));
            Console.WriteLine(Utility.Center("██║  ██║█████╗     ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║█████╗  ██║  ██║"));
            Console.WriteLine(Utility.Center("██║  ██║██╔══╝     ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ██║  ██║"));
            Console.WriteLine(Utility.Center("██████╔╝███████╗   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║███████╗██████╔╝"));
            Console.WriteLine(Utility.Center("╚═════╝ ╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚═════╝ "));
            Console.WriteLine(Utility.Center("[]xxx[]::::::::::>  A Text Based Game  <::::::::::[]xxx[]"));
            Console.WriteLine();
            Console.WriteLine(Utility.Center("Created by:"));
            Console.WriteLine(Utility.Center("Mark Melkumyan, Kev Karnani, Humaid Mustajab,"));
            Console.WriteLine(Utility.Center("Cort Williams, and Joey Hermann."));
            Console.WriteLine();

            Utility.Write("        Controls:");
            Utility.Write("        - Choices are shown in cyan", choiceColor);
            Utility.Write("            - Type a # to choose an option (ex. '2')");
            Utility.Write("        - Type 'I' to open your inventory");
            Utility.Write("        - Type 'O' to open your player overview");
            Utility.Write("        - Type 'Q' to quit any menu");
            Console.WriteLine();
            

            CreatePlayer();
            
            Player.playerStats.CurrentHP -= 50;
            
            Equipable weapon1 = new Equipable("1", "iron sword", "a crappy sword", true);
            weapon1.SetStats(10, 10, 0);
            Equipable weapon2 = new Equipable("2", "wooden sword", "a shitty sword", true);
            weapon2.SetStats(5, 5, 0);
            Equipable armor1 = new Equipable("3", "iron armor", "shiny armor fancy fancy", false);
            armor1.SetStats(0, 0, 10);
            Equipable armor2 = new Equipable("4", "leather armor", "old leather armor that smells like shit", false);
            armor2.SetStats(0, 0, 5);
            
            Inventory.AddItem(weapon1);
            Inventory.AddItem(weapon2);
            Inventory.AddItem(armor1);
            Inventory.AddItem(armor2);
            weapon1.Equip();
            weapon2.Equip();
            armor1.Equip();

            Consumable potion1 = new Consumable("1", "Health potion", "a red liquid in a shiny bottle", true);
            potion1.SetStats(0, 0, 20);
            Consumable potion2 = new Consumable("2", "Attack potion", "a blue liquid in a dark bottle", false);
            potion2.SetStats(10, 0, 0);

            Inventory.AddItem(potion1);
            Inventory.AddItem(potion1);
            Inventory.AddItem(potion2);
            //potion1.UseEffect();

            InitializeScenarios();
            StartGameLoop();
            End();
        }

        //This method sets the player's name and player's archetype
        public static void CreatePlayer()
        {
            //Make sure this input is a number between 1 and 4
            while (true)
            {
                try
                {
                    Utility.Write("What class would you like to play as?");
                    Utility.Write("1) Adventurer: Balanced stats", Game.choiceColor);
                    Utility.Write("2) Paladin: Defense focused", Game.choiceColor);
                    Utility.Write("3) Brawler: Attack focused", Game.choiceColor);
                    Utility.Write("4) Rogue: Quick", Game.choiceColor);
                    Utility.Write("Type 1, 2, 3, or 4", Game.choiceColor);

                    Player.Archetype = Utility.Input();
                    break;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is FormatException)
                    {
                        Utility.Write("Invalid Archetype Selection. Try Again", Game.errorColor);
                    }
                }
            }
            Utility.Write("Welcome " + Player.Name + "! You are a(n) " + Player.archetype + "!");
            Utility.Write("Now let the story begin...\n");
        }

        //This method initializes all Choice objects
        public static void InitializeScenarios()
        {
            GameFileParser.Parser();
            CurrentScenario = GameFileParser.GlobalChoices["A1A"];
        }
        
        //Loops through Choice objects for branching narrative
        public static void StartGameLoop()
        {
            while (true)
            {
                Utility.Write(CurrentScenario.Description);
                if (!CurrentScenario.CheckChoice()) //TODO: Change this to check the scenario's hasCombat variable
                {
                    StartCombat();
                    break;
                }
                Utility.AllValues(CurrentScenario);
                string selection = Utility.Input();
                //Error checking the user input
                if(selection.ToLower() == "i") //press i to open inventory menu
                {
                    Inventory.OpenInventoryMenu();
                }
                else if (selection.ToLower() == "o")
                {
                    Player.PrintPlayerOverview(); //press o to open player overview
                }
                else
                {
                    try
                    {
                        CurrentScenario = CurrentScenario.GetChoice(selection);
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentOutOfRangeException || ex is FormatException)
                        {
                            Utility.Write("Invalid Choice Selection. Try Again.", Game.errorColor);
                        }
                    }
                }
                
            }
        }

        //Start Combat
        public static void StartCombat()
        {
            Console.ReadLine();
            EnemyFileParser.Parser();
            Enemy currentEnemy = EnemyFileParser.GlobalEnemies["1"];
            Console.WriteLine();
            Player.PrintPlayerOverview();

            Combat fight1 = new Combat(currentEnemy);
            fight1.StartCombatLoop();

            Player.PrintPlayerOverview();
        }

        //Create Game Title
        static void GameTitle()
        {
            string Title = @"TBD TBG";
            Console.Title = Title;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Utility.Write(Title);
            Console.ResetColor();
            Utility.Write("Please fullscreen the window for the best experience.", "red");
            Utility.Write("Press enter to start");
            Console.ReadKey();
            Console.Clear();
        }

        //End the Game
        public static void End()
        {
            Utility.Write("Press enter to exit.");
        }
    }
}
