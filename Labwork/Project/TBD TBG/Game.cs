using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Game
    {
        //TO DO: CREATE COMBAT LOOP
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
            Console.WriteLine(Utility.Center("▁ ▂ ▃ ▄ ▅ ▆ ▇ ▌  A Text Based Game  ▌ ▇ ▆ ▅ ▄ ▃ ▂ ▁"));
            Console.WriteLine();
            Console.WriteLine(Utility.Center("Created by:"));
            Console.WriteLine(Utility.Center("Mark Melkumyan, Kev Karnani, Humaid Mustajab,"));
            Console.WriteLine(Utility.Center("Cort Williams, and Joey Hermann."));

            CreatePlayer();

            InitializeScenarios();
            StartGameLoop();
            End();
        }

        //This method sets the player's name and player's archetype
        public static void CreatePlayer()
        {
            Player.Name = Utility.Input("What would you like your character's name to be?");

            //Make sure this input is a number between 1 and 4
            while (true)
            {
                try
                {
                    Utility.Write("What class would you like to play as?");
                    Utility.Write("1) Adventurer: Balanced stats");
                    Utility.Write("2) Paladin: Defense focused");
                    Utility.Write("3) Brawler: Attack focused");
                    Utility.Write("4) Rogue: Quick");

                    Player.Archetype = Utility.Input("Type 1, 2, 3, or 4");
                    break;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is FormatException)
                    {
                        Utility.Write("Invalid Archetype Selection. Try Again", "red");
                    }
                }
            }
            Utility.Write("Welcome " + Player.Name + "! You are a(n) " + Player.archetype + "!");
            Utility.Write("Now let the story begin...\n");
        }

        //This method initializes all Choice objects
        public static void InitializeScenarios()
        {
            Choice A1A = new Choice("The intoxicating stench of smoke stirs you from your slumber. Hearing the loud crackling of fire tells only on danger.");
            Choice A1B = new Choice("The sound of wood crashing to the floor is becoming hard to ignore. If action is not taken soon, you get the feeling you might find yourself in serious danger.");
            Choice A1C = new Choice("You’re going to be one of those players huh? Fine! Be that way, but I’m not going to take your crap. You get up.");
            Choice A2A = new Choice("Looking up, you can see that things have indeed gone terribly wrong. Around you lies the wreckage of the skyship Aethor’s Glory, now engulfed in flame.");
            Choice A2B = new Choice("You can tell that it’s about midday, but that’s all you are able to glean from the sky right now. The rest of it is obscured by the smoke rising from the charred corpse of Aethor’s Glory.");
            Choice A2C = new Choice("Looking up, you can see that things have indeed gone terribly wrong. Around you lies the wreckage of the skyship Aethor, now engulfed in flame.");
            Choice A2D = new Choice("You may be playing games, but I’m not.");
            Choice A2E = new Choice("You may be playing games, but I’m not.");
            Choice A3A = new Choice("Now wandering through the ruins of the Aethor’s Glory, you come a come across a rack of conflagrant weapons.");
            Choice A3B = new Choice("Upon grasping the conflagrant sword, you are quickly reminded what the word means as your hands are engulfed in flame. Way to go pal.");
            Choice A4A = new Choice("As reach a opening in the husk Aethor’s Glory, you find a rusted iron shortsword, untouched by the flames. Despite the wear and tear, it fits well in your dominant hand.");
            Choice A4B = new Choice("No, you can’t.");
            Choice A5A = new Choice("Sword in hand, you venture through the opening in the ship’s hull. In front of you lies a lush, green forest.");
            Choice A6A = new Choice("You wander through the forest for what feels like hours. You are unable to tell as the canopy of leaves obstructs your view of the sun. The only thing you can glean is that it isn’t night yet.Eventually you see lights in the distance and begin to hear sounds of life. Upon exiting the forest, you come upon a moderately sized village teeming with life.");
            Choice A7A = new Choice("Gazing upwards, you can see that the sun has nearly set. You must have been in the forest for hours.");

            Choice B1A = new Choice("You enter into what appears to be the residential district of the town. Similarly built wood and brick houses line the roads, with people either relaxing outside or staring out their windows from inside. As you continue, a low growling from your stomach reminds you how hungry you are.");
            Choice B2A = new Choice("Not too long after you start looking, you come upon a tavern adjacent to the town square. From the inside you can hear the loud laughing and voices overlapping one another. Once you get inside, it is not only cramped, but crowded. Luckily, there are a few stools open over at the bar.");
            Choice B2B = new Choice("Once you settle into your seat, a barmaid comes along and asks if you would like something to eat.");
            Choice B2C = new Choice("As previously mentioned, you’re ravenously hungry. We both know you don’t want to starve to death here.");
            Choice B2D = new Choice("This “ignoring the narrator thing” has gotten old real quick. Eat something before I make you. Got it?");
            Choice B3A = new Choice("The barmaid takes your money and goes to retrieve your meal. While waiting, you observe a group of farmers getting up to leave after finishing their meals. You notice one of them has forgotten his coin purse on his seat.");
            Choice B3B = new Choice("As they reach the door to the tavern you flag down the group and gesture to the forgotten purse. The largest of the punch checks his pockets before realizing that it’s his. He quickly grabs it and makes his exit, thanking you profusely as he leaves.");
            Choice B3C = new Choice("Making sure that no one is paying you any attention, you lean down and snatch the pouch. Inside you find 40 drachma. Score!");
            Choice B4A = new Choice("The waitress returns soon after with your food, which you wolf down in record time. As soon as it hits your stomach, exhaustion kicks in. So you pay your bill and ask the barmaid if you can find an inn nearby. Luckily for you this tavern also functions as an inn! For 5 drachma you get room and board for a whole day.");

            Choice C1A = new Choice("Your hibernation is interrupted by a commotion coming from the town square.");
            Choice C1B = new Choice("Stop.");
            Choice C2A = new Choice("You gather your things and leave the tavern to investigate. The town square is brimming with townsfolk gathering to do their daily shopping.");
            Choice C2B = new Choice("While meandering through the crowds, you hear people begin to cry out. Upon reaching the source of the noises you find two guards brutalizing a young man on the ground. They kick him over and over again as he cries out for help, blood leaking from his mouth. At this rate he’s going to die.");
            Choice C2C = new Choice("You charge at one of the guards, tackling him to the ground. The other guard stops kicking and throws you off of him.");
            Choice C2D = new Choice("You draw your sword from its ill-fitting sheath and prepare for combat. From behind you hear a deep voice call out. It’s a man in pristine armor, flanked by five more town guards. “You there! " + Player.Name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            Choice C2E = new Choice("Turning away from the beatdown, you decide to look for a shop. Maybe a blacksmith can remove the rust from your blade? From behind you hear a deep voice call out. It’s a man in pristine armor, flanked by five more town guards. “You there! " + Player.Name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            Choice C2F = new Choice("Realizing that challenging two town guards with nothing but a rusty iron sword wasn’t you’re greatest decision ever, you try to flee. Unfortunately, you hear a deep voice call out from behind you. It’s a man in pristine armor, flanked by five more town guards. “You there! " + Player.Name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            //csv file with all the choice information (id num, des, jump scenarios, choices 1-4)
            // write a script that initializes all of this

            A1A.SetChoices(new Dictionary<string, Choice>() { { "Wake up", A2A }, { "Deal with it later", A1B } });
            A1B.SetChoices(new Dictionary<string, Choice>() { { "Get up", A2A }, { "Sleep is important to maintain my healthy lifestyle", A1C } });
            A1C.SetChoices(new Dictionary<string, Choice>() { { "Get up", A2A } });
            A2A.SetChoices(new Dictionary<string, Choice>() { { "Look up", A2B }, { "Look for a weapon", A3A }, { "Guess this is where I die", A2D } });
            A2B.SetChoices(new Dictionary<string, Choice>() { { "Look for a weapon", A3A }, { "This patch of burning wood looks comfortable!", A2E } });
            A2C.SetChoices(new Dictionary<string, Choice>() { { "Look for a weapon", A3A } });
            A2D.SetChoices(new Dictionary<string, Choice>() { { "Look up", A2C }, { "Look for weapon", A3A } });
            A2E.SetChoices(new Dictionary<string, Choice>() { { "Look for a weapon", A3A } });
            A3A.SetChoices(new Dictionary<string, Choice>() { { "Grab one", A3B }, { "Keep Looking", A4A } });
            A3B.SetChoices(new Dictionary<string, Choice>() { { "Drop the sword and keep looking", A4A } });
            A4A.SetChoices(new Dictionary<string, Choice>() { { "Take the sword", A5A }, { "I can do better", A4B } });
            A4B.SetChoices(new Dictionary<string, Choice>() { { "Take the sword", A5A } });
            A5A.SetChoices(new Dictionary<string, Choice>() { { "Venture Forth", A6A } });
            A6A.SetChoices(new Dictionary<string, Choice>() { { "Look at the sky", A7A } });
            A7A.SetChoices(new Dictionary<string, Choice>() { { "Head into town", B1A } });

            B1A.SetChoices(new Dictionary<string, Choice>() { { "Find a tavern", B2A } });
            B2A.SetChoices(new Dictionary<string, Choice>() { { "Head to the bar", B2B } });
            B2B.SetChoices(new Dictionary<string, Choice>() { { "Order dinner [3 drachma]", B3A }, { "I’ll pass, thanks", B2C} });
            B2C.SetChoices(new Dictionary<string, Choice>() { { "Order dinner [3 drachma]", B3A }, { "Order an ale [1 drachma]", B2D } });
            B2D.SetChoices(new Dictionary<string, Choice>() { { "Order dinner [3 drachma]", B3A } });
            B3A.SetChoices(new Dictionary<string, Choice>() { { "Get his attention and return the money", B3B }, { "Yoink!", B3C} });
            B3B.SetChoices(new Dictionary<string, Choice>() { { "Return to the bar", B4A } });
            B3C.SetChoices(new Dictionary<string, Choice>() { { "Return to the bar", B4A } });
            B4A.SetChoices(new Dictionary<string, Choice>() { { "It’s snooze time", C1A } });

            C1A.SetChoices(new Dictionary<string, Choice>() { { "Check it out", C2A }, { "2) Just five more minutes", C1B } });
            C1B.SetChoices(new Dictionary<string, Choice>() { { "Check it out", C2A } });
            C2A.SetChoices(new Dictionary<string, Choice>() { { "Explore", C2B} });
            C2B.SetChoices(new Dictionary<string, Choice>() { { "Something needs to be done", C2C }, { "Not my problem, back to exploring!", C2E } });
            C2C.SetChoices(new Dictionary<string, Choice>() { { "Draw your sword", C2D }, { "Run Away!", C2F } });
            C2D.SetChoices(new Dictionary<string, Choice>() { });
            C2E.SetChoices(new Dictionary<string, Choice>() { });
            C2F.SetChoices(new Dictionary<string, Choice>() { });



            CurrentScenario = A1A;
        }
        
        //Loops through Choice objects for branching narrative
        public static void StartGameLoop()
        {
            while (true)
            {
                if (!CurrentScenario.CheckChoice())
                {
                    StartCombat();
                    break;
                }
                Utility.Write(CurrentScenario.Description);
                Utility.AllValues(CurrentScenario);
                string selection = Utility.Input();
                //Error checking the user input
                try
                {
                    CurrentScenario = CurrentScenario.GetChoice(selection);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException || ex is FormatException)
                    {
                        Utility.Write("Invalid Choice Selection. Try Again.", "red");
                    }
                }
            }
        }

        //Start Combat
        public static void StartCombat()
        {
            Enemy Enemy = new Enemy("Guard", 40, 10, 200)
            {
                description = "Royal Guard of the palace"
            };
            Enemy.SetAttackChance(.33, .33, .33);

            Enemy.enemyStats.PrintStatOverview();
            Console.WriteLine();
            Player.PrintPlayerOverview();

            Combat fight1 = new Combat(Enemy);
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
