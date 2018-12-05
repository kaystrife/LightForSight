using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockItem : MonoBehaviour {

    Button button;
    Image image;
    bool unlocked;

    public Item item;
    public Text itemDescription;
    public Text itemName;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();
        image = GetComponent<Image>();
        unlocked = false;

        if(button !=null)
        {
            button.onClick.AddListener(ShowItemDescription);
        }
	}

    private void Update()
    {
        if(!unlocked)
        {
            if(CheckGameRecord())
            {
                image.sprite = item.itemImage;
                unlocked = true;
            }
        }
    }

    void ShowItemDescription()
    {
        if(unlocked)
        {
            itemDescription.text = item.itemDescription;
            itemName.text = item.itemName;
        }
        else
        {
            itemDescription.text = "You haven't unlocked this item!";
            itemName.text = "";
        }

    }
	
    bool CheckGameRecord()
    {
        string checkItem = item.itemName;
        bool hasItem = false;

        switch(checkItem)
        {
            case "Apple":
                if(GameRecord.hasApple)
                {
                    hasItem = true;
                } break;
            case "Axe":
                if(GameRecord.hasAxe)
                {
                    hasItem = true;
                } break;
            case "Speed Up Potion":
                if (GameRecord.hasSpeedUpPotion)
                {
                    hasItem = true;
                } break;
            case "Ice Stone":
                if(GameRecord.hasIceStone)
                {
                    hasItem = true;
                } break;
            case "Stone":
                if(GameRecord.hasStone)
                {
                    hasItem = true;
                }
                break;
            default:
                hasItem = false;
                break;
        }

        return hasItem;
    }
}
