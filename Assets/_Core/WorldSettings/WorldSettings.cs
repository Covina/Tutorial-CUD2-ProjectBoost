using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New World", menuName = "World Setting")]
public class WorldSettings : ScriptableObject {

    public int worldID = 0;

    public string worldName = "";
    public Sprite worldimage;

    public int levelsInPack;

    public float gravityX = 0.0f;
    public float gravityY = -9.81f;

    public float mass = 0.15f;
    public float drag = 0.3f;


    public AudioClip worldMusicLoop;


}
