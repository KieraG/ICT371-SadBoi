using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript1 : MonoBehaviour
{
    public DialogueManager mang;
    // Start is called before the first frame update
    void Start()
    {
        mang.Enqueue("Welcome to the first scene of the game. Press E to continue dialogue");
        mang.Enqueue("First off, a bit about the purpose of the game.");
        mang.Enqueue("The game's main purpose is to show how throughout a person's life, not matter their age, their impact on climate change.");
        mang.Enqueue("It will involve discussion and teaching, analysing the causes and effects of climate change, such as the earth’s rotation, vegetation, greenhouse gases, solar activity, and aerosols.");
        mang.Enqueue("Lastly it will teach the player how they themselves can look back at their own effect on climate change in real life, and what they can change to help with lower the effects of it.");
        mang.Enqueue("More details, such as the learning objectives, and proof of the approval of the game is in the document titled the ICT371 Concept Document.");
        mang.Enqueue("Moving on to the first scene, this is where the player first starts out as a child, and where they get one their first tastes on their effect of climate change, no matter how small.");
        mang.Enqueue("This scenes purpose is also introduce the controls, how to interact with objects, and the general feel of the game.");
        mang.Enqueue("First go talk to your mum, who is in the kitchen. Use the arrow keys to move (if using a keyboard)");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
