﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteJuice : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		//When the object is placed in a given collider, destroy the juice
		if (other.gameObject.name == "juice")
		{
			Destroy(other.gameObject);
		}

	}
}
