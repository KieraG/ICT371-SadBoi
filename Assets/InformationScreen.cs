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

    public GameObject window = null;

    // Start is called before the first frame update
    void Start()
    {
        infoLogo = Instantiate(infoLogo, new Vector3(infoLogo.transform.position.x + 0.1f, infoLogo.transform.position.y - 0.15f, infoLogo.transform.position.z - 0.025f), transform.rotation);
        infoLogo.transform.localScale = new Vector3(0.00814856f, 0.00814856f, 0.00814856f);

        infoDate = Instantiate(infoDate, new Vector3(infoLogo.transform.position.x + 0.13f, infoLogo.transform.position.y, infoLogo.transform.position.z - 0.025f), transform.rotation);
        infoDate.transform.localScale = new Vector3(0.01014856f, 0.00614856f, 0.00814856f);

        infoSignature = Instantiate(infoSignature, new Vector3(infoLogo.transform.position.x + 0.23f, infoLogo.transform.position.y, infoLogo.transform.position.z - 0.025f), transform.rotation);
        infoSignature.transform.localScale = new Vector3(0.00814856f, 0.00814856f, 0.00814856f);


        //Instantiate(infoDate);
        //Instantiate(infoSignature);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        infoLogo.SetActive(false);
        infoDate.SetActive(false);
        infoSignature.SetActive(false);
    }

    public void SetImageActive()
    {
        infoLogo.SetActive(true);
        infoDate.SetActive(true);
        infoSignature.SetActive(true);
    }

}
