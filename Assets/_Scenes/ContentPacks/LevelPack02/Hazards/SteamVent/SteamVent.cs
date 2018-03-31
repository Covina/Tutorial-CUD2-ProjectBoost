using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVent : MonoBehaviour {


    public Vector3 appliedForceVector = new Vector3(0f, 100f, 0f);
    public float cooldownLength = 2f;

    private bool isCooldown = false;
    

    private Rocket player;


    private BoxCollider boxCollider;

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Rocket>();

        boxCollider = GetComponent<BoxCollider>();

        appliedForceVector = transform.up * 100f;
        Debug.Log("new appliedForceVector: " + appliedForceVector);

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

            StartCoroutine(ApplyCooldown());

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

            StartCoroutine(ApplyCooldown());
        }

    }


    IEnumerator ApplyCooldown()
    {
        ToggleAirCollider();

        yield return new WaitForSeconds(cooldownLength);

        isCooldown = false;
        ToggleAirCollider();

    }


 

    // Toggle the Air Vent collider on/off
    private void ToggleAirCollider()
    {
        // Set it to the opposite
        boxCollider.enabled = !boxCollider.enabled;

    }


}
