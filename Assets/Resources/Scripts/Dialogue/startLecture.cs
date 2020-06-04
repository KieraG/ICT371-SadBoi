using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLecture : DialogueInteractableInterface
{
    private bool hadConversation = false;
    public DialogueManager mang = null;
    public GameObject SlideShowScreen;
    private DialogueManager.DoAction Action = null;
    private DialogueManager.DoAction EndQuizAction = null;

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

        EndQuizAction = delegate
        {
            var Waypoint = GameObject.Find("Waypoint");
            Waypoint.GetComponent<Waypoint>().SetPosition(GameObject.Find("DoorTrigger").transform.position);
            Waypoint.GetComponent<Waypoint>().Offset = new Vector3(0.5f, 2, -0.5f);
            var DoorTrigger = GameObject.Find("DoorTrigger");
            DoorTrigger.GetComponent<MeshCollider>().enabled = true;
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
            dialogueManager.Enqueue("Professor: Please go sit at your desk, and we will begin a quiz on Climate Change.");
            dialogueManager.Enqueue("Professor: Take a look at the board before you sit down, you might learn something useful.");
            dialogueManager.Enqueue("Me: I should take a look at the board and then go sit at my desk.", Action);
            hadConversation = true;
        }
        else
        {
            dialogueManager.Enqueue("Professor: Still can't find your desk? It is the middle desk in the front row.", Action);
        }
    }

    public void QuizEnd()
    {
        string dialogueText;
        float percentageCorrect = GlobalValues.correctQuestions / (GlobalValues.correctQuestions + GlobalValues.incorrectQuestions) * 100;
        if (percentageCorrect > 99)
        {
            dialogueText = "Me: I got every question correct, I did a really great job here. ";
        }
        else if (percentageCorrect > 75)
        {
            dialogueText = "Me: I got most of the questions correct, I'm pretty happy with the result but I should try to get a better result next time";
        }
        else if (percentageCorrect > 50)
        {
            dialogueText = "Me: I got about half of the questions correct, I should try to get better for next time. ";
        }
        else
        {
            dialogueText = "Me: I really need to study climate change more to get a better result on the next test. ";
        }
        dialogueManager.Enqueue(dialogueText);
        dialogueManager.Enqueue("Me: The lecture is over now, I should leave", EndQuizAction);
    }
}
