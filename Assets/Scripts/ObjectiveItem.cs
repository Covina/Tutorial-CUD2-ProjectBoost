using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour {

    // Sound effect on pickup
    public AudioClip singleObjectiveCollectedSFX;

    // get reference to Level Objectives Manager
    private LevelObjectives levelObj;


    // Reference to GameManager to play the sound for pickup
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {

        levelObj = GameObject.FindObjectOfType<LevelObjectives>();

        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Increment the count of items found
            //levelObj.ObjectivesCollected += 1;

            levelObj.CollectObjective();

            // play sound
            audioSource.PlayOneShot(singleObjectiveCollectedSFX);

            // destroy the item
            Destroy(gameObject);

        }
    }

}
