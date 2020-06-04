using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RightDocument : MonoBehaviour
{
    // Start is called before the first frame update

    public CreateDocument changeDocument = null;
    public TMP_Text score;
    public TMP_Text numberOfWarnings;

    [HideInInspector]
    public bool infoScreen = true;
    void Start()
    {

    }

    void Update()
    {
        //If the player presses the B controller button to accept the document
        if (!infoScreen && Input.GetKeyDown("joystick button 1"))
        {
            changeDocument.changeDocument = true;

            //Check to make sure the currently displayed document doesn't contain any of the things listed at the start screen and the total price is correct
            if (changeDocument.currentDate.tag != changeDocument.incorrectDate && changeDocument.currentLogo.tag != changeDocument.incorrectLogo && changeDocument.currentSignature.tag != changeDocument.incorrectSignature && changeDocument.total == changeDocument.fakeTotal)
            {
                //Increase the score counter
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            //If it does contain an illegal item or the total price is incorrect, then the document shouldnt have been approved, so increases the wrong counter by 1
            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }

    void OnMouseDown()
    {

        //If the player clicks the apporove button
        if (!infoScreen)
        {
            changeDocument.changeDocument = true;

            //Check to make sure the currently displayed document doesn't contain any of the things listed at the start screen and the total price is correct
            if (changeDocument.currentDate.tag != changeDocument.incorrectDate && changeDocument.currentLogo.tag != changeDocument.incorrectLogo && changeDocument.currentSignature.tag != changeDocument.incorrectSignature && changeDocument.total == changeDocument.fakeTotal)
            {
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            //If it does contain an illegal item or the total price is incorrect, then the document shouldnt have been approved, so increases the wrong counter by 1
            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }
}