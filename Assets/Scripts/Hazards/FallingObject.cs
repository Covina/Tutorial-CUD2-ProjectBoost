using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    private float ttl;

    // how long do we sink the rock before destroying it
    private float animationTime = 2.0f;

    private bool animateRockRemoval = false;

    private bool isFalling = true;


	private float rotationDirectionY = 1.0f;
	private float rotationDirectionZ = 1.0f;

    void Awake()
    {

        ttl = Random.Range(5.0f, 10.0f);

    }

    // Use this for initialization
    void Start()
    {

        StartCoroutine(RemoveRock());

		rotationDirectionY = Random.Range(-5.0f, 5.0f);
		rotationDirectionZ = Random.Range(-5.0f, 5.0f);
    }

    void Update ()
	{

		if (animateRockRemoval) {


			// move it downward at a speed over each frame.
			transform.position = new Vector3 (
				transform.position.x, 
				transform.position.y - (10 * Time.deltaTime), 
				transform.position.z
			);

		}

		if (isFalling) {

			transform.Rotate (new Vector3(0f, rotationDirectionY, rotationDirectionZ) );
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


    // Stop rotation if it hits something
    private void OnCollisionEnter (Collision target)
	{

		isFalling = false;

    }
}
