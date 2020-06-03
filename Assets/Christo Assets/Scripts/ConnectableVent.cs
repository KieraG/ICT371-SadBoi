using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableVent : MonoBehaviour
{
    public bool isActive = false;

    public ConnectableVent connectedVent1 = null;

    public ConnectableVent connectedVent2 = null;

    public string ventType;
    
    public DialogueManager dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
        setVentActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vent") && !isActive)
        {
            Debug.Log(isActive);
            Debug.Log(canAcceptVent());
        }

        if (!isActive && other.gameObject.CompareTag("Vent") && canAcceptVent())
        {
            if (other.gameObject.GetComponent<ConnectableVentLoose>().ventType == ventType)
            {
                other.gameObject.SetActive(false);
                setVentActive(true);
            }
            else if (!dialogueManager.DialogQueued())
            {
                dialogueManager.Enqueue("Me: This vent doesn't fit, maybe I should try another one");   
            }
        }			
    }

    private bool canAcceptVent()
    {
        bool output = false;
        Debug.Log("Connected");
        Debug.Log(connectedVent1.isActive);
        if (connectedVent1 != null && connectedVent1.isActive)
        {
            output = true;
        } else if (connectedVent2 != null && connectedVent2.isActive)
        {
            output = true;
        }

        return output;
    }

    private void setVentActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
        this.isActive = isActive;
    }
}
