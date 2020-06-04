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

    private GameObject secretary;

    private GameObject scene4State;
    
    private static ConnectableVent[] _vents;
    
    // Start is called before the first frame update
    void Start()
    {
        setVentActive(isActive);
        scene4State = GameObject.Find("State");
        secretary = GameObject.Find("SecretaryPerson");
        if (_vents == null)
        {
            _vents = GameObject.FindObjectsOfType<ConnectableVent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        // don't start the minigame early
        if ((secretary.GetComponent<AssistantDialogue>().gaveAirconJob))
        {
            if (!isActive && other.gameObject.CompareTag("Vent") && canAcceptVent())
            {
                if (other.gameObject.GetComponent<ConnectableVentLoose>().ventType == ventType)
                {
                    other.gameObject.SetActive(false);
                    setVentActive(true);
                    // if all vents are completed, point to the secretary
                    if (ventsCompleted())
                    {
                        secretary.GetComponent<AssistantDialogue>().airconJobFinished = true;
                        scene4State.GetComponent<Scene4State>().arrowState = "SecretaryPerson";
                    }
                }
                else if (!dialogueManager.DialogQueued())
                {
                    dialogueManager.Enqueue("Me: This vent doesn't fit, maybe I should try another one");
                }
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
    
    public static bool ventsCompleted()
    {
        bool output = true;

        foreach (var vent in _vents)
        {
            if (!vent.isActive)
            {
                output = false;
                break;
            }
        }

        return output;
    }
}
