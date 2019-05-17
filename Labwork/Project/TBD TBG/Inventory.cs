using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Inventory
    {
        static List<Item> InventoryList = new List<Item>(); //list that will serve as inventory
        //TODO: MAKE EQUIPABLE LIST AND CONSUMABLE LIST


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
                Utility.Write(cnt + ") " + i.Name);
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
            Utility.Write("[]xx[]:::::> INVENTORY MENU <:::::[]xx[]");
            string option = "";
            while(option.ToLower() != "q")
            {
                //Inventory.Display();
                Utility.Write("What would you like to do?");
                Utility.Write("1) Check item");
                Utility.Write("2) Equip item");
                Utility.Write("3) Consume item");
                Utility.Write("Q) Quit");
                option = Utility.Input();
                switch (option)
                {
                    case ("1"):
                        CheckItemSubmenu();
                        break;
                    case ("2"):
                        EquipItemSubmenu();
                        break;
                    case ("3"):
                        ConsumeItemSubmenu();
                        break;
                    case ("Q"):
                        break;
                }

            }
        }
        private static void CheckItemSubmenu()
        {
            Utility.Write("~~~ CHECK ITEM ~~~");
            string option = "";
            
            Inventory.Display();
            Utility.Write("Q) Quit");
            Utility.Write("What item would you like to check?");

            //TODO: Error check this!!
            //option = Int32.Parse(Utility.Input());
            //option = Utility.Input()

            while(option.ToLower() != "q")
            {
                option = Utility.Input();
                //print item info 

            }

            //TODO: Make equippable list




        }
        private static void EquipItemSubmenu()
        {

        }
        private static void ConsumeItemSubmenu()
        {

        }

    }
}
