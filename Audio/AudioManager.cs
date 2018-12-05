using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

#region Don't Destroy On Load
    private static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }

        else
            Destroy(gameObject);
    }
    #endregion

    public static AudioClip blood, click, digRock, eatApple, freeze, glassBreak, rockExplode, speedUp, spiderFall, spiderHiss, spiderSqueak;
    static AudioSource audioSource;
    public static float sfxVolume;
    

	void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();

        blood = Resources.Load<AudioClip>("Blood");
        click = Resources.Load<AudioClip>("Click");
        digRock = Resources.Load<AudioClip>("DigRock");
        eatApple = Resources.Load<AudioClip>("EatApple");
        freeze = Resources.Load<AudioClip>("Freeze");
        glassBreak = Resources.Load<AudioClip>("GlassBreak");
        rockExplode = Resources.Load<AudioClip>("RockExplode");
        speedUp = Resources.Load<AudioClip>("SpeedUp");
        spiderFall = Resources.Load<AudioClip>("SpiderFall");
        spiderHiss = Resources.Load<AudioClip>("SpiderHiss");
        spiderSqueak = Resources.Load<AudioClip>("SpiderSqueak");

        sfxVolume = 1.0f;
    }

    public static void changeSFXVolume(float volume)
    {
        sfxVolume = volume;
    }

    public static void Play (string clip)
    {
        audioSource.volume = sfxVolume;

        switch(clip)
        {
            case "Blood":
                audioSource.PlayOneShot(blood);
                break;
            case "Click":
                audioSource.PlayOneShot(click);
                break;
            case "DigRock":
                audioSource.volume = 0.3f;
                audioSource.PlayOneShot(digRock);
                break;
            case "EatApple":
                audioSource.PlayOneShot(eatApple);
                break;
            case "Freeze":
                audioSource.PlayOneShot(freeze);
                break;
            case "GlassBreak":
                audioSource.PlayOneShot(glassBreak);
                break;
            case "RockExplode":
                audioSource.PlayOneShot(rockExplode);
                break;
            case "SpeedUp":
                audioSource.PlayOneShot(speedUp);
                break;
            case "SpiderFall":
                audioSource.PlayOneShot(spiderFall);
                break;
            case "SpiderHiss":
                audioSource.PlayOneShot(spiderHiss);
                break;
            case "SpiderSqueak":
                audioSource.volume = 1.0f;
                audioSource.PlayOneShot(spiderSqueak);
                break;
        }
    }
	
}
