using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
	public Transform playerGrabPoint;
	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "MainCharacter")
		{
			hasPlayer = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "MainCharacter")
		{
			hasPlayer = false;
		}			
	}

	void Update()
	{
		var rigidbody = GetComponent<Rigidbody>();
		if (beingCarried)
		{
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
			{
				rigidbody.isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				rigidbody.AddForce(playerGrabPoint.forward * throwForce);
			}
		}
		else
		{
			if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && hasPlayer)
			{
				rigidbody.isKinematic = true;
				transform.parent = playerGrabPoint;
				transform.localPosition = Vector3.zero;
				beingCarried = true;
			}
		}
	}
}