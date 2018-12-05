using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoQuitBtn : MonoBehaviour {

    Button button;
    public GameObject quitGamePanel;
    public Button quitGameBtn;

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
        quitGameBtn.enabled = true;
        quitGamePanel.SetActive(false);
    }
}
