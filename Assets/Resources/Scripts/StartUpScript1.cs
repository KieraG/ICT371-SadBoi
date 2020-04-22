using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpScript1 : MonoBehaviour
{
    public DialogueManager mang;
    // Start is called before the first frame update
    void Start()
    {
        mang.Enqueue("Out of Character: Press E to interact and move over dialog.");
        mang.Enqueue("Out of Character: This scenes purpose is introduce the controlls.");
        mang.Enqueue("Out of Character: How to interact with objects.");
        mang.Enqueue("Out of Character: Also the general feel of the game.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
