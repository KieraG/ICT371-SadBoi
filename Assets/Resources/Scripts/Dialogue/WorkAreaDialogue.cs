using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkAreaDialogue : MonoBehaviour
{
    public DialogueManager mang;

    [SerializeField]
    private PlayerController pc = null;
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
            pc.AllowLooking = false;
            pc.AllowMovement = false;

            mang.Enqueue("Home sweet office cubicle...");
            mang.Enqueue("I can't believe my boss, he really just doesn't get the damage climate change is doing to planet.");
            mang.Enqueue("But maybe he is right? Maybe I should stop worrying about it and concentrate on my work...");
            mang.Enqueue("Anyway I better get started on approving spreadsheets.");

            Destroy(this.gameObject);
         }

        if (!mang.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    } 
}

