using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class WilliamInteraction : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    public bool jobGiven = false;
    public bool jobInitialised = false;
    public bool jobComplete = false;

    private GameObject scene4State = null;

    public AssistantDialogue secretary = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (jobGiven && jobInitialised && !jobComplete && other.gameObject.name == "WilliamPaper")
        {
            other.gameObject.SetActive(false);
            jobComplete = true;
            secretary.williamJobFinished = true;
            dialogueManager.Enqueue("William: Thanks! This will help a lot!");
            dialogueManager.Enqueue("William: While your here, has there been any update when our office is getting fixed up?");
            dialogueManager.Enqueue("William: It's been three months and the air con is still broken, along with the fridges and the elevator.");
            dialogueManager.Enqueue("Me: The repair men have been difficult to get a hold of. Let me check with my secretary.");
            scene4State.GetComponent<Scene4State>().arrowState = "SecretaryPerson";
        }			
    }

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (jobGiven)
        {
            if (!jobInitialised)
            {
                dialogueManager.Enqueue(
                    "William: Hey boss, I need some information on this client. Do you have any info?");
                dialogueManager.Enqueue(
                    "Me: I have something on my desk in my office. I'll grab it for you and be right back William.");
                scene4State.GetComponent<Scene4State>().arrowState = "WilliamPaper";
                jobInitialised = true;
            }
            else
            {
                if (!jobComplete)
                {
                    dialogueManager.Enqueue("William: Hey boss, I still need that information in your office. Could you please grab it for me?");
                }
                else
                {
                    dialogueManager.Enqueue("William: Thanks for the help boss");
                }
            }
        }
    }
}
