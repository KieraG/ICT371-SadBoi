using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMinigame : MonoBehaviour
{
    public DialogueManager dialogueManager;

    [SerializeField]
    private PlayerController pc = null;
    void Start()
    {
        pc.allowMove = false;

        if (PlayerPrefs.GetInt("scoreCounter") == -1)
        {
            dialogueManager.Enqueue("Boss: I am very dissapointed in you! You accepted and passed through 3 incorrect documents! This will cost a lot of time and money for the company to fix your mistakes.");
            dialogueManager.Enqueue("Boss: You are lucky I don't fire you on the spot!");
            dialogueManager.Enqueue("Boss: Go home now through the back door and think about what you have done!");
        }

        else if (PlayerPrefs.GetInt("scoreCounter") >= 0 && PlayerPrefs.GetInt("scoreCounter") <= 5)
        {
            dialogueManager.Enqueue("Boss: Hmmm... You only managed to analyze " + PlayerPrefs.GetInt("scoreCounter") + " spreadsheets, which is a performance that is below the satisfactory level of an employee of this company.");
            dialogueManager.Enqueue("Boss: If you want to ever be considered for a promotion here, I would suggest you start working harder!");
            dialogueManager.Enqueue("Boss: Anyway, go home now through the back door and come back to work with an improved outlook.");
        }

        else if (PlayerPrefs.GetInt("scoreCounter") > 5 && PlayerPrefs.GetInt("scoreCounter") <= 15)
        {
            dialogueManager.Enqueue("Boss: Good job, you correctly analyzed " + PlayerPrefs.GetInt("scoreCounter") + " spreadsheets. The company satisifed with this level of work being done.");
            dialogueManager.Enqueue("Boss: Keep this up and I might one day put in a good word for you to get promoted!");
            dialogueManager.Enqueue("Boss: I think you have earned yourself a rest, head out the back door at the end of the room!");
        }

        else if (PlayerPrefs.GetInt("scoreCounter") > 15)
        {
            dialogueManager.Enqueue("Boss: WOW, AMAZING! Somehow you managed to analyze " + PlayerPrefs.GetInt("scoreCounter") + " spreadsheets. This is a new office record, way beyond the amount workers normally do!");
            dialogueManager.Enqueue("Boss: If I could, I would promote you right here and now! I will definitely recommend you to the higher ups!");
            dialogueManager.Enqueue("Boss: I wish I could keep you here working longer, but I think it is only fair that you go and have some well earned rest! Head out the door at the back to go home.");
        }



    }

    void Update()
    {
        if (!dialogueManager.DialogQueued())
        {
            pc.allowMove = true;
        }
    }

}
