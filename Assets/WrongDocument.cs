using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WrongDocument : MonoBehaviour
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
        //If the player presses the X controller button to disaprove the document
        if (!infoScreen && Input.GetKeyDown("joystick button 2"))
        {
            changeDocument.changeDocument = true;

            // If the currently displayed document contains any of the following items displayed in the info screen at the start OR the total price is incorrect, then it correctly has been trashed
            if (changeDocument.currentDate.tag == changeDocument.incorrectDate || changeDocument.currentLogo.tag == changeDocument.incorrectLogo || changeDocument.currentSignature.tag == changeDocument.incorrectSignature || changeDocument.total != changeDocument.fakeTotal)
            {
                //add 1 to the score
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            //If the currently displayed document DOESNT contain any of the displayed in the info screen at the start OR the total price is correct, then it has wrongly been trashed and thus warning is to be given
            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }

    void OnMouseDown()
    {
        //If the player clicks the trash icon
        if (!infoScreen)
        {
            changeDocument.changeDocument = true;

            // If the currently displayed document contains any of the following items displayed in the info screen at the start OR the total price is incorrect, then it correctly has been trashed
            if (changeDocument.currentDate.tag == changeDocument.incorrectDate || changeDocument.currentLogo.tag == changeDocument.incorrectLogo || changeDocument.currentSignature.tag == changeDocument.incorrectSignature || changeDocument.total != changeDocument.fakeTotal)
            {
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            //If the currently displayed document DOESNT contain any of the displayed in the info screen at the start OR the total price is correct, then it has wrongly been trashed and thus warning is to be given
            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }

}