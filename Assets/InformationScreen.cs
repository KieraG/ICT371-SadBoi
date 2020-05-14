using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationScreen : MonoBehaviour
{
   
    public GameObject infoLogo = null;
    public GameObject infoDate = null;
    public GameObject infoSignature = null;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(infoLogo);
        //Instantiate(infoDate);
        //Instantiate(infoSignature);

        infoLogo.transform.position = new Vector3(infoLogo.transform.position.x + 5, infoLogo.transform.position.y - 5, infoLogo.transform.position.z + 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
