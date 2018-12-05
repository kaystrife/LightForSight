using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] items;
    public float itemSpawnTime;
    public Transform floor;
    private Matrix4x4 localToWorld;

    /*Matrix4x4 localToWorld;
    MeshFilter mf;
    Vector3 offset = new Vector3(0, 2f, 0);*/

    // Use this for initialization
    void Start () {

        //mf = floor.GetComponent<MeshFilter>();
        //localToWorld = floor.localToWorldMatrix;

        InvokeRepeating("SpawnItem", 5, itemSpawnTime);
	}
	
	void SpawnItem()
    {
        int randomItem = Random.Range(0, items.Length);
        float xPos = Random.Range(-26, 26);
        float zPos = Random.Range(-31, 24);
        Vector3 randomPos = new Vector3 (xPos, 2.5f, zPos);

        //Vector3 world_v = localToWorld.MultiplyPoint3x4(mf.mesh.vertices[i]) + offset;
        Instantiate(items[randomItem], randomPos, Quaternion.Euler(Vector3.right*35));

    }
}
