using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectives : MonoBehaviour {

    public AudioClip allObjectivesCollectedSFX;

    private AudioSource audioSource;

    //
    private GameObject landingPad;

    private CanvasManager canvasManager;

    private bool levelHasObjectives = false;
    public bool LevelHasObjectives
    {
        get { return levelHasObjectives; }
        set { levelHasObjectives = value; }
    }


    // has the player collected enough objectives?
    private bool isObjectiveComplete = false;

    // store how many objectives there are to collect
    private int objectiveCount;
    public int ObjectiveCount
    {
        get
        {
            return objectiveCount;
        }
        set
        {
            objectiveCount = value;
        }
    }

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

        // Get Audio source to play SFX when all objectives have been collected
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

        // get a reference to the canvas
        canvasManager = GetComponent<CanvasManager>();

        // If this level has objectives, hide the Exit
        if(objectiveCount > 0) {

            levelHasObjectives = true;

            //Debug.Log("LevelObjectives Start(): objectiveCount > 0 so we are Setting levelHasObjectives to TRUE");

            // update text hud
            canvasManager.UpdateObjectivesHUD();

            // hide the exit
            StartCoroutine(HideTheExit());
        }
        
    }

    // Update is called once per frame
    void Update() {

        if (levelHasObjectives == false) { return; }

        // Did we meet or exceed the requirement?
        if (objectivesCollected >= objectiveCount && isObjectiveComplete == false)
        {
            isObjectiveComplete = true;

            // play sound
            audioSource.PlayOneShot(allObjectivesCollectedSFX);

            // animate
            landingPad.GetComponent<LandingPadController>().DisplayLandingPad();
        }
    }

    /// <summary>
    /// Animation to hide the landing pad
    /// </summary>
    /// <returns></returns>
    private IEnumerator HideTheExit()
    {
        yield return new WaitForSeconds(2.0f);

        landingPad.GetComponent<LandingPadController>().HideLandingPad();


    }

    /// <summary>
    /// Track the objectives collected and update the status display
    /// </summary>
    public void CollectObjective()
    {
        // incremenet the Objectives Collected
        objectivesCollected += 1;

        // Update the HUD
        canvasManager.UpdateObjectivesHUD();

    }

}
