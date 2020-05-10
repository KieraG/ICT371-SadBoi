using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureTheatreController : MonoBehaviour
{
    public bool ShowWaypoint = true;
    private GameObject Waypoint = null;
    private Vector3 WaypointStart = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        Waypoint = GameObject.Find("DeskWaypoint");
        WaypointStart = Waypoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowWaypoint)
        {
            Waypoint.GetComponentInChildren<Renderer>().enabled = true;
            UpdateWaypoint();
        }
        else
        {
            Waypoint.GetComponentInChildren<Renderer>().enabled = false;
        }
        
    }

    void UpdateWaypoint()
    {
        const float amplitude = 0.5f;
        const float frequency = 0.5f;
        double level = amplitude * Math.Sin(2 * Math.PI * frequency * Time.time);

        Vector3 newPos = WaypointStart;
        newPos.y += (float)level;
        Waypoint.transform.position = newPos;
    }

}
