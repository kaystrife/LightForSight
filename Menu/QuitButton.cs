using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(QuitGame);
        }
	}
	
    void QuitGame()
    {
        AudioManager.Play("Click");
        Application.Quit();
    }
}
