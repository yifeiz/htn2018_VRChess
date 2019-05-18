using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class PlayerController : MonoBehaviour {
    public int speed = 0;
    private int minFreq;
    private int maxFreq;
    private AudioSource goAudioSource;
    private AudioClip clip;
    private AudioClip _audioClip;
    private SpeechToText _speechToText;


    // private boolean firstPressed = false, firstReleased = false,secondPressed = false, secondReleased = true;

    // private double timeSinceStart = 0;

    // Use this for initialization
    void Start()
    {

        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
        goAudioSource = GetComponent<AudioSource>();

        _speechToText = new SpeechToText(new Credentials("334f8ed4-4f4a-4b78-a211-765d9174e94a", "RimNDl2eS8ZZ", "https://stream.watsonplatform.net/speech-to-text/api"));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")) //OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
        {
            Debug.Log("udashaas");
            StartCoroutine(Test());

        }

        // get input data from keyboard or controller
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        // update player position based on input
        // Vector3 position = transform.position;
        // position.x += moveHorizontal * speed * Time.deltaTime;
        // position.z += moveVertical * speed * Time.deltaTime;
        // transform.position = position;

    }

    public AudioClip getAudio()
    {
        return this.clip;
    }

    IEnumerator Test()
    {
        AudioSource aud = GetComponent<AudioSource>();
        Debug.Log("1");
        aud.clip = Microphone.Start(null, false, 4, 44100);
        Debug.Log("2");

        yield return new WaitForSeconds(3);

        Microphone.End(null);
        clip = aud.clip;
        //aud.Play();
        Recognize();
        Debug.Log("3");
    }

    private void Recognize()
    {
        //  create AudioClip with clip bytearray data
        _audioClip = clip;

        _speechToText.Keywords = new string[]{ "E1", "E2", "E3", "E4", "E5" };
        _speechToText.KeywordsThreshold = 0.3f;
        if (!_speechToText.Recognize(HandleRecognize, OnFail,_audioClip))
            Debug.Log("ExampleSpeechToText.Recognize() Failed to recognize!");
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object> customData){
        Debug.Log("!" + error);
        Debug.Log("!" + customData);
        Debug.Log("NaNi");
    }

    private void HandleRecognize(SpeechRecognitionEvent result, Dictionary<string, object> customData)
    {
        Debug.Log("ExampleSpeechToText.HandleRecognize() Speech to Text - Get model response: " + customData["json"].ToString());

    }

}
