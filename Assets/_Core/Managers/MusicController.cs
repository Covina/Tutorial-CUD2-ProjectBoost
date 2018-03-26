using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static MusicController instance;

    private AudioSource audioSource;

    void Awake()
    {
        MakeSingleton();    
    }

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

        InitializeVolume();

	}
	

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    public void AdjustVolume(float newVolume)
    {

        audioSource.volume = newVolume;

        PlayerPrefs.SetFloat("VOLUME", newVolume);

    }

    public void InitializeVolume()
    {
        // Check player prefs
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            float volumeSetting = PlayerPrefs.GetFloat("VOLUME");

            audioSource.volume = volumeSetting;

        } else
        {
            audioSource.volume = 0.5f;
        }
            
    }
}
