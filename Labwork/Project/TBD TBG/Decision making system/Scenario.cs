using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public class Scenario
    {
        //TODO: ADD Morality value, hasCombat var (empty = no enemy, anything else = enemy ID), and hasItem var

        public string Key { get; set; }
        public string Description { get; set; }
        public string OptionDescription { get; set; }
        public string OptionKeys { get; set; }
        public string Morality { get; set; }

        public string GetDescription()
        {
            return Description;
        }

        public string GetKey()
        {
            return Key;
        }

        public string[] GetOptionKeys()
        {
            return OptionKeys.Split(",");
        }

        public string[] GetOptionDescription()
        {
            return OptionDescription.Split(",");
        }

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

        public int[] GetMorality()
        {
            string[] moralities = Morality.Split(",");
            return Array.ConvertAll(moralities, Int32.Parse);
        }
    }
}
