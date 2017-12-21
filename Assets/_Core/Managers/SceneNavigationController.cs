using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour
{

    public static SceneNavigationController instance = null;

    // Current Scene Index
    private int currentSceneIndex = 0;

    // how many times the player has tried to complete the level
    private int attemptsTrackerValue = 1;

    // Store the Packs and its list of level names
    private Dictionary<string, List<string>> gameLevels = new Dictionary<string, List<string>>();

    //
    private List<string> levelFolderNames = new List<string>();
    
    private int currentLoadedLevelListIndex = 0;
    private string currentLoadedLevelPackName;

    // LevelPack01_TrainingGround
    private List<string> pack01LevelNames = new List<string>();

    private bool changed = false;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }


    // Use this for initialization
    void Start()
    {
        // TODO - Move the content list somewhere else.
        levelFolderNames.Add("LevelPack01_TrainingGround");
        levelFolderNames.Add("LevelPack02_EarthDusk");
        levelFolderNames.Add("LevelPack03_HeavyPlanet");

        foreach(string folderName in levelFolderNames)
        {

            // get the scene levels into a list
            var loadedObjects = Resources.LoadAll(folderName + "/Levels", typeof(Scene));

            foreach (var o in loadedObjects)
            {
                pack01LevelNames.Add(o.name);
                Debug.Log("Adding level: " + o.name);
            }

            gameLevels.Add(folderName, pack01LevelNames);

            //Debug.Log("Total Levels in loadedNames.count: " + pack01LevelNames.Count);
            //Debug.Log("gameLevel.Count: " + gameLevels.Count);

        }
        
    }


    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the lobby
    /// </summary>
    public void LoadWorldLobby()
    {
        // Load the first level based on index position
        SceneManager.LoadScene("WorldLobby");
    }

    /// <summary>
    /// Shortcut to load end credits
    /// </summary>
    private static void LoadEndCredits()
    {
        SceneManager.LoadScene("EndCredits");
    }




    /// <summary>
    /// Loads the next level.
    /// </summary>
	public void LoadNextLevel()
    {

        // Set current scene index.
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // increment by 1
        int nextSceneIndex = currentSceneIndex + 1;

        //Debug.Log("LoadNextLevel() :: About to LoadNextLevel: " + nextSceneIndex);

        SceneManager.LoadScene(nextSceneIndex);

    }


    /// <summary>
    /// Loads the first level.
    /// </summary>
    public void LoadStartingLevelInPack(string levelPackName)
    {

        // Set which pack we're using
        currentLoadedLevelPackName = levelPackName;

        // Get level list to load
        List<string> levelList = gameLevels[levelPackName];

        //Debug.Log("levelList[0]: " + levelList[0]);

        // Load the first level based on index position
        SceneManager.LoadScene(levelList[0]);

    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
	public void LoadNextLevelInPack()
    {

        // Increment to next scene
        currentLoadedLevelListIndex += 1;

        // Get info on which to load
        List<string> levelList = gameLevels[currentLoadedLevelPackName];

        if (currentLoadedLevelListIndex > levelList.Count)
        {
            LoadEndCredits();
        }
        else
        {

            // Load the first level based on index position
            SceneManager.LoadScene(levelList[currentLoadedLevelListIndex]);

        }

    }



    /// <summary>
    /// Reloads the level.
    /// </summary>
    public void ReloadLevel()
    {
        //Debug.Log("ReloadLevel currentSceneIndex " + currentSceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //public void DisplayDictionary()
    //{

    //    foreach (KeyValuePair<string, List<string>> entry in gameLevels)
    //    {
    //        // do something with entry.Value or entry.Key
    //        Debug.Log("gamelevel key: " + entry.Key);
    //    }


    //}

}
