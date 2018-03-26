using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    private Slider volumeSlider;

    private MusicController musicController;

	// Use this for initialization
	void Start () {

        volumeSlider = GetComponent<Slider>();

        musicController = FindObjectOfType<MusicController>();

        // Check player prefs
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            float volumeSetting = PlayerPrefs.GetFloat("VOLUME");

            volumeSlider.value = volumeSetting;

        }
        else
        {
            volumeSlider.value = 0.5f;
        }


    }
	
	// Update is called once per frame
	void Update () {

        musicController.AdjustVolume(volumeSlider.value);

	}
}
