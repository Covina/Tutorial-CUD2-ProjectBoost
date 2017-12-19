using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour {

	public static SceneNavigationController instance;

    // Current Scene Index
	private int currentSceneIndex = 0;

	// how many times the player has tried to complete the level
	private int attemptsTrackerValue = 1;

    private Dictionary<string, List<string>> gameLevels = new Dictionary<string, List<string>>();

    private string[] levelFolderNames = new string[1];


    // Use this for initialization
    void Awake () {

		MakeSingleton ();
		
	}


	// Use this for initialization
	void Start () {

        // All Level Folder Names
        levelFolderNames[0] = "LevelPack01_TrainingGround";

        // TODO put this into a foreach.

        // get the scene levels into an array
        var loadedObjects = Resources.LoadAll("_Levels/" + levelFolderNames[0]);

        List<string> loadedNames = new List<string>();

        foreach(var o in loadedObjects)
        {
            loadedNames.Add(o.name);
            //Debug.Log("Loading level name " + o.name);
        }

        Debug.Log("loadedNames.count: " + loadedNames.Count);

        // add into dictionary
        gameLevels.Add("levelpack01", loadedNames);


    }

	/// <summary>
	/// Makes the singleton.
	/// </summary>
	private void MakeSingleton() 
	{

		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}


	/// <summary>
    /// Loads the main menu.
    /// </summary>
    public void LoadMainMenu() 
    {
        //Debug.Log("LoadMainMenu: currentSceneIndex : " + currentSceneIndex);

        SceneManager.LoadScene ("MainMenu");

    }

	/// <summary>
	/// Loads the first level.
	/// </summary>
    public void LoadFirstLevel()
    {

        // Load the first level based on index position
        SceneManager.LoadScene(1);

    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
	public void LoadNextLevel ()
	{

        // Set current scene index.
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // increment by 1
        int nextSceneIndex = currentSceneIndex + 1;

        //Debug.Log("LoadNextLevel() :: About to LoadNextLevel: " + nextSceneIndex);

		SceneManager.LoadScene(nextSceneIndex);

    }

    /// <summary>
    /// Reloads the level.
    /// </summary>
    public void ReloadLevel()
    {
        //Debug.Log("ReloadLevel currentSceneIndex " + currentSceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
