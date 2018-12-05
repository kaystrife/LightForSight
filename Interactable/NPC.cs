using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable {

    public override void MoveToInteraction(NavMeshAgent playerAgent)
    {
        base.MoveToInteraction(playerAgent);
        playerAgent.stoppingDistance = 5.0f;
    }

    public override void Interact()
    {
        Debug.Log("Interacting with NPC");
    }
}
