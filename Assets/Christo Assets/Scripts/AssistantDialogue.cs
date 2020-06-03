using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class AssistantDialogue : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    private bool gaveWilliamJob = false;
    public bool williamJobFinished = false;

    private bool gaveAirconJob = false;
    public bool airconJobFinished = false;
    
    private GameObject scene4State = null;
    public WilliamInteraction william = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }
    
    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (!gaveWilliamJob) {
            Debug.Log("trigger action");
            dialogueManager.Enqueue("Secretary: Good morning boss, how can I help?");
            dialogueManager.Enqueue("Me: What tasks have I got at hand?");
            dialogueManager.Enqueue("Secretary: Your employees need your help around the office, then you've got an interview with a potential recruit.");
            dialogueManager.Enqueue("Secretary: William is just around the corner, please check with him first.");
            gaveWilliamJob = true;
            william.jobGiven = true;
            scene4State.GetComponent<Scene4State>().arrowState = "William";
        } else {
            if (!williamJobFinished)
            {
                dialogueManager.Enqueue("Secretary: I believe William still needs your help.");
            }
            else
            {
                if (!gaveAirconJob)
                {
                    dialogueManager.Enqueue("Me: What's the run down on repairing the office?");
                    dialogueManager.Enqueue("Secretary: We haven't found anyone available to fix the elevator or kitchen appliances yet.");
                    dialogueManager.Enqueue("Secretary: The air conditioner was booked to be repaired yesterday, though the repairman never showed up.");
                    dialogueManager.Enqueue("Secretary: Little irresponsible considering they took the whole system apart, though I hear they're quite busy.");
                    dialogueManager.Enqueue("Me: The aircon needs to be fixed ASAP, its getting unbearably hot.");
                    dialogueManager.Enqueue("Me: I'll take a shot at repairing it myself");
                    gaveAirconJob = true;
                }
                else
                {
                    
                }
            }
        }
    }
}