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
            dialogueManager.Enqueue("Mum: Hey Honey");
            dialogueManager.Enqueue("Mum: Could you please put your juice box into the trash can?");
            dialogueManager.Enqueue("Mum: Once you have done that you can go and play on your MegaBox 64.");
            dialogueManager.Enqueue("Mum: But dont stay on it to late...");
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Did you put your OJ in the trash? You can play on your MegaBox 64 when you have.");
            dialogueManager.Enqueue("I dont think Dad unplugged it, so it should be next to the TV.");
            dialogueManager.Enqueue("Narrator: Press E on the console to enter the game/interact.");
        }
    }
}
