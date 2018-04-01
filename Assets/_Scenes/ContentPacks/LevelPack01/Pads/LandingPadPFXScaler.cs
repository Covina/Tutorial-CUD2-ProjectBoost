using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPadPFXScaler : MonoBehaviour {

    private Transform parentTransform;

	// Use this for initialization
	void Start () {

        parentTransform = transform.parent.transform;
        Vector3 parentLocalScale = parentTransform.localScale;


        ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();

        var shapeModule = ps.shape;

        //Debug.Log("Setting LandingPadPFX size from " + gameObject.GetComponent<ParticleSystem>().shape.scale + " + to " + parentLocalScale);

        shapeModule.scale = parentLocalScale;
        

    }
	

}
