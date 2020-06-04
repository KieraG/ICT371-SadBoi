using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager mang;

    void Start()
    {
        mang.Enqueue("Me: It's my first day at University, I should go speak to the Lecturer.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
