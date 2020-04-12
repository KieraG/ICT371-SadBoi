using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFridge : MonoBehaviour
{
    private bool openMore = true;
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
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && openMore)
        {
            transform.Rotate(new Vector3(0,-40,0).normalized,40f );
            openMore = false;
        }

        else if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !openMore)
        {
            transform.Rotate(new Vector3(0, 40, 0).normalized, 40f);
            openMore = true;
        }
    }

}


