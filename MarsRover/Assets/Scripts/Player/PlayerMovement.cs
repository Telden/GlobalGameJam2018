using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float rotationSpeed;
	public float movementSpeed;
	[Range(0,1)]
	public float lerpValue;

	private Rigidbody rb;

	private int speedScale;

	public LayerMask groundMask;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		CheckInput();
		RotateToNormal();
	}

	private void CheckInput()
	{
		speedScale = 0;

		// left wheels
		if (Input.GetButton("Left1"))
		{
			RotateRover(true);
			speedScale++;
		}
		if (Input.GetButton("Left2"))
		{
			RotateRover(true);
			speedScale++;
		}
		if (Input.GetButton("Left3"))
		{
			RotateRover(true);
			speedScale++;
		}

		// right wheels
		if (Input.GetButton("Right1"))
		{
			RotateRover(false);
			speedScale++;
		}
		if (Input.GetButton("Right2"))
		{
			RotateRover(false);
			speedScale++;
		}
		if (Input.GetButton("Right3"))
		{
			RotateRover(false);
			speedScale++;
		}

		Vector3 tmpVel = transform.forward * movementSpeed * speedScale;
		rb.velocity = new Vector3(tmpVel.x, rb.velocity.y, tmpVel.z);
	}

	private void RotateRover(bool left)
	{
		Vector3 tmpAngle;

		// rotate left or right
		if (left)
		{
			tmpAngle = transform.up * Time.deltaTime * rotationSpeed * -1;
			transform.Rotate(0, tmpAngle.y, 0);
		}
		else
		{
			tmpAngle = transform.up * Time.deltaTime * rotationSpeed;
			transform.Rotate(0, tmpAngle.y, 0);
		}
	}

	private void RotateToNormal()
	{
		RaycastHit hit;
		Physics.Raycast(transform.position, transform.up * -1, out hit, groundMask);
		// not made by me lol, Nick wouldn't email me the link what an ass
		transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.FromToRotation(this.transform.up, hit.normal) * this.transform.rotation, lerpValue);
	}
}