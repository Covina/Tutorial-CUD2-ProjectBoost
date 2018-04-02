using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FuelBoost : MonoBehaviour {

	// Set Fuel addition increment
    public float fuelAmount = 3f;

    private Rocket rocketPlayer;

    private AudioSource gmAudioSource;
    public AudioClip boostAcquiredSFX;


    [SerializeField] private GameObject pickupExplosion;

    private void Start()
    {
        gmAudioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

        rocketPlayer = GameObject.FindObjectOfType<Rocket>();

    }


    // Detect if the Player picked it up
    void OnTriggerEnter (Collider target)
	{
		//Debug.Log("Fuel Boost triggered by " + target.gameObject.name);

		// if it was the player
		if (target.gameObject.tag == "Player") {

			AddFuel(fuelAmount);

            // Fire off the boost particles
            PlayBoostPickupEffects();

            // destroy the fuel once picked up
            Destroy(gameObject);

        }


	}

	// Player picked up fuel barrel
	private void AddFuel (float amount)
	{
        // get reference to rocket
        //Rocket temp = FindObjectOfType<Rocket>();

        // Add fuel, capping it at the max
        rocketPlayer.FuelCurrentValue = Mathf.Clamp (rocketPlayer.FuelCurrentValue + amount, rocketPlayer.FuelMinCapacity, rocketPlayer.FuelMaxCapacity);

	}


    public void PlayBoostPickupEffects()
    {

        GameObject fuelPFXGO = Instantiate(pickupExplosion) as GameObject;
        fuelPFXGO.transform.position = gameObject.transform.position;

        // play particle effect
        //fuelPFXGO.GetComponent<ParticleSystem>().Play();

        // play sound
        gmAudioSource.PlayOneShot(boostAcquiredSFX);

    }


}
