using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject window = null;

    [SerializeField]
    private RightDocument stopApprove = null;

    [SerializeField]
    private WrongDocument stopTrash = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            window.SetActive(true);
            window.GetComponent<InformationScreen>().SetImageActive();
            stopApprove.infoScreen = true;
            stopTrash.infoScreen = true;
        }

    }

    private void OnMouseDown()
    {
        window.SetActive(true);
        window.GetComponent<InformationScreen>().SetImageActive();
        stopApprove.infoScreen = true;
        stopTrash.infoScreen = true;
    }

}
