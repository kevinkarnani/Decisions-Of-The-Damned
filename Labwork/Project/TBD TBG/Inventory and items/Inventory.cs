using System;
using System.Collections.Generic;

namespace TBD_TBG
{
    public static class Inventory
    {
        //TODO: CONSUMABLE LIST
        //TODO: Error check user inputs

        public static List<Equipable> EquipableList = new List<Equipable>();
        public static List<Consumable> ConsumableList = new List<Consumable>();

        public static Equipable equippedWeapon = new Equipable("", "default", "default");
        public static Equipable equippedArmor = new Equipable("", "default", "default");
        
        //Adds an item to your inventory, either the equipable list or consumable list
        public static void AddItem(Item newItem)
        {
            equippedWeapon.SetIsWeapon(true);
            equippedArmor.SetIsWeapon(true);
            if (newItem is Equipable)
            {
                EquipableList.Add((Equipable)newItem);
            }
            else if (newItem is Consumable) //it's a consumable
            {
                ConsumableList.Add((Consumable)newItem);
            }
        }
        //displays all items in your inventory, first the equipables then the consumbales
        public static void DisplayAll(string color)
        {
            Utility.Write("Equipable Items: ", Game.inventoryColor);
            int count = 1;
            foreach (var i in EquipableList)
            {
                string itemLine = i.Name;
                
                if (i.isEquipped) //if the equipable is currently equiped, then show it
                {
                    itemLine += " [EQUIPPED]";
                }                
                Menu.OutputIndent(count.ToString(), new Menu(itemLine));
                count++;
            }
            Utility.Write("Consumable Items: ", Game.inventoryColor);
            //for each in consumable list
            foreach (var i in ConsumableList)
            {
                string itemLine = i.Name;
                Menu.OutputIndent(count.ToString(), new Menu(itemLine));
                count++;
                
            }
        }
        //displays only the items in your equipable list
        public static void DisplayEquipables(string color)
        {
            int count = 1;
            foreach (var i in EquipableList)
            {
                string itemLine = i.Name;

                if (i.isEquipped) //if the equipable is currently equiped, then show it
                {
                    itemLine += " [EQUIPPED]";
                }
                Menu.OutputIndent(count.ToString(), new Menu(itemLine));
                count++;
            }
        }
        //TODO: displayConsumables
        public static void DisplayConsumables(string color)
        {
            int count = 1;
            foreach (var i in ConsumableList)
            {
                string itemLine = i.Name;
                Menu.OutputIndent(count.ToString(), new Menu(itemLine));
                count++;        
            }
        }

        //Opens an interface for the user to interact with their inventory
        public static void OpenInventoryMenu()
        {            
            //Utility.Write("[]xxx[]::::::::> INVENTORY MENU <::::::::[]xxx[]", Game.inventoryColor);
            string option = "";
            while(option.ToLower() != "q") //type q to exit the menu
            {
                Utility.Write("[]xxx[]::::::::> INVENTORY MENU <::::::::[]xxx[]", Game.inventoryColor);
                //TODO: error check the user's input
                Utility.Write("What would you like to do?", Game.inventoryColor);
                Menu.OutputIndent("1", new Menu("Check item")); //look at item description and stats
                Menu.OutputIndent("2", new Menu("Equip item")); //add equipable stats to your stats
                Menu.OutputIndent("3", new Menu("Consume item")); //use a consumable item
                Menu.OutputIndent("Q", new Menu("Quit"));
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
                        Utility.Write("Current stats: ", Game.inventoryColor);
                        Player.playerStats.PrintStatOverview();
                        Console.WriteLine();
                         break;
                }
            }
        }

        //submenu that lets the user look at item descriptions and stats
        private static void CheckItemSubmenu()
        {
            Utility.Write("~~~~~~ CHECK ITEM ~~~~~~", Game.inventoryColor);
            Utility.Write("What item would you like to check?", Game.inventoryColor);

            string option = "";            
            
            //TODO: Error check this!!

            while(option.ToLower() != "q")
            {
                Utility.Write("Inventory: ", Game.inventoryColor);
                DisplayAll(Game.choiceColor); //displays all items in your invenory
                Menu.OutputIndent("Q", new Menu("Quit"));

                option = Utility.Input();
                if(option.ToLower() == "q") //type q to exit
                {
                    break;
                }
                int itemNum = Int32.Parse(option) - 1;

                //print item info 
                if (EquipableList.Count!=0 && itemNum < EquipableList.Count) //item chosen is an equipable item
                {
                    Utility.Write("Item type: Equipable", Game.inventoryColor);
                    Utility.Write("Name: " + EquipableList[itemNum].Name, Game.inventoryColor);
                    Utility.Write("Description: " + EquipableList[itemNum].Description, Game.inventoryColor);
                    Utility.Write("Stats:", Game.inventoryColor);
                    EquipableList[itemNum].PrintStats();
                }
                //TODO: display consumable item info
                else if (ConsumableList.Count != 0 && itemNum >= EquipableList.Count && itemNum< (EquipableList.Count + ConsumableList.Count))//item chosen is an equipable item
                {
                    itemNum -= EquipableList.Count;
                    Utility.Write("Item type: Consumable", Game.inventoryColor);
                    Utility.Write("Name: " + ConsumableList[itemNum].Name, Game.inventoryColor);
                    Utility.Write("Description: " + ConsumableList[itemNum].Description, Game.inventoryColor);
                    Utility.Write("Buff:", Game.inventoryColor);
                    ConsumableList[itemNum].PrintStats();
                }
            }
        }

