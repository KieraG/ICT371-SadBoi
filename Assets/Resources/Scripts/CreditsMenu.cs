using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    
    public GameObject credits;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void ToggleMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
