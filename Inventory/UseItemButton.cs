using UnityEngine;
using UnityEngine.UI;

public class UseItemButton : MonoBehaviour {

    Button itemSlot;
    Inventory inventory;
    bool canUseItem;
    float coolingTime = 0.75f;
    float coolingTimeCnt;

    ActionLog action;

    [SerializeField]
    private int itemSlotNum;

    // Use this for initialization
    void Start () {

        itemSlot = GetComponent<Button>();
        inventory = Inventory.instance;
        action = ActionLog.instance;
        coolingTimeCnt = coolingTime;
        canUseItem = true;

        if(itemSlot!=null)
        {
            itemSlot.onClick.AddListener(UseItem);
        }
	}

    private void Update()
    {
        if(!canUseItem)
        {
            coolingTimeCnt -= Time.deltaTime;
            if(coolingTimeCnt <= 0)
            {
                canUseItem = true;
                coolingTimeCnt = coolingTime;
            }
        }
    }

    void UseItem()
    {
        AudioManager.Play("Click");

        if(canUseItem)
        {
            inventory.UseItem(itemSlotNum);
            canUseItem = false;
        }else
        {
            action.NewLog("Inventory cooling Down");
        }

    }
}
