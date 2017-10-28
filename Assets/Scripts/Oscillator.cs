using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {


    // controls for the oscillation distance
    [SerializeField] private Vector3 movementVector;

    // Locking the range on the slide in the inspector
    [Range(0, 1)] [SerializeField] float movementFactor;


    // Starting position of the object
    Vector3 startingPos;

	// Use this for initialization
	void Start () {

        startingPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPos + offset;

	}
}
