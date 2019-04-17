using System;

namespace TBD_TBG
{
    public class Item
    {
        string Name;
        string Description;

        string[] Items;
        string[] Descriptions;
        int number;
        Random random = new Random();

        public Item()
        {
            this.number = random.Next(Items.Length);
            this.Name = Items[number];
            this.Description = Descriptions[number];
        }

    }
}
