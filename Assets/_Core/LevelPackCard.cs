using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPackCard : MonoBehaviour {

    [SerializeField] private GameObject packImage;
    [SerializeField] private GameObject packTitle;
    [SerializeField] private GameObject gravitySettingValue;


    public WorldSettings metaData;

    // Use this for initialization
    void Start () {

        packImage.GetComponent<Image>().sprite = metaData.worldimage;

        packTitle.GetComponent<TextMeshProUGUI>().text = metaData.worldName;

        gravitySettingValue.GetComponent<TextMeshProUGUI>().text = GetGravitySettingValue();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private string GetGravitySettingValue()
    {


        float tmp = Mathf.Abs(metaData.gravityY / -9.81f);

        string gravString = tmp.ToString("N1") + " G";

        //Debug.Log("GetGravitySettingValue() produced: " + gravString);

        return gravString;
    }
}
