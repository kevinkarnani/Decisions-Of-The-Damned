
using System;
using CsvHelper;
using System.IO;
using System.Collections.Generic;

namespace TBD_TBG
{
    class FileParser
    {
        public static Dictionary<string, Choice> GlobalChoices = new Dictionary<string, Choice>();
        static void Parser()
        {
            FileStream fileStream = new FileStream("Choice.csv", FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Scenario>();
                List<Scenario> things = new List<Scenario>();
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
