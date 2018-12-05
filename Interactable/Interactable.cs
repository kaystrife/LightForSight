using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    public NavMeshAgent playerAgent;
    private bool hasInteracted = true;

    private void Update()
    {
        if(!hasInteracted && playerAgent!=null && !playerAgent.pathPending)
        {
            if(playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    //move the player agent to the interactable object
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;

        this.playerAgent = playerAgent;
        playerAgent.destination = transform.position;
        playerAgent.stoppingDistance = 2.0f;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }
}
