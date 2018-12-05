using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettingPanel : MonoBehaviour {

    Button button;
    public GameObject mainButtons;
    public GameObject volumeControllers;
    public Animator anim;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(CloseSetting);
        }
	}
	
	void CloseSetting()
    {
        AudioManager.Play("Click");
        volumeControllers.SetActive(false);
        anim.SetBool("isOpen", false);
        mainButtons.SetActive(true);
    }
}
