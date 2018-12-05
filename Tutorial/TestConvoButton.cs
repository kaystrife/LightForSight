using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConvoButton : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(TurnOn);
        }
	}
	
    void TurnOn()
    {
        TutorialConvoManager.TurnOnConvo();
    }
}
