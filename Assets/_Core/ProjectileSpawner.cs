using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    [Header("GameObject Admin")]
    [SerializeField] private GameObject projectileSpawnPoint;
    
    // Projectile to spawn
    [SerializeField] private GameObject projectileObject;

    [SerializeField] private GameObject projectileContainer;

    [Header("Projectile")]
    // Spawn Rate
    public float spawnEverySeconds;

    // Projectile Speed
    public float projectileSpeed;

    public Vector3 directionVector;

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
        projectile.transform.SetParent(projectileContainer.transform);

        // Fire it in specified direction
        projectile.GetComponent<Rigidbody>().velocity = directionVector * projectileSpeed;

    }

}
