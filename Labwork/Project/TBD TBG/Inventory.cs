using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Inventory
    {
        static List<Item> InventoryList = new List<Item>(); //list that will serve as inventory
        
        public static Equipable equippedWeapon = new Equipable("", "default", "default", true);
        public static Equipable equippedArmor = new Equipable("", "default", "default", true);

        public static void AddItem(Item newItem)
        {
            InventoryList.Add(newItem);
        }
        public static void Display()
        {
            Utility.Write("Inventory: ");
            int cnt = 1;
            foreach (var i in InventoryList)
            {
                /*if (i is Equipable )
                {
                    if (i.isEquipped)//<-- TODO: Fix this error
                    {
                        Console.Write("EQUIPPED");
                    }
                }*/
                Utility.Write(cnt + ". " + i.Name);
                cnt++;
            }
        }
        public static void EquipItem(Equipable newEquip)
        {
            //Console.WriteLine(newEquip.Name + " EQUIPED", "yellow");
            if (newEquip.isWeapon) //unequips current weapon
            {   
                Inventory.UnequipItem(Inventory.equippedWeapon);                    
                Inventory.equippedWeapon = newEquip;
            }
            else //unequips current armor
            {
                Inventory.UnequipItem(Inventory.equippedArmor);
                Inventory.equippedArmor = newEquip;
            }

            newEquip.isEquipped = true;
            Player.playerStats.Attack += newEquip.plusAttack;
            Player.playerStats.MaxHP += newEquip.plusHP;
            Player.playerStats.CurrentHP += newEquip.plusHP;            
            Player.playerStats.Agility += newEquip.plusAgility;
        }
        public static void UnequipItem(Equipable oldEquip)
        {
            //Console.WriteLine(oldEquip.Name + " UNEQUIPED","yellow");
            if (oldEquip.isEquipped)
            {
                oldEquip.isEquipped = false;
                Player.playerStats.Attack -= oldEquip.plusAttack;                
                Player.playerStats.MaxHP -= oldEquip.plusHP;
                Player.playerStats.CurrentHP -= oldEquip.plusHP;
                Player.playerStats.Agility -= oldEquip.plusAgility;
            }                   
        }        
        public static void OpenInventoryMenu()
        {
            //TODO: create inventory interface
        }

    }
}
