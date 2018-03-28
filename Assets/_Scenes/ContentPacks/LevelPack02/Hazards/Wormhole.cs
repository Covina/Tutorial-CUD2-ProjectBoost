using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour {


    public Transform singularityPoint;

    private float gravityForce = 4f;

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
        Debug.Log("ApplyGravitySuction()");

        player.MoveTowardsPoint(singularityPoint.transform.position, gravityForce);


    }

}
