using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface used to make any GameObject interactable to trigger dialogue, a long as it has a Transform component
public abstract class DialogueInteractableInterface : MonoBehaviour
{
    // Range the GameObject has to be within relative to the player to trigger
    public float range = 5;

    // Need to link the dialogue manager, so classes can call methods on the dialogue manager such as Enqueueing new dialogue
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method that is called when a controller (can be a player controller script, or different script) determines an action should be triggered
    public abstract void TriggerAction();
}
