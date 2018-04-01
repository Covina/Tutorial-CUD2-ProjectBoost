using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHazard : MonoBehaviour {

    private WorldSettings worldSettings;

	// Use this for initialization
	void Start () {

        worldSettings = DataManager.Instance.currentWorldMetaFile;

        if(worldSettings != null)
        {
            Material newMaterial = worldSettings.staticHazardMaterial;

            GetComponent<MeshRenderer>().material = newMaterial;

        }



    }
	

}
