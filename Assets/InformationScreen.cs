using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationScreen : MonoBehaviour
{
    [HideInInspector]
    public GameObject infoLogo = null;
    [HideInInspector]
    public GameObject infoDate = null;
    [HideInInspector]
    public GameObject infoSignature = null;

    [SerializeField]
    private RightDocument stopApprove = null;

    [SerializeField]
    private WrongDocument stopTrash = null;

    // Start is called before the first frame update
    void Start()
    {
        infoLogo = Instantiate(infoLogo, new Vector3(infoLogo.transform.position.x + 0.1f, infoLogo.transform.position.y - 0.15f, infoLogo.transform.position.z - 0.025f), transform.rotation);
        //infoLogo.transform.localScale = new Vector3(0.00814856f, 0.00814856f, 0.00814856f);

        infoDate = Instantiate(infoDate, new Vector3(infoLogo.transform.position.x + 0.17f, infoLogo.transform.position.y + 0.03f, infoLogo.transform.position.z - 0.025f), transform.rotation);
        //infoDate.transform.localScale = new Vector3(0.01014856f, 0.00814856f, 0.00814856f);

        infoSignature = Instantiate(infoSignature, new Vector3(infoLogo.transform.position.x + 0.18f, infoLogo.transform.position.y - 0.03f, infoLogo.transform.position.z - 0.025f), transform.rotation);
        //infoSignature.transform.localScale = new Vector3(0.00814856f, 0.00814856f, 0.00814856f);


        //Instantiate(infoDate);
        //Instantiate(infoSignature);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            gameObject.SetActive(false);
            infoLogo.SetActive(false);
            infoDate.SetActive(false);
            infoSignature.SetActive(false);
            stopApprove.infoScreen = false;
            stopTrash.infoScreen = false;
        }

    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        infoLogo.SetActive(false);
        infoDate.SetActive(false);
        infoSignature.SetActive(false);
        stopApprove.infoScreen = false;
        stopTrash.infoScreen = false;

    }

    public void SetImageActive()
    {
        infoLogo.SetActive(true);
        infoDate.SetActive(true);
        infoSignature.SetActive(true);
    }

}
