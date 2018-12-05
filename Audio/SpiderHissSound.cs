using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpiderHissSound : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.sfxVolume;

    }
}
