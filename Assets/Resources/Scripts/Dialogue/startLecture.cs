using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLecture : DialogueInteractableInterface
{
    private bool hadConversation = false;
    public DialogueManager mang = null;
    public GameObject SlideShowScreen;
    private DialogueManager.DoAction Action = null;

    void Start()
    {
        Action = delegate
        {
            var Waypoint = GameObject.Find("Waypoint");
            Waypoint.GetComponent<Waypoint>().SetPosition(GameObject.Find("DeskTrigger").transform.position);
            Waypoint.GetComponent<Waypoint>().Offset = new Vector3(0, 2, 0);
            var DeskTrigger = GameObject.Find("DeskTrigger");
            DeskTrigger.GetComponent<BoxCollider>().enabled = true;
        };
    }

    void Update()
    {

    }

    public override void TriggerAction()
    {
        if (!hadConversation)
        {

            dialogueManager.Enqueue("Professor: Welcome to Climatology class.");
            dialogueManager.Enqueue("Professor: In the final version of the game, I will talk about the effects and the causes of climate change and show a short video on screen.");
            dialogueManager.Enqueue("Me: I will go and sit at my desk to complete a quiz on climate change.", Action);
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Professor: Still can't find your desk? It is at the back left of the room.", Action);
        }
    }

    public void QuizEnd()
    {
        string dialogueText;
        float percentageCorrect = GlobalValues.correctQuestions / (GlobalValues.correctQuestions + GlobalValues.incorrectQuestions) * 100;
        if (percentageCorrect > 99)
        {
            dialogueText =  "I got every question correct, I did a really great job here. ";
        }
        else if (percentageCorrect > 75)
        {
            dialogueText = "I got most of the questions correct, I'm pretty happy with the result but I should try to get a better result next time";
        }
        else if (percentageCorrect > 50)
        {
            dialogueText = "I got about half of the questions correct, I should try to get better for next time. ";
        }
        else
        {
            dialogueText = "Me: I really need to study climate change more to get a better result on the next test. ";
        }
        dialogueManager.Enqueue(dialogueText);
    }
}
