using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelMonitor : MonoBehaviour {

    public Slider fuelSlider;
    public Image fillColorObject;


    private float fuelWarningThreshold = .33f;

    private Color defaultColor;

    private Rocket player; 

    // Use this for initialization
    void Start () {

        fuelSlider = GetComponent<Slider>();
        player = FindObjectOfType<Rocket>();


        defaultColor = fillColorObject.color;

        // Calculate based on actual amount of fuel
        fuelWarningThreshold = player.FuelMaxCapacity * fuelWarningThreshold;

    }
	
	// Update is called once per frame
	void Update () {

        CheckFuel();

	}

    public void CheckFuel()
    {

        //Debug.Log("Comparing " + fuelSlider.value + " <= " + fuelWarningThreshold);

        if (fuelSlider.value <= fuelWarningThreshold)  
        {
            //Debug.Log("======= Changing to red =======");

            fillColorObject.color = Color.red;

        }
        else
        {
            fillColorObject.color = defaultColor;
        }

    }

}
