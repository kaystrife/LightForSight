using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public float sensitivity;

    public float minAngle = -360F;
    public float maxAngle = 360F;

    float rotationAngle = 0F;

    void Update()
    {
        //right click and drag to change camera angle along the x axis
        if (Input.GetMouseButton(1))
        {
            rotationAngle += Input.GetAxis("Mouse X") * 0.3f * sensitivity;
            transform.localEulerAngles = new Vector3(0, rotationAngle, 0);
        }
    }
}

