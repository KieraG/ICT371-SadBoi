using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class MumDialogue : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    private bool hadConversation = false;

    // Determines what to do when the action is triggered
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
