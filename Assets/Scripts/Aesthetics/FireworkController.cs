using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkController : MonoBehaviour
{
    // Starts the fireworks show
    public void Play()
    {
        ParticleSystem fireworks = gameObject.GetComponent<ParticleSystem>();
        fireworks.Play();
    }


    // Ends the fireworks show
    public void Stop()
    {
        ParticleSystem fireworks = gameObject.GetComponent<ParticleSystem>();
        fireworks.Stop();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
