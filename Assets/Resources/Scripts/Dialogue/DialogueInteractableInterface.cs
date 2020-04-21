using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueInteractableInterface : MonoBehaviour
{
    public int range = 5;

    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void TriggerAction();
}
