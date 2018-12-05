
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject menuButton;
    public Text gameOverText;

    bool showGameOverText;
    float alpha;

	// Use this for initialization
	void Start () {

        showGameOverText = false;
        alpha = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if(GameRecord.GetPlayerDied())
        {
            StartCoroutine(PlayGameOver());
        }

        if(showGameOverText)
        {
            alpha += Time.deltaTime * 0.5f;

            if(alpha > 1)
            {
                alpha = 1;
            }

            gameOverText.color = new Color(255, 0, 0, alpha);
        }
	}

    IEnumerator PlayGameOver()
    {
        gameOverPanel.SetActive(true);
        showGameOverText = true;

        yield return new WaitForSeconds(2);
        menuButton.SetActive(true);
        StopAllCoroutines();
    }


}
