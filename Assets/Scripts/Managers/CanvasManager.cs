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

    private Rocket rocketRef;

	// Use this for initialization
	void Start () {


		levelValueText = GameObject.Find("LevelValue").GetComponent<Text>();

        // Set all the Fuel Gauge Values
		InitializeFuelGauge ();

        // Set the current Level
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

        fuelSlider.value = FindObjectOfType<Rocket>().FuelCurrentValue;

	}


	/// <summary>
	/// Initializes the fuel gauge.
	/// </summary>
	private void InitializeFuelGauge ()
	{

        rocketRef = FindObjectOfType<Rocket>();

        // Get reference to slider object
        fuelSlider = GameObject.Find ("FuelTankSlider").GetComponent<Slider> ();

		// Set slider Max value
		fuelSlider.maxValue = rocketRef.FuelMaxCapacity;

		// Set Slider Min value
		fuelSlider.minValue = rocketRef.FuelMinCapacity;

		// Start Slider at max
		fuelSlider.value = rocketRef.FuelMaxCapacity;

        // Set Player current Value
        rocketRef.FuelCurrentValue = rocketRef.FuelMaxCapacity;


		// Update Max Label
		fuelGaugeMaxValueText = GameObject.Find ("FuelValueMax").GetComponent<Text> ();
		fuelGaugeMaxValueText.text = rocketRef.FuelMaxCapacity.ToString();

	}

	public void UpdateHUDCurrentLevel ()
	{

        // display current level number
        levelValueText.text = SceneManager.GetActiveScene().name;

	}
}
