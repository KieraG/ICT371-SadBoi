using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class AssistantDialogue : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    public bool gaveWilliamJob = false;
    public bool williamJobFinished = false;

    public bool gaveAirconJob = false;
    public bool airconJobFinished = false;

    public bool gaveSteveJob = false;

    private GameObject scene4State = null;
    public WilliamInteraction william = null;
    public SteveInteraction steve = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (!gaveWilliamJob)
        {
            dialogueManager.Enqueue("Secretary: Good morning boss, how can I help?");
            dialogueManager.Enqueue("Me: What tasks have I got at hand?");
            dialogueManager.Enqueue(
                "Secretary: Your employees need your help around the office, then you've got an interview with a potential recruit.");
            dialogueManager.Enqueue("Secretary: William is just around the corner, please check with him first.");
            gaveWilliamJob = true;
            william.jobGiven = true;
            scene4State.GetComponent<Scene4State>().arrowState = "William";
        }
        else
        {
            if (!williamJobFinished)
            {
                dialogueManager.Enqueue("Secretary: I believe William still needs your help.");
            }
            else
            {
                if (!gaveAirconJob)
                {
                    dialogueManager.Enqueue("Me: What's the run down on repairing the office?");
                    dialogueManager.Enqueue(
                        "Secretary: We haven't found anyone available to fix the elevator or kitchen appliances yet.");
                    dialogueManager.Enqueue(
                        "Secretary: The air conditioner was booked to be repaired yesterday, though the repairman never showed up.");
                    dialogueManager.Enqueue(
                        "Secretary: Little irresponsible considering they took the whole system apart, though I hear they're quite busy.");
                    dialogueManager.Enqueue("Me: The aircon needs to be fixed ASAP, its getting unbearably hot.");
                    dialogueManager.Enqueue("Me: I'll take a shot at repairing it myself");
                    dialogueManager.Enqueue(
                        "Secretary: You will need to reassemble the vents in the room next door by picking up vents and placing them down.");
                    dialogueManager.Enqueue("Secretary: Use the interact key to pick up/drop vents");
                    dialogueManager.Enqueue("Secretary: Let me know if you need any help");
                    scene4State.GetComponent<Scene4State>().arrowState = "";
                    gaveAirconJob = true;
                }
                else
                {
                    if (!airconJobFinished)
                    {
                        dialogueManager.Enqueue(
                            "Secretary: Reassemble the vents in the room next door by picking up vents and placing them down.");
                        dialogueManager.Enqueue("Secretary: Use the interact key to pick up/drop vents");
                    }
                    else
                    {
                        if (!gaveSteveJob)
                        {
                            dialogueManager.Enqueue("Secretary: Good job boss.");
                            scene4State.GetComponent<Scene4State>().arrowState = "Steve";
                            gaveSteveJob = true;
                            steve.jobGiven = true;
                        }

                        if (!steve.jobComplete)
                        {
                            dialogueManager.Enqueue(
                                "Secretary: Steve wants some help downstairs, please provide him with some assistance.");
                            dialogueManager.Enqueue(
                                "Secretary: After you help Steve, make sure to interview the potential recruit.");
                        }
                        else
                        {
                            dialogueManager.Enqueue(
                                "Secretary: Make sure to interview the potential recruit.");
                        }
                    }
                }
            }
        }
    }
}