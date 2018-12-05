using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpItem : Interactable {

    public Item item;
    public GameObject lightSphereBurst;
    Inventory inventory;
    WeakenLight lightSource;
    ActionLog action;
    Vector3 offset = new Vector3(0, 1f, 0);

    public void Start()
    {
        inventory = Inventory.instance;
        lightSource = WeakenLight.instance;
        action = ActionLog.instance;
    }

    public override void Interact()
    {
        Debug.Log("Interacting with Pick up item");

        if (item.isLight)
        {
            lightSource.IncreaseLight(item.lightIntensity);
            LightSphereSpawner.canSpawn = true;
            Instantiate(lightSphereBurst, transform.position + offset, transform.rotation);
            GameRecord.SetLightSphere();
            AudioManager.Play("GlassBreak");
            Destroy(gameObject);

        }
        else //is an item that can be put into inventory*/
        {
            if (inventory.AddItem(item))
            {
                action.NewLog("You picked up (1) " + item.itemName);
                AudioManager.Play("Click");
                Destroy(gameObject);
            }
            else
            {
                action.NewLog("Your inventory is full");
            }
        }
        
    }

    public override void MoveToInteraction(NavMeshAgent playerAgent)
    {
        base.MoveToInteraction(playerAgent);
        playerAgent.stoppingDistance = 5.0f;
    }
}
