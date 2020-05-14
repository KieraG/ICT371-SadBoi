using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLecture : DialogueInteractableInterface
{
    private bool hadConversation = false;
    public DialogueManager mang = null;
    public GameObject SlideShowScreen;
    private  DialogueManager.DoAction Action = null;

    void Start()
    {
        Action = delegate
        {
            var Waypoint = GameObject.Find("Waypoint");
            Waypoint.GetComponent<Waypoint>().SetPosition(GameObject.Find("DeskTrigger").transform.position);
            Waypoint.GetComponent<Waypoint>().Offset = new Vector3(0,2,0);
            var DeskTrigger = GameObject.Find("DeskTrigger");
            DeskTrigger.GetComponent<BoxCollider>().enabled = true;
        };
    }

    void Update()
    {

    }

    public override void TriggerAction()
    {
        if (!hadConversation)
        {

            dialogueManager.Enqueue("Professor: Welcome to Climatology class.");
            dialogueManager.Enqueue("Professor: In the final version of the game, I will talk about the effects and the causes of climate change and show a short video on screen.");
            dialogueManager.Enqueue("Me: I will go and sit at my desk to complete a quiz on climate change.", Action);
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Professor: Still can't find your desk? It is at the back left of the room.", Action);
        }
    }
}
