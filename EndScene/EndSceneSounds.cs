using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneSounds : MonoBehaviour {

    public EndSceneSpider spider;
    public Text youWinText;
    public Animator anim;

    bool showText;
    float alpha = 0;
    ScoreManager sm;

	// Use this for initialization
	void Start () {

        showText = false;
        StartCoroutine(Blood());
        GameRecord.gameStarted = false;
        sm = GetComponent<ScoreManager>();
	}

    private void Update()
    {
        if (showText && alpha < 1)
        {
            alpha += Time.deltaTime * 0.5f;
        }
        

        youWinText.color = new Color(255, 255, 0, alpha);
    }

    IEnumerator Blood()
    {
        yield return new WaitForSeconds(2.2f);
        AudioManager.Play("Blood");
        spider.canCry = true;
        yield return new WaitForSeconds(1.75f);
        AudioManager.Play("Blood");
        yield return new WaitForSeconds(1f);
        AudioManager.Play("SpiderFall");
        yield return new WaitForSeconds(2f);
        youWinText.text = "CONGRATULATIONS";
        showText = true;
        yield return new WaitForSeconds(2f);
        anim.SetBool("ShowScore", true);
        yield return new WaitForSeconds(1f);
        sm.enabled = true;

    }
}
