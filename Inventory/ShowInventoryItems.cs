
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventoryItems : MonoBehaviour {

    Inventory inventory;

    public Image[] buttonSprites;
    public Text[] itemQty;
    public Sprite emptySlotImage;

    // Use this for initialization
    void Start () {

        inventory = Inventory.instance;
        UpdateSlotItems();
	}

    public void UpdateSlotItems () {

        for (int i = 0; i < inventory.itemInSlots.Length; i++)
        {
            if (inventory.itemInSlots[i].itemName == "Empty")
            {
                Debug.Log("Show Empty");
                buttonSprites[i].sprite = emptySlotImage;
                itemQty[i].text = "";
            }
            else
            {
                Debug.Log("Show something");
                buttonSprites[i].sprite = inventory.itemInSlots[i].itemImage;
                itemQty[i].text = inventory.itemQty[i].ToString();
            }
        }
	}
}
