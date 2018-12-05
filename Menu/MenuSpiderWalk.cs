using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MenuSpiderWalk : MonoBehaviour {

    NavMeshAgent agent;
    float changePathTime = 3.0f;
    bool canWalk;
    Animator anim;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        canWalk = true;

    }

	
	// Update is called once per frame
	void Update () {
		
        if(agent.remainingDistance <= 0 && canWalk)
        {
            StartCoroutine(MoveRandomly());
            canWalk = false;
        }

        if(agent.remainingDistance >0)
        {
            anim.SetBool("isWalking", true);
        }else
        {
            anim.SetBool("isWalking", false);
        }

	}

    IEnumerator MoveRandomly()
    {
        Debug.Log("New Path");
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomZ = Random.Range(-1.0f, 1.0f);
        float randomDistance = Random.Range(15f, 30f);
        float xMove = randomX * randomDistance;
        float zMove = randomZ * randomDistance;

        agent.SetDestination(new Vector3(transform.position.x + xMove, transform.position.y, transform.position.z + zMove));
        agent.speed = 10.0f;
        agent.stoppingDistance = 0;

        yield return new WaitForSeconds(changePathTime);

        canWalk = true;
        StopAllCoroutines();

    }
}
