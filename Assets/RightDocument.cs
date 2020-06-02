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
        if (!infoScreen && Input.GetKeyDown("joystick button 2"))
        {
            changeDocument.changeDocument = true;

            if (changeDocument.currentDate.tag != changeDocument.incorrectDate && changeDocument.currentLogo.tag != changeDocument.incorrectLogo && changeDocument.currentSignature.tag != changeDocument.incorrectSignature && changeDocument.total == changeDocument.fakeTotal)
            {
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }

    void OnMouseDown()
    {
       
        if (!infoScreen)
        {
            changeDocument.changeDocument = true;

            if (changeDocument.currentDate.tag != changeDocument.incorrectDate && changeDocument.currentLogo.tag != changeDocument.incorrectLogo && changeDocument.currentSignature.tag != changeDocument.incorrectSignature && changeDocument.total == changeDocument.fakeTotal)
            {
                changeDocument.scoreCounter++;
                score.text = changeDocument.scoreCounter.ToString();
            }

            else
            {
                changeDocument.wrongCounter++;
                numberOfWarnings.text = changeDocument.wrongCounter.ToString();
            }
        }
    }
}