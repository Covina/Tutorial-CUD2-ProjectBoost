using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour {
    

    // Time delay
    public float spawnEverySeconds;

    [Header("Falling Object")]
    [SerializeField] private GameObject fallingObject;
    public float minSecondsAlive;
    public float maxSecondsAlive;


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

        rock.GetComponent<FallingObject>().SetTTL(minSecondsAlive, maxSecondsAlive);

        // house it in the holder
        rock.transform.parent = GameObject.Find("RocksContainer").transform;

    }

}
