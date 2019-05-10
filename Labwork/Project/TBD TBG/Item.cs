using System;

namespace TBD_TBG
{
    public class Item
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
    }
}
