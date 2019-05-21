using System;

namespace TBD_TBG
{
    public class Consumable : Item
    {
        //STILL IN PROGRESS
        public int plusAgility;
        public int plusHP;
        public int plusAttack;
        
        public Consumable(string Identification, string Name, string Description) : base(Identification, Name, Description)
        {
            //TODO: fix this init? it doesnt look right ^^^
            this.ID = Identification;
            this.Name = Name;
            this.Description = Description;
        }
        public void UseEffect()
        {
            //player.hasEffect = true
            //hp +=
        }
        public void ClearEffect()
        {

        }
        public void AttackingEnemyEffect()
        {

        }
        public void TakingDamageEffect()
        {

        }
        public void DodgeEffect()
        {

        }
    }
}
