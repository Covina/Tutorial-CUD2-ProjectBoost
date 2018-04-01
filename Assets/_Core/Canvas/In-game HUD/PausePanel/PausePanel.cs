using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour {

    public void ClosePausePanel()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);

    }


    public void LoadMainMenu()
    {
        SceneNavigationController.Instance.LoadMainMenu();
    }

}
