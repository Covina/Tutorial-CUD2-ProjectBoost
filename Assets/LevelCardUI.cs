using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCardUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI levelNameValue;
    [SerializeField] private Button levelCardButton;


    public void SetLevelFriendlyName(string levelName)
    {
        levelNameValue.text = levelName;
    }

    public void AddButtonHandler(string sceneFileName)
    {

        Button btn = levelCardButton.GetComponent<Button>();

        btn.onClick.AddListener(delegate { SceneNavigationController.Instance.LoadScene(sceneFileName); } );


    }

}
