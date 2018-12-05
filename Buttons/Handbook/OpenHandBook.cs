using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenHandBook : MonoBehaviour {

    Button button;
    public Animator anim;
    public GameObject handBookContent;
    public GameObject notification;
    public Button[] buttons;
    public WorldInteraction player;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if(button != null)
        {
            button.onClick.AddListener(Open);
        }
	}

    private void Update()
    {
        if(GameRecord.hasNewItem)
        {
            notification.SetActive(true);
        }else
        {
            notification.SetActive(false);
        }

    }
    void Open()
    {
        AudioManager.Play("Click");
        GameRecord.hasNewItem = false;
        StartCoroutine(ShowContent());

    }

    IEnumerator ShowContent()
    {
        anim.SetBool("isOpen", true);
        button.enabled = false;
        player.enabled = false;

        foreach (Button btn in buttons)
        {
            btn.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);
        handBookContent.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
    }
}
