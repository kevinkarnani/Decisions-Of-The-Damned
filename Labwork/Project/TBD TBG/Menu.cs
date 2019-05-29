using System;

namespace TBD_TBG
{
    class Menu
    {
        private readonly string Description;

        public Menu(string description)
        {
            Description = description;
        }

        public static void Output(string i, Menu menu)
        {
            Utility.Write(i + ") ", Game.choiceColor, false);
            Console.WriteLine(Utility.CleanDes(menu.Description));
        }
        public static void OutputIndent(string i, Menu menu)
        {
            Utility.Write("    " + i + ") ", Game.choiceColor, false);
            Console.WriteLine(Utility.CleanDes(menu.Description));
        }
    }
}
