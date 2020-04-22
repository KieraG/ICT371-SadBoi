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
            dialogueManager.Enqueue("Here the player and their mum will talk about the video on the tv, and discuss about how even small things, such as putting trash into the bin, will help. This will be present in the final game.");
            dialogueManager.Enqueue("Mum: Hey Honey, it's getting late.");
            dialogueManager.Enqueue("Mum: You should be getting ready for bed.");
            dialogueManager.Enqueue("Mum: Also could you please put your juice box into the trash can?");
            dialogueManager.Enqueue("Mum: You left it in the lounge room on the coffee table.");
            dialogueManager.Enqueue("In the final game, the player will be play a chasey minigame on their videogame console before going to bed.");
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Come on honey, its getting late. Head up stairs and get to bed.");
        }
    }
}
