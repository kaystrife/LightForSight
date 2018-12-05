using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text[] bNames;
    public Text[] bScore;
    public Button button;

    public GameObject nameInputBox;

    public GameObject baseScoreText;
    public Text baseScore;

    public GameObject tScoreText;
    public Text tScore;

    public GameObject clearTimeText;
    public Text clearTime;

    public GameObject underscore;

    TopScoreManager tsm;

    Queue<string> bNamesQ;
    Queue<int> bScoreQ;

    int clearMin;
    int clearSec;
    int totalScore;
    int _baseScore;

    bool showClearedTime;
    bool showBaseScore;
    bool showTotalScore;
    int i = 0;
    
	// Use this for initialization
	void Start () {

        tsm = TopScoreManager.instance;

        bNamesQ = new Queue<string>();
        bScoreQ = new Queue<int>();

        clearMin = (int)(GameRecord.GetCompleteTime() / 60);
        clearSec = (int)(GameRecord.GetCompleteTime() % 60);
        _baseScore = (int)(600 - GameRecord.GetCompleteTime());

        if(_baseScore <0)
        {
            _baseScore = 0;
        }

        totalScore = _baseScore;

        showBaseScore = false;
        showTotalScore = false;

        clearTimeText.SetActive(true);
        clearTime.text = clearMin.ToString() + "min " + clearSec.ToString() + "sec";

        CheckBonus();
	}

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(!showTotalScore)
            {
                ShowBonus();
            }else
            {
                underscore.SetActive(true);
                ShowTotalScore();
            }
        }
    }


    void CheckBonus()
    {
        //collect 30 light crystal
        if(GameRecord.GetLightSphereNum() > 15)
        {
            bNamesQ.Enqueue("Collected over 15 light crystals");
            bScoreQ.Enqueue(50);
            totalScore += 50;
        }

        //collect at least one of each item
        if(GameRecord.hasApple && GameRecord.hasIceStone && GameRecord.hasSpeedUpPotion)
        {
            bNamesQ.Enqueue("Collected at least one of each item");
            bScoreQ.Enqueue(20);
            totalScore += 20;
        }

        //used 0 item
        if(!GameRecord.usedApple && !GameRecord.usedSpeedUp && !GameRecord.usedIceStone)
        {
            bNamesQ.Enqueue("Used 0 item");
            bScoreQ.Enqueue(100);
            totalScore += 100;
        }

        //cleared game under 3 mins
        if(GameRecord.GetCompleteTime() < 180)
        {
            bNamesQ.Enqueue("Cleared game under 3min");
            bScoreQ.Enqueue(150);
            totalScore += 150;
        }
       
        //got no damage
        if(!GameRecord.GetIsHit())
        {
            bNamesQ.Enqueue("Received no damage");
            bScoreQ.Enqueue(200);
            totalScore += 200;
        }
    }

    void ShowBonus()
    {
        if(!showBaseScore)
        {
            baseScoreText.SetActive(true);
            baseScore.text = _baseScore.ToString();
            showBaseScore = true;
            return;
        }

        if(bNamesQ.Count >0 && bScoreQ.Count>0 && i<bNames.Length && i<bScore.Length)
        {
                bNames[i].text = bNamesQ.Dequeue();
                bScore[i].text = bScoreQ.Dequeue().ToString();
        }

        if(bNamesQ.Count<=0 && bScoreQ.Count<=0)
        {
            showTotalScore = true;
        }

        i++;
    }

    void ShowTotalScore()
    {
        if(Input.GetMouseButtonUp(0))
        {
            tScoreText.SetActive(true);
            tScore.text = totalScore.ToString();
            StartCoroutine(ShowTopNameInput());

        }
    }

    IEnumerator ShowTopNameInput()
    {
        yield return new WaitForSeconds(1);
        int rank = tsm.SubmitScores(totalScore);
        Debug.Log("Submit score");

        if (rank == 0)
        {
            button.gameObject.SetActive(true);
        } else
        {
            nameInputBox.SetActive(true);
            tsm.thisRank = rank;
        }

        StopAllCoroutines();
        this.enabled = false;

    }
}
