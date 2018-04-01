using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour {

	//public static CanvasManager instance;

    // The level the player is currently on
	private TextMeshProUGUI levelValueText;

    // Reference to the fuel Slider object
	private Slider fuelSlider;

    // Reference to the maximum value on the fuel gauge
	private Text fuelGaugeMaxValueText;

    // Reference to the rocket itself;
    private Rocket rocketRef;

    [Header("Pop-Ups")]
    [SerializeField] private GameObject pausePanelPrefab;

    [Header("Objectives")]
    // References to the Objectives tracking
    [SerializeField] private GameObject objectiveTextContainer;
    [SerializeField] private TextMeshProUGUI objectivesCollectedTextValue;

    // Reference for the LevelObjectives script.
    private LevelObjectives levelObjectives;

    

    // Use this for initialization
    void Start ()
    {
        
        levelValueText = GameObject.Find("LevelValue").GetComponent<TextMeshProUGUI>();

        //pausePanel.SetActive(false);

        // get reference
        objectiveTextContainer = GameObject.FindGameObjectWithTag("ObjectivesText");

        // get reference to level objectives
        levelObjectives = GameObject.FindObjectOfType<LevelObjectives>();

        if(levelObjectives == null)
        {
            Debug.Log("START() in CanvasManager : unable to find LevelObjectives object");
        }

        // Set all the Fuel Gauge Values
        InitializeFuelGauge();

        // Set the current Level
        UpdateHUDCurrentLevel();

        // Update the HUD
        UpdateObjectivesHUD();

        //Debug.Log("===== STARTING " + levelValueText + " ===== ");


        pausePanelPrefab.SetActive(false);


    }


    // Update is called once per frame
    void Update () {

		// Update the Fuel Gauge
		UpdateFuelHUD();

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
		//fuelGaugeMaxValueText = GameObject.Find ("FuelValueMax").GetComponent<Text> ();
		//fuelGaugeMaxValueText.text = rocketRef.FuelMaxCapacity.ToString();

	}



    /// <summary>
    /// Display the current level
    /// </summary>
	public void UpdateHUDCurrentLevel ()
	{

        // display current level number
        levelValueText.text = SceneManager.GetActiveScene().name;

	}

    /// <summary>
    /// Updates the fuel HUD
    /// </summary>
    public void UpdateFuelHUD()
    {

        if(FindObjectOfType<Rocket>() != null)
        {
            fuelSlider.value = FindObjectOfType<Rocket>().FuelCurrentValue;
        }
        

    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateObjectivesHUD()
    {

        //Debug.Log("UpdateObjectivesHUD() Called: levelObjectives.ObjectivesCollected: " + levelObjectives.ObjectivesCollected);
        //Debug.Log("UpdateObjectivesHUD() Continued: LevelHasObjectives = " + levelObjectives.LevelHasObjectives);
        levelObjectives = GameObject.FindObjectOfType<LevelObjectives>();

        if (levelObjectives.LevelHasObjectives == false) {
            
            // disable
            objectiveTextContainer.SetActive(false);
            //Debug.Log("UpdateObjectivesHUD() :: levelHasObjectives is False; Disable objectives text");

            return;
        }

        if (levelObjectives.LevelHasObjectives == true)
        {

            // disable
            objectiveTextContainer.SetActive(true);
            //Debug.Log("UpdateObjectivesHUD() :: levelHasObjectives is True; enable objectives text");

        }


        // Update to "0 of 2", or "1 of 2", etc
        objectivesCollectedTextValue.text = levelObjectives.ObjectivesCollected.ToString() + " of " + levelObjectives.ObjectiveCount.ToString();

    }



    public void DisplayPausePanel()
    {
        // Play entry animation

        pausePanelPrefab.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ClosePausePanel()
    {

        Debug.Log("ClosePausePanel() called");

        pausePanelPrefab.SetActive(false);

        Time.timeScale = 1f;


    }

}
