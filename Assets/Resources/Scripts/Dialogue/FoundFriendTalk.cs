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
        if (!hadConversation)
        {
            Vector3 look = new Vector3(pc.gameObject.transform.position.x, this.transform.position.y, pc.gameObject.transform.position.z);
            transform.LookAt(look);

            pc.AllowLooking = false;
            pc.AllowMovement = false;

            dialogueManager.Enqueue("Good Friend 2: Woah, long time no see! How crazy is this protest! Hopefully something good will come out of it! ");
            dialogueManager.Enqueue("Me: Yeah its incredible, however our friend sent me to find you, so you should probably go back to her.");
            dialogueManager.Enqueue("*Phone rings*");
            dialogueManager.Enqueue("Boss: In the full game I will ask the main character that he needs to come in now to work or they are fired. No excuses!");
            dialogueManager.Enqueue("*Phone call ends*");
            dialogueManager.Enqueue("Me: That was my boss, he wants me to go into work!");
            dialogueManager.Enqueue("Good friend: Don't do it, we need you here.");
            dialogueManager.Enqueue("Me: If I don't go, I will get fired!");
            dialogueManager.Enqueue("The good friend and the main character will have a discussion on needing to stand up for what you believe in");
            dialogueManager.Enqueue("Me: I am sorry I have to go to work... I will stay for the next one.");
            dialogueManager.Enqueue("If you really want to man, don't let your work take over you! Just follow the arrow to the next area, that will lead you out of the area to the next scene.");

            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Just follow the arrow my friend.");
        }

        if (!mang.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }
}

