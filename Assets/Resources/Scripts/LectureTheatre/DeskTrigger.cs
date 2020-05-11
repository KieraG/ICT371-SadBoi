using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Waypoint").GetComponentInChildren<Renderer>().enabled = false;
        var Player = GameObject.Find("Main Character").GetComponent<PlayerController>();
        Player.AllowLooking = false;
        Player.AllowMovement = false;

    }
}
