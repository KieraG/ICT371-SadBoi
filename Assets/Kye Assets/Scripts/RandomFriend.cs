using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFriend : MonoBehaviour
{
    public GameObject blocker = null;
    public GameObject transitionArea = null;
    public GameObject arrow = null;

    [SerializeField]
    private GameObject speaker = null;

    [SerializeField]
    private FoundFriendTalk talkingToFriend = null;

    private bool noMoreCall = false;
    // Start is called before the first frame update
    void Start()
    {

        charRandLocation();

    }

    // Update is called once per frame
    void Update()
    {
        if (talkingToFriend.hadConversation && !talkingToFriend.mang.DialogQueued() && !noMoreCall)
        {
            blocker.GetComponent<Transition>().continueOn = true;
            transitionArea.SetActive(true);
            arrow.SetActive(true);
            noMoreCall = true;
        }
    }


    void charRandLocation()
    {
        // Places the main characters friend in a random postion (within bounds) and a semi-random rotation
        transform.position = new Vector3(Random.Range(35f, 70f), 0f, Random.Range(20f, 40f));

        Vector3 look = new Vector3(speaker.gameObject.transform.position.x, this.transform.position.y, speaker.gameObject.transform.position.z);
        transform.LookAt(look);
    }

    private void OnCollisionStay(Collision collision)
    {

        // If the character collides with anything but the ground, change position so a new one to prevent colliding
        if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player")
        {
            charRandLocation(); //Change its location if its colliding with objects due to random placement
        }

            
    }
}
