using System;
using System.Globalization;


namespace TBD_TBG
{
    /*
     * Derived from "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
     * https://creativecommons.org/licenses/by/4.0/
     */
    class Utility
    {
        static string margin = "  ";
        static string indent = "    ";

        public static string Input()
        {
            Console.Write(margin + ": ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.ResetColor();
            return input;
        }
        public static string Input(string _string)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margin + _string + ": ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.ResetColor();
            return input;
        }

        public static void CleanDes(string text)
        {
            string[] words = text.Split(' ');
            int i = 0;
            if (words.Length > 80)
            {
                foreach (string word in words)
                {
                    i += word.Length + 1;
                    if (i < 80)
                    {
                        Console.Write(word + ' ');
                    }
                    else if (word == words[words.Length - 1])
                    {
                        Console.Write(word);
                    }
                    else
                    {
                        Console.WriteLine(word);
                        i = 0;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        public static void Write(string _string)
        {
            _string = _string.Replace("\n", "\n" + margin);
            CleanDes(margin + _string);
        }

        public static void Write(string _string, string _color)
        {
            _string = _string.Replace("\n", "\n" + margin);
            switch (_color)
            {
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Write(_string);
            Console.ResetColor();
        }
        public static void Write(string _string, string _color, string _background)
        {
            _string = _string.Replace("\n", "\n" + margin);
            switch (_color)
            {
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            switch (_background)
            {
                case "blue":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }

            Write(_string);
            Console.ResetColor();
        }
        public static void Heading(string _string)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(margin + indent + _string);
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margin + "Press enter to continue...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }

        public static void Title(string _title, string _subheading)
        {
            Console.Title = _title;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Center("Welcome to"));
            Console.WriteLine("\n" + Center("*´·._.·" + _title + "·._.·`*") + "\n");
            Console.WriteLine(Center(_subheading));
            Console.ResetColor();
        }
        public static void Title(string _title)
        {
            Console.Title = _title;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Center("Welcome to"));
            Console.WriteLine("\n" + Center("*´·._.·" + _title + "·._.·`*") + "\n");
            Console.ResetColor();
        }

        public static string Center(string _string)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = _string.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);
            return _string.PadLeft(spaces);
        }

        public static string TitleCase(string _string)
        {
            TextInfo TitleCase = new CultureInfo("en-US", false).TextInfo;
            _string = TitleCase.ToTitleCase(_string);
            return _string;
        }

        //modification of method at https://msdn.microsoft.com/en-us/library/d9hy2xwa(v=vs.110).aspx
        public static bool Search(string[] _array, string _string)
        {
            bool result = false;
            int i = 0;
            foreach (string s in _array)
            {
                _array[i] = s.ToLower();
                i++;
            }

            if (Array.Find(_array, element => element == _string) == _string)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        //modification of DisplayValues method at https://msdn.microsoft.com/en-us/library/aw9s5t8f(v=vs.110).aspx
        public static void AllValues(String[] _array)
        {
            for (int i = _array.GetLowerBound(0); i <= _array.GetUpperBound(0); i++)
            {
                Console.WriteLine(margin + _array[i]);
            }
            Console.WriteLine();
        }
    }
}