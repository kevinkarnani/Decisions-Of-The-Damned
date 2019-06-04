using System;
using System.Linq;

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
        public static bool game = true;

        static Choice CurrentScenario; //Choice object that is associated with certain paths in the branching narrative
        static Enemy CurrentEnemy;

        /* 
         * This function is meant to start the game. It outputs the title, the ASCII ART, the authors, creates the player,
         * sets player archetypes, deals with the branching narrative, *deals with combat*, and ends the game.
         */
        public static void Start()
        {
            GameTitle();
            Console.WriteLine();
            Console.WriteLine(Utility.Center("████████▄     ▄████████  ▄████████  ▄█     ▄████████  ▄█   ▄██████▄  ███▄▄▄▄      ▄████████       ▄██████▄     ▄████████"));
            Console.WriteLine(Utility.Center("███   ▀███   ███    ███ ███    ███ ███    ███    ███ ███  ███    ███ ███▀▀▀██▄   ███    ███      ███    ███   ███    ███"));
            Console.WriteLine(Utility.Center("███    ███   ███    █▀  ███    █▀  ███▌   ███    █▀  ███▌ ███    ███ ███   ███   ███    █▀       ███    ███   ███    █▀ "));
            Console.WriteLine(Utility.Center("███    ███  ▄███▄▄▄     ███        ███▌   ███        ███▌ ███    ███ ███   ███   ███             ███    ███  ▄███▄▄▄    "));
            Console.WriteLine(Utility.Center("███    ███ ▀▀███▀▀▀     ███        ███▌ ▀███████████ ███▌ ███    ███ ███   ███ ▀███████████      ███    ███ ▀▀███▀▀▀    "));
            Console.WriteLine(Utility.Center("███    ███   ███    █▄  ███    █▄  ███           ███ ███  ███    ███ ███   ███          ███      ███    ███   ███       "));
            Console.WriteLine(Utility.Center("███   ▄███   ███    ███ ███    ███ ███     ▄█    ███ ███  ███    ███ ███   ███    ▄█    ███      ███    ███   ███       "));
            Console.WriteLine(Utility.Center("████████▀    ██████████ ████████▀  █▀    ▄████████▀  █▀    ▀██████▀   ▀█   █▀   ▄████████▀        ▀██████▀    ███       "));
            Console.WriteLine(Utility.Center(""));
            Console.WriteLine(Utility.Center("    ███        ▄█    █▄       ▄████████      ████████▄     ▄████████   ▄▄▄▄███▄▄▄▄   ███▄▄▄▄      ▄████████ ████████▄   "));
            Console.WriteLine(Utility.Center("▀█████████▄   ███    ███     ███    ███      ███   ▀███   ███    ███ ▄██▀▀▀███▀▀▀██▄ ███▀▀▀██▄   ███    ███ ███   ▀███  "));
            Console.WriteLine(Utility.Center("   ▀███▀▀██   ███    ███     ███    █▀       ███    ███   ███    ███ ███   ███   ███ ███   ███   ███    █▀  ███    ███  "));
            Console.WriteLine(Utility.Center("    ███   ▀  ▄███▄▄▄▄███▄▄  ▄███▄▄▄          ███    ███   ███    ███ ███   ███   ███ ███   ███  ▄███▄▄▄     ███    ███  "));
            Console.WriteLine(Utility.Center("    ███     ▀▀███▀▀▀▀███▀  ▀▀███▀▀▀          ███    ███ ▀███████████ ███   ███   ███ ███   ███ ▀▀███▀▀▀     ███    ███  "));
            Console.WriteLine(Utility.Center("    ███       ███    ███     ███    █▄       ███    ███   ███    ███ ███   ███   ███ ███   ███   ███    █▄  ███    ███  "));
            Console.WriteLine(Utility.Center("    ███       ███    ███     ███    ███      ███   ▄███   ███    ███ ███   ███   ███ ███   ███   ███    ███ ███   ▄███  "));
            Console.WriteLine(Utility.Center("   ▄████▀     ███    █▀      ██████████      ████████▀    ███    █▀   ▀█   ███   █▀   ▀█   █▀    ██████████ ████████▀   "));
            Console.WriteLine(Utility.Center("               _      _____         _     ____                     _    ____                                "));
            Console.WriteLine(Utility.Center("              / \\    |_   _|____  _| |_  | __ )  __ _ ___  ___  __| |  / ___| __ _ _ __ ___   ___           "));
            Console.WriteLine(Utility.Center("       / _ \\     | |/ _ \\ \\/ / __| |  _ \\ / _` / __|/ _ \\/ _` | | |  _ / _` | '_ ` _ \\ / _ \\    "));
            Console.WriteLine(Utility.Center("  / ___ \\    | |  __/>  <| |_  | |_) | (_| \\__ \\  __/ (_| | | |_| | (_| | | | | | |  __/"));
            Console.WriteLine(Utility.Center(" /_/   \\_\\   |_|\\___/_/\\_\\___| |____/ \\__,_|___/\\___|\\__,_|  \\____|\\__,_|_| |_| |_|\\___|"));
            Console.WriteLine();
            Console.WriteLine(Utility.Center("<::::::::::::[]xxx[] xXx []xxx[]::::::::::::>"));
            Console.WriteLine();
            Console.WriteLine(Utility.Center("Created by:"));
            Console.WriteLine(Utility.Center("Mark Melkumyan, Kev Karnani, Humaid Mustajab,"));
            Console.WriteLine(Utility.Center("Cort Williams, and Joey Hermann."));
            Console.WriteLine();
            var pressAnyKey = Console.ReadLine();  //make the player press any key to continue

            Console.WriteLine(String.Concat(Enumerable.Repeat("=", Console.WindowWidth)));
            Console.WriteLine();

            Utility.Write("Controls:");
            Utility.Write(" - Choices are shown in cyan", choiceColor);
            Utility.Write("    - Type a # to choose an option (ex. '2')");
            Utility.Write(" - Type 'I' to open your inventory");
            Utility.Write(" - Type 'O' to open your player overview");
            Utility.Write(" - Type 'Q' to quit any menu");
            Console.WriteLine();
            

            CreatePlayer();
            
            ///*
            Equipable weapon1 = new Equipable("1", "iron sword", "a crappy sword");
            weapon1.SetIsWeapon(true);
            weapon1.SetStats(10, 10, 0);
            Equipable weapon2 = new Equipable("2", "wooden sword", "a shitty sword");
            weapon2.SetStats(5, 5, 0);
            weapon2.SetIsWeapon(true);
            Equipable armor1 = new Equipable("3", "iron armor", "shiny armor fancy fancy");
            armor1.SetStats(0, 0, 10);
            armor1.SetIsWeapon(false);
            Equipable armor2 = new Equipable("4", "leather armor", "old leather armor that smells like shit");
            armor2.SetStats(0, 0, 5);
            armor2.SetIsWeapon(false);

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
            //*/

            InitializeScenarios();
            InitializeEnemy();
            GameLoop();
            End();
        }

        //This method sets the player's name and player's archetype
        public static void CreatePlayer()
        {
            //Make sure this input is a number between 1 and 4
            while (game)
            {
                try
                {
                    Utility.Write("What class would you like to play as?");
                    Menu.Output("1", new Menu("Adventurer: Your experiences traveling have provided you with the knowledge to handle yourself in combat. A perfectly balanced fighter."));
                    Menu.Output("2", new Menu("Paladin: Blessed with a hardy constitution, you are able to withstand blows that a lesser being could not."));
                    Menu.Output("3", new Menu("Brawler: Years in the gym has given you the strength to hit your enemies as hard as you hit the weights."));
                    Menu.Output("4", new Menu("Rogue: Fleet of foot, your speed allows you to avoid the blows rained down upon you by your enemies."));
                    Utility.Write("Type 1, 2, 3, or 4", choiceColor);

                    Player.Archetype = Utility.Input();
                    break;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is FormatException)
                    {
                        Utility.Write("Invalid Archetype Selection. Try Again", errorColor);
                    }
                }
            }
            Utility.Write("Welcome " + Player.Name + "! You are a(n) " + Player.archetype + "!");
            Utility.Write("Now let the story begin...\n");
            var pressAnyKey = Console.ReadLine();  //make the player press any key to continue
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", Console.WindowWidth)));
            Console.WriteLine();
        }

        //This method initializes all Choice objects
        public static void InitializeScenarios()
        {
            CurrentScenario = GameFileParser.GlobalChoices["A1A"];
        }

        public static void InitializeEnemy()
        {
            CurrentEnemy = EnemyFileParser.GlobalEnemies["1"];
        }
        
        public static void GameLoop()
        {
            while (game)
            {
                if (Player.inCombat) //TODO: Change this to check the scenario's hasCombat variable
                {
                    CombatLoop();
                }
                else
                {
                    DecisionLoop();
                }
            }
            game = false;
        }

        //Loops through Choice objects for branching narrative
        public static void DecisionLoop()
        {
            while (!Player.inCombat)
            {
                Utility.Write(CurrentScenario.Description);
                if (!CurrentScenario.CheckChoice())
                {
                    Player.inCombat = true;
                }
                else
                {
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
                            Player.honor += CurrentScenario.GetMorality();
                        }
                        catch (Exception ex)
                        {
                            if (ex is ArgumentOutOfRangeException || ex is FormatException)
                            {
                                Utility.Write("Invalid Choice Selection. Try Again.", errorColor);
                            }
                        }
                    }
                }
            }
        }

        //Start Combat
        public static void CombatLoop()
        {
            while (Player.inCombat)
            {
                Console.ReadLine();
                Console.WriteLine();
                Player.PrintPlayerOverview();

                Combat fight = new Combat(CurrentEnemy);
                fight.StartCombatLoop();
                if (CurrentEnemy.Name == "Marquise" && CurrentEnemy.ID == "1")
                {
                    if (Combat.PlayerWon)
                    {
                        CurrentScenario = GameFileParser.GlobalChoices["D1A"];
                    }
                    else
                    {
                        CurrentScenario = GameFileParser.GlobalChoices["D2A"];
                    }
                }
                Player.PrintPlayerOverview();
                Player.inCombat = false;
            }
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

        public static void AddItem()
        {
            if (CurrentScenario == GameFileParser.GlobalChoices["A5A"])
            {
                //Inventory.AddItem();
            }
        }
    }
}
