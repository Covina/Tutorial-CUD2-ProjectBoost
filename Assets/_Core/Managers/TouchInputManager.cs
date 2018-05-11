using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchInputManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler  {

	private Rocket rocket;

	void Start()
	{
		// Get reference to the player rocket
		rocket = GameObject.FindObjectOfType<Rocket>();

	}


    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            // Apply thrust
            rocket.IsThrusting = true;

        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            // Stop thrust
            rocket.IsThrusting = false;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rocket.IsRotatingLeft = true;

        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rocket.IsRotatingLeft = false;
        }


        if(Input.GetKey(KeyCode.RightArrow))
        {
            rocket.IsRotatingRight = true;

        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rocket.IsRotatingRight = false;
        }

    }


    // built in to detect on press
    public void OnPointerDown(PointerEventData eventData)
    {

        // Don't proceed if player is dead
        if(rocket.state != Rocket.State.Alive) { return;  }


        // Check tag
        if (gameObject.tag == "UI_Thrust")
        {
            // Apply thrust
            rocket.IsThrusting = true;
        }

        if (gameObject.tag == "UI_TurnLeft")
        {
            // Rotate Left
			rocket.IsRotatingLeft = true;
        
        }
        else if (gameObject.tag == "UI_TurnRight")
        {
            // Rotate Right
			rocket.IsRotatingRight = true;

        }

    }



    // built in to detect on release
    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.name == "ThrustButton")
        {
            // Apply thrust
			rocket.IsThrusting = false;
        }


        if (gameObject.name == "ButtonRotateLeft")
        {
            // Rotate Left
			rocket.IsRotatingLeft = false;

        }
        else if (gameObject.name == "ButtonRotateRight")
        {
            // Rotate Right
			rocket.IsRotatingRight = false;

        }
    }
}
