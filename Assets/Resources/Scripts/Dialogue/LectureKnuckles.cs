using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureKnuckles : DialogueInteractableInterface
{
    public DialogueManager mang = null;
    public GameObject SlideShowScreen;

    public override void TriggerAction()
    {
        dialogueManager.Enqueue("Do you no da wae?");
        dialogueManager.Enqueue("Follow the arrow ma brotha");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
