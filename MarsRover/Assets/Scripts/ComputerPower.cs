using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPower : MonoBehaviour
{
	public bool power;

	private GameObject rover;
	public GameObject radarCamCover, camCover;
	public GameObject screenLight, radarLight;

	void Start()
	{
		rover = GameObject.Find("Rover");
		power = false;

		// disable movement if power is disabled
		rover.GetComponent<PlayerMovement>().movementEnabled = power;
		// black out cameras for power being off
//		radarCamCover.SetActive(power);
//		camCover.SetActive(power);
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			// toggle power
			power = !power;

			// black out cameras for power being off
//			radarCamCover.SetActive(power);
//			camCover.SetActive(power);

			if (!power)
			{
				// respawn the power when the power goes off
				rover.GetComponent<PlayerMovement> ().Respawn ();

				// disable movement if power is disabled
				rover.GetComponent<PlayerMovement> ().movementEnabled = false;
			}
			else
			{
				// disable movement if power is disabled
				rover.GetComponent<PlayerMovement>().movementEnabled = power;
			}
		}
	}
}
