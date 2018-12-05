using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSettingButton : MonoBehaviour {

    Button button;

    public GameObject settingPanel;
    public GameObject volumeControllers;
    public WorldInteraction player;
    public Button[] buttons;
    public Animator anim;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(OpenPanel);
        }
	}
	
    void OpenPanel()
    {
        AudioManager.Play("Click");
        anim.SetBool("isOpen", true);
        StartCoroutine(ShowVolumeControllers());
    }

    IEnumerator ShowVolumeControllers()
    {
        player.enabled = false;
        button.enabled = false;

        foreach(Button btn in buttons)
        {
            btn.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);
        volumeControllers.SetActive(true);
        Time.timeScale = 0;
    }
}
