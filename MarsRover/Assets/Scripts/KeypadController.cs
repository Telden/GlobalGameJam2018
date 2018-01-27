using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour {

	public GameObject[] keys;
	Vector3[] keyPositions;
	[Range(0, 1)]
	public float keyPressSpeed;
	public float keyPressDistance;

	private AudioSource auds;

	// Use this for initialization
	void Start () {
		keyPositions = new Vector3[9];

		auds = GetComponent<AudioSource>();

		for (int i = 0; i < keys.Length; i++) 
		{
			keyPositions [i] = keys [i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Left3"))
			keys [0].transform.position = Vector3.Lerp (keys [0].transform.position, keyPositions [0] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [0].transform.position = Vector3.Lerp (keys [0].transform.position, keyPositions [0], keyPressSpeed);

		if (Input.GetButton ("Mid3"))
			keys [1].transform.position = Vector3.Lerp (keys [1].transform.position, keyPositions [1] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [1].transform.position = Vector3.Lerp (keys [1].transform.position, keyPositions [1], keyPressSpeed);

		if (Input.GetButton ("Right3"))
			keys [2].transform.position = Vector3.Lerp (keys [2].transform.position, keyPositions [2] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [2].transform.position = Vector3.Lerp (keys [2].transform.position, keyPositions [2], keyPressSpeed);

		if (Input.GetButton ("Left2"))
			keys [3].transform.position = Vector3.Lerp (keys [3].transform.position, keyPositions [3] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [3].transform.position = Vector3.Lerp (keys [3].transform.position, keyPositions [3], keyPressSpeed);

		if (Input.GetButton ("Mid2"))
			keys [4].transform.position = Vector3.Lerp (keys [4].transform.position, keyPositions [4] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [4].transform.position = Vector3.Lerp (keys [4].transform.position, keyPositions [4], keyPressSpeed);

		if (Input.GetButton ("Right2"))
			keys [5].transform.position = Vector3.Lerp (keys [5].transform.position, keyPositions [5] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [5].transform.position = Vector3.Lerp (keys [5].transform.position, keyPositions [5], keyPressSpeed);

		if (Input.GetButton ("Left1"))
			keys [6].transform.position = Vector3.Lerp (keys [6].transform.position, keyPositions [6] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [6].transform.position = Vector3.Lerp (keys [6].transform.position, keyPositions [6], keyPressSpeed);

		if (Input.GetButton ("Mid1"))
			keys [7].transform.position = Vector3.Lerp (keys [7].transform.position, keyPositions [7] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [7].transform.position = Vector3.Lerp (keys [7].transform.position, keyPositions [7], keyPressSpeed);

		if (Input.GetButton ("Right1"))
			keys [8].transform.position = Vector3.Lerp (keys [8].transform.position, keyPositions [8] - Vector3.up * keyPressDistance, keyPressSpeed);
		else
			keys [8].transform.position = Vector3.Lerp (keys [8].transform.position, keyPositions [8], keyPressSpeed);

		for (int i = 1; i <= 3; i++)
		{
			if (Input.GetButtonDown ("Left" + i))
			{
				auds.Stop();
				auds.pitch = Random.Range (0.9f, 1.1f);
				auds.Play();
			}
		}

		for (int i = 1; i <= 3; i++)
		{
			if (Input.GetButtonDown ("Mid" + i))
			{
				auds.Stop();
				auds.pitch = Random.Range (0.9f, 1.1f);
				auds.Play();
			}
		}

		for (int i = 1; i <= 3; i++)
		{
			if (Input.GetButtonDown ("Right" + i))
			{
				auds.Stop();
				auds.pitch = Random.Range (0.9f, 1.1f);
				auds.Play();
			}
		}
	}
}
