using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public WorldInteraction player;
    public static int tutorialLightSphereNum;
    public Animator anim;
    public AudioSource spiderHiss;

    TutorialWeakenLight lightSource;
    DialogueTrigger dt;
    bool hasGotLight;
    bool hasblinked;
    bool hasSpiderHiss;
    bool hasChangeScene;

    // Use this for initialization
    void Start () {

        tutorialLightSphereNum = 0;
        hasGotLight = false;
        hasblinked = false;
        hasSpiderHiss = false;
        lightSource = TutorialWeakenLight.instance;
        dt = GetComponent<DialogueTrigger>();


        if (dt!=null)
        {
            StartCoroutine(WaitAndStartConvo(1));
        }

    }
	
	// Update is called once per frame
	void Update () {
		
        if(TutorialConvoManager.isConvo)
        {
            player.enabled = false;
        }else
        {
            player.enabled = true;
        }

        //Game scene trigger
        if (tutorialLightSphereNum == 5)
        {
            if (!hasGotLight)
            {
                dt.TriggerDialogue();
                hasGotLight = true;
            }

            TutorialWeakenLight.canDim = false;
            lightSource.lightSource.intensity = 10f;
        }


        //Dialogue progression trigger
        if (dt.dialogueIndex==1)
        {
            if (!hasblinked)
            {
                hasblinked = true;
                StartCoroutine(Blink());
            }
        }

        if(dt.dialogueIndex == 3)
        {
            if (!hasSpiderHiss)
            {
                hasSpiderHiss = true;
                StartCoroutine(PlaySpiderHiss());
            }
        }

        if(dt.dialogueIndex==4)
        {
            if(!hasChangeScene)
            {
                hasChangeScene = true;
                StartCoroutine(WaitAndChangeScene());

            }
        }
	}

    IEnumerator WaitAndStartConvo(float time){
    
        yield return new WaitForSeconds(time);
        dt.TriggerDialogue();
        StopAllCoroutines();
    }

    IEnumerator Blink()
    {
        anim.SetBool("OpenEyes", true);
        yield return new WaitForSeconds(4);
        TutorialWeakenLight.canDim = true;
        dt.TriggerDialogue();
        StopAllCoroutines();
    }

    IEnumerator PlaySpiderHiss()
    {
        spiderHiss.Play();
        Debug.Log("Play spider hiss");
        yield return new WaitForSeconds(3);
        dt.TriggerDialogue();
        StopAllCoroutines();
    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SpiderAppearScene");

    }
}
