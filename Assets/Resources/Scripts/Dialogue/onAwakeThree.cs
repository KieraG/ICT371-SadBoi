using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAwakeThree : MonoBehaviour
{
    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;

    [SerializeField]
    private Canvas startingCanvas = null;


    public bool hadConversation = false;

    void Start()
    {
        pc.AllowLooking = false;
        pc.AllowMovement = false;

       
    }

    void Update()
    {
        //Waits until the fade in has completed before displaying the conversation
        if (startingCanvas.GetComponent<CanvasGroup>().alpha == 0 && hadConversation == false)
        {
            mang.Enqueue("Okay I am finally at work!");
            mang.Enqueue("I am a bit later then I thought I would be though...");
            mang.Enqueue("I better try and go quickly go to my desk...");

            hadConversation = true;
        }

        //Allows movement when all dialogue has been read
        if (!mang.DialogQueued() && startingCanvas.GetComponent<CanvasGroup>().alpha == 0)
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }

}
