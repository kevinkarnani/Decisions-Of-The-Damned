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
            Utility.Write("                    ████████╗ ██████╗     ██████╗ ███████╗                       ");
            Utility.Write("                    ╚══██╔══╝██╔═══██╗    ██╔══██╗██╔════╝                       ");
            Utility.Write("                       ██║   ██║   ██║    ██████╔╝█████╗                         ");
            Utility.Write("                       ██║   ██║   ██║    ██╔══██╗██╔══╝                         ");
            Utility.Write("                       ██║   ╚██████╔╝    ██████╔╝███████╗                       ");
            Utility.Write("                       ╚═╝    ╚═════╝     ╚═════╝ ╚══════╝                       ");
            Utility.Write("██████╗ ███████╗████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗███████╗██████╗ ");
            Utility.Write("██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔════╝██╔══██╗");
            Utility.Write("██║  ██║█████╗     ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║█████╗  ██║  ██║");
            Utility.Write("██║  ██║██╔══╝     ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ██║  ██║");
            Utility.Write("██████╔╝███████╗   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║███████╗██████╔╝");
            Utility.Write("╚═════╝ ╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚═════╝ ");
            Utility.Write("              ▁ ▂ ▃ ▄ ▅ ▆ ▇ ▌  A Text Based Game  ▌ ▇ ▆ ▅ ▄ ▃ ▂ ▁");
            Utility.Write("");
            Utility.Write("                                 Created by:");
            Utility.Write("                  Mark Melkumyan, Kev Karnani, Humaid Mustajab,");
            Utility.Write("                       Cort Williams, and Joey Hermann.");
            Utility.Write("Now let the story begin...");

            

            CreatePlayer();
            InitializeScenarios();
            StartGameLoop();
            End();
        }

        //This method sets the player's name and player's archetype
        public static void CreatePlayer()
        {
            Utility.Write("What would you like your character's name to be?");
            Player.setName(Console.ReadLine());
            Utility.Write("What class would you like to play as? (Type 1,2,3, or 4)");
            Utility.Write("1.) Adventurer: Balanced stats");
            Utility.Write("2.) Paladin: Defense focused");
            Utility.Write("3.) Brawler: Attack focused");
            Utility.Write("4.) Rogue: Quick");
            //TODO: Make sure this input is a number between 1 and 4
            Player.setArchetype(Console.ReadLine());

            Utility.Write("Welcome " + Player.name+ "! You are a(n) " + Player.archetype + "!");

            Console.WriteLine(Player.playerStats.getStatOverview());
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
            Choice A6A = new Choice("You wander through the forest for what feels like hours. You are unable to tell as the canopy of leaves obstructs your view of the sun. The only thing you can glean is that it isn’t night yet.\nEventually you see lights in the distance and begin to hear sounds of life. Upon exiting the forest, you come upon a moderately sized village teeming with life.");
            Choice A7A = new Choice("Gazing upwards, you can see that the sun has nearly set. You must have been in the forest for hours.");

            Choice B1A = new Choice("You enter into what appears to be the residential district of the town. Similarly built wood and brick houses line the roads, with people either relaxing outside or staring out their \nwindows from inside. As you continue, a low growling from your stomach reminds you how hungry you are.");
            Choice B2A = new Choice("Not too long after you start looking, you come upon a tavern adjacent to the town square. From the inside you can hear the loud laughing and voices overlapping one another. \nOnce you get inside, it is not only cramped, but crowded. Luckily, there are a few stools open over at the bar.");
            Choice B2B = new Choice("Once you settle into your seat, a barmaid comes along and asks if you would like something to eat.");
            Choice B2C = new Choice("As previously mentioned, you’re ravenously hungry. We both know you don’t want to starve to death here.");
            Choice B2D = new Choice("This “ignoring the narrator thing” has gotten old real quick. Eat something before I make you. Got it?");
            Choice B3A = new Choice("The barmaid takes your money and goes to retrieve your meal. While waiting, you observe a group of farmers getting up to leave after finishing their meals. You notice one of \nthem has forgotten his coin purse on his seat.");
            Choice B3B = new Choice("As they reach the door to the tavern you flag down the group and gesture to the forgotten purse. The largest of the punch checks his pockets before realizing that it’s his. \nHe quickly grabs it and makes his exit, thanking you profusely as he leaves.");
            Choice B3C = new Choice("Making sure that no one is paying you any attention, you lean down and snatch the pouch. Inside you find 40 drachma. Score!");
            Choice B4A = new Choice("The waitress returns soon after with your food, which you wolf down in record time. As soon as it hits your stomach, exhaustion kicks in. So you pay your bill and ask the \nbarmaid if you can find an inn nearby. Luckily for you this tavern also functions as an inn! For 5 drachma you get room and board for a whole day.");

            Choice C1A = new Choice("Your hibernation is interrupted by a commotion coming from the town square.");
            Choice C1B = new Choice("Stop.");
            Choice C2A = new Choice("You gather your things and leave the tavern to investigate. The town square is brimming with townsfolk gathering to do their daily shopping.");
            Choice C2B = new Choice("While meandering through the crowds, you hear people begin to cry out. Upon reaching the source of the noises you find two guards brutalizing a young man on the ground. \nThey kick him over and over again as he cries out for help, blood leaking from his mouth. At this rate he’s going to die.");
            Choice C2C = new Choice("You charge at one of the guards, tackling him to the ground. The other guard stops kicking and throws you off of him.");
            Choice C2D = new Choice("You draw your sword from its ill-fitting sheath and prepare for combat. From behind you hear a deep voice call out. It’s a man in pristine armor, flanked by five more town guards. \n“You there! " + Player.name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            Choice C2E = new Choice("Turning away from the beatdown, you decide to look for a shop. Maybe a blacksmith can remove the rust from your blade? From behind you hear a deep voice call out. \nIt’s a man in pristine armor, flanked by five more town guards. “You there! " + Player.name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            Choice C2F = new Choice("Realizing that challenging two town guards with nothing but a rusty iron sword wasn’t you’re greatest decision ever, you try to flee. Unfortunately, you hear a deep voice \ncall out from behind you. It’s a man in pristine armor, flanked by five more town guards. “You there! " + Player.name + ", did you think I wouldn’t recognize you? You’re under arrest for conspiring against the Duke. Men, arrest him!”");
            Choice C3A = new Choice("End of the demo! Thanks for playing!");


            A1A.SetChoices(new Dictionary<string, Choice>() { { "1) Wake up", A2A }, { "2) Deal with it later", A1B } });
            A1B.SetChoices(new Dictionary<string, Choice>() { { "1) Get up", A2A }, { "2) Sleep is important to maintain my healthy lifestyle", A1C } });
            A1C.SetChoices(new Dictionary<string, Choice>() { { "1) Get up", A2A } });
            A2A.SetChoices(new Dictionary<string, Choice>() { { "1) Look up", A2B }, { "2) Look for a weapon", A3A }, { "3) Guess this is where I die", A2D } });
            A2B.SetChoices(new Dictionary<string, Choice>() { { "1) Look for a weapon", A3A }, { "2) This patch of burning wood looks comfortable!", A2E } });
            A2C.SetChoices(new Dictionary<string, Choice>() { { "1) Look for a weapon", A3A } });
            A2D.SetChoices(new Dictionary<string, Choice>() { { "1) Look up", A2C }, { "2) Look for weapon", A3A } });
            A2E.SetChoices(new Dictionary<string, Choice>() { { "1) Look for a weapon", A3A } });
            A3A.SetChoices(new Dictionary<string, Choice>() { { "1) Grab one", A3B }, { "2) Keep Looking", A4A } });
            A3B.SetChoices(new Dictionary<string, Choice>() { { "1) Drop the sword and keep looking", A4A } });
            A4A.SetChoices(new Dictionary<string, Choice>() { { "1) Take the sword", A5A }, { "2) I can do better", A4B } });
            A4B.SetChoices(new Dictionary<string, Choice>() { { "1) Take the sword", A5A } });
            A5A.SetChoices(new Dictionary<string, Choice>() { { "1) Venture Forth", A6A } });
            A6A.SetChoices(new Dictionary<string, Choice>() { { "1) Look at the sky", A7A } });
            A7A.SetChoices(new Dictionary<string, Choice>() { { "1) Head into town", B1A } });

            B1A.SetChoices(new Dictionary<string, Choice>() { { "1) Find a tavern", B2A } });
            B2A.SetChoices(new Dictionary<string, Choice>() { { "1) Head to the bar", B2B } });
            B2B.SetChoices(new Dictionary<string, Choice>() { { "1) Order dinner [3 drachma]", B3A }, { "2) I’ll pass, thanks", B2C} });
            B2C.SetChoices(new Dictionary<string, Choice>() { { "1) Order dinner [3 drachma]", B3A }, { "2) Order an ale [1 drachma]", B2D } });
            B2D.SetChoices(new Dictionary<string, Choice>() { { "1) Order dinner [3 drachma]", B3A } });
            B3A.SetChoices(new Dictionary<string, Choice>() { { "1) Get his attention and return the money", B3B }, { "2) Yoink!", B3C} });
            B3B.SetChoices(new Dictionary<string, Choice>() { { "1) Return to the bar", B4A } });
            B3C.SetChoices(new Dictionary<string, Choice>() { { "1) Return to the bar", B4A } });
            B4A.SetChoices(new Dictionary<string, Choice>() { { "1) It’s snooze time", C1A } });

            C1A.SetChoices(new Dictionary<string, Choice>() { { "1) Check it out", C2A }, { "2) Just five more minutes", C1B } });
            C1B.SetChoices(new Dictionary<string, Choice>() { { "1) Check it out", C2A } });
            C2A.SetChoices(new Dictionary<string, Choice>() { { "1) Explore", C2B} });
            C2B.SetChoices(new Dictionary<string, Choice>() { { "1) Something needs to be done", C2C }, { "2) Not my problem, back to exploring!", C2E } });
            C2C.SetChoices(new Dictionary<string, Choice>() { { "1) Draw your sword", C2D }, { "2) Run Away!", C2F } });
            C2D.SetChoices(new Dictionary<string, Choice>() { { "", C3A } });
            C2E.SetChoices(new Dictionary<string, Choice>() { { "", C3A } });
            C2F.SetChoices(new Dictionary<string, Choice>() { { "", C3A } });
            C3A.SetChoices(new Dictionary<string, Choice>() { });


            CurrentScenario = A1A;
        }
        
        //Loops through Choice objects for branching narrative
        public static void StartGameLoop()
        {
            while (true)
            {
                if (!CurrentScenario.CheckChoice())
                {
                    break;
                }
                Utility.Write(CurrentScenario.Description);
                Utility.Write(CurrentScenario.GetChoiceText());
                string selection = Console.ReadLine();
                //Error checking the user input
                try
                {
                    CurrentScenario = CurrentScenario.GetChoice(selection);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException || ex is FormatException)
                    {
                        Console.WriteLine("Invalid Choice Selection. Try Again.");
                    }
                }
            }
            // game over stuff here
        }
        public static void StartCombatLoop()
        {
            //TODO: 
            //Create combat loop
            //Create test scenario (other than prologue)
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