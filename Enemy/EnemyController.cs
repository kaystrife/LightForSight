using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius;
    public float changePathTime;
    public float chasePlayerSpeed;

    float smooth = 5.0f;
    float moveSpeed = 5.0f;
    float changePathTimeCnt;

    [SerializeField]
    float brightRadius;
    [SerializeField]
    float darkRadius;

    Transform target;
    NavMeshAgent agent;
    WeakenLight lightSource;
    Player player;
    Enemy enemy;

    float distance;


	void Start () {
    
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        changePathTimeCnt = changePathTime;
        lightSource = WeakenLight.instance;
        player = Player.instance;
        enemy = Enemy.instance;
	}
	

	void Update () {

        distance = Vector3.Distance(target.position, transform.position);
        
        if(!lightSource.isDim)
        {
            lookRadius = brightRadius;
        }else
        {
            lookRadius = darkRadius;
        }

        if(enemy.isFrozen)
        {
            Debug.Log("The Enemy is frozen");
            agent.speed = 0f;
            player.Escaped();
        }

        if(!enemy.isFrozen)
        {
            if (distance <= lookRadius)
            {
                enemy.isChasing = true;
                agent.SetDestination(target.position);
                agent.speed = chasePlayerSpeed;
                agent.stoppingDistance = 5.0f;
            }

            else if (distance > lookRadius)
            {
                enemy.isChasing = false;
                agent.speed = moveSpeed;
                changePathTimeCnt -= Time.deltaTime;

                if (changePathTimeCnt <= 0)
                {
                    MoveRandomly();
                    changePathTimeCnt = changePathTime;
                }
            }

            if (distance <= agent.stoppingDistance && !enemy.isDead)
            {
                Debug.Log("Enemy caught player");
                enemy.canAttack = true;
                player.GetCaught();
                FaceTarget();
            }
            else
            {
                player.Escaped();
                enemy.canAttack = false;
            }


            if (agent.remainingDistance > 0 && !enemy.canAttack)
            {
                enemy.isWalking = true;
            }
            else
            {
                enemy.isWalking = false;
            }

            if(GameRecord.GetPlayerDied())
            {
                enemy.canAttack = false;
                enemy.isChasing = false;
                agent.speed = moveSpeed;
                changePathTimeCnt -= Time.deltaTime;

                if (changePathTimeCnt <= 0)
                {
                    MoveRandomly();
                    changePathTimeCnt = changePathTime;
                }
            }

        }

        if (distance <= agent.stoppingDistance)
        {
            enemy.isVulnerable = true;
        }else
        {
            enemy.isVulnerable = false;
        }

    }

    //turn to player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * smooth);
    }

    //enemy moves randomly when player is not within attack range
    void MoveRandomly()
    {
        Debug.Log("New Path");
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomZ = Random.Range(-1.0f, 1.0f);
        float randomDistance = Random.Range(5.0f, 10.0f);
        float xMove = randomX * randomDistance;
        float zMove = randomZ * randomDistance;

        agent.SetDestination(new Vector3(transform.position.x + xMove, transform.position.y, transform.position.z + zMove));
        agent.speed = 5.0f;
        agent.stoppingDistance = 0;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
