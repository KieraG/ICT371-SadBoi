using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeThreeOne : MonoBehaviour
{
    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;

    // Start is called before the first frame update
    void Start()
    {
        pc.AllowLooking = false;
        pc.AllowMovement = false;

        mang.Enqueue("Good Friend: Hey, you finally made it! This is the third scene in the life of the main character. Here we are in the middle of the city, protesting against the governments lack of action on reducing the effect on climate change! (Press E to contunue)");
        mang.Enqueue("Good Friend: You can hear the chants of all the protestors, its crazy, hopefully it leads to some good changes!");
        mang.Enqueue("Good Friend: We will then go to talk about the different ways you can take action against climate change to help push the change in government policy, and what you personally can do about it, in the full game!");
        mang.Enqueue("Good Friend: I almost forgot! I lost our other friend within the crowd! Can you help me find them! Remember they always wear their shoes with the purple shoelaces! (This person randomly appears in the game, meaning his hiding location on the map is different each time!");
        mang.Enqueue("Press E to interact with our friend when you find them!");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mang.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }
}
