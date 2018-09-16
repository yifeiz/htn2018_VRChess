using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePawn : MonoBehaviour {

    public void MoveYoAss ()
    {
        transform.Translate(Vector3.up * 4);
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
 
    }
}
