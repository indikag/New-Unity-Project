using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour {

    public AudioClip crashSoft;

    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;
    private float volLowRange = .8f;
    private float volHighRange = 1.0f;

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.pitch = Random.Range(lowPitchRange, highPitchRange);
            source.PlayOneShot(crashSoft, vol);
        }

    }
}
