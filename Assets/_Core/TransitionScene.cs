using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScene : MonoBehaviour {

    private SceneNavigationController snc;

    [SerializeField] private Text successText;

	// Use this for initialization
	void Start () {

        snc = FindObjectOfType<SceneNavigationController>();

        successText.text = "You've completed " + snc.CurrentLoadedLevelPackName + "!";

        StartCoroutine(NavToNext());
	}
	

    public IEnumerator NavToNext()
    {

        yield return new WaitForSeconds(4.0f);

        // load the first level in the next pack
        //snc.LoadNextLevel();
        snc.LoadNextWorld();
    }

}
