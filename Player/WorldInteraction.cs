using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;
    Camera mainCamera;
    Player player;

    float moveSpeed;
    GameObject goThereClone;


    public GameObject goThere;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        player = GetComponent<Player>();

    }

    private void Update()
    {

        moveSpeed = player.playerStat.moveSpeed;
        playerAgent.speed = moveSpeed;
        


        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Left click");
            GetInteraction();
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            Debug.Log(interactedObject.name);

            Vector3 goTherePos = new Vector3(interactionInfo.point.x, 0.55f, interactionInfo.point.z);

            Destroy(goThereClone);
            goThereClone = (GameObject)Instantiate(goThere, goTherePos, Quaternion.Euler(Vector3.right*90));

            if (interactedObject.tag == "Interactable")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else if(interactedObject.tag == "Tutorial")
            {
                interactedObject.GetComponent<TutorialLightSphere>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.destination = interactionInfo.point;
                playerAgent.stoppingDistance = 0;
            }
        }
    }
}
