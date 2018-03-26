using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New World", menuName = "Wold Setting")]
public class WorldSettings : ScriptableObject {

    public string worldName = "";
    public Sprite worldimage;

    public float gravityX = 0.0f;
    public float gravityY = -9.81f;

    public float mass = 0.15f;
    public float drag = 0.3f;


    public AudioClip worldMusicLoop;


}
