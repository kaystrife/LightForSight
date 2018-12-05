using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRecord : MonoBehaviour {

#region Don't Destroy On Load
    public static bool created;

    private void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public static bool gameStarted;
    static int lightSphereNum;
    static bool isHit;
    static float timeLapse;
    static bool playerDied;

    public static bool hasNewItem;
    public static bool hasIceStone;
    public static bool hasSpeedUpPotion;
    public static bool hasApple;
    public static bool hasAxe;
    public static bool hasStone;
    public static bool usedIceStone;
    public static bool usedSpeedUp;
    public static bool usedApple;

    // Use this for initialization
    void Start () {

        gameStarted = false;
        lightSphereNum = 0;
        timeLapse = 0;
        isHit = false;
        playerDied = false;

        hasNewItem = false;
        hasApple = false;
        hasIceStone = false;
        hasSpeedUpPotion = false;
        hasAxe = false;
        hasStone = false;
        usedApple = false;
        usedIceStone = false;
        usedSpeedUp = false;

    }
	
	// Update is called once per frame
	void Update () {

        if(!gameStarted)
        {
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                Debug.Log("Start Game");
                gameStarted = true;
            }
        }else
        {
            timeLapse += Time.deltaTime;
        }

	}

    //////////Set data
    public static void SetLightSphere()
    {
        lightSphereNum++;
    }

    public static void SetIsHit(){

        isHit = true;
    }

    public static void SetPlayerDied()
    {
        playerDied = true;
    }

    ///////////Get data
    public static bool GetIsHit()
    {
        return isHit;
    }

    public static int GetLightSphereNum()
    {
        return lightSphereNum;
    }

    public static float GetCompleteTime()
    {
        return timeLapse;
    }

    public static bool GetPlayerDied()
    {
        return playerDied;
    }

    public static void ResetGameRecord()
    {
        gameStarted = false;
        lightSphereNum = 0;
        timeLapse = 0;
        isHit = false;
        playerDied = false;

        hasNewItem = false;
        hasApple = false;
        hasIceStone = false;
        hasSpeedUpPotion = false;
        hasAxe = false;
        hasStone = false;
        usedApple = false;
        usedIceStone = false;
        usedSpeedUp = false;
    }

}
