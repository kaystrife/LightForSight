using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeScene());
	}
	
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MenuScene");
    }
}
