using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMenuButton : MonoBehaviour {

    Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(GoToMenu);
        }
	}
	
	void GoToMenu()
    {
        AudioManager.Play("Click");
        GameRecord.ResetGameRecord();
        SceneManager.LoadScene("MenuScene");
    }
}
