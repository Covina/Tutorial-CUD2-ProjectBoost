using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour {


    public Transform singularityPoint;

    private float gravityForce = 50f;

    private bool isWithinRange = false;

    private Rocket player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Rocket>();

	}
	
	// Update is called once per frame
	void Update () {
		

	}


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered wormhole gravity");

        isWithinRange = true;
        ApplyGravitySuction();
        

    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Player still inside wormhole gravity");

        isWithinRange = true;
        ApplyGravitySuction();
    }

    private void OnTriggerExit(Collider other)
    {
        isWithinRange = false;
    }


    private void ApplyGravitySuction()
    {

        if(isWithinRange)
        {
            Debug.Log("ApplyGravitySuction()");

            // increase g-force when closer
            float distanceFromSingularity = Vector3.Distance(singularityPoint.transform.position, player.transform.position);

            float realGravityForce = gravityForce * ( 1 / distanceFromSingularity);

            // Apply the calculated force
            player.MoveTowardsPoint(singularityPoint.transform.position, realGravityForce);
        }




    }

}
