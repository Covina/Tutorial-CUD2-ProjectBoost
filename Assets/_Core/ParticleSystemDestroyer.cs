using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour {

    ParticleSystem ps;

	// Use this for initialization
	void Start () {

        // Get access to the particle system
        ps = GetComponent<ParticleSystem>();

        // total up the amount of time to live
        float ttlTime = ps.main.duration + ps.main.startLifetime.constantMax;

        // start self destruct sequence
        StartCoroutine(DestroyParticles(ttlTime));

	}
	
    /// <summary>
    /// Countdown to particle system destruction
    /// </summary>
    /// <param name="ttl"></param>
    /// <returns></returns>
    public IEnumerator DestroyParticles(float ttl)
    {
        yield return new WaitForSeconds(ttl);

        Destroy(gameObject);

    }
}
