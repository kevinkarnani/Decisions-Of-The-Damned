using System;

namespace TBD_TBG
{
    class Program
    {
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