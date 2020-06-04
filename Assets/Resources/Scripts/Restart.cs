using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        // Death trigger script, when you hit this, you restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
