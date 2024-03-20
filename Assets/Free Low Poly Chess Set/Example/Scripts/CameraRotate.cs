using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public float Speed = 8;

	void FixedUpdate () {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime, Space.World);
	}
}
