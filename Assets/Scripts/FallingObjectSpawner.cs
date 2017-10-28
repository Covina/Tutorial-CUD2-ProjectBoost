using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour {

    // Rock to spawn
    [SerializeField] private GameObject rockObject;

    // Time delay
    public float spawnEverySeconds;

    private bool continueSpawningRocks = true;

    // Use this for initialization
    void Start () {

        StartCoroutine( SpawnRockCoroutine() );

	}
	


    private IEnumerator SpawnRockCoroutine()
    {
        Debug.Log("SpawnRockCoroutine started");

        while(continueSpawningRocks) { 

            yield return new WaitForSeconds(spawnEverySeconds);

            //
            SpawnRock();

        }
   

    }


    private void SpawnRock()
    {
        Debug.Log("SpawnRock called");

        // small randomization to rock spawn on the X
        Transform rockSpawnTransform = transform;

        Vector3 temp = rockSpawnTransform.position;

        temp.x += Random.Range(-2.0f, 2.0f);

        rockSpawnTransform.position = temp;

        // parent the object under Container
        GameObject rock = Instantiate(rockObject, rockSpawnTransform) as GameObject;

        // house it in the holder
        rock.transform.parent = GameObject.Find("RocksContainer").transform;

    }

}
