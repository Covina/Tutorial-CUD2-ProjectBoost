using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public static DataManager Instance;

    public const string LEVELPACK01 = "LevelPack01";
    public const string LEVELPACK02 = "LevelPack02";


    private List<string> levelPackList = new List<string>();
    public List<string> LevelPackList
    {
        get
        {
            return levelPackList;
        }

    }

    public Dictionary<string, List<string>> worldLevelSceneDictionary = new Dictionary<string, List<string>>();
    public Dictionary<string, List<string>> WorldLevelSceneDictionary
    {
        get
        {
            return worldLevelSceneDictionary;
        }

    }


    public List<ScriptableObject> worldMetaFiles;

    public WorldSettings currentWorldMetaFile;

    void Awake()
    {
        MakeSingleton();

        GenerateWorldLevelPackList();

        GenerateWorldLevelDictionary();

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

    private void GenerateWorldLevelPackList()
    {
        levelPackList.Add(LEVELPACK01);
        levelPackList.Add(LEVELPACK02);
    }

    private void GenerateWorldLevelDictionary()
    {
        // WORLD 1 - TRAINING GROUND
        string keyPack01 = LEVELPACK01;

        List<string> levelListPack01 = new List<string>();
        levelListPack01.Add("01_01");
        levelListPack01.Add("01_02");
        levelListPack01.Add("01_03");
        levelListPack01.Add("01_04");
        levelListPack01.Add("01_05");
        levelListPack01.Add("01_06");
        levelListPack01.Add("01_07");
        levelListPack01.Add("01_08");
        levelListPack01.Add("01_09");
        levelListPack01.Add("01_10");

        // ADD TO DICTIONARY
        worldLevelSceneDictionary.Add(keyPack01, levelListPack01);



        // WORLD 2 - Mercury 2160
        string keyPack02 = LEVELPACK02;

        List<string> levelListPack02 = new List<string>();
        levelListPack02.Add("02_01");
        levelListPack02.Add("02_02");
        //levelListPack01.Add("01_03");
        //levelListPack01.Add("01_04");
        //levelListPack01.Add("01_05");
        //levelListPack01.Add("01_06");
        //levelListPack01.Add("01_07");
        //levelListPack01.Add("01_08");
        //levelListPack01.Add("01_09");
        //levelListPack01.Add("01_10");

        // Add it to the dictionary
        worldLevelSceneDictionary.Add(keyPack02, levelListPack02);
    }

    /// <summary>
    /// Return the scene name list for a given content pack
    /// </summary>
    /// <param name="packName"></param>
    /// <returns></returns>
    public List<string> GetLevelList(string packName)
    {
        if(worldLevelSceneDictionary.ContainsKey(packName))
        {
            return worldLevelSceneDictionary[packName];
        }

        Debug.LogWarning("DataManager.GetLevelList(" + packName + ") returned null");
        return null;
    }


    public void SetCurrentWorldMetaFile()
    {

    }

}
