using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnuclesDialogue : DialogueInteractableInterface
{
    public openFridge fridgeInteraction;
    private bool hadConversation = false;

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
