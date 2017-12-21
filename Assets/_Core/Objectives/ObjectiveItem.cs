using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour {

    // Sound effect on pickup
    public AudioClip singleObjectiveCollectedSFX;

    [SerializeField] private GameObject objectivePickupPFX;

    // get reference to Level Objectives Manager
    private LevelObjectives levelObj;

    // Reference to GameManager to play the sound for pickup
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {

        levelObj = GameObject.FindObjectOfType<LevelObjectives>();

        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

	}



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Increment the count of items found
            levelObj.CollectObjective();

            GameObject objectivePFXGO = Instantiate(objectivePickupPFX) as GameObject;
            objectivePFXGO.transform.position = gameObject.transform.position;


            // play sound
            audioSource.PlayOneShot(singleObjectiveCollectedSFX);

            // destroy the item
            Destroy(gameObject);

        }
    }

}
