using System;

namespace TBD_TBG
{
    public abstract class Item
    {
        /*
         * Abstract base class for equipables and consumables. 
         * Includes getters and setters and info on items
         */
        public string ID { get; set; } //id of item
        public string Name { get; set; } //name of item
        public string Description { get; set; } //description of item
        public Stats ItemStats { get; set; }
        public string LocationDescription { get; set; }

        public Item(string ID, string Name, string Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
        }

        //sets the location for an item in the story (ex: "A1A")
        public void SetLocation(string LocationDescription)
        {
            this.LocationDescription = LocationDescription;
        }

        //prints an overview of the item
        public void PrintItemOverview()
        {
            string color = Game.inventoryColor;
            Utility.Write("ID: " + ID, color);
            Utility.Write("Name: " + Name, color);
            Utility.Write("Description: " + Description, color);
            Console.WriteLine();
        }

        //sets stats of an item
        public void SetItemStats(int Agility, int Attack, int HP)
        {
            ItemStats = new Stats(Agility, Attack, HP);
        }
    }
}
