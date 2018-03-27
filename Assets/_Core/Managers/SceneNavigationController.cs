using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour
{

    public static SceneNavigationController Instance = null;

    // Current Scene Index
    private int currentLevelIndex = 0;
    public int CurrentLevelIndex
    {
        get
        {
            return currentLevelIndex;
        }
        set
        {
            currentLevelIndex = value;
        }
    }

    private string currentSceneName;
    public string CurrentSceneName
    {
        get
        {
            return currentSceneName;
        }
        set
        {
            currentSceneName = value;
        }
    }

    private int currentWorldIndex = 0;
    public int CurrentWorldIndex
    {
        get
        {
            return currentWorldIndex;
        }
        set
        {
            currentWorldIndex = value;
        }
    }

    // how many times the player has tried to complete the level
    private int attemptsTrackerValue = 1;


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


    List<string> levelList = new List<string>();


    // Use this for initialization
    void Awake()
    {
        MakeSingleton();

    }


    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    public void LoadTransition()
    {
        SceneManager.LoadScene("TransitionLoader");
    }



    /// <summary>
    /// Shortcut to load end credits
    /// </summary>
    public void LoadEndCredits()
    {
        SceneManager.LoadScene("EndCredits");
    }

    /// <summary>
    /// Loads the first level of a given level pack
    /// </summary>
    public void LoadFirstLevelInPack(string levelPackName)
    {
        Debug.Log("LoadFirstLevelInPack(" + levelPackName + ") called");

        // Set which pack we're using
        currentLoadedLevelPackName = levelPackName;

        // Get the string list of level names
        levelList = DataManager.Instance.GetLevelList(levelPackName);

        Debug.Log("levelList count: " + levelList.Count);

        //// Reset the Content List Index Position
        //currentLoadedLevelListIndex = 0;

        // Load the first level based on index position
        SceneManager.LoadScene(levelList[0]);

    }


    /// <summary>
    /// Loads the next level.
    /// </summary>
	public void LoadNextLevel()
    {
        SetCurrentSceneData();

        // Check if we are at the last level?
        if (currentLevelIndex == levelList.Count - 1)
        {
            LoadTransition();

        }
        else
        {
            // LOAD NEXT LEVEL WITHIN THE PACK

            // increment by 1
            int nextSceneIndex = currentLevelIndex + 1;

            Debug.Log("LoadNextLevel() :: About to LoadNextLevel: " + nextSceneIndex);

            SceneManager.LoadScene(levelList[nextSceneIndex]);

        }

    }

    public void LoadNextWorld()
    {
        Debug.Log("Last level detected");

        // Is there another world?
        int nextWorldIndex = currentWorldIndex + 1;

        if (DataManager.Instance.LevelPackList[nextWorldIndex] != null)
        {
            // LOAD FIRST LEVEL IN NEXT WORLD
            Debug.Log("Another world is available...");

            // get new world name
            string newWorldPackname = DataManager.Instance.LevelPackList[nextWorldIndex];

            // Load the first level
            LoadFirstLevelInPack(newWorldPackname);

        }
        else
        {
            // WE ARE AT THE VERY END... no more worlds nor levels
            LoadEndCredits();
        }
    }

    private void SetCurrentSceneData()
    {
        // Set current scene name
        currentSceneName = SceneManager.GetActiveScene().name;

        // Set current levelList index number
        currentLevelIndex = levelList.IndexOf(currentSceneName);

        if (currentLoadedLevelPackName == null)
        {
            currentLoadedLevelPackName = FindWorldLevelPackname(currentSceneName);
        }

        // Get the current world index in the list
        currentWorldIndex = DataManager.Instance.LevelPackList.IndexOf(currentLoadedLevelPackName);


    }


    /// <summary>
    /// Reloads the level.
    /// </summary>
    public void ReloadLevel()
    {
        //Debug.Log("ReloadLevel currentSceneIndex " + currentSceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private string FindWorldLevelPackname(string sceneName)
    {
       
        // Loop through each pair
        foreach(KeyValuePair<string, List<string>> entry in DataManager.Instance.WorldLevelSceneDictionary)
        {
            // Loop through the list for the given key
            foreach(string levelName in entry.Value)
            {
                if(levelName == sceneName)
                {
                    return entry.Key;
                }

            }

        }

        return null;
    }

}
