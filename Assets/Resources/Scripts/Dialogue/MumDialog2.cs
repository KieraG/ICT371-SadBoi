using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumDialog2 : DialogueInteractableInterface
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
            dialogueManager.Enqueue("Mum: Your still playing games?");
            dialogueManager.Enqueue("Mum: Its way passed your bedtime...");
            dialogueManager.Enqueue("Mum: Did you even bother to atleast watch the video that was on.");
            dialogueManager.Enqueue("Mum: Anyway head to bed.");
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Come on, its way past your bedtime.");
        }
    }
}
