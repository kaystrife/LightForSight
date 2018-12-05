using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickSpider : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            Debug.Log(interactedObject.name);

            if (interactedObject.tag == "Enemy")
            {
                AudioManager.Play("SpiderSqueak");
            }
        }
    }
}
