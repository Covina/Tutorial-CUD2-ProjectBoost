using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Store current camera position
    private Vector3 cameraPosition;

    // Camera Boundaries
    private float minXClampPos = 0.0f;  // LEFT
    private float maxXClampPos = 0.0f;  // RIGHT
    private float minYClampPos = 0.0f;  // BOTTOM
    private float maxYClampPos = 0.0f;  // TOP

    // Camera Boarders Offset from Boundaries
    private float cameraClampOffsetX = 30.0f;
    private float cameraClampOffsetY = 10.0f;

    // Default Vertical Rise 
    private float cameraYAxisOffset = 15.0f;

    private Rocket playerRocket;

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

        // Get all Boundary objects
        GameObject[] boundaryMarkers = GameObject.FindGameObjectsWithTag("BoundaryMarker");

        // loop through for Min and Max X and Y Values
        foreach (var marker in boundaryMarkers)
        {
            // LEFT
            minXClampPos = (marker.transform.position.x < minXClampPos) ? marker.transform.position.x : minXClampPos;

            // RIGHT
            maxXClampPos = (marker.transform.position.x > maxXClampPos) ? marker.transform.position.x : maxXClampPos;

            // BOTTOM
            minYClampPos = (marker.transform.position.y < minYClampPos) ? marker.transform.position.y : minYClampPos;

            // TOP
            maxYClampPos = (marker.transform.position.y > maxYClampPos) ? marker.transform.position.y : maxYClampPos;

        }

        // Set initial clamp positions
        minXClampPos += cameraClampOffsetX; // LEFT
        maxXClampPos -= cameraClampOffsetX; // RIGHT
        maxYClampPos -= cameraClampOffsetY; // TOP

        //Debug.Log("minXClampPos: " + minXClampPos);
        //Debug.Log("maxXClampPos: " + maxXClampPos);
        //Debug.Log("minYClampPos: " + minYClampPos);
        //Debug.Log("maxYClampPos: " + maxYClampPos);

    }

}
