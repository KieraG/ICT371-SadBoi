using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start3_3 : DialogueInteractableInterface
{
    public DialogueManager mang;
    void Start()
    {

    }

    void Update()
    {

    }

    public override void TriggerAction()
    {

        dialogueManager.Enqueue("Boss: Please leave through the door at the back of the room...");

    } 
}
