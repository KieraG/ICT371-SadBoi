using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class AssistantDialogue : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC
    private bool hadConversation = false;
    
    private GameObject scene4State = null;
    public WilliamInteraction william = null;

    void Start()
    {
        scene4State = GameObject.Find("State");
    }
    
    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (!hadConversation) {
            Debug.Log("trigger action");
            dialogueManager.Enqueue("Secretary: Good morning boss, how can I help?");
            dialogueManager.Enqueue("Me: What tasks have I got at hand?");
            dialogueManager.Enqueue("Secretary: Your employees need your help around the office, then you've got an interview with a potential recruit.");
            dialogueManager.Enqueue("Secretary: William is just around the corner, please check with him first.");
            hadConversation = true;
            william.jobGiven = true;
            scene4State.GetComponent<Scene4State>().arrowState = "William";
        } else {
            dialogueManager.Enqueue("Secretary: Your employees need your help around the office, then you've got an interview with a potential recruit.");
        }
    }
}