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
        Player.transform.position = GameObject.Find("PlayerChair").transform.position;
        GameObject.Find("Main Camera").transform.forward = GameObject.Find("PlayerChair").transform.forward;

    }
}
