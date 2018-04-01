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

    private float reductionAmount;

    // Use this for initialization
    void Start()
    {

        if(ttl == 0f)
        {
            ttl = Random.Range(3.0f, 6.0f);
        }

        rotationDirectionY = Random.Range(-5.0f, 5.0f);
        rotationDirectionZ = Random.Range(-5.0f, 5.0f);

        // Reduction amount per frame
        reductionAmount = (transform.localScale.x / animationTime);

    }

    void Update ()
	{

		if (animateRockRemoval) {


            //// move it downward at a speed over each frame.
            //transform.position = new Vector3 (
            //	transform.position.x, 
            //	transform.position.y - (10 * Time.deltaTime), 
            //	transform.position.z
            //);


            // Scale it downward at a speed over each frame.
            transform.localScale = new Vector3(
                transform.localScale.x - (reductionAmount * Time.deltaTime),
                transform.localScale.y - (reductionAmount * Time.deltaTime),
                transform.localScale.z - (reductionAmount * Time.deltaTime)
            );

        }

        if (isFalling) {

			transform.Rotate (new Vector3(0f, rotationDirectionY, rotationDirectionZ) );
		}

    }



    private IEnumerator RemoveRock()
    {

        yield return new WaitForSeconds(ttl);


        //if (gameObject.GetComponent<MeshCollider>() != null)
        //{
        //    gameObject.GetComponent<MeshCollider>().enabled = false;
        //}

        //if (gameObject.GetComponent<SphereCollider>() != null)
        //{
        //    gameObject.GetComponent<SphereCollider>().enabled = false;
        //}


        animateRockRemoval = true;

        yield return new WaitForSeconds(animationTime);

        //Debug.Log("TTL for " + gameObject.name + ": " + ttl);
        // remove the rock
        Destroy(gameObject);
    }


    // Stop rotation if it hits something
    private void OnCollisionEnter (Collision target)
	{

		isFalling = false;

        StartCoroutine(RemoveRock());

    }

    public void SetTTL(float min, float max)
    {
        ttl = Random.Range(min, max);
    }
}
