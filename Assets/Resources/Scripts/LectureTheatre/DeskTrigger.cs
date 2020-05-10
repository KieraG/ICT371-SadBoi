using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    public GameObject LectureTheatre = null;

    
    void OnTriggerEnter(Collider other)
    {
        LectureTheatre.GetComponent<LectureTheatreController>().ShowWaypoint = false;
    }
}
