using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGust : MonoBehaviour {

    [SerializeField] private float timeToLive = 10.0f;

    // Track Time since spawned
    private float timeElapsed;

    // Length of time the wind will effect the player after contact
    //private float effectDuration = 0.25f;

    // has the wind made conctact with the player?
    private bool isEffecting = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeElapsed += Time.deltaTime;

        // check if its expired
        if (timeElapsed >= timeToLive)
        {
            Destroy(gameObject);
        }
    }

    // If we hit something, destroy the bullet
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter() WindGustProjectile collided with " + collision.gameObject.name);

        if(isEffecting == false)
        {
            Debug.Log("isEffecting is " + isEffecting);

            StartCoroutine(DestroyWind());
        }
        
    }

    // Desotry the object after some time
    private IEnumerator DestroyWind()
    {
        Debug.Log("DestroyWind() called");

        // we've hit something
        isEffecting = true;

        yield return new WaitForSeconds(effectDuration);

        Destroy(gameObject);


    }

}
