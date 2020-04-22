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

            dialogueManager.Enqueue("Hey Honey, it's getting late.");
            dialogueManager.Enqueue("You should be getting ready for bed.");
            dialogueManager.Enqueue("Also could you please put your juice box into the trash can?");
            dialogueManager.Enqueue("You left it in the lounge room on the coffee table.");

            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Come on honey, its getting late. Head up stairs and get to bed.");
        }
    }
}
