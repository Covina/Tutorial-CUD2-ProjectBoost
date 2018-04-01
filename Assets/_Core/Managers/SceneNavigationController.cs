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

    private string currentLevelPackName;
    public string CurrentLoadedLevelPackName {
        get
        {
            return currentLevelPackName;
        }
        set {
            currentLevelPackName = value;
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
        currentLevelPackName = levelPackName;

        // Set World Meta File
        DataManager.Instance.SetCurrentWorldMetaFile(levelPackName);


        // Get the string list of level names
        levelList = DataManager.Instance.GetLevelList(levelPackName);

        //Debug.Log("levelList count: " + levelList.Count);

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
        Debug.Log("LoadNextLevel() currentWorldIndex :: " + currentWorldIndex);

        Debug.Log("LoadNextLevel() Called");

        SetCurrentSceneData();

        Debug.Log("currentLevelIndex[" + currentLevelIndex + "] || levelList.Count - 1 [" + (levelList.Count - 1) + "]");

        Debug.Log("LoadNextLevel() currentWorldIndex :: " + currentWorldIndex);

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
        Debug.Log("LoadNextWorld() - Last level detected");

        //SetCurrentSceneData();


        // Is there another world?
        int nextWorldIndex = currentWorldIndex + 1;

        //Debug.Log("currentWorldIndex :: " + currentWorldIndex);
        //Debug.Log("LoadNextWorld() - currentWorldIndex: " + currentWorldIndex);
        //Debug.Log("LoadNextWorld() - nextWorldIndex: " + nextWorldIndex);

        if(nextWorldIndex >= DataManager.Instance.LevelPackList.Count)
        {
            // WE ARE AT THE VERY END... no more worlds nor levels
            LoadEndCredits();
        } 
        else
        {

            // get new world name
            string newWorldPackname = DataManager.Instance.LevelPackList[nextWorldIndex];

            // LOAD FIRST LEVEL IN NEXT WORLD
            //Debug.Log("LoadNextWorld() - Another world is available..." + newWorldPackname);

            // Load the first level
            LoadFirstLevelInPack(newWorldPackname);
        }
    }

    private void SetCurrentSceneData()
    {
        //Debug.Log("SetCurrentSceneData() ---------------");
        // Set current scene name
        currentSceneName = SceneManager.GetActiveScene().name;
        //Debug.Log("Setting currentSceneName[" + currentSceneName + "]");

        //Debug.Log("SetCurrentSceneData() currentWorldIndex :: " + currentWorldIndex);

        //if (currentLoadedLevelPackName == null)
        //{
        //    currentLoadedLevelPackName = FindWorldLevelPackname(currentSceneName);
        //}

        currentLevelPackName = FindWorldLevelPackname(currentSceneName);

        //Debug.Log("SetCurrentSceneData() - currentLoadedLevelPackName[" + currentLevelPackName + "]");


        // Set current levelList index number
        if (levelList.Count < 1)
        {
            levelList = DataManager.Instance.GetLevelList(currentLevelPackName);
        }
        currentLevelIndex = levelList.IndexOf(currentSceneName);
        //Debug.Log("currentLevelIndex[" + currentLevelIndex + "]");



        //Debug.Log("Setting currentWorldIndex based on searching [" + currentLevelPackName + "]");
        // Get the current world index in the list
        currentWorldIndex = DataManager.Instance.LevelPackList.IndexOf(currentLevelPackName);

        //Debug.Log("SetCurrentSceneData() - currentWorldIndex[" + currentWorldIndex + "])");

        //Debug.Log("/////////////////////");
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
       
        //Debug.Log("FindWorldLevelPackname(" + sceneName + ")");

        // Loop through each pair
        foreach(KeyValuePair<string, List<string>> dictionaryEntry in DataManager.Instance.WorldLevelSceneDictionary)
        {

            List<string> searchLevelList = dictionaryEntry.Value;

            // Loop through the list for the given key
            foreach (string levelName in searchLevelList)
            {
                if(levelName == sceneName)
                {
                    //Debug.Log("FindWorldLevelPackname(" + sceneName + ") - found match level: returning [" + dictionaryEntry.Key + "]");
                    return dictionaryEntry.Key;
                }

            }

        }

        return null;
    }


}
