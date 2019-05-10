using System;
using CsvHelper;
using System.IO;
using System.Collections.Generic;
using TBD_TBG;

namespace CSV_Script_test
{ 
    public class scenario
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string optionDescription { get; set; }
        public string optionKeys { get; set; }

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
            return optionDescription;
        }

        public Dictionary<string, Choice> GetKeyValueOptions()
        {
            Dictionary<string, Choice> dict = new Dictionary<string, Choice>();
            string[] options = optionKeys.Split(",");
            string[] optdescs = optionDescription.Split(",");
            for (int i = 0; i < options.Length; i++)
            {
                dict.Add(optdescs[i], Program.GlobalChoices[options[i]]);
            }
            return dict;
        }
    }
    public static class Program
    {
        public static Dictionary<string, Choice> GlobalChoices = new Dictionary<string, Choice>();
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("Choice.csv", FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<scenario>();
                List<scenario> things = new List<scenario>();
                foreach (var record in records)
                {
                    GlobalChoices.Add(record.GetKey(), new Choice(record.GetDescription()));
                    things.Add(record);
                }
                foreach (var record in things)
                {
                    Dictionary<string, Choice> options = record.GetKeyValueOptions();
                    
                    GlobalChoices[record.GetKey()].SetChoices(options);
                }
            }
        }
    }
}

