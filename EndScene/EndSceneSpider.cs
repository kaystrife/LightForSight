using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneSpider : MonoBehaviour {

    public AudioClip cry;
    public bool canCry;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        canCry = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(canCry)
        {
            audioSource.PlayOneShot(cry);
            canCry = false;
        }

	}
}
