using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    #region Don't Destroy On Load
    private static bool created = false;
    public static BGM instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance!=this)
        {
            Destroy(gameObject);
        }

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }

        else
            Destroy(gameObject);
    }
    #endregion

    AudioSource audioSources;
    public static float bgmVolume = 1.0f;

    private void Start()
    {
        audioSources = GetComponent<AudioSource>();
    }

    public void ChangeBGMVolume(float volume)
    {
        audioSources.volume = volume;
    }

}
