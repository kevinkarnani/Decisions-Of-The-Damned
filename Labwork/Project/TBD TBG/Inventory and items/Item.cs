using System;

namespace TBD_TBG
{
    public abstract class Item
    {
        public string ID { get; set; } //id of item
        public string Name { get; set; } //name of item
        public string Description { get; set; } //description of item
        public ItemStats ItemStat { get; set; }

        public Item(string ID, string Name, string Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
        }

        public void PrintItemOverview()
        {
            string color = "darkcyan";
            Utility.Write("ID: " + ID, color);
            Utility.Write("Name: " + Name, color);
            Utility.Write("Description: " + Description, color);
            Console.WriteLine();
        }
    }
}
