using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    #region singleton
    public static Player instance = null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    float speedUpTimeCnt;
    bool isCaught;
    bool isSpeedUp;
    //public bool canChop;
    public PlayerStat playerStat;
    //public Animator anim;
    ActionLog action;

    WeakenLight lightSource;


	void Start () {

        playerStat = new PlayerStat();
        isCaught = false;
        isSpeedUp = false;
        //canChop = false;
        action = ActionLog.instance;
        lightSource = WeakenLight.instance;
	}
	
	void Update () {
		
        if(GameRecord.gameStarted)
        {
            if (!isSpeedUp)
            {
                playerStat.moveSpeed = 8.0f;
            }
            else
            {
                speedUpTimeCnt -= Time.deltaTime;
                if (speedUpTimeCnt <= 0)
                {
                    isSpeedUp = false;
                    action.NewLog("Your speed returns back to normal");
                }
            }

            //player's HP will decrease when being attacked by enemy or when the light is too dim
            if (isCaught)
            {
                playerStat.currentHP -= Time.deltaTime;
            }

            if (lightSource.isDim)
            {
                playerStat.currentHP -= Time.deltaTime * 0.5f;
            }

            if (playerStat.currentHP <= 0)
            {
                playerStat.currentHP = 0;
                GameRecord.SetPlayerDied();
             
                GetComponent<WorldInteraction>().enabled = false;
                
                Destroy(GetComponent<NavMeshAgent>());
                
            }

            if(playerStat.currentHP < 19f)
            {
                if (!GameRecord.GetIsHit())
                {
                    GameRecord.SetIsHit();
                    //action.NewLog("Is hit is false");
                }
            }
        }
  
	}


    public void GetCaught()
    {
        Debug.Log("Is Caught");
        isCaught = true;
    }

    public void RecoverHP(int HP)
    {
        playerStat.currentHP += HP;
        action.NewLog("You recovered some HP");

        if (playerStat.currentHP > playerStat.maxHP)
        {
            playerStat.currentHP = playerStat.maxHP;
        }
    }

    public void SpeedUp(float time, float speed)
    {
        isSpeedUp = true;
        speedUpTimeCnt = time;
        playerStat.moveSpeed = speed;
        action.NewLog("Your speed increased");
    }

    public void Escaped()
    {
        isCaught = false;
    }

}
