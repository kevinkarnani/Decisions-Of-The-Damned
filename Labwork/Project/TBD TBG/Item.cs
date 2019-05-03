using System;

namespace TBD_TBG
{
    public class Item
    {
        string ID; //id of item
        string Name; //name of item
        string Description; //description of item

        public Item(string _ID, string _name, string _des)
        {
            ID = _ID;
            Name = _name;
            Description = _des;
        }

    }
}
