using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public static CanvasManager instance;

	private Slider fuelSlider;


	// Use this for initialization
	void Start () {

		// Get referenec to slider object
		fuelSlider = GameObject.Find("FuelTankSlider").GetComponent<Slider>();

		// Set slider Max value
		fuelSlider.maxValue = PlayerManager.instance.FuelMaxCapacity;

		// Set Slider Min value
		fuelSlider.minValue = PlayerManager.instance.FuelMinCapacity;

		// Start Slider at max
		fuelSlider.value = PlayerManager.instance.FuelMaxCapacity;

		// Set Player current Value
		PlayerManager.instance.FuelCurrentValue = PlayerManager.instance.FuelMaxCapacity;

	}

		
	// Update is called once per frame
	void Update () {

		// Update the Fuel Gauge
		UpdateFuelHUD();

	}

	/// <summary>
	/// Updates the fuel HUD
	/// </summary>
	public void UpdateFuelHUD() {

		fuelSlider.value = PlayerManager.instance.FuelCurrentValue;

	}


}
