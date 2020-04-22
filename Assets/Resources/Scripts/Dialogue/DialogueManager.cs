using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Queue of all currently-queued dialogue
    private Queue<string> dialogQueue = new Queue<string>();

    public GameObject dialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        HideDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogQueued()) {
            DisplayDialogue(dialogQueue.Peek());
        } else {
            HideDialogue();
        }
    }

    private void DisplayDialogue(string dialogue)
    {
        dialogueCanvas.SetActive(true);
        dialogueCanvas.GetComponentInChildren<TextMeshProUGUI>().text = dialogue;
    }

    private void HideDialogue()
    {
        dialogueCanvas.SetActive(false);
    }

    public void IterateDialogue()
    {
        if (DialogQueued()) {
            dialogQueue.Dequeue();
        }
    }

    public void Enqueue(string dialogue)
    {
        dialogQueue.Enqueue(dialogue);
    }

    public bool DialogQueued()
    {
        return dialogQueue.Count > 0;
    }
}
