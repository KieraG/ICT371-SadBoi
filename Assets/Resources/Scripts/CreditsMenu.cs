using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ToggleMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
