using System;

namespace TBD_TBG
{
    class Program
    {
        //TODO: start all methods with capital letters

        //main method, calls most important functions
        static void Main()
        {
            GameFileParser.Parser();
            EnemyFileParser.Parser();
            ItemParser.Parser();
            Game.Start();
            Console.Read();
        }
    }
}