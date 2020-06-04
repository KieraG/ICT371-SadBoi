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

            dialogueManager.Enqueue("Boss: You finally made it. I need you to start working as soon as possible.");
            dialogueManager.Enqueue("Boss: In the final version of the game, I will give a speech at how important is that you put your work first and how it will set you up later in life.");
            dialogueManager.Enqueue("Me: I will then ask whether or not I can return to the climate change rally, as it is important issue that needs to be changed, and everyone person is needed at the rally.");
            dialogueManager.Enqueue("Boss: I can't let you go as you need to stay late. I will then go on about that the climate change isn't a problem and you must sacrafice it if you want to get anywhere in life.");
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
