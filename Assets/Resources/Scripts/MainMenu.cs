using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    void Start()
    {
        // Make sure the cursor is visible for the main menu scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        credits.SetActive(false);
    }

    void Update()
    {
        //Xbox button A
        if (Input.GetKeyDown("joystick button 0"))
        {
            PlayScene();
        }
        //Xbox button B
        if (Input.GetKeyDown("joystick button 1"))
        {
            Quit();
        }
        //Xbox button X
        if (Input.GetKeyDown("joystick button 2"))
        {

            ToggleCredits();
        }
        //Xbox button Y
        if (Input.GetKeyDown("joystick button 3"))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(11, LoadSceneMode.Single);            
        }
    }

    // Changes the scene to scene 1 when called, should be called externally (e.g. by a UI button)
    public void PlayScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ToggleCredits()
    {
        credits.SetActive(true);
        gameObject.SetActive(false);
    }

    // Quits the program when called, should be called externally (e.g. by a UI button)
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
