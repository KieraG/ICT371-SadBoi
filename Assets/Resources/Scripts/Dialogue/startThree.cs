using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThree : MonoBehaviour
{
    public DialogueManager dialogueManager;

    [SerializeField]
    private PlayerController pc = null;

    private bool hadConversation = false;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            pc.AllowLooking = false;
            pc.AllowMovement = false;

            dialogueManager.Enqueue("Boss: You finally made it. I need you to start working as soon as possible.");
            dialogueManager.Enqueue("Boss: In the final version of the game, I will give a speech at how important is that you put your work first and how it will set you up later in life.");
            dialogueManager.Enqueue("Me: I will then ask whether or not I can return to the climate change rally, as it is important issue that needs to be changed, and everyone person is needed at the rally.");
            dialogueManager.Enqueue("Boss: I can't let you go as you need to stay late. I will then go on about that the climate change isn't a problem and you must sacrafice it if you want to get anywhere in life.");
            dialogueManager.Enqueue("Boss: Now go to your desk and start working. Its the one with the hotdog in it.");
            hadConversation = true;
            Destroy(gameObject);
        }
        /*else
        {
            dialogueManager.Enqueue("Boss: Still can't find your desk? It is at the back left of the room.");

        }*/

        if (!dialogueManager.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
           
        }
    } 
}
