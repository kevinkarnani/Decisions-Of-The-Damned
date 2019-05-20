using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Inventory
    {
        //static List<Item> InventoryList = new List<Item>(); //list that will serve as inventory
        //TODO: MAKE EQUIPABLE LIST AND CONSUMABLE LIST
        static List<Equipable> EquipableList = new List<Equipable>();

        public static Equipable equippedWeapon = new Equipable("", "default", "default", true);
        public static Equipable equippedArmor = new Equipable("", "default", "default", true);

        static readonly string inventoryColor = "yellow";
        static readonly string choiceColor = "cyan";
        /*
         * 
         * 
         */

        public static void AddItem(Item newItem)
        {
            if (newItem is Equipable)
            {
                EquipableList.Add((Equipable)newItem);
            }
            else
            {
                //it's a consumable
            }
        }
        public static void DisplayAll()
        {
            Utility.Write("Inventory: ", inventoryColor);
            int cnt = 1;
            foreach (var i in EquipableList)
            {
                string itemLine = cnt + ") " + i.Name;
                
                if (i.isEquipped)
                {
                    itemLine += " [EQUIPPED]";
                }                
                Utility.Write(itemLine, inventoryColor);
                cnt++;
            }
            //for each in consumable list
        }
        public static void DisplayEquipables()
        {
            Utility.Write("Equipable Items: ", inventoryColor);
            int cnt = 1;
            foreach (var i in EquipableList)
            {
                string itemLine = cnt + ") " + i.Name;

                if (i.isEquipped)
                {
                    itemLine += " [EQUIPPED]";
                }
                Utility.Write(itemLine, inventoryColor);
                cnt++;
            }
        }
        //TODO: displayConsumables


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
            Utility.Write("[]xx[]:::::> INVENTORY MENU <:::::[]xx[]", inventoryColor);
            string option = "";
            while(option.ToLower() != "q")
            {
                //Inventory.Display();
                Utility.Write("What would you like to do?", inventoryColor);
                Utility.Write("1) Check item", choiceColor);
                Utility.Write("2) Equip item", choiceColor);
                Utility.Write("3) Consume item", choiceColor);
                Utility.Write("Q) Quit", choiceColor);
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
                    case ("q"):
                        break;
                }

            }
        }
        private static void CheckItemSubmenu()
        {
            Utility.Write("~~~ CHECK ITEM ~~~", inventoryColor);
            string option = "";
            
            Inventory.DisplayAll();
            Utility.Write("Q) Quit", choiceColor);
            Utility.Write("What item would you like to check?", choiceColor);

            //TODO: Error check this!!

            while(option.ToLower() != "q")
            {
                option = Utility.Input();
                if(option.ToLower() == "q")
                {
                    break;
                }
                int itemNum = Int32.Parse(option);
                //print item info 
                if (itemNum < EquipableList.Count) //item chosen is an equipable item
                {
                    Utility.Write("Name:" + EquipableList[itemNum].Name, inventoryColor);
                    Utility.Write("Description: " + EquipableList[itemNum].Description, inventoryColor);
                    Utility.Write("Stats:", inventoryColor);
                    EquipableList[itemNum].PrintEquipableStats();
                }

            }

            //TODO: Make equippable list




        }
        private static void EquipItemSubmenu()
        {
            Utility.Write("~~~ EQUIP ITEM ~~~", inventoryColor);
            string option = "";

            Inventory.DisplayEquipables();
            Utility.Write("Q) Quit", choiceColor);
            Utility.Write("What item would you like to equip?", choiceColor);

            //TODO: Error check this!!

            while (option.ToLower() != "q")
            {
                option = Utility.Input();
                if (option.ToLower() == "q")
                {
                    break;
                }
                int itemNum = Int32.Parse(option);
                //print item info 
                if (itemNum < EquipableList.Count) //item chosen is an equipable item
                {
                    Utility.Write("Item Equipped:" + EquipableList[itemNum].Name, inventoryColor);
                    Inventory.EquipItem(EquipableList[itemNum]);
                }

            }
        }
        private static void ConsumeItemSubmenu()
        {

        }

    }
}
