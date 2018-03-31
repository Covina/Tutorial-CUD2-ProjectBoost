using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour {


    public Transform singularityPoint;

    private float gravityForce = 60f;

    private bool isWithinRange = false;

    private Rocket player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Rocket>();

	}
	

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            //Debug.Log("Player entered wormhole gravity");

            isWithinRange = true;
            ApplyGravitySuction();

        }



    }


    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log("Player still inside wormhole gravity");

            isWithinRange = true;
            ApplyGravitySuction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isWithinRange = false;
        }
    }


    private void ApplyGravitySuction()
    {

        if(isWithinRange)
        {
            //Debug.Log("ApplyGravitySuction()");

            // increase g-force when closer
            float distanceFromSingularity = Vector3.Distance(singularityPoint.transform.position, player.transform.position);

            float realGravityForce = gravityForce * ( 1 / distanceFromSingularity);

            // Apply the calculated force
            player.MoveTowardsPoint(singularityPoint.transform.position, realGravityForce);
        }




    }

}
