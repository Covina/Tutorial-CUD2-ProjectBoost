using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FuelBoost : MonoBehaviour {

	// Set Fuel addition increment
    public float fuelAmount = 3f;

	// Detect if the Player picked it up
	void OnTriggerEnter (Collider target)
	{
		//Debug.Log("Fuel Boost triggered by " + target.gameObject.name);

		// if it was the player
		if (target.gameObject.tag == "Player") {

			AddFuel(fuelAmount);

		}


	}

	// Player picked up fuel barrel
	private void AddFuel (float amount)
	{

		// Add fuel, capping it at the max
		PlayerManager.instance.FuelCurrentValue = Mathf.Clamp
													(
													PlayerManager.instance.FuelCurrentValue + amount, 
													PlayerManager.instance.FuelMinCapacity,
													PlayerManager.instance.FuelMaxCapacity
													);

		// destroy the fuel once picked up
		Destroy(gameObject);

	}

}
