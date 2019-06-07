using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public class Scenario
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string OptionDescription { get; set; }
        public string OptionKeys { get; set; }
        public string Morality { get; set; }

        //getter for description
        public string GetDescription()
        {
            return Description;
        }

        //getter for key
        public string GetKey()
        {
            return Key;
        }

        //getter for possible keys
        public string[] GetOptionKeys()
        {
            return OptionKeys.Split(",");
        }

        //getter for possible descriptions
        public string[] GetOptionDescription()
        {
            return OptionDescription.Split(",");
        }

        //appends possible keys and values to a dictionary and return said dictionary
        public Dictionary<string, Choice> GetKeyValueOptions()
        {
            Dictionary<string, Choice> dict = new Dictionary<string, Choice>();
            string[] options = GetOptionKeys();
            string[] optdescs = GetOptionDescription();
            for (int i = 0; i < options.Length; i++)
            {
                try
                {
                    dict.Add(optdescs[i], GameFileParser.GlobalChoices[options[i]]);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return dict;
        }

        //places all morality values into an int array and returns said array
        public int[] GetMorality()
        {
            string[] moralities = Morality.Split(",");
            return Array.ConvertAll(moralities, Int32.Parse);
        }
    }
}
