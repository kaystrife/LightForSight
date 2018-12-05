using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

#region singleton
    public static Enemy instance = null;

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int HP;
    public bool isFrozen;
    public bool isChasing;
    public bool canAttack;
    public bool isDead;
    public bool isVisible;
    public bool isWalking;
    public bool isVulnerable;
    public GameObject enemyGraphic;
    public GameObject blood;
    public Animator anim;

    ActionLog action;
    WeakenLight lightSource;
    AudioSource audioSource;
    Player player;
    float frozenTimeCnt;
    Vector3 offset = new Vector3(0, 2f, 0);
    bool playChasingClip;

    private void Start()
    {
        action = ActionLog.instance;
        lightSource = WeakenLight.instance;
        player = Player.instance;

        audioSource = GetComponent<AudioSource>();

        playChasingClip = false;
        isFrozen = false;
        isChasing = false;
        canAttack = false;
        isDead = false;
        isVisible = true;
        isWalking = false;
        isVulnerable = false;
    }

    private void Update()
    {
        VisibleOrNot();

        if(isFrozen)
        {
            frozenTimeCnt -= Time.deltaTime;

            if(frozenTimeCnt <=0)
            {
                isFrozen = false;
                anim.SetBool("isFrozen", false);
                action.NewLog("The enemy is no longer frozen");
            }
        }

        if(lightSource.isDim && !isChasing && !isFrozen)
        {
            isVisible = false;
        }else
        {
            isVisible = true;
        }

        if(isChasing && !isFrozen)
        {
            if(!playChasingClip)
            {
                audioSource.loop = true;
                audioSource.Play();
                playChasingClip = true;
            }
        }else
        {
            audioSource.Stop();

            if (playChasingClip)
            {
                playChasingClip = false;
            }
        }

        PlayAnimation();

    }

    public bool ReceiveDamage(int damage)
    {
        if(isVulnerable)
        {
            HP -= damage;
            Instantiate(blood, transform.position + offset, Quaternion.Euler(Vector3.forward*90));
            AudioManager.Play("Blood");
            action.NewLog("The enemy is hurt");

            if (HP <= 0)
            {
                HP = 0;
                Die();
            }

            return true;
        }else
        {
            action.NewLog("The enemy is too far away");
            return false;
        }
    }

    void VisibleOrNot()
    {
        if(isVisible)
        {
            enemyGraphic.SetActive(true);
        }else
        {
            enemyGraphic.SetActive(false);
        }
    }

    public bool GetFrozen(float freezeTime)
    {
        if (canAttack)
        {
            isFrozen = true;
            canAttack = false;
            frozenTimeCnt = freezeTime;
            anim.SetBool("isFrozen", true);
            AudioManager.Play("Freeze");
            action.NewLog("The enemy is frozen");
            return true;
        }

        action.NewLog("The enemy is too far away");
        return false;
    }

    void Die()
    {
        isDead = true;
        canAttack = false;
        player.Escaped();
        GetComponent<EnemyController>().enabled = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isFrozen", false);
        anim.SetBool("isDead", true);

        action.NewLog("Congratulations! You've killed the enemy!");
        StartCoroutine(ToWinScene());
    }

    void PlayAnimation()
    {
        if (canAttack)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        if (isWalking && !canAttack)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    IEnumerator ToWinScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("WinScene");

    }
}
