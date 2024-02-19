using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingSystem : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = 40;
        }
        else
        {
            cam.fieldOfView = 60;
        }
    }
}
