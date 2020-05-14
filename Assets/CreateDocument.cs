using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateDocument : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] logoComponents = null;
    public GameObject[] dateComponents = null;
    public GameObject[] signatureComponents = null;

    public TMP_Text timerText;
    public GameObject endscreen = null;
    

    [HideInInspector]
    public bool changeDocument = true;

    [HideInInspector]
    public GameObject currentObj = null;
    [HideInInspector]
    public string incorrectLogo = null;
    [HideInInspector]
    public string incorrectDate = null;
    [HideInInspector]
    public string incorrectSignature = null;
    [HideInInspector]
    public GameObject currentLogo = null;
    [HideInInspector]
    public GameObject currentDate = null;
    [HideInInspector]
    public GameObject currentSignature = null;


    [HideInInspector]
    public int scoreCounter = 0;

    [HideInInspector]
    public int wrongCounter = 0;

    private float timer = 60;


    void Start()
    {
        incorrectLogo = logoComponents[(int)Random.Range(0, logoComponents.Length)].tag;
        incorrectDate = dateComponents[(int)Random.Range(0, dateComponents.Length)].tag;
        incorrectSignature = signatureComponents[(int)Random.Range(0, signatureComponents.Length)].tag;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (wrongCounter == 3)
        {
            endscreen.SetActive(true);
        }

        if (changeDocument)
        {
            //Destroy(currentObj);
            //currentObj = Instantiate(documentComponents[(int)Random.Range(0, documentComponents.Length)]);

            Destroy(currentLogo);
            Destroy(currentDate);
            Destroy(currentSignature);

            currentLogo = Instantiate(logoComponents[(int)Random.Range(0, logoComponents.Length)]);

            currentDate = Instantiate(dateComponents[(int)Random.Range(0, dateComponents.Length)]);

            currentSignature = Instantiate(signatureComponents[(int)Random.Range(0, signatureComponents.Length)]);

            changeDocument = false;
        }

        timer -= Time.deltaTime;

        timerText.text = timer.ToString("F1");
    }
}
