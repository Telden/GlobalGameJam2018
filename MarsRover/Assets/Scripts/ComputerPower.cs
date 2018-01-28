using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPower : MonoBehaviour
{
	public bool power;

	public GameObject radarCover, camCover, radarLight, screenLight, radarBlink;

	private GameObject rover;

	void Start ()
	{
		rover = GameObject.Find("Rover");
        rover.GetComponent<PlayerMovement>().movementEnabled = false;
        power = false;

		radarCover.SetActive (true);
		camCover.SetActive (true);
		radarLight.SetActive (false);
		screenLight.SetActive (false);

		radarBlink.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			if (power)
			{
				power = false;

				radarCover.SetActive (true);
				camCover.SetActive (true);
				radarLight.SetActive (false);
				screenLight.SetActive (false);
				radarBlink.SetActive (false);

                rover.GetComponent<PlayerMovement>().Respawn();
                rover.GetComponent<PlayerMovement>().movementEnabled = false;
            }
			else
			{

                rover.GetComponent<PlayerMovement>().movementEnabled = true;
				power = true;

				radarCover.SetActive (false);
				camCover.SetActive (false);
				radarLight.SetActive (true);
				screenLight.SetActive (true);
				radarBlink.SetActive (true);
            }
		}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
