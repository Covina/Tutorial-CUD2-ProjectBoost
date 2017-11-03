using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour {


    private LevelObjectives levelObj;

	// Use this for initialization
	void Start () {

        levelObj = GameObject.FindObjectOfType<LevelObjectives>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Increment the count of items found
            levelObj.ObjectivesCollected += 1;

            // destroy the item
            Destroy(gameObject);

        }
    }

}
