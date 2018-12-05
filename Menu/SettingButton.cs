using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour {

    Button button;
    public GameObject mainButtons;
    public GameObject volumeControllers;
    public Animator anim;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(ShowSettings);
        }
	}
	
	void ShowSettings()
    {
        AudioManager.Play("Click");
        anim.SetBool("isOpen", true);
        StartCoroutine(ShowVolumeControllers());
    }

    IEnumerator ShowVolumeControllers()
    {
        yield return new WaitForSeconds(0.5f);
        volumeControllers.SetActive(true);
        mainButtons.SetActive(false);
    }
}
