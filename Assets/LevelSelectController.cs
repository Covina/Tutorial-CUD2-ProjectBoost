using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour {

    public GameObject levelCardPrefab;
    public GameObject levelCardParentObject;


    // For storing the level data for the curerntly selected world
    private List<LevelCard> currentLevelList;

	// Use this for initialization
	void Start () {

        currentLevelList = DataManager.Instance.SingleLevelList;
        foreach (LevelCard card in currentLevelList)
        {

            GameObject spawnedCard = Instantiate(levelCardPrefab, levelCardParentObject.transform) as GameObject;

            LevelCardUI tmp = spawnedCard.GetComponent<LevelCardUI>();

            // Update scene friendly name
            tmp.SetLevelFriendlyName(card.sceneLevelName);

            // Add button click to launch scene
            tmp.AddButtonHandler(card.sceneFileName);
        }


    }
	

}
