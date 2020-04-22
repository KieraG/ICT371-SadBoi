using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager mang;

    void Start()
    {
        mang.Enqueue("Welcome to the second scene of the game, when the main character is a young hero");
        mang.Enqueue("In the final game, the main character will start at their home, and will have the choice of either taking their car or bus university. It's designed to show how a simple and seemingly small choice can add up throughout the players life.");
        mang.Enqueue("Once the player gets to university, they then talk to the professor, who give an interactive quiz. The player must try and get as many questions right as possible, in the final version of the game.");
        mang.Enqueue("However for this protype, talk to the professor (Press E to talk to him), then sit down at your seat at the back of the class to move onto the next scene.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
