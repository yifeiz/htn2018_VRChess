using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var theta = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var x = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        transform.Rotate(0, theta, 0);
        transform.Translate(0, 0, x);
    }
}