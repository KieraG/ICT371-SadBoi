using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteJuice : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "juice")
		{
			Destroy(other.gameObject);
		}

	}
}
