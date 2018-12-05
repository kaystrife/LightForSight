using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	
	void Start () {

        StartCoroutine(ChangeScene());
	}
	
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("GameScene");
    }
}
