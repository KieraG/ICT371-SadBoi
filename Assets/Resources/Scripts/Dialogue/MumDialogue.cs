using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumDialogue : DialogueInteractableInterface
{
    private bool hadConversation = false;
    public override void TriggerAction()
    {
        dialogueManager.Enqueue("Me: Hello mother");
        dialogueManager.Enqueue("Mother: Hello child");
        if (!hadConversation) {
            dialogueManager.Enqueue("Mother: What do you want for breakfast?");
            dialogueManager.Enqueue("Me: Meatballs");
            dialogueManager.Enqueue("Mother: No...");
            hadConversation = true;
        } else {
            dialogueManager.Enqueue("Mother: What do you actually want for breakfast?");
            dialogueManager.Enqueue("Me: Meatballs");
            dialogueManager.Enqueue("Mother: I already told you, NO!");
        }
    }
}
