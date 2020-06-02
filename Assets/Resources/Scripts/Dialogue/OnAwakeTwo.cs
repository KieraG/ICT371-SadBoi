using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager mang;

    void Start()
    {
        mang.Enqueue("Me: I've finally arrived at my lecture, I should go and talk to the Professor.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
