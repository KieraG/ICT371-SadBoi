using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Make sure the cursor is visible for the main menu scene
        Cursor.lockState = CursorLockMode.None;
    }

    // Changes the scene to scene 1 when called, should be called externally (e.g. by a UI button)
    public void PlayScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    // Quits the program when called, should be called externally (e.g. by a UI button)
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
