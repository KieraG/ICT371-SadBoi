using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Stops the player from moving and starts the quizher
        if (!GlobalValues.finishedQuiz)
        {
            GameObject.Find("Waypoint").GetComponentInChildren<Renderer>().enabled = false;
            var Player = GameObject.Find("Main Character").GetComponent<PlayerController>();
            Player.AllowLooking = false;
            Player.AllowMovement = false;
            Player.transform.position = GameObject.Find("PlayerChair").transform.position;
            GameObject.Find("Main Camera").transform.forward = GameObject.Find("PlayerChair").transform.forward;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            Cursor.lockState = CursorLockMode.None;
        }


    }
}
