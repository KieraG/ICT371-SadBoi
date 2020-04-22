using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFriend : MonoBehaviour
{
    public GameObject blocker = null;
    public GameObject transitionArea = null;
    public GameObject arrow = null;

    // Start is called before the first frame update
    void Start()
    {

        charRandLocation();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void charRandLocation()
    {
        // Places the main characters friend in a random postion (within bounds) and a semi-random rotation
        transform.position = new Vector3(Random.Range(35f,70f),0f, Random.Range(20f, 40f));
        transform.rotation = Quaternion.Euler(0f, Random.Range(50f, 150f), 0f);
    }

    private void OnCollisionStay(Collision collision)
    {

        //Checks to see if the friend is colliding with the player. If they initate speech and turn on the transition to the next scene.
        if (collision.gameObject.tag == "Player" )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {


                blocker.GetComponent<Transition>().continueOn = true;
                transitionArea.SetActive(true);
                arrow.SetActive(true);
            }
                
        }
        // If the character collides with anything but the ground, change position so a new one to prevent colliding
        else if (collision.gameObject.tag != "Ground")
        {
            charRandLocation(); //Change its location if its colliding with objects due to random placement
        }

            
    }
}
