using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public Animator anim;
    public GameObject tutorialOptionPanel;
    public GameObject fadeOut;

    public Button startBtn, settingBtn, yesBtn, noBtn;

	// Use this for initialization
	void Start () {

        startBtn.onClick.AddListener(StartGame);
        settingBtn.onClick.AddListener(Settings);
        yesBtn.onClick.AddListener(GoToTutorialScene);
        noBtn.onClick.AddListener(GoToGameScene);

	}

    public void Settings()
    {
        AudioManager.Play("Click");
        Debug.Log("Go to Setting page");
    }

    public void StartGame()
    {
        AudioManager.Play("Click");
        tutorialOptionPanel.SetActive(true);
    }

    public void GoToTutorialScene()
    {
        AudioManager.Play("Click");
        StartCoroutine(ChangeSceneIE("TutorialScene"));
    }

	public void GoToGameScene()
    {
        //GameRecord.gameStarted = true;
        AudioManager.Play("Click");
        StartCoroutine(ChangeSceneIE("LoadingScene"));
    }

    IEnumerator ChangeSceneIE(string sceneName)
    {
        fadeOut.SetActive(true);
        anim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
