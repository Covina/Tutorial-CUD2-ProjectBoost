using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour {


    // Time delay
    [Header("Spawner")]
    public float spawnEverySeconds;
    public GameObject spawnContainer;

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
        //Transform objectSpawnTransform = transform;

        // small randomization in X axis
        Vector3 fallingRockSpawnPosition = transform.position;
        fallingRockSpawnPosition.x += Random.Range(-3.0f, 3.0f);
    
        // Spawn the falling object
        GameObject rock = Instantiate(fallingObject) as GameObject;

        // house it in the holder
        rock.transform.SetParent(spawnContainer.transform);

        // move the rock a bit
        rock.transform.position = fallingRockSpawnPosition;

        // Set Time to Live
        rock.GetComponent<FallingObject>().SetTTL(minSecondsAlive, maxSecondsAlive);



    }

}
