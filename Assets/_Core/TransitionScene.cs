using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene : MonoBehaviour {

    private SceneNavigationController snc;

	// Use this for initialization
	void Start () {

        snc = FindObjectOfType<SceneNavigationController>();

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
