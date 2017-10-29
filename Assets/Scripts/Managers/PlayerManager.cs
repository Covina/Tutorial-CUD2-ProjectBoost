using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Singleton
	public static PlayerManager instance;


	// Fuel tank Min and Max Capacities
	public float FuelMaxCapacity = 10.0f;
	public float FuelMinCapacity = 0.0f;

	// Get/Set for current fuel value;
	private float fuelCurrentValue;
	public float FuelCurrentValue {
		get { return fuelCurrentValue;	}
		set { fuelCurrentValue = value;	}	
	}


	// Use this for initialization
	void Awake () {

		MakeSingleton ();
		
	}

	/// <summary>
	/// Makes the singleton.
	/// </summary>
	private void MakeSingleton() 
	{

		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

}
