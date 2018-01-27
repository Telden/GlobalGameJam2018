using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float rotationSpeed;
	public float movementSpeed;

	private Rigidbody rb;

	private int speedScale;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		CheckInput();

		Debug.Log(rb.velocity.magnitude);
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
		// rotate left or right
		if (left)
		{
			transform.Rotate(transform.up * Time.deltaTime * rotationSpeed * -1);
		}
		else
		{
			transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
		}
	}
}