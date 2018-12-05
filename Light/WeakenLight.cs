using UnityEngine;
using UnityEngine.UI;

public class WeakenLight : MonoBehaviour {

    #region singleton
    public static WeakenLight instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance !=this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    Light lightSource;
    public float lightIntensity;
    public Slider slider;
    public bool isDim;
    bool hasWarnedPlayer;
    ActionLog action;

    [SerializeField]
    float weakenRate;

	void Start () {

        lightSource = GetComponent<Light>();
        action = ActionLog.instance;

        isDim = false;
        hasWarnedPlayer = false;

        if (lightSource!=null)
        {
            lightSource.intensity = 10f;
            lightIntensity = lightSource.intensity;
        }
	}
	

	void Update () {

        //light intensity decrease with time
        if (lightIntensity >= 1.5f)
        {
            lightSource.intensity -= Time.deltaTime * weakenRate;
            lightIntensity = lightSource.intensity;

            if(lightIntensity >= 4.5f)
            {
                if(isDim)
                {
                    isDim = false;
                    hasWarnedPlayer = false;
                }
            }
        }

        if(lightIntensity >10f)
        {
            lightSource.intensity = 10f;
            lightIntensity = lightSource.intensity;
        }

        if(lightIntensity< 4.5f)
        {
            isDim = true;

            if(!hasWarnedPlayer)
            {
                action.NewLog("The light is getting dim...");
                hasWarnedPlayer = true;
            }
        }

        slider.value = lightIntensity;

	}

    public void IncreaseLight(float light)
    {
        action.NewLog("The cave becomes slightly brighter");
        lightSource.intensity += light;
        lightIntensity = lightSource.intensity;
    }
}
