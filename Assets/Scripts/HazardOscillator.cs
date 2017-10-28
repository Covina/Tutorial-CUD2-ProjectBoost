using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardOscillator : MonoBehaviour {

    // controls for the oscillation distance
    [SerializeField] private Vector3 movementVector = new Vector3(10f, 10f, 10f);

    // length of SIN wave until it repeats
    [SerializeField] float period = 2f;

    // How far it should move
    private float movementFactor;

    // Starting position of the hazard object
    private Vector3 startingPos;

    // Use this for initialization
    void Start()
    {

        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Gaurd against zero Period
        if(period <= Mathf.Epsilon) { return; }

        // set movement factor
        float cycles = Time.time / period;  // grows continually from zero

        const float tau = Mathf.PI * 2;     // Tau is 2 x PI

        // generate sine value
        float rawSinWave = Mathf.Sin(cycles * tau);
        

        // reduce amplitude to go between 0.5 / -0,5
        // normalize it to 0,1 by shifting up by 1/2
        movementFactor = (rawSinWave / 2f) + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        //print(offset);

        transform.position = startingPos + offset;

    }
}
