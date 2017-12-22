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
    private List<string> contentPackFolders = new List<string>();
    public List<string> ContentPackFolders {
        get
        {
            return contentPackFolders;
        }
    }

    private int currentLoadedLevelListIndex = 0;
    public int CurrentLoadedLevelListIndex { get; set; }

    private string currentLoadedLevelPackName;
    public string CurrentLoadedLevelPackName {
        get
        {
            return currentLoadedLevelPackName;
        }
        set {
            currentLoadedLevelPackName = value;
        }
    }

    // LevelPack01_TrainingGround
    private List<string> levelFileNames = new List<string>();

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
        contentPackFolders.Add("LevelPack01_TrainingGround");
        contentPackFolders.Add("LevelPack02_EarthDusk");
        contentPackFolders.Add("LevelPack03_HeavyPlanet");

        foreach(string folderName in contentPackFolders)
        {

            // get the scene levels into a list
            var loadedObjects = Resources.LoadAll(folderName + "/Levels");
            List<string> levelFileNames = new List<string>();

            foreach (var o in loadedObjects)
            {
                levelFileNames.Add(o.name);
                //Debug.Log("Adding level: " + o.name);
            }

            gameLevels.Add(folderName, levelFileNames);

            Debug.Log("For Pack [" + folderName + "], adding " + levelFileNames.Count + " Levels.");
            

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
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    /// <summary>
    /// Shortcut to load end credits
    /// </summary>
    public void LoadEndCredits()
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

        Debug.Log("LoadNextLevel() :: About to LoadNextLevel BuildIndex: " + nextSceneIndex);

        SceneManager.LoadScene(nextSceneIndex);

    }


    /// <summary>
    /// Loads the first level.
    /// </summary>
    public void LoadStartingLevelInPack(string levelPackName)
    {
        Debug.Log("LoadStartingLevelInPack() called");

        // Set which pack we're using
        currentLoadedLevelPackName = levelPackName;

        // Get level list to load
        List<string> levelList = gameLevels[levelPackName];

        //Debug.Log("levelList[0]: " + levelList[0]);

        // Reset the Content List Index Position
        currentLoadedLevelListIndex = 0;

        // Load the first level based on index position
        SceneManager.LoadScene(levelList[0]);

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
