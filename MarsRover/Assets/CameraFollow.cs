using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject cameraTarget;
	[Range(0, 1)]
	public float followSpeed;
	[Range(0, 1)]
	public float turnSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, followSpeed);
		transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.transform.rotation, turnSpeed);
	}
}
