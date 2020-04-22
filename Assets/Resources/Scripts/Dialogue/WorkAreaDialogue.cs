using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkAreaDialogue : MonoBehaviour
{
    public DialogueManager mang;
    void Start()
    {

    }

    void Update()
    {

    }


     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Player")
         {
            mang.Enqueue("This is my office, where I will perform my work I will need");
            mang.Enqueue("When I collide with my desk it will start a minigame, in where I must go quickly go through paperwork under a certain amount of time, like a puzzle.");
            mang.Enqueue("However the mini game has yet to be completed, so the table will now take you to the next scene.");
            Destroy(this.gameObject);
        }

     } 
}

