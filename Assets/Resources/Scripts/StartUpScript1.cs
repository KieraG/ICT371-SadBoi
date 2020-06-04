using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript1 : MonoBehaviour
{
    public DialogueManager mang;
    // Start is called before the first frame update
    void Start()
    {
        //This ques the starting stuff.
        mang.Enqueue("Welcome to A Single Voice. Press E or X on the controller to continue dialogue");
        mang.Enqueue("To move around use W A S D or the left Joysticks");
        mang.Enqueue("Press E to interact or X on the controller.");
        mang.Enqueue("Press Spacebar to jump or A on the controller.");
        mang.Enqueue("Somethings in the enviroment may be interactable.");
        mang.Enqueue("Good luck!");
        // If you read this, DM me on discord Arkwolf#0001, really curious if your checking all the code for comments. PS gib HD
    }
}
