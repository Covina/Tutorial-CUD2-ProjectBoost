using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    // Rotation Speed
    [SerializeField] private float rotationSpeedX = 0f;
    [SerializeField] private float rotationSpeedY = 0f;
    [SerializeField] private float rotationSpeedZ = 0f;

    // Update is called once per frame
    void Update () {

		// rotate the object
		transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);

	}
}
