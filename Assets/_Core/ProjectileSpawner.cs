using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {


    [SerializeField] private GameObject projectileSpawnPoint;
    
    // Projectile to spawn
    [SerializeField] private GameObject projectileObject;


    // Spawn Rate
    public float spawnEverySeconds;

    // Projectile Speed
    public float projectileSpeed;


    private bool isSpawning = true;

    // Use this for initialization
    void Start()
    {

        StartCoroutine(FireProjectile());

    }



    private IEnumerator FireProjectile()
    {
        //Debug.Log("SpawnRockCoroutine started");

        while (isSpawning)
        {

            yield return new WaitForSeconds(spawnEverySeconds);

            //
            SpawnProjectile();

        }


    }

    /// <summary>
    /// Spawn the Projectile
    /// </summary>
    private void SpawnProjectile()
    {
        //Debug.Log("SpawnRock called");

        // Parent the Projectile under Container
        GameObject projectile = Instantiate(projectileObject, projectileSpawnPoint.transform.position, Quaternion.identity) as GameObject;

        // Parent it in the holder
        projectile.transform.parent = GameObject.Find("ProjectileContainer").transform;

        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.up * projectileSpeed;

    }

}
