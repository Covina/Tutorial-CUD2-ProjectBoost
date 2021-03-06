﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidNavigationHandler : MonoBehaviour {

    [SerializeField] private GameObject quitPopUp;

    // Use this for initialization
    void Start()
    {
        quitPopUp.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ProcessEscapeKey();
        }		
	}

    private void ProcessEscapeKey()
    {
        // check which scene it is
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Display Quit App pop-up
            Debug.Log("Escape key pressed");
            quitPopUp.SetActive(true);
        }
    }

}