        //submenu that lets the user equip equipables (and unequip current equipable)
        private static void EquipItemSubmenu()
        {
            Utility.Write("~~~~~~ EQUIP ITEM ~~~~~~", Game.inventoryColor);
            Utility.Write("What item would you like to equip?", Game.inventoryColor);

            string option = ""; 
            
            //TODO: Error check this!!

            while (option.ToLower() != "q")
            {
                Utility.Write("Equipable items: ", Game.inventoryColor);
                DisplayEquipables(Game.choiceColor);
                Menu.OutputIndent("Q", new Menu("Quit"));

                option = Utility.Input();
                if (option.ToLower() == "q") //type q to exit
                {
                    break;
                }
                int itemNum = Int32.Parse(option) - 1;

                //print item info 
                if (itemNum < EquipableList.Count) //item chosen is an equipable item
                {
                    Equipable oldEquip; 
                    //stores the current equipped item 
                    if (EquipableList[itemNum].isWeapon)
                    {
                        oldEquip = equippedWeapon;
                    }
                    else
                    {
                        oldEquip = equippedArmor;
                    }
                    Utility.Write("Item Equipped:" + EquipableList[itemNum].Name, Game.inventoryColor);
                    //EquipItem(EquipableList[itemNum]); //equip item to player
                    (EquipableList[itemNum]).Equip();
                    //print the difference in stats between the old equipable and the new equipable
                    PrintDifferenceInStats(oldEquip, EquipableList[itemNum]);
                }
                //TODO: else, throw an error
            }
        }

        //displays the difference between the stats of one equipable and a new equipable
        private static void PrintDifferenceInStats(Equipable oldEquip, Equipable newEquip)
        {
            //TODO: Don't display change if it = 0

            Utility.Write("Change in stats: ", Game.inventoryColor);
            Utility.Write("Attack: " + (newEquip.plusAttack - oldEquip.plusAttack), Game.statsColor);
            Utility.Write("Agility: " + (newEquip.plusAgility - oldEquip.plusAgility), Game.statsColor);
            Utility.Write("HP: " + (newEquip.plusHP - oldEquip.plusHP), Game.statsColor);
            Console.WriteLine();
        }

        //submenu to consume a consumable item
        public static void ConsumeItemSubmenu()
        {
            //TODO: Can you consume an item outside of combat? 
            /* Only hp potions should be usable outside of combat
             * Ex: You can use potions outside of combat in pokemon,
             * but no xattacks or xdefenses
             */

            //only display if the consumable is usable outside of combat
            if (Player.inCombat)
            {
            }
            else
            {
            }

            Utility.Write("~~~~~~ CONSUME ITEM ~~~~~~", Game.inventoryColor);
            Utility.Write("What item would you like to consume?", Game.inventoryColor);

            string option = "";

            //TODO: Error check this!!

            while (option.ToLower() != "q")
            {
                Utility.Write("Consumable items: ", Game.inventoryColor);
                DisplayConsumables(Game.choiceColor);
                Menu.OutputIndent("Q", new Menu("Quit"));

                option = Utility.Input();
                if (option.ToLower() == "q") //type q to exit
                {
                    break;
                }
                int itemNum = Int32.Parse(option) - 1;

                //print item info 
                if (itemNum < ConsumableList.Count) //item chosen is a consumabel item
                {
                    //usable: not in combat and usable outside
                    //and in combat and usable outside
                    //not usable: not in combat and not usable outside
                    //
                    if (!(Player.inCombat) && !(ConsumableList[itemNum].isUsableOutsideOfCombat))
                    {
                        //can't use
                        Utility.Write("You can only use that item in combat.", Game.errorColor);
                    }
                    else
                    {
                        ConsumableList[itemNum].isActive = true;

                        Utility.Write("Item Consumed:" + ConsumableList[itemNum].Name, Game.inventoryColor);
                        //use item
                        (ConsumableList[itemNum]).UseEffect();
                        Player.playerStats.PrintStatOverview();
                        Console.WriteLine();
                    }
                }
                //TODO: else, throw an error
            }
        }
    }
}
