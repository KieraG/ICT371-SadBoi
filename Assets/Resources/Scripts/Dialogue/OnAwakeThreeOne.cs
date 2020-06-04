using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeThreeOne : MonoBehaviour
{
    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;

    [SerializeField]
    private Canvas startingCanvas = null;

    public bool hadConversation = false;
    // Start is called before the first frame update
    void Start()
    {
        pc.AllowLooking = false;
        pc.AllowMovement = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (startingCanvas.GetComponent<CanvasGroup>().alpha == 0 && hadConversation == false)
        {
            mang.Enqueue("Good Friend: Hey, you finally made it! The protest against the governments lack of action on reducing the effect of climate change has just kicked into full gear! (Press E to contunue)");
            mang.Enqueue("Good Friend: You can hear the chants of all the protestors, its crazy, hopefully it leads to some good changes!");
            mang.Enqueue("Good Friend: Peaceful protesting, where people gather into groups to express their want of change, its just one of many things people can do with their local government to help make a difference.");
            mang.Enqueue("Good Friend: Some other are ways include writing to your local memeber of parliment, creating pro-climate clubs and participating in climate change initatives.");
            mang.Enqueue("Good Friend: Hopefully we can celebrate your 19th birthday after the protests!");
            mang.Enqueue("Good Friend: Ah I also almost forgot! I lost our other friend within the crowd! Can you help me find them! Remember they always wear their shoes with the purple beanie.");
            mang.Enqueue("Press E to interact with our friend when you find them!");
            hadConversation = true;
        }


        if (!mang.DialogQueued() && startingCanvas.GetComponent<CanvasGroup>().alpha == 0)
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    }
}
