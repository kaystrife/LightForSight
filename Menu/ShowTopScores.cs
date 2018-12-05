using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTopScores : MonoBehaviour {

    public Text firstName, secondName, thirdName, forthName, fifthName;
    public Text firstScore, secondScore, thirdScore, forthScore, fifthScore;

    TopScoreManager tsm;

	// Use this for initialization
	void Start () {

        tsm = TopScoreManager.instance;
	}
	
    public void ShowNamesAndScores()
    {
        if(PlayerPrefs.HasKey("FirstName"))
        {
            firstName.text = tsm.GetTopNames(1);
            secondName.text = tsm.GetTopNames(2);
            thirdName.text = tsm.GetTopNames(3);
            forthName.text = tsm.GetTopNames(4);
            fifthName.text = tsm.GetTopNames(5);

            firstScore.text = tsm.GetTopScores(1);
            secondScore.text = tsm.GetTopScores(2);
            thirdScore.text = tsm.GetTopScores(3);
            forthScore.text = tsm.GetTopScores(4);
            fifthScore.text = tsm.GetTopScores(5);
        }
        else
        {
            Debug.Log("No top score record");
        }
    }
}
