using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)|| OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote)){
            if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger)|| OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
                SingleMicrophoneCapture mic = new SingleMicrophoneCapture();
            }
        }

        // get input data from keyboard or controller
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // update player position based on input
        Vector3 position = transform.position;
        position.x += moveHorizontal * speed * Time.deltaTime;
        position.z += moveVertical * speed * Time.deltaTime;
        transform.position = position;

    }
}
