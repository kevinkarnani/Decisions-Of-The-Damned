using System;
using System.Collections.Generic;
using System.Text;

namespace TBD_TBG
{
    public class Scenario
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string OptionDescription { get; set; }
        public string OptionKeys { get; set; }

        public void GetData()
        {
            //Console.WriteLine($"Key: {Key} ;\n Description: {Description} ;\n Options: {optionDescription} ;\n Choices: {optionKeys}");
            //Console.WriteLine();

            //Dictionary <string, string> jumpChoice = new Dictionary<string, string>();
            //jumpChoice.Add(Key, Description);
            //Dictionary<string, string> myDict = new Dictionary<string, string>();
        }

        public string GetDescription()
        {
            return Description;
        }

        public string GetKey()
        {
            return Key;
        }

        public string GetOptionDescription()
        {
            return OptionDescription;
        }

        public Dictionary<string, Choice> GetKeyValueOptions()
        {
            Dictionary<string, Choice> dict = new Dictionary<string, Choice>();
            string[] options = OptionKeys.Split(",");
            string[] optdescs = OptionDescription.Split(",");
            for (int i = 0; i < options.Length; i++)
            {
                dict.Add(optdescs[i], FileParser.GlobalChoices[options[i]]);
            }
            return dict;
        }
    }
}
