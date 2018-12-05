using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScoreManager : MonoBehaviour {

    #region singleton
    public static TopScoreManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    TopScores topScores;
    public int thisRank;

	// Use this for initialization
	void Start () {

        LoadHighScores();
        thisRank = 0;
    }
	
    public int SubmitScores(int newScore)
    {
        if(!PlayerPrefs.HasKey("FirstScore"))
        {
            Debug.Log("New record");
            topScores.first = newScore;
            SaveHighScores();
            return 1;
        }else
        {
            int rank = CompareScores(newScore);
            Debug.Log(rank);
            return rank;
        }
    }

    public void SubmitName(string newName)
    {
        switch(thisRank)
        {
            case 1:
                topScores.fifthName = topScores.forthName;
                topScores.forthName = topScores.thirdName;
                topScores.thirdName = topScores.secondName;
                topScores.secondName = topScores.firstName;
                topScores.firstName = newName;
                break;
            case 2:
                topScores.fifthName = topScores.forthName;
                topScores.forthName = topScores.thirdName;
                topScores.thirdName = topScores.secondName;
                topScores.secondName = newName;
                break;
            case 3:
                topScores.fifthName = topScores.forthName;
                topScores.forthName = topScores.thirdName;
                topScores.thirdName = newName;
                break;
            case 4:
                topScores.fifthName = topScores.forthName;
                topScores.forthName = newName;
                break;
            case 5:
                topScores.fifthName = newName;
                break;
            default:
                break;
        }

        SaveNames();
    }

    int CompareScores(int newScore)
    {
        //new rank 1
        if(newScore >= topScores.first)
        {
            topScores.fifth = topScores.forth;
            topScores.forth = topScores.third;
            topScores.third = topScores.second;
            topScores.second = topScores.first;
            topScores.first = newScore;

            SaveHighScores();
            return 1;

        }
        //new rank 2
        else if(newScore < topScores.first && newScore>= topScores.second)
        {
            topScores.fifth = topScores.forth;
            topScores.forth = topScores.third;
            topScores.third = topScores.second;
            topScores.second = newScore;

            SaveHighScores();
            return 2;
        }
        //new rank 3
        else if(newScore < topScores.second && newScore >= topScores.third)
        {
            topScores.fifth = topScores.forth;
            topScores.forth = topScores.third;
            topScores.third = newScore;

            SaveHighScores();
            return 3;
        }
        //new rank 4
        else if (newScore < topScores.third && newScore >= topScores.forth)
        {
            topScores.fifth = topScores.forth;
            topScores.forth = newScore;

            SaveHighScores();
            return 4;
        }
        //new rank 5
        else if (newScore < topScores.forth && newScore >= topScores.fifth)
        {
            topScores.fifth = newScore;

            SaveHighScores();
            return 5;
        }

        return 0;
    }
   

    void LoadHighScores()
    {
        topScores = new TopScores();

        if (PlayerPrefs.HasKey("FirstScore"))
        {
            topScores.first = PlayerPrefs.GetInt("FirstScore");
            topScores.second = PlayerPrefs.GetInt("SecondScore");
            topScores.third = PlayerPrefs.GetInt("ThirdScore");
            topScores.forth = PlayerPrefs.GetInt("ForthScore");
            topScores.fifth = PlayerPrefs.GetInt("FifthScore");

            topScores.firstName = PlayerPrefs.GetString("FirstName");
            topScores.secondName = PlayerPrefs.GetString("SecondName");
            topScores.thirdName = PlayerPrefs.GetString("ThirdName");
            topScores.forthName = PlayerPrefs.GetString("ForthName");
            topScores.fifthName = PlayerPrefs.GetString("FifthName");
        }
    }

    void SaveHighScores()
    {
        PlayerPrefs.SetInt("FirstScore", topScores.first);
        PlayerPrefs.SetInt("SecondScore", topScores.second);
        PlayerPrefs.SetInt("ThirdScore", topScores.third);
        PlayerPrefs.SetInt("ForthScore", topScores.forth);
        PlayerPrefs.SetInt("FifthScore", topScores.fifth);
    }

    void SaveNames()
    {
        PlayerPrefs.SetString("FirstName", topScores.firstName);
        PlayerPrefs.SetString("SecondName", topScores.secondName);
        PlayerPrefs.SetString("ThirdName", topScores.thirdName);
        PlayerPrefs.SetString("ForthName", topScores.forthName);
        PlayerPrefs.SetString("FifthName", topScores.fifthName);
    }

    public string GetTopScores(int rank)
    {
        switch (rank)
        {
            case 1:
                return topScores.first.ToString();
            case 2:
                return topScores.second.ToString();
            case 3:
                return topScores.third.ToString();
            case 4:
                return topScores.forth.ToString();
            case 5:
                return topScores.fifth.ToString();
        }

        return "0";
    }

    public string GetTopNames(int rank)
    {
        switch (rank)
        {
            case 1:
                return topScores.firstName;
            case 2:
                return topScores.secondName;
            case 3:
                return topScores.thirdName;
            case 4:
                return topScores.forthName;
            case 5:
                return topScores.fifthName;
            default:
                return "N/A";
        }
    }
}
