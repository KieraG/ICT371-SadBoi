using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAwakeThree : MonoBehaviour
{
    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;

    [SerializeField]
    private GameObject boss = null;

    void Start()
    {
        pc.AllowLooking = false;
        pc.AllowMovement = false;

        mang.Enqueue("Okay I am finally at work!");
        mang.Enqueue("This is the second part of the Adult arc of the game. The area involves the players work office, which contains cubicles, a small kitchen and other small areas.");
        mang.Enqueue("I better go talk to my boss, who is right in front of the hallway. Press E to interact with him.");
       
    }

    void Update()
    {
        if (!mang.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }

}
