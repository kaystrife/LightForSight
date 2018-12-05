using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseRankingButton : MonoBehaviour {

    Button button;

    public GameObject rankingText;
    public GameObject mainButtons;
    public Animator anim;

    // Use this for initialization
    void Start()
    {

        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(CloseRankingPanel);
        }

    }

    void CloseRankingPanel()
    {
        AudioManager.Play("Click");
        rankingText.SetActive(false);
        anim.SetBool("PopUp", false);
        mainButtons.SetActive(true);
    }
}
