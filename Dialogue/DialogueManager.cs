using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region singleton
    public static DialogueManager instance = null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Text dialogueText;
    public GameObject dialogueBox;
    WorldInteraction player;
    DialogueTrigger dt;

    bool havingConvo;
    bool richText;

    Queue<string> sentences;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<WorldInteraction>();
        sentences = new Queue<string>();
        //dialogueBox.SetActive(false);
        havingConvo = false;
        richText = false;

    }

    private void Update()
    {
        if(havingConvo)
        {
            if(player!=null)
            {
                player.enabled = false;
            }

            if(Input.GetMouseButtonUp(0))
            {
                AudioManager.Play("Click");
                DisplayNextSentence();
            }

        }else
        {
            if (player != null)
            {
                player.enabled = true;
            }
        }
        
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger dtSource)
    {
        Debug.Log("Starting Convo");

        dt = dtSource;

        havingConvo = true;
        richText = dialogue.isRichText;
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count ==0)
        {
            EndDialogue();
            return;
        }

        string sentenceToShow = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceToShow));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Convo");
        dt.endDialogue = true;
        havingConvo = false;
        richText = false;
        dialogueBox.SetActive(false);
    }

}
