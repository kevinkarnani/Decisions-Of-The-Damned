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
            using (StreamReader reader = new StreamReader(fileStream))
            using (CsvReader csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<ItemStats>();
                foreach (ItemStats record in records)
                {
                    if (record.GetItemType() == "Equibable")
                    {
                        Equipable item = new Equipable(record.GetID(), record.GetName(), record.GetDes());
                        item.SetItemStats(record.GetAgility(), record.GetAttack(), record.GetHP());
                        item.SetLocation(record.GetLocDes());
                        GlobalItems.Add(record.GetID(), item);
                    }
                    else if (record.GetItemType() == "Consumable")
                    {
                        Consumable item = new Consumable(record.GetID(), record.GetName(), record.GetDes());
                        item.SetItemStats(record.GetAgility(), record.GetAttack(), record.GetHP());
                        item.SetLocation(record.GetLocDes());
                        item.SetUsability(record.GetCombatUsability());
                        GlobalItems.Add(record.GetID(), item);
                    }
                }
            }
        }
    }
}
