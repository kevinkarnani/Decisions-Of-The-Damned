using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System;

namespace TBD_TBG
{
    class GameFileParser
    {
        public static Dictionary<string, Choice> GlobalChoices = new Dictionary<string, Choice>(); //dictionary to hold Choices based on their key

        /*
         * This function will parse the CSV containing all the Choices
         */
        public static void Parser()
        {
            string path = "CSV-GameChoice.csv"; //store file path
            FileStream fileStream = new FileStream(path, FileMode.Open); //create File object
            using (StreamReader reader = new StreamReader(fileStream)) //read text
            using (CsvReader csv = new CsvReader(reader)) //parse text as a CSV
            {
                var records = csv.GetRecords<Scenario>(); //Get all records in the CSV as a Enumerable of Scenarios
                List<Scenario> Scenarios = new List<Scenario>(); //create list of Scenarios
                foreach (Scenario record in records)
                {
                    GlobalChoices.Add(record.GetKey(), new Choice(record.GetDescription())); //append Choice object to dictionary based on key
                    Scenarios.Add(record); //append to Scenario list
                }
                foreach (Scenario record in Scenarios)
                {
                    Dictionary<string, Choice> options = record.GetKeyValueOptions(); //create dictionary storing the next possible point (branching narrative)
                    GlobalChoices[record.GetKey()].SetChoices(options); //set possible branches to each key already stored in the Global dictionary
                    for (int i = 0; i < record.GetOptionKeys().Length; i++)
                    {
                        try
                        {
                            GlobalChoices[record.GetOptionKeys()[i]].SetMorality(record.GetMorality()[i]); //set morality to each possible branching point
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
