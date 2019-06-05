using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System;

namespace TBD_TBG
{
    class GameFileParser
    {
        public static Dictionary<string, Choice> GlobalChoices = new Dictionary<string, Choice>();
        public static void Parser()
        {
            string path = "CSV-GameChoice.csv";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            using (CsvReader csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Scenario>();
                List<Scenario> Scenarios = new List<Scenario>();
                foreach (Scenario record in records)
                {
                    GlobalChoices.Add(record.GetKey(), new Choice(record.GetDescription()));
                    Scenarios.Add(record);
                }
                foreach (Scenario record in Scenarios)
                {
                    Dictionary<string, Choice> options = record.GetKeyValueOptions();
                    GlobalChoices[record.GetKey()].SetChoices(options);
                    for (int i = 0; i < record.GetOptionKeys().Length; i++)
                    {
                        try
                        {
                            GlobalChoices[record.GetOptionKeys()[i]].SetMorality(record.GetMorality()[i]);
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
