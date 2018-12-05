using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameBtn : MonoBehaviour {

    Button button;
    public GameObject quitGamePanel;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OpenPanel);
        }
    }
	
    void OpenPanel()
    {
        AudioManager.Play("Click");
        quitGamePanel.SetActive(true);
        button.enabled = false;
    }
}
