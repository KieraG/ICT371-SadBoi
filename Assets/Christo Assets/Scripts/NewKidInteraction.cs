using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Dialogue that lets the user talk to their mum
// The first conversation is different to the following conversations
public class NewKidInteraction : DialogueInteractableInterface
{
    // Whether the user has already had a conversation with the NPC

    private DialogueManager.DoAction NextSceneAction = null;

    public bool jobGiven = false;

    void Start()
    {
        scene4State = GameObject.Find("State");
        NextSceneAction = delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        };
    }
    
    private GameObject scene4State = null;

    // Determines what to do when the action is triggered
    public override void TriggerAction()
    {
        if (jobGiven)
        {
            dialogueManager.Enqueue(
                "Potential Recruit: Good morning.");
            dialogueManager.Enqueue(
                "Me: Good morning, what was your name again?");
            dialogueManager.Enqueue(
                "Potential Recruit: It's Fredrick sir.");
            dialogueManager.Enqueue(
                "Me: Fredrick, I've already read through your resume and your references and you seem quite capable.");
            dialogueManager.Enqueue(
                "Fredrick: Thank you sir.");
            dialogueManager.Enqueue(
                "Me: I am sure you will have no trouble completing the work we have here even in these rougher times.");
            dialogueManager.Enqueue(
                "Me: Before I decide to hire you, what do you think you could bring to this company?");
            dialogueManager.Enqueue(
                "Fredrick: Using my specialised skillset I believe I can optimise your workplace to be more efficient.");
            dialogueManager.Enqueue(
                "Fredrick: I also wish to help promote a company culture that focuses on protecting the environment.");
            dialogueManager.Enqueue(
                "Fredrick: Every year the temperature of the globe keeps heating up due to our lack of action, I believe this company could make a strong difference.");
            dialogueManager.Enqueue(
                "Me: I like the enthusiasm as I use to be like you, but I don't think we'll have the time for that kind of thing here.");
            dialogueManager.Enqueue(
                "Me: If you join us you will not have the time to be focusing on insignificant problems like global warmining, you should be focusing on your job.");
            dialogueManager.Enqueue(
                "Fredrick: I completeley understand, the job is always number 1.");
            dialogueManager.Enqueue(
                "", NextSceneAction);
        }
    }
}
