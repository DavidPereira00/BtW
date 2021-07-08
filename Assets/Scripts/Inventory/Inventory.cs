using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    public List<Item> items;
    private Player player;
    
    public Inventory(Player player) 
    {
        items = new List<Item>();
        this.player = player;
    }

    public void AddItemToInventory(Item item) 
    {
        bool itemInInventory = false;
        foreach (Item currItem in items)
        {
            if (currItem.itemType == item.itemType)
            {
                currItem.amount = currItem.amount + 1;
                itemInInventory = true;
                break;
            }
        }

        if (!itemInInventory) {
            item.amount = 1;
            items.Add(item);
        }

        if (item.itemType == ItemType.BlueKey) {
            player.PrintMessage("Blue Key acquired! Blue building is now open!");
        } else if (item.itemType == ItemType.GreenKey) {
            player.PrintMessage("Green Key acquired! Green building is now open!");
        } else if (item.itemType == ItemType.YellowKey) {
            player.PrintMessage("Yellow Key acquired! Yellow building is now open!");
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }   

    public void RemoveItemFromInventory(Item item)
    {
        bool itemInInventory = true;
        foreach (Item currItem in items)
        {
            if (currItem.itemType == item.itemType)
            {
                currItem.amount = currItem.amount - 1;
                if (currItem.amount == 0)
                {
                    itemInInventory = false;
                }
            }
        }

        if (!itemInInventory)
        {
            item.amount = 0;
            items.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public List<Item> GetItems()
    {
        return items;
    }
}