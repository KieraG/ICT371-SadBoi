using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class SteveInteraction : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    public bool jobGiven = false;
    public bool jobInitialised = false;
    public bool jobComplete = false;

    public NewKidInteraction newKid = null;

    private GameObject scene4State = null;

    public AssistantDialogue secretary = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (jobGiven && jobInitialised && !jobComplete && other.gameObject.CompareTag("Book"))
        {
            if (other.gameObject.name == "GreenBook")
            {
                other.gameObject.SetActive(false);
                jobComplete = true;
                dialogueManager.Enqueue(
                    "Steve: Thanks for the book. I believe you have an interview in the room behind me.");
                scene4State.GetComponent<Scene4State>().arrowState = "NewKid";
            }
            else
            {
                dialogueManager.Enqueue(
                    "Steve: I think that's the wrong book. The one you were looking for was green.");
            }
        }
    }

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        Debug.Log("STEVE");
        if (jobGiven)
        {
            if (!jobInitialised)
            {
                dialogueManager.Enqueue(
                    "Steve: Whew its so hot. Any idea when the aircon is getting fixed?");
                dialogueManager.Enqueue(
                    "Me: I just fixed the aircon for upstairs and downstairs.");
                dialogueManager.Enqueue(
                    "Steve: Damn, it feels a little colder but just barely.");
                dialogueManager.Enqueue(
                    "Steve: Anyway I'm having trouble understanding this concept for tomorrow's presentation, could you help?");
                dialogueManager.Enqueue(
                    "Me: There's a really good green book in the storage room I'll get for you. Be right back.");
                scene4State.GetComponent<Scene4State>().arrowState = "";
                jobInitialised = true;
            }
            else
            {
                if (!jobComplete)
                {
                    dialogueManager.Enqueue("Steve: Any luck finding the book? I believe you said it was a green one in the storage room.");
                    newKid.jobGiven = true;
                }
                else
                {
                    dialogueManager.Enqueue("Steve: Thanks for the book. I believe you have an interview in the room behind me.");
                }
            }
        }
    }
}
