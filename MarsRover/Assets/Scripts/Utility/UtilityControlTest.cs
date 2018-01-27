using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTest : MonoBehaviour
{
	void Start ()
	{
		
	}

	// numlock has to be activated for the num pad to actually work!
	void Update ()
	{
		if (Input.GetButtonDown("Left1"))
		{
			Debug.Log("left 1");
		}
		if (Input.GetButtonDown("Left2"))
		{
			Debug.Log("left 2");
		}
		if (Input.GetButtonDown("Left3"))
		{
			Debug.Log("left 3");
		}

		if (Input.GetButtonDown("Mid1"))
		{
			Debug.Log("mid 1");
		}
		if (Input.GetButtonDown("Mid2"))
		{
			Debug.Log("mid 2");
		}
		if (Input.GetButtonDown("Mid3"))
		{
			Debug.Log("mid 3");
		}

		if (Input.GetButtonDown("Right1"))
		{
			Debug.Log("right 1");
		}
		if (Input.GetButtonDown("Right2"))
		{
			Debug.Log("right 2");
		}
		if (Input.GetButtonDown("Right3"))
		{
			Debug.Log("right 3");
		}
	}
}