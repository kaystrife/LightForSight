using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseHandBook : MonoBehaviour {

    Button button;
    public Button[] buttons;

    public Animator anim;
    public GameObject handBookContent;
    public Text itemDescription;
    public Text itemName;
    public WorldInteraction player;

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
        itemName.text = "";
        itemDescription.text = "";
        handBookContent.SetActive(false);
        anim.SetBool("isOpen", false);

        foreach(Button btn in buttons)
        {
            btn.enabled = true;
        }

        player.enabled = true;
    }
}
