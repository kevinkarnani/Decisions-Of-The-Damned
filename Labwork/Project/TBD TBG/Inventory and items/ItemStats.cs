using System;
using System.Collections.Generic;
using System.Text;

namespace TBD_TBG
{
    class ItemStats
    {
        public string ID { get; set; } //id of item
        public string Name { get; set; } //name of item
        public string Description { get; set; } //description of item
        public string Location { get; set; }
        public int Attack { get; set; }
        public int Agility { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public string LocationDescription { get; set; }

        public string[] GetLoc()
        {
            List<string> Locations = new List<string>();
            if (Location.Contains(",")) {
                foreach (string location in Location.Split(","))
                {
                    Locations.Add(location);
                }
            }
            else
            {
                Locations.Add(Location);
            }
            return Locations.ToArray();
        }

        public string GetLocDes()
        {
            return LocationDescription;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public int GetAgility()
        {
            return Agility;
        }

        public string GetID()
        {
            return ID;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDes()
        {
            return Description;
        }

        public string GetItemType()
        {
            return Type;
        }

        public int GetHP()
        {
            return HP;
        }
    }
}
