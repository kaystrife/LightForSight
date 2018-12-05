using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
   
    #region singleton

    public static Inventory instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance !=this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public Item[] itemInSlots;
    public int[] itemQty;
    public Item emptySlot;

    public PlayerUseItem player;
    ShowInventoryItems updateInventory;

    private void Start()
    {
        updateInventory = GetComponent<ShowInventoryItems>();
    }

    public bool AddItem(Item item)
    {
        Debug.Log("Add Item to inventory");
        int index = CheckItemExists(item.itemName);

        if (index != -1) //item already exists in the inventory
        {
            itemQty[index]++;
            updateInventory.UpdateSlotItems();
            return true;

        } else //new item check enough space or not
        {
            bool added = false;

            for (int i = 0; i < itemInSlots.Length; i++)
            {
                if(itemInSlots[i] == emptySlot)
                {
                    itemInSlots[i] = item;
                    itemQty[i]++;
                    updateInventory.UpdateSlotItems();
                    added = true;
                }

                if(added)
                {
                    break;
                }
            }

            if(added)
            {
                CheckWhatItem(item);
            }

            return added;
        }

    }

    public void UseItem(int itemIndex)
    {
        if(itemInSlots[itemIndex] == emptySlot)
        {
            Debug.Log("This is an empty item slot");
            return;
        }

        if(player.UseItem(itemInSlots[itemIndex])){
            itemQty[itemIndex]--;
        }

        Debug.Log("Item Qty of item " + itemIndex + " decrease");

        if (itemQty[itemIndex]==0) //that item is used up
        {
            itemInSlots[itemIndex] = emptySlot;
            TidyUp();
        }

        updateInventory.UpdateSlotItems();
    }

    public int CheckItemExists(string checkItem)
    {
        for (int i = 0; i < itemInSlots.Length; i++)
        {
            if(itemInSlots[i].itemName == checkItem)
            {
                return i;
            }
        }

        return -1;
    }

    public void DestroyItem(string destroyItem)
    {
        for (int i = 0; i < itemInSlots.Length; i++)
        {
            if(itemInSlots[i].itemName == destroyItem)
            {
                itemQty[i]--;
                if(itemQty[i]==0)
                {
                    itemInSlots[i] = emptySlot;
                    TidyUp();
                }
                return;
            }
        }
    }

    //Tidy up the inventory when an item is used up
    private void TidyUp()
    {
        for (int i = 1; i < itemInSlots.Length; i++)
        {
            if(itemInSlots[i-1] == emptySlot)
            {
                itemInSlots[i - 1] = itemInSlots[i];
                itemQty[i - 1] = itemQty[i];

                itemInSlots[i] = emptySlot;
                itemQty[i] = 0;

                updateInventory.UpdateSlotItems();
            }
        }
    }

    private void CheckWhatItem(Item item)
    {
        if(item.isFreeze)
        {
           if(!GameRecord.hasIceStone)
            {
                GameRecord.hasIceStone = true;
                GameRecord.hasNewItem = true;
            }
        }
        else if(item.isHP)
        {
            if (!GameRecord.hasApple)
            {
                GameRecord.hasApple = true;
                GameRecord.hasNewItem = true;
            }
        }
        else if(item.isSpeedUp)
        {
            if (!GameRecord.hasSpeedUpPotion)
            {
                GameRecord.hasSpeedUpPotion = true;
                GameRecord.hasNewItem = true;
            }
        }
        else if(item.isWeapon)
        {
            if (!GameRecord.hasStone)
            {
                GameRecord.hasStone = true;
                GameRecord.hasNewItem = true;
            }
        }
        else
        {
            if(!GameRecord.hasAxe)
            {
                GameRecord.hasAxe = true;
                GameRecord.hasNewItem = true;
            }
        }
    }
}
