using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start3_3 : DialogueInteractableInterface
{
    public DialogueManager mang;

    [SerializeField]
    private EndOfMinigame eom = null;
    void Start()
    {

    }

    void Update()
    {

    }

    public override void TriggerAction()
    {
        if(eom.hadConversation)
            mang.Enqueue("Boss: Please leave through the door at the back of the room...");

    } 
}
