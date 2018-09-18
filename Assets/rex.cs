using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rex : MonoBehaviour {
    int minfreq, maxfreq;
    AudioSource AS;

    // Use this for initialization
    void Start () {
        StartCoroutine(Test());
    }

    IEnumerator Test() {
        AudioSource aud = GetComponent<AudioSource>();
        Debug.Log("1");
        aud.clip = Microphone.Start(null, false, 300, 44100);
        Debug.Log("2");

        yield return new WaitForSeconds(5);

        Microphone.End(null);
        aud.Play();
        Debug.Log("3");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
