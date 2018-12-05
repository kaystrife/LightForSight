using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YesQuitBtn : MonoBehaviour {

    Button button;
    public GameObject fadeOut;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(QuitGame);
        }
    }
	
    void QuitGame()
    {
        AudioManager.Play("Click");
        Time.timeScale = 1.0f;
        StartCoroutine(BackToMenu());
    }

    IEnumerator BackToMenu()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        GameRecord.ResetGameRecord();
        SceneManager.LoadScene("MenuScene");
    }
}
