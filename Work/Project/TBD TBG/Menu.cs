using System;

namespace TBD_TBG
{
    class Menu
    {
        private readonly string Description;

        /*
         * Meant for player archetype selection
         */
        public Menu(string description)
        {
            Description = description;
        }

        //outputs possible choices
        public static void Output(string i, Menu menu)
        {
            Utility.Write(i + ") ", Game.choiceColor, false);
            Console.WriteLine(Utility.CleanDes(menu.Description));
        }

        //outputs possible choices with indent
        public static void OutputIndent(string i, Menu menu)
        {
            Utility.Write("    " + i + ") ", Game.choiceColor, false);
            Console.WriteLine(Utility.CleanDes(menu.Description));
        }
    }
}
