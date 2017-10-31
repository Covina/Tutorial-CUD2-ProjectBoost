using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour {


    private float successTimeRequirement = 3.0f;

    private bool isFooterTouching = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    // detect if the player's ship has collided with it.
    private void OnCollisionEnter(Collision collision)
    {
        
        // if its the base
        if(collision.gameObject.tag == "PlayerFooting")
        {

            isFooterTouching = true;

            // start 3-second countdown to confirm success


        }
    }

    // are we no longer touching?
    private void OnCollisionExit(Collision collision)
    {
        // Continue to check
        if (collision.gameObject.tag == "PlayerFooting")
        {
            Debug.Log(collision.gameObject.name + " is no longer touching the landing pad");
            isFooterTouching = false;

        }


    }

    // Wait for some time before declaring victory
    private IEnumerator SuccessCountdown()
    {

        yield return new WaitForSeconds(successTimeRequirement);

        if(isFooterTouching)
        {
            // call success method

        }

    }

}
