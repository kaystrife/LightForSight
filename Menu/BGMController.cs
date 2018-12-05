using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMController : MonoBehaviour {

    Slider slider;
    BGM bgm1;
    BGM2 bgm2;


	// Use this for initialization
	void Start () {

        slider = GetComponent<Slider>();
        bgm1 = BGM.instance;
        bgm2 = BGM2.instance;

        slider.value = bgm1.GetComponent<AudioSource>().volume;

	}
	
	// Update is called once per frame
	void Update () {

        bgm1.ChangeBGMVolume(slider.value);
        bgm2.ChangeBGMVolume(slider.value);
    }
}
