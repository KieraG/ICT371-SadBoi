using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundFriendTalk : DialogueInteractableInterface
{
    public bool hadConversation = false;

    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void TriggerAction()
    {

        //If the player presses E and talks to their 2nd friend
        if (!hadConversation)
        {
            // The friend will turn and look at the player depending on which direction they came from
            Vector3 look = new Vector3(pc.gameObject.transform.position.x, this.transform.position.y, pc.gameObject.transform.position.z);
            transform.LookAt(look);

            //Stops movement
            pc.AllowLooking = false;
            pc.AllowMovement = false;

            //Displays dialogue
            dialogueManager.Enqueue("Good Friend 2: Yoooooo! You finally arrived sleepy head. Happy birthday! The protest here is really popping off.");
            dialogueManager.Enqueue("Me: Yeah it really is, hopefully the government will really listen to our concerns.");
            dialogueManager.Enqueue("Good Friend 2: Lets hope! We should get a sign and join in with the crowd");
            dialogueManager.Enqueue("Me: Yeah sure thing, I will ju...");
            dialogueManager.Enqueue("*Phone rings*");
            dialogueManager.Enqueue("Boss: Hey, I need you to drop everything and come in work NOW!");
            dialogueManager.Enqueue("Me: Ah... sorry, I am really busy at the moment, I am at the climate change rally and I got the day off...");
            dialogueManager.Enqueue("Boss: I don't care, that is not as important as you coming to work now!! I expect you to be here within the hour!");
            dialogueManager.Enqueue("Me: But...");
            dialogueManager.Enqueue("Boss: NO BUTS! If you don't come, you will be fired!");
            dialogueManager.Enqueue("*Phone call ends*");
            dialogueManager.Enqueue("Me: That was my boss, he wants me to go into work!");
            dialogueManager.Enqueue("Good Friend 2: Don't do it, we need you here helping the cause! You even got the day off for this!");
            dialogueManager.Enqueue("Me: If I don't go, I will get fired!");
            dialogueManager.Enqueue("Good Friend 2: You are letting that job dictate your life! You really need to stand up for yourself there...");
            dialogueManager.Enqueue("Me: I know, but if I just stay a bit longer at the job I could get a promotion!");
            dialogueManager.Enqueue("If that is what you want, just remember that there are bigger things in life then just work. Trust me this would have been worth it, for you and everyone else.");
            dialogueManager.Enqueue("Me: I am sorry I have to go to work now... I will definitely stay for the next one.");
            dialogueManager.Enqueue("Okay... and remember don't let your work take over you! Just follow the arrow to the next area, that will lead you out of the area, away from the protestors.");

            hadConversation = true;
        }

        //If the player has finished the main dialogue, the friend says this if they interact with them again
        else
        {
            dialogueManager.Enqueue("Just follow the arrow my friend.");
        }

        //allows movemment if all dialogue has been read
        if (!mang.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }
}

