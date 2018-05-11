using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelCard {

    // World
    public int worldID;
    public string worldName;
    
    // Scene
    public string sceneFileName;
    public string sceneLevelName;

    // State
    public bool isLocked;


}
