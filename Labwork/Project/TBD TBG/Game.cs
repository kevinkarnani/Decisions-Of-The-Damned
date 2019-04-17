using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Game
    {
        static string characterName;
        static Choice CurrentScenario;

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

            GetName();
            InitializeScenarios();
            StartGameLoop();
            End();
        }

        public static void GetName()
        {
            Utility.Write("What would you like your character's name to be?");
            characterName = Console.ReadLine();
            Utility.Write("Welcome " + characterName + "! Your character is now named " + characterName + ".");
        }

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
            Choice A6A = new Choice("You wander through the forest for what feels like hours. You are unable to tell as the canopy of leaves obstructs your view of the sun. The only thing you can glean is that it isn’t night yet. Eventually you see lights in the distance and begin to hear sounds of life. Upon exiting the forest, you come upon a moderately sized village teeming with life.");
            Choice A7A = new Choice("Gazing upwards, you can see that the sun has nearly set. You must have been in the forest for hours.");

            A1A.SetChoices(new Dictionary<string, Choice>() { { "1) Wake up", A2A }, { "2) Deal with it later", A1B } });
            A1B.SetChoices(new Dictionary<string, Choice>() { { "1) Get up", A2A }, { "Sleep is important to maintain my healthy lifestyle", A1C } });
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
            A7A.SetChoices(new Dictionary<string, Choice>() { });

            CurrentScenario = A1A;
        }

        public static void StartGameLoop()
        {
            while (true)
            {
                Utility.Write(CurrentScenario.Description);
                Utility.Write(CurrentScenario.GetChoiceText());
                string selection = Console.ReadLine();
                //try..catch, check if legit
                if (true)
                {
                    CurrentScenario = CurrentScenario.GetChoice(selection);
                }
            }
        }

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

        public static void End()
        {
            Utility.Write("End of story :( Thanks for playing!!!");
            Utility.Write("Press enter to exit.");
        }
    }

}