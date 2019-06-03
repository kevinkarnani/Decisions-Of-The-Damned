using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace TBD_TBG
{
    class ItemParser
    {
        public static Dictionary<string, Item> GlobalItems = new Dictionary<string, Item>();
        public static void Parser()
        {
            string path = "CSV-Items.csv";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<ItemStats>();
                foreach (ItemStats record in records)
                {
                    Item item = new Item(record.GetID(), record.GetName(), record.GetDes());
                    GlobalItems.Add(record.GetID(), item);

                }
            }
        }
    }
}
