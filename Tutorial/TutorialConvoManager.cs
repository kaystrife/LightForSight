using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialConvoManager : MonoBehaviour {

    public Text convoText;
    public GameObject convoBox;
    public Animator anim;

    public static bool isConvo;

    [SerializeField]
    [TextArea]
    string[] convo;
    static int convoIndex;

	// Use this for initialization
	void Start () {

        convoIndex = 0;
        convoText.text = "";
        isConvo = false;

        StartCoroutine(StartConvo());
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(convoIndex);

        if(convoIndex==11)
        {
            StartCoroutine(ChangeScene());
        }

        if(isConvo)
        {
            if (convoIndex >= convo.Length)
            {
                isConvo = false;
                convoBox.SetActive(false);
                return;
                //this.enabled = false;
            }else
            {
                convoBox.SetActive(true);
                convoText.text = convo[convoIndex];
            }

            if (Input.GetMouseButtonUp(0))
            {
                AudioManager.Play("Click");
                convoIndex++;

                if (CheckConvoProgress())
                {
                    if (convoIndex >= convo.Length)
                    {
                        return;
                    }
                    convoText.text = convo[convoIndex];
                }
            }
        }
	}

    IEnumerator StartConvo()
    {
        yield return new WaitForSeconds(1);
        convoBox.SetActive(true);
        isConvo = true;
        yield return new WaitForSeconds(1);

    }

    bool CheckConvoProgress()
    {
        switch (convoIndex)
        {
            case (2):
                isConvo = false;
                convoBox.SetActive(false);
                StartCoroutine(WaitAndStartConvoAgain(4));
                anim.SetBool("openEyes", true);
                TutorialWeakenLight.canDim = true;
                return false;
            case (7):
                isConvo = false;
                convoBox.SetActive(false);
                return false;
            case(10):
                AudioManager.Play("SpiderHiss");
                return false;

        }

        return true;
    }

    IEnumerator WaitAndStartConvoAgain(float time)
    {
        yield return new WaitForSeconds(time);
        isConvo = true;

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        //change scene
        Debug.Log("Change scene");
    }

    public static void TurnOnConvo()
    {
        isConvo = true;
        Debug.Log("Turn on convo");
    }
}
