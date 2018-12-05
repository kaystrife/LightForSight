using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue[] dialogues;
    public int dialogueIndex;
    public bool endDialogue;
    DialogueManager dm;

    private void Start()
    {
        dialogueIndex = 0;
        endDialogue = false;
        dm = DialogueManager.instance;
    }

    void Update()
    {
        if(endDialogue)
        {
            dialogueIndex++;
            endDialogue = false;
        }
    }

    public void TriggerDialogue()
    {
        if(dialogueIndex < dialogues.Length)
        {
            dm.StartDialogue(dialogues[dialogueIndex], this);
        }
    }
}
