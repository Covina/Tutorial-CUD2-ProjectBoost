using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	// Rotation Speed
	[SerializeField] private float rotationSpeed = 1f;

	// Update is called once per frame
	void Update () {

		// rotate the object
		transform.Rotate(1f * rotationSpeed, 0f, 0f);

	}
}
