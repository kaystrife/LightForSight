using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSphereSpawner : MonoBehaviour {

    public GameObject spawnObject;
    public Transform floor;
    public static bool canSpawn;

    Matrix4x4 localToWorld;
    MeshFilter mf;
    Vector3 offset = new Vector3(0, 1.5f, 0);

	void Start () {

        canSpawn = true;
        mf = floor.GetComponent<MeshFilter>();
        localToWorld = floor.localToWorldMatrix;

	}
	
    void Update()
    {
        if(canSpawn)
        {
            int i = Random.Range(0, mf.mesh.vertices.Length);

            Vector3 world_v = localToWorld.MultiplyPoint3x4(mf.mesh.vertices[i]) + offset;
            Instantiate(spawnObject, world_v, Quaternion.Euler(Vector3.zero));
            canSpawn = false;
        }
    }
}
