using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    // The Rocket Ship
    private Rigidbody rigidBody;

    // to play the thrust sound
    private AudioSource audioSource;

    // how fast it should rotate
    private float rotationSpeed = 20.0f;


	// Use this for initialization
	void Start () {

        // Get reference to the component
        rigidBody = GetComponent<Rigidbody>();

        // Get reference to the audio source component
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        //
        ProcessInput();


	}


    // Look for keyboard input
    private void ProcessInput()
    {

        // check for thrust
        if(Input.GetKey(KeyCode.Space))
        {

            // Add force only in the direction of where its pointing (rotation)
            // Vector3.up = (0,1,0)  in the Y Axis
            rigidBody.AddRelativeForce(Vector3.up);

            // check if its already playing, and if not, play it
            if(audioSource.isPlaying == false) {

                audioSource.Play();

            }

        } else
        {
            // player is not thrusting, end sound
            audioSource.Stop();


        }

        // check for left tilt
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);


        } else if (Input.GetKey(KeyCode.RightArrow))
        {


            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);


        }



    }

}
