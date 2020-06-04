using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public DialogueManager dialogueManager;

    [SerializeField]
    private PlayerController pc = null;

    [SerializeField]
    private GameObject boss = null;

    [SerializeField]
    private Camera mainCamera = null;

    [SerializeField]
    private GameObject arrow = null;

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
            Vector3 bossLook = new Vector3(pc.gameObject.transform.position.x, boss.transform.position.y, pc.gameObject.transform.position.z);
            Vector3 playerLook = new Vector3(boss.transform.position.x + 5, pc.gameObject.transform.position.y, boss.transform.position.z);

            arrow.SetActive(true);

            boss.transform.LookAt(bossLook);
            mainCamera.transform.LookAt(playerLook);


            pc.AllowLooking = false;
            pc.AllowMovement = false;

            dialogueManager.Enqueue("Boss: You finally made it. You are ten minutes late! You should be on call and be able to come to work at any time during work hours!");
            dialogueManager.Enqueue("Me: I am sorry... I was at the climate change rally, which is about trying to help futu...  ");
            dialogueManager.Enqueue("Boss: It doesn't matter! You need to start putting your work first!");
            dialogueManager.Enqueue("Boss: If you want to every make it up the corporate ladder you need to grow up and move away from silly things like \"Climate Change rallies\".");
            dialogueManager.Enqueue("Boss: Trust me, it is better in the long run for you.");
            dialogueManager.Enqueue("Me: But sir, I believe we can balance out both our jobs and commitment to causes such as climate change...");
            dialogueManager.Enqueue("Boss: Enough with that talk, you will see once you have more responsiblities, that this worrying about these issues are unimportant!");
            dialogueManager.Enqueue("Me: I see, yes sir. Will I at least be able to leave early to go back to the rally if my work is done quickly?");
            dialogueManager.Enqueue("Boss: I can't let you go as you need to stay late! Trust me there is a lot of work to be done!");
            dialogueManager.Enqueue("Boss: Now go to your desk and start working. Its the one with the hotdog in it.");

            Destroy(gameObject);
        }

        if (!dialogueManager.DialogQueued())
        {
            pc.AllowLooking = true;
            pc.AllowMovement = true;
        }
    } 
}
