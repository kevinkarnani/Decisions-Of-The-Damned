using System.Collections.Generic;

namespace TBD_TBG
{
    class ItemStats
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Attack { get; set; }
        public int Agility { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public string Combat { get; set; }
        public string LocationDescription { get; set; }
        bool Usable;

        /*
         * returns a string array of locations
         */
        public string[] GetLoc()
        {
            List<string> Locations = new List<string>(); //create list to store locations, done because arrays require hardcoded lengths
            if (Location.Contains(",")) { //if multiple locations, separated by commas, in string
                foreach (string location in Location.Split(","))
                {
                    Locations.Add(location); //add each location to list
                }
            }
            else
            {
                Locations.Add(Location); //else just add the single location
            }
            return Locations.ToArray(); //return after converting from list to array
        }

        //getter for location description
        public string GetLocDes()
        {
            return LocationDescription;
        }

        //getter for attack boost
        public int GetAttack()
        {
            return Attack;
        }

        //getter for agility boost
        public int GetAgility()
        {
            return Agility;
        }

        //getter for ID
        public string GetID()
        {
            return ID;
        }

        //getter for name
        public string GetName()
        {
            return Name;
        }

        //getter for description
        public string GetDes()
        {
            return Description;
        }

        //getter for Type (Equipable or Consumable)
        public string GetItemType()
        {
            return Type;
        }

        //see if item can be used outside of combat
        public bool GetCombatUsability()
        {
            return Combat == "Yes";
        }

        //getter for HP boost
        public int GetHP()
        {
            return HP;
        }
    }
}
