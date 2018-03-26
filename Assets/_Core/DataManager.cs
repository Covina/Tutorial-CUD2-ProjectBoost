using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public static DataManager Instance;

    public const string LEVELPACK01 = "LevelPack01";
    public const string LEVELPACK02 = "LevelPack02";


    public Dictionary<string, List<string>> worldLevelSceneList = new Dictionary<string, List<string>>();
    public Dictionary<string, List<string>> WorldLevelSceneList
    {
        get
        {
            return worldLevelSceneList;
        }

    }

    void Awake()
    {
        MakeSingleton();

        GenerateWorldLevelList();

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

    private void GenerateWorldLevelList()
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
        worldLevelSceneList.Add(keyPack01, levelListPack01);



        // WORLD 2 - Mercury 2160
        string keyPack02 = LEVELPACK02;

        List<string> levelListPack02 = new List<string>();
        levelListPack01.Add("02_01");
        levelListPack01.Add("02_02");
        //levelListPack01.Add("01_03");
        //levelListPack01.Add("01_04");
        //levelListPack01.Add("01_05");
        //levelListPack01.Add("01_06");
        //levelListPack01.Add("01_07");
        //levelListPack01.Add("01_08");
        //levelListPack01.Add("01_09");
        //levelListPack01.Add("01_10");

        // Add it to the dictionary
        worldLevelSceneList.Add(keyPack02, levelListPack02);
    }

    /// <summary>
    /// Return the scene name list for a given content pack
    /// </summary>
    /// <param name="packName"></param>
    /// <returns></returns>
    public List<string> GetLevelList(string packName)
    {
        if(worldLevelSceneList.ContainsKey(packName))
        {
            return worldLevelSceneList[packName];
        }

        Debug.LogWarning("DataManager.GetLevelList(" + packName + ") returned null");
        return null;
    }

}
