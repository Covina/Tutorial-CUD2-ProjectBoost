using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FuelBoost : MonoBehaviour {

	// Set Fuel addition increment
    public float fuelAmount = 3f;

	// Detect if the Player picked it up
	void OnTriggerEnter (Collider target)
	{
		Debug.Log("Fuel Boost triggered by " + target.gameObject.name);

		// if it was the player
		if (target.gameObject.tag == "Player") {

			AddFuel(fuelAmount);

		}


	}

	// Player picked up fuel barrel
	private void AddFuel (float amount)
	{
        // get reference to rocket
        Rocket temp = FindObjectOfType<Rocket>();

        // Add fuel, capping it at the max
        temp.FuelCurrentValue = Mathf.Clamp (temp.FuelCurrentValue + amount, temp.FuelMinCapacity, temp.FuelMaxCapacity);

		// destroy the fuel once picked up
		Destroy(gameObject);

	}

}
