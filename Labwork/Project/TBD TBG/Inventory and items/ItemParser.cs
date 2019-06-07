using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace TBD_TBG
{
    class ItemParser
    {
        public static Dictionary<string, Item> GlobalItems = new Dictionary<string, Item>(); //dictionary to hold Items based on their ID

        /*
         * This function will parse the CSV containing all the items
         */
        public static void Parser()
        {
            string path = "CSV-Items.csv"; //file path
            FileStream fileStream = new FileStream(path, FileMode.Open); //create File object
            using (StreamReader reader = new StreamReader(fileStream)) //read text
            using (CsvReader csv = new CsvReader(reader)) //parse text as a CSV
            {
                var records = csv.GetRecords<ItemStats>(); //Get all records in the CSV as a Enumerable of ItemStats
                foreach (ItemStats record in records)
                {
                    if (record.GetItemType() == "Equibable") //if item can be equipped
                    {
                        Equipable item = new Equipable(record.GetID(), record.GetName(), record.GetDes()); //create Equipable object
                        item.SetItemStats(record.GetAgility(), record.GetAttack(), record.GetHP()); //set Equipable item's stats
                        item.SetLocation(record.GetLocDes()); //set location of item
                        GlobalItems.Add(record.GetID(), item); //append item to dictionary based on ID
                    }
                    else if (record.GetItemType() == "Consumable") //if item can be consumed
                    {
                        Consumable item = new Consumable(record.GetID(), record.GetName(), record.GetDes()); //create Consumable object
                        item.SetItemStats(record.GetAgility(), record.GetAttack(), record.GetHP()); //set Consumable item's stats
                        item.SetLocation(record.GetLocDes()); //set location of item
                        item.SetUsability(record.GetCombatUsability()); //determine if Consumable item can be used outside of battle
                        GlobalItems.Add(record.GetID(), item); //append to dictionary based on ID
                    }
                }
            }
        }
    }
}
