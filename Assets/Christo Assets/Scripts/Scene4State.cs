using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Scene4State : MonoBehaviour
{
    private GameObject waypoint = null;
    public string arrowState = "SecretaryPerson";

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GameObject.Find("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowState.Length > 0)
        {
            waypoint.GetComponent<Waypoint>().SetPosition(GameObject.Find(arrowState).transform.position);
        } else
        {
            waypoint.GetComponent<Waypoint>().SetPosition(new Vector3(-1000, -1000, -1000));
        }
    }
}
