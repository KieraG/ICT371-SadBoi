using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateObjectController : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 2")))
        {
            // Used to activate object
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
