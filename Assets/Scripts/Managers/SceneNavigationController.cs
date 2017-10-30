using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour {


	public static SceneNavigationController instance;


	private int totalSceneCount;		// Total Scenes
	private int levelStartIndex = 1;	// The index of the first level
	private int lastLevelIndex = 5;		// The index of the last level

	// init on load
	private int currentSceneIndex = 0;

	// how many times the player has tried to complete the level
	private int attemptsTrackerValue = 1;

	private int levelNumber = 1;
	public int LevelNumber {
		get { return levelNumber; }
		set { levelNumber = value; }
	}

	// Use this for initialization
	void Awake () {

		MakeSingleton ();
		
	}


	// Use this for initialization
	void Start () {

		totalSceneCount = SceneManager.sceneCountInBuildSettings;

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
		SceneManager.LoadScene (0);
		currentSceneIndex = 0;
    }

	/// <summary>
	/// Loads the first level.
	/// </summary>
    public void LoadFirstLevel()
    {
    	// Set level Number for display
    	levelNumber = 1;

    	// set current scene navigation index
		currentSceneIndex = levelStartIndex;

		// Load the first level based on index position
		SceneManager.LoadScene(levelStartIndex);
    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
	public void LoadNextLevel ()
	{

		levelNumber++;

		currentSceneIndex++;

		// check if we're at the end.
		if (currentSceneIndex <= lastLevelIndex) {

			SceneManager.LoadScene (currentSceneIndex);

		} else {

			// Load the end of game scene
			SceneManager.LoadScene ("EndCredits");
		}
    }

    /// <summary>
    /// Reloads the level.
    /// </summary>
    public void ReloadLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
