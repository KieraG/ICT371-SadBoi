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

    [HideInInspector]
    public bool timerStart = false;

    void Start()
    {
        // Unlocks the cursor for the minigame
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameObject temp;

        //At the start RANDOMLY select an inncorrect logo,date and signature. If any of the given documents in the mini game contain these, then it is to be trashed. These are set to the infomations screen to be shown on minigame start up
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

        //If the player incorrect trashes or approve a document 3 times, then their PC is locked and ends the minigame
        if (wrongCounter == 3)
        {
            endscreen.SetActive(true);
            lockoutTimer -= Time.deltaTime;
            PlayerPrefs.SetInt("scoreCounter", -1);

            Destroy(currentLogo);
            Destroy(currentDate);
            Destroy(currentSignature);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (lockoutTimer <= 0)
                transitionToNext.continueOn = true;

           
        }

        if (!infoScreen.isActiveAndEnabled && firstInfoWindow)
        {
            timerStart = true;

            //For everytime the player trashes or approves a document, a new document is created
            if (changeDocument)
            {
                //Destroy(currentObj);
                //currentObj = Instantiate(documentComponents[(int)Random.Range(0, documentComponents.Length)]);

                //At the start of the minigame, create the spread sheet templete
                if (createSpreadSheet)
                {
                    Instantiate(spreadSheet);
                    createSpreadSheet = false;
                }

                //Delete the old document infomation
                Destroy(currentLogo);
                Destroy(currentDate);
                Destroy(currentSignature);
                total = 0;
                fakeTotal = 0;

                //Create a new RANDOM document, with a random logo, date and signature
                currentLogo = Instantiate(logoComponents[(int)Random.Range(0, logoComponents.Length)]);

                currentDate = Instantiate(dateComponents[(int)Random.Range(0, dateComponents.Length)]);

                currentSignature = Instantiate(signatureComponents[(int)Random.Range(0, signatureComponents.Length)]);

                //Create 3 random prices for the items in the spread sheet
                itemNum1 = (int)Random.Range(0, 10);
                itemNum2 = (int)Random.Range(0, 10);
                itemNum3 = (int)Random.Range(0, 10);

                //Display the prices
                items[0].text = itemNum1.ToString();
                items[1].text = itemNum2.ToString();
                items[2].text = itemNum3.ToString();

               
                total = itemNum1 + itemNum2 + itemNum3;

                //Have a 10% chance for the total price to be inncorrect
                if ((int)Random.Range(0, 10) == 1)
                    fakeTotal = total + (int)Random.Range(1, 10);
                else
                    fakeTotal = total;

                //Display the total
                items[3].text = fakeTotal.ToString();

                changeDocument = false;
            }

        }

        //If the minigame has started and infoscreen has been pressed for the first time
        if (timerStart)
        {
            // If the timer reaches 0, end the minigame
            if (timer <= 0)
            {
                transitionToNext.continueOn = true;
                PlayerPrefs.SetInt("scoreCounter", scoreCounter);
                Cursor.lockState = CursorLockMode.Locked;
            }

            //else take 1 sec off the timer
            else
                timer -= Time.deltaTime;

            //Display the time
            timerText.text = timer.ToString("F1");
        }
           
    }
}
