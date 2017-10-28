using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    private float ttl;

    // how long do we sink the rock before destroying it
    private float animationTime = 2.0f;

    private bool animateRockRemoval = false;

    void Awake()
    {

        ttl = Random.Range(5.0f, 10.0f);

    }

    // Use this for initialization
    void Start()
    {

        StartCoroutine(RemoveRock());


    }

    void Update()
    {

        if(animateRockRemoval) {


            // move it downward at a speed over each frame.
            transform.position = new Vector3(
                                            transform.position.x, 
                                            transform.position.y - (10 * Time.deltaTime), 
                                            transform.position.z
                                            );

        }

    }



    private IEnumerator RemoveRock()
    {

        yield return new WaitForSeconds(ttl);


        gameObject.GetComponent<MeshCollider>().enabled = false;

        animateRockRemoval = true;

        yield return new WaitForSeconds(animationTime);

        // remove the rock
        Destroy(gameObject);
    }
}
