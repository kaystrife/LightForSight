using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSpiderAppear : MonoBehaviour {

    public Transform pos;
    Animator anim;
    float moveSpeed = 8.0f;
    DialogueTrigger dt;

    bool hasChangeScene;
    bool hasAppeared;

    private void Start()
    {
        anim = GetComponent<Animator>();
        dt = GetComponent<DialogueTrigger>();

        hasAppeared = false;
        hasChangeScene = false;
    }

    // Update is called once per frame
    void Update () {

        transform.position = Vector3.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);

        if(transform.position == pos.position)
        {
            if(!hasAppeared)
            {
                hasAppeared = true;
                anim.SetBool("Arrived", true);
                dt.TriggerDialogue();
            }
        }

        if(dt.dialogueIndex==1)
        {
            if(!hasChangeScene)
            {
                hasChangeScene = true;
                StartCoroutine(WaitAndChangeScene());
            }
        }
	}

    IEnumerator WaitAndChangeScene()
    {
        //GameRecord.gameStarted = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoadingScene");
    }
}
