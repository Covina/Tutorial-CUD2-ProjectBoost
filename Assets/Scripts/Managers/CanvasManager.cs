using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	//public static CanvasManager instance;

	private Text levelValueText;

	private Slider fuelSlider;

	private Text fuelGaugeMaxValueText;


	// Use this for initialization
	void Start () {


		levelValueText = GameObject.Find("LevelValue").GetComponent<Text>();

		InitializeFuelGauge ();

		UpdateHUDCurrentLevel ();


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




	/// <summary>
	/// Initializes the fuel gauge.
	/// </summary>
	private void InitializeFuelGauge ()
	{
		// Get reference to slider object
		fuelSlider = GameObject.Find ("FuelTankSlider").GetComponent<Slider> ();


		// Set slider Max value
		fuelSlider.maxValue = PlayerManager.instance.FuelMaxCapacity;

		// Set Slider Min value
		fuelSlider.minValue = PlayerManager.instance.FuelMinCapacity;

		// Start Slider at max
		fuelSlider.value = PlayerManager.instance.FuelMaxCapacity;

		// Set Player current Value
		PlayerManager.instance.FuelCurrentValue = PlayerManager.instance.FuelMaxCapacity;


		// Update Max Label
		fuelGaugeMaxValueText = GameObject.Find ("FuelValueMax").GetComponent<Text> ();
		fuelGaugeMaxValueText.text = PlayerManager.instance.FuelMaxCapacity.ToString();



	}

	public void UpdateHUDCurrentLevel ()
	{
		// display current level number
		levelValueText.text = SceneNavigationController.instance.LevelNumber.ToString();

	}
}
