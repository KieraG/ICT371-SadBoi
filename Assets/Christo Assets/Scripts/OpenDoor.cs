using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool open = false;

    public Vector3 openAngle = new Vector3(0, 270, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2")) && open)
        {
            Debug.Log("close");
            transform.Rotate(new Vector3(0, 0, 0));
            open = false;
        }

        else if (collision.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2")) && !open)
        {
            Debug.Log("open");
            transform.Rotate(openAngle);
            open = true;
        }

    }
}
