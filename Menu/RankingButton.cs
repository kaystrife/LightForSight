using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankingButton : MonoBehaviour {

    Button button;

    public GameObject rankingText;
    public GameObject mainButtons;
    public Animator anim;
    public ShowTopScores showTopScore;

	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        if(button!=null)
        {
            button.onClick.AddListener(ShowRankingPanel);
        }
  
	}
	
	void ShowRankingPanel()
    {

        AudioManager.Play("Click");
        StartCoroutine(WaitAndShowRanking());

    }

    IEnumerator WaitAndShowRanking()
    {
        anim.SetBool("PopUp", true);
        yield return new WaitForSeconds(0.5f);
        rankingText.SetActive(true);
        showTopScore.ShowNamesAndScores();
        mainButtons.SetActive(false);
    }

}
