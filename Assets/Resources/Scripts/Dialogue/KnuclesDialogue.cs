using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to knuckles, who is inside a fridge, if the fridge is open
// The first conversation is different to the following conversations
public class KnuclesDialogue : DialogueInteractableInterface
{
    // Fridge script to check if the fridge is currently open
    public openFridge fridgeInteraction;

    // Whether the user has already had a conversation with the NPC
    private bool hadConversation = false;

    // Initial range to reset when the door is open
    private float initialRange;

    void Start()
    {
        initialRange = range;
    }

    void Update()
    {
        if (fridgeInteraction.openMore) {
            range = 0;
        } else {
            range = initialRange;
        }
    }

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (!hadConversation) {
            dialogueManager.Enqueue("Me: Hello my god, how may i serve you??");
            dialogueManager.Enqueue("???: HELLO BRADDAH");
            dialogueManager.Enqueue("Me: Hello?");
            hadConversation = true;
        } else {
            dialogueManager.Enqueue("Me: What even is this");
            dialogueManager.Enqueue("???: do u no de wae?");
            dialogueManager.Enqueue("Me: ???");
        }
    }
}
