using UnityEngine;
using UnityEngine.UI;


public class TutorialWeakenLight : MonoBehaviour {

    public static TutorialWeakenLight instance = null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        else if(instance !=this)
        {
            Destroy(gameObject);
        }
    }

    public Light lightSource;
    public Slider slider;

    public static bool canDim;

	// Use this for initialization
	void Start () {

        canDim = false;
        lightSource = GetComponent<Light>();

        if(lightSource!=null)
        {
            lightSource.intensity = 5;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(canDim)
        {
            lightSource.intensity -= Time.deltaTime * 0.2f;
        }

        if(lightSource.intensity < 1.5f)
        {
            lightSource.intensity = 1.5f;
        }

        if(lightSource.intensity> 10)
        {
            lightSource.intensity = 10;
        }

        slider.value = lightSource.intensity;
	}
}
