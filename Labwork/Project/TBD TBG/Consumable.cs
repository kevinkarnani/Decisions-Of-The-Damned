using System;

namespace TBD_TBG
{
    public class Consumable : Item
    {
        public bool isEquipped;
        public bool isWeapon;

        //Don't use parser for consumables, just make it an abstract class and create instances that inherit from it

        public Consumable(string Identification, string Name, string Description) : base(Identification, Name, Description)
        {
            //TODO: fix this init? it doesnt look right ^^^
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
        }
        public void Use()
        {

        }
        public void ClearEffect()
        {

        }
    }
}
