using UnityEngine;
using UnityEngine.AI;

public class Rock : Interactable {

    public GameObject stone;
    public GameObject dirtSplatter;
    public string requiredItem;
    int rockHP;
    Player player;
    Inventory inventory;
    ActionLog action;
    Vector3 offset = new Vector3(0, 1.5f, 0);

    private void Start()
    {
        player = Player.instance;
        inventory = Inventory.instance;
        action = ActionLog.instance;
        rockHP = 20;
    }

    public override void Interact()
    {
        if(inventory.CheckItemExists(requiredItem) != -1)
        {
            rockHP--;
            AudioManager.Play("DigRock");
            action.NewLog("You hit the rock with an axe");
            Instantiate(dirtSplatter, transform.position, Quaternion.Euler(Vector3.forward*90));
        }
        else
        {
            action.NewLog("You need a tool");
        }

        if(rockHP <=0)
        {
            AudioManager.Play("RockExplode");
            action.NewLog("The rock is broken into pieces...");
            action.NewLog("Your axe is broken");
            inventory.DestroyItem(requiredItem);
            RockSpawner.canSpawn = true;
            Instantiate(stone, transform.position + offset, Quaternion.Euler(Vector3.right * 35));
            Destroy(gameObject);
        }
    }

    public override void MoveToInteraction(NavMeshAgent playerAgent)
    {
        base.MoveToInteraction(playerAgent);
        playerAgent.stoppingDistance = 5.0f;
    }
}
