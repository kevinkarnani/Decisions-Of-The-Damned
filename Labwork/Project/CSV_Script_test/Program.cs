using System;
using CsvHelper;
using System.IO;

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
            Console.WriteLine($"{Key} : {Description} : {optionDescription} : {optionKeys}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("/Users/humaid/Choice.csv", FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<scenario>();
                foreach (var record in records)
                {
                    record.GetData();
                }
            }
        }
    }
}

