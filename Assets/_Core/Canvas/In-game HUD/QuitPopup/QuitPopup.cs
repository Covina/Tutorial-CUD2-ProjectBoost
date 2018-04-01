using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPopup : MonoBehaviour {

    public void CloseQuitPopup()
    {
        gameObject.SetActive(false);

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
