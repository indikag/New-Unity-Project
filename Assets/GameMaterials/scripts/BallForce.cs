using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallForce : MonoBehaviour {

	public float thrust;
    public Rigidbody player;
    Vector3 originalPos;
    GlobalVariables globalVariables;

    public Text powerField;
    public Text scoreField;
    public Text nameField;

    private bool isUpKeyPressing = false;
    private bool isDownKeyPressing = false;

    public Canvas winingStatus;

    //Win sound
    public AudioClip winSound;
    public AudioSource winSource;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;
    private float volLowRange = .8f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody> ();
        originalPos = gameObject.transform.position;
        globalVariables = new GlobalVariables(powerField, scoreField, nameField);
        winingStatus.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        //When start the key press
        if (Input.GetKeyDown (KeyCode.Space)) {}

        //Exit the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu 3D");
        }

        //When release the key
        if (Input.GetKeyUp(KeyCode.Space)) {
            isUpKeyPressing = false;
            player.AddForce(new Vector3(0, 0, 1) * thrust * GlobalVariables.power * 10/100);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //reset
            player.transform.position = originalPos;
            player.velocity = Vector3.zero;
        }

        //Arrow keys for change the ball power
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            isUpKeyPressing = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            isUpKeyPressing = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isDownKeyPressing = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isDownKeyPressing = false;
        }

        if (isUpKeyPressing)
        {
            globalVariables.addPower();
        }

        if (isDownKeyPressing) {
            globalVariables.reducePower();
        }

    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        print("hello");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("hit the collider");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Found the collision");
        if (collision.gameObject.name == "Goal") {
            print("Hit the ball");
            globalVariables.addPoint();
            winingStatus.enabled = true;

            //play the music
            float vol = Random.Range(volLowRange, volHighRange);
            winSource.pitch = Random.Range(lowPitchRange, highPitchRange);
            winSource.PlayOneShot(winSound, vol);
        } else {
            globalVariables.reducePoint();
        }
    }
}
