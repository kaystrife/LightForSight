using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour {

    Slider slider;

    // Use this for initialization
    void Start()
    {

        slider = GetComponent<Slider>();
        slider.value = AudioManager.sfxVolume;

    }

    // Update is called once per frame
    void Update()
    {

        AudioManager.changeSFXVolume(slider.value);
    }
}
