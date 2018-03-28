using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindVent : MonoBehaviour {


    public Vector3 appliedForceVector = new Vector3(0f, 100f, 0f);
    public float cooldownLength = 2f;

    private bool isCooldown = false;
    

    private Rocket player;


    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Rocket>();

    }
	

    private void OnTriggerEnter(Collider other)
    {

        if(isCooldown == false && other.gameObject.tag == "Player")
        {

            //Debug.Log("Air particle Collided");

            Vector3 forceVector = appliedForceVector;

            // Apply Upward Force
            player.ApplyOutsideForceVector(forceVector);


            // Initiate Cooldown
            isCooldown = true;

            StartCoroutine(DisableCooldown());

        }

    }


    private void OnTriggerStay(Collider other)
    {

        if (isCooldown == false && other.gameObject.tag == "Player")
        {
            //Debug.Log("OnTriggerStay()");

            Vector3 forceVector = appliedForceVector;

            // Apply Upward Force
            player.ApplyOutsideForceVector(forceVector);

            // Initiate Cooldown
            isCooldown = true;

            StartCoroutine(DisableCooldown());
        }

    }


    IEnumerator DisableCooldown()
    {
        yield return new WaitForSeconds(cooldownLength);

        isCooldown = false;


    }


    // TODO - Create an on/off toggle for the collider when air vent is on/off

}
