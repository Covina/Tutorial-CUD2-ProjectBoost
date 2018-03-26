using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPackCard : MonoBehaviour {

    [SerializeField] private GameObject packImage;
    [SerializeField] private GameObject packTitle;

    public WorldSettings metaData;

    // Use this for initialization
    void Start () {

        packImage.GetComponent<Image>().sprite = metaData.worldimage;

        packTitle.GetComponent<TextMeshProUGUI>().text = metaData.worldName;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
