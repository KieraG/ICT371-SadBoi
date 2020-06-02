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
    public TMP_Text[] items = null;
    public GameObject spreadSheet = null;

    public TMP_Text timerText;
    public GameObject endscreen = null;

    public TransitionMinigame transitionToNext = null;  
    
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

    [SerializeField]
    private InformationScreen infoScreen = null;


    private bool firstInfoWindow = true;

    [SerializeField]
    private float timer = 60;

    private float lockoutTimer = 2;
    private bool createSpreadSheet = true;

    private int itemNum1, itemNum2, itemNum3 = 0;
    
    [HideInInspector]
    public int total, fakeTotal = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        GameObject temp;

        temp = logoComponents[(int)Random.Range(0, logoComponents.Length)];
        infoScreen.infoLogo = temp;
        incorrectLogo = temp.tag;

        temp = dateComponents[(int)Random.Range(0, dateComponents.Length)];
        infoScreen.infoDate = temp;
        incorrectDate = temp.tag;

        temp = signatureComponents[(int)Random.Range(0, signatureComponents.Length)];
        infoScreen.infoSignature = temp;
        incorrectSignature= temp.tag;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (wrongCounter == 3)
        {
            endscreen.SetActive(true);
            lockoutTimer -= Time.deltaTime;
            PlayerPrefs.SetInt("scoreCounter", -1);

            Destroy(currentLogo);
            Destroy(currentDate);
            Destroy(currentSignature);

            Cursor.lockState = CursorLockMode.Locked;
            if (lockoutTimer <= 0)
                transitionToNext.continueOn = true;

           
        }

        if (!infoScreen.isActiveAndEnabled && firstInfoWindow)
        {
            if (changeDocument)
            {
                //Destroy(currentObj);
                //currentObj = Instantiate(documentComponents[(int)Random.Range(0, documentComponents.Length)]);
                if (createSpreadSheet)
                {
                    Instantiate(spreadSheet);
                    createSpreadSheet = false;
                }

                Destroy(currentLogo);
                Destroy(currentDate);
                Destroy(currentSignature);
                total = 0;
                fakeTotal = 0;

                currentLogo = Instantiate(logoComponents[(int)Random.Range(0, logoComponents.Length)]);

                currentDate = Instantiate(dateComponents[(int)Random.Range(0, dateComponents.Length)]);

                currentSignature = Instantiate(signatureComponents[(int)Random.Range(0, signatureComponents.Length)]);

                itemNum1 = (int)Random.Range(0, 10);
                itemNum2 = (int)Random.Range(0, 10);
                itemNum3 = (int)Random.Range(0, 10);

                items[0].text = itemNum1.ToString();
                items[1].text = itemNum2.ToString();
                items[2].text = itemNum3.ToString();

                total = itemNum1 + itemNum2 + itemNum3;

                if ((int)Random.Range(0, 10) == 1)
                    fakeTotal = total + (int)Random.Range(1, 10);
                else
                    fakeTotal = total;

                items[3].text = fakeTotal.ToString();

                changeDocument = false;
            }


            if (timer <= 0)
            {
                transitionToNext.continueOn = true;
                PlayerPrefs.SetInt("scoreCounter", scoreCounter);
                Cursor.lockState = CursorLockMode.Locked;
            }

            else
                timer -= Time.deltaTime;

            timerText.text = timer.ToString("F1");

        }
           
    }
}
