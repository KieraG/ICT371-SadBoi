using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playScene;

    public void PlayScene()
    {
        SceneManager.LoadScene(playScene);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
