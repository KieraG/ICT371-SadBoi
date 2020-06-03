using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAfterDialogue : DialogueInteractableInterface
{
    void Start()
    {

    }

    void Update()
    {

    }

    public override void TriggerAction()
    {

        dialogueManager.Enqueue("Boss: Please go to your cubicle at the end of the room");

    } 
}
