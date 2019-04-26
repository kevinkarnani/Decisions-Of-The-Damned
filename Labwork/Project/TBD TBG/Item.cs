using System;

namespace TBD_TBG
{
    public class Item
    {
        string Name; //name of item
        string Description; //description of item

        string[] Items; //string array holding all item names
        string[] Descriptions; //string array holding all item descriptions
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
