using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class WilliamInteraction : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    public bool jobGiven = false;
    private bool jobInitialised = false;
    private bool jobComplete = false;

    private GameObject scene4State = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "WilliamPaper")
        {
            jobComplete = true;
            dialogueManager.Enqueue("William: Thanks! This will help a lot!");
            dialogueManager.Enqueue("William: While your here, has there been any update when our office is getting fixed up?");
            dialogueManager.Enqueue("William: It's been three months and the air con is still broken, along with the fridges and the elevator.");
            dialogueManager.Enqueue("Me: The repair men have been difficult to get a hold of. Let me check with my secretary.");
            scene4State.GetComponent<Scene4State>().arrowState = "SecretaryPerson";
            other.gameObject.SetActive(false);
        }			
    }

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        Debug.Log("trigger william action");
        Debug.Log(jobGiven);
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
                    dialogueManager.Enqueue(
                        "William: Hey boss, I still need that information in your office. Could you please grab it for me?");
                }
            }
        }
    }
}
