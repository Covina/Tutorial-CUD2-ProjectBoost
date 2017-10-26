using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

            print("Thrusting");

        }


        // check for left tilt
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate toward left
            print("Left Arrow Pressed");

        } else if (Input.GetKey(KeyCode.RightArrow))
        {

            // Rotate toward right
            print("Right Arrow Pressed");

        }



    }

}
