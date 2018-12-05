using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameCloseSettingBtn : MonoBehaviour {

    Button button;

    public WorldInteraction player;
    public Button[] buttons;
    public Animator anim;
    public GameObject volumeControllers;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Close);
        }
    }
	
	void Close()
    {
        AudioManager.Play("Click");
        Time.timeScale = 1.0f;
        volumeControllers.SetActive(false);
        anim.SetBool("isOpen", false);

        foreach (Button btn in buttons)
        {
            btn.enabled = true;
        }

        player.enabled = true;
    }
}
