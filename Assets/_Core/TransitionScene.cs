using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScene : MonoBehaviour {
    // TODO - Update "completed" text o sue World Name


    [SerializeField] private Text successText;

	// Use this for initialization
	void Start () {

        successText.text = "You've completed " + SceneNavigationController.Instance.CurrentLoadedLevelPackName + "!";

        StartCoroutine(NavToNext());

        //Debug.Log("transitionScene snc.CurrentWorldIndex:: " + SceneNavigationController.Instance.CurrentWorldIndex);
    }
	

    public IEnumerator NavToNext()
    {

        yield return new WaitForSeconds(4.0f);

        //Debug.Log("transitionScene NavToNext() snc.CurrentWorldIndex:: " + SceneNavigationController.Instance.CurrentWorldIndex);

        // load the first level in the next pack
        //snc.LoadNextLevel();
        SceneNavigationController.Instance.LoadNextWorld();
    }

}
