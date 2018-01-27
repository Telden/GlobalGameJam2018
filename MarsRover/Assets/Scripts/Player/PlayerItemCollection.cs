using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
	[Header("Old radar system")]
    public GameObject[] items;
    public Vector3 radar;
    public float angleThreshold;

	[Header("Level info")]
	public int currentLevel = 1;

	[Header("Level spawn points")]
	public Transform level1Spawn;
	public Transform level2Spawn;
	public Transform level3Spawn;

	void Start ()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
		currentLevel = 1;
    }

	void Update ()
    {
        radar = transform.forward;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                Vector3 toItem = items[i].transform.position;
                toItem = new Vector3(toItem.x, transform.position.y, toItem.z);
                Debug.DrawLine(transform.position, toItem);
                if (Vector3.Angle(toItem - transform.position, radar) < angleThreshold)
                {
                    GetComponent<Renderer>().material.color = Color.green;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item" && Input.GetButtonDown("Mid3"))
        {
			switch (currentLevel)
			{
				case 1:
				{
					GetComponent<PlayerMovement>().defPosition = level2Spawn.position;
					GetComponent<PlayerMovement>().defRotation = level2Spawn.rotation;
					currentLevel++;
					break;
				}
				case 2:
				{
					GetComponent<PlayerMovement>().defPosition = level3Spawn.position;
					GetComponent<PlayerMovement>().defRotation = level3Spawn.rotation;
					currentLevel++;
					break;
				}
				case 3:
				{
					//GetComponent<PlayerMovement>().defPosition = level3Spawn.position;
					//GetComponent<PlayerMovement>().defRotation = level3Spawn.rotation;
					//currentLevel++;
					break;
				}
				default:
				{
					Debug.Log("PLAYERITEMCOLLECTION ERROR: " + currentLevel + " is not a valid level number.");
					break;
				}
			}

			GetComponent<PlayerMovement>().Respawn();
            Destroy(other.gameObject);
        }
    }


}
