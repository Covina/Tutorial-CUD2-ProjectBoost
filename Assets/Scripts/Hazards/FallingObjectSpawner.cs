using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour {

    // Rock to spawn
    [SerializeField] private GameObject fallingObject;

    // Time delay
    public float spawnEverySeconds;

    private bool continueSpawningRocks = true;

    // Use this for initialization
    void Start () {

        StartCoroutine( Spawner() );

	}
	


    private IEnumerator Spawner()
    {
        //Debug.Log("SpawnRockCoroutine started");

        while(continueSpawningRocks) { 

            yield return new WaitForSeconds(spawnEverySeconds);

            //
            SpawnFallingObject();

        }
   

    }

    /// <summary>
    /// Spawn the Falling Object
    /// </summary>
    private void SpawnFallingObject()
    {
        //Debug.Log("SpawnRock called");

        // small randomization to rock spawn on the X
        Transform objectSpawnTransform = transform;

        // small randomization in X axis
        Vector3 temp = objectSpawnTransform.position;
        temp.x += Random.Range(-3.0f, 3.0f);
        objectSpawnTransform.position = temp;


        // parent the object under Container
        GameObject rock = Instantiate(fallingObject, objectSpawnTransform) as GameObject;

        // house it in the holder
        rock.transform.parent = GameObject.Find("RocksContainer").transform;

    }

}
