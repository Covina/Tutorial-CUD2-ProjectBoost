using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectives : MonoBehaviour {


    //
    private GameObject landingPad;

    // store how many objectives there are to collect
    private int objectiveCount;

    // has the player collected enough objectives?
    private bool isObjectiveComplete = false;

    // Get/Set current objectives collected
    private int objectivesCollected = 0;
    public int ObjectivesCollected {
        get
        {
            return objectivesCollected;
        }
        set
        {
            objectivesCollected = value;
        }
    }


    // Use this for initialization
    void Start() {

        // store how many objectives there are in this level
        objectiveCount = GameObject.FindObjectsOfType<ObjectiveItem>().Length;

        // Get reference to the landing pad
        landingPad = GameObject.FindGameObjectWithTag("LandingPad");

        // Hide it
        StartCoroutine(HideTheExit());
    }

    // Update is called once per frame
    void Update() {

        // Did we meet or exceed the requirement?
        if (objectivesCollected >= objectiveCount)
        {
            isObjectiveComplete = true;
            landingPad.GetComponent<LandingPadController>().DisplayLandingPad();
        }
    }


    private IEnumerator HideTheExit()
    {
        yield return new WaitForSeconds(2.0f);

        landingPad.GetComponent<LandingPadController>().HideLandingPad();


    }


}
