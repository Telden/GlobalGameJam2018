using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
    public GameObject[] items;
    public Vector3 radar;
    public float angleThreshold;

	void Start ()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
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
            Destroy(other.gameObject);
        }
    }


}
