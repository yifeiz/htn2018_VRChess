using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static GameObject camera; 


    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("OVRCameraRig");
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.Translate(Vector3.right * (transform.position.x - camera.transform.position.x));
        camera.transform.Translate(Vector3.forward * (transform.position.z - camera.transform.position.z));
    }
}
