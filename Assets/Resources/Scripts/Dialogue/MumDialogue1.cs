using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumDialogue1 : DialogueInteractableInterface
{
    private bool hadConversation = false;
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

            dialogueManager.Enqueue("I say stuff here");

            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("I say stuff here after you have talked to me!");
        }
    }
}
