using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePlayerPrefs : MonoBehaviour {

    Button button;
    
	// Use this for initialization
	void Start () {

        button = GetComponent<Button>();

        button.onClick.AddListener(DeletePrefs);
	}
	
	void DeletePrefs()
    {
        PlayerPrefs.DeleteKey("FirstScore");
        PlayerPrefs.DeleteKey("SecondScore");
        PlayerPrefs.DeleteKey("ThirdScore");
        PlayerPrefs.DeleteKey("ForthScore");
        PlayerPrefs.DeleteKey("FifthScore");

        PlayerPrefs.DeleteKey("FirstName");
        PlayerPrefs.DeleteKey("SecondName");
        PlayerPrefs.DeleteKey("ThirdName");
        PlayerPrefs.DeleteKey("ForthName");
        PlayerPrefs.DeleteKey("FifthName");

        Debug.Log("Deleted");
    }
}
