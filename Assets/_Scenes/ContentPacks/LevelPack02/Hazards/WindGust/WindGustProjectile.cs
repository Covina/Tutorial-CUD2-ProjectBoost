using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGustProjectile : MonoBehaviour {

    public Vector3 forceVector;

    private Rocket player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Rocket>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// Player and Wind collide
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
           // Debug.Log("WingGust hit Player");

            player.AddConstantForce(forceVector);


        }

    }

}
