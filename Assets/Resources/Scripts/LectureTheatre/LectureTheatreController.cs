using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureTheatreController : MonoBehaviour
{
    private GameObject Professor = null;
    private GameObject Waypoint = null;
    private GameObject Desk = null;

    // Start is called before the first frame update
    void Start()
    {
        Professor = GameObject.Find("Professor");
        Waypoint = GameObject.Find("Waypoint");
        Desk = GameObject.Find("DeskTrigger");

        Waypoint.GetComponent<Waypoint>().SetPosition(Professor.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


}
