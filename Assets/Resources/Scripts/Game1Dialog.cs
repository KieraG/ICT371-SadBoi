using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hadConversation = false;
    public DialogueManager dialogueManager;
    void Start()
    {
        if (!hadConversation)
        {
            dialogueManager.Enqueue("Welcome to Chasebot5000");
            dialogueManager.Enqueue("See that ball over there...");
            dialogueManager.Enqueue("He is coming for you!!!.");
            dialogueManager.Enqueue("RUUUUUUUUUUUUUUUUUUUUUUN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueManager.DialogQueued())
        {
            hadConversation = true;
        }
    }
}

