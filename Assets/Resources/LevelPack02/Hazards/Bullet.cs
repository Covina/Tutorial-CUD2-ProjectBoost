using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

     
    [SerializeField] private float timeToLive = 3.0f;

    // Track Time since spawned
    private float timeElapsed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        timeElapsed += Time.deltaTime;

        // check if its expired
        if(timeElapsed >= timeToLive)
        {
            Destroy(gameObject);
        }
    }

    // If we hit something, destroy the bullet
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
