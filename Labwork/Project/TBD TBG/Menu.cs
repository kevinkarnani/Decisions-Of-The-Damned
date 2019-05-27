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

        public static void Output(int i, Menu menu)
        {
            Utility.Write(i + ") ", Game.choiceColor, false);
            Console.WriteLine(Utility.CleanDes(menu.Description));
        }
    }
}
