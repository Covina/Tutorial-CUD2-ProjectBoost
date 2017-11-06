using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    private Vector3 cameraPosition;

    private float minXClampPos = 0.0f;
    private float maxXClampPos = 0.0f;

    private float minYClampPos = 0.0f;
    private float maxYClampPos = 0.0f;


    private Rocket playerRocket;

    private float cameraRocketClampOffsetX = 30.0f;
    private float cameraRocketClampOffsetY = 10.0f;

    private float cameraYAxisOffset = 10.0f;

    // Use this for initialization
    void Start () {

        // get stating position
        cameraPosition = gameObject.transform.position;

        // get player rocket
        playerRocket = GameObject.FindObjectOfType<Rocket>();

        // Set all the mins and maxes for clamping camera
        SetCameraPositionClamps();


    }
	
	// Update is called once per frame
	void Update () {

        // if player is alive, move the camera
        if(playerRocket.state == Rocket.State.Alive)
        {

            cameraPosition = new Vector3(
                                    Mathf.Clamp(playerRocket.transform.position.x, minXClampPos, maxXClampPos),
                                    Mathf.Clamp(playerRocket.transform.position.y + cameraYAxisOffset, minYClampPos, maxYClampPos),
                                    cameraPosition.z
                                    );

            gameObject.transform.position = cameraPosition;

        }
		
	}

    private void SetCameraPositionClamps()
    {

        // get all hazard objects
        GameObject[] hazardArray = GameObject.FindGameObjectsWithTag("Hazard");

        //Debug.Log("Hazard objects found: " + hazardArray.Length);

        // loop through for Min and Max X and Y Values
        foreach(var hazard in hazardArray)
        {

            minXClampPos = (hazard.transform.position.x < minXClampPos) ? hazard.transform.position.x : minXClampPos;
            maxXClampPos = (hazard.transform.position.x > maxXClampPos) ? hazard.transform.position.x : maxXClampPos;

            minYClampPos = (hazard.transform.position.y < minYClampPos) ? hazard.transform.position.y : minYClampPos;
            maxYClampPos = (hazard.transform.position.y > maxYClampPos) ? hazard.transform.position.y : maxYClampPos;

        }

        // adjust
        
        minXClampPos += cameraRocketClampOffsetX;
        minYClampPos += cameraRocketClampOffsetY;

        maxXClampPos -= cameraRocketClampOffsetX;
        maxYClampPos -= cameraRocketClampOffsetY;
        

        // if the celing is low, don't use the large clamp.
        if(minYClampPos - maxYClampPos <= cameraRocketClampOffsetY)
        {

            //Debug.Log("Celing too Small");

            //maxYClampPos = maxYClampPos + cameraRocketClampOffsetY;

        }

        //Debug.Log("Mins: " + minXClampPos + ", " + minYClampPos + "; Maxes: " + maxXClampPos + ", " + maxYClampPos);



    }

}
