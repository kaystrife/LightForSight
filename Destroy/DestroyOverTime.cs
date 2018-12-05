using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float destroyTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndDestroy());
	}
	
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
