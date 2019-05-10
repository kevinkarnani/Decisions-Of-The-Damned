using System;

namespace TBD_TBG
{
    public abstract class Item
    {
        string ID { get; set; } //id of item
        string Name { get; set; } //name of item
        string Description { get; set; } //description of item

        public Item(string Identification, string Name, string Description)
        {
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
        }
        public void printItemOverview()
        {
            string color = "darkcyan";
            Utility.Write("ID: " + ID, color);
            Utility.Write("Name: " + Name, color);
            Utility.Write("Description: " + Description, color);
            Console.WriteLine();
        }
               

    }

    
}
