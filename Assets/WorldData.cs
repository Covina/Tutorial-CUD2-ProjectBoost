using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour {


    public WorldSettings worldSettingsObject;


    public float GetGravityY()
    {

        //Debug.Log("WorldName " + worldSettingsObject.worldName);
        //Debug.Log("Gravity in this object is " + worldSettingsObject.gravityY);

        return worldSettingsObject.gravityY;
        
    }

}
