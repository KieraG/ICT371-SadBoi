using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WrongDocument : MonoBehaviour
{
    // Start is called before the first frame update

    public CreateDocument changeDocument = null;
    public  TMP_Text score;

    void Start()
    {

    }

    void OnMouseDown()
    {
        changeDocument.changeDocument = true;

        if (!changeDocument.currentObj.GetComponent<DocumentQualities>().isCorrect)
        {
            changeDocument.scoreCounter++;
            score.text = changeDocument.scoreCounter.ToString();
        }

    }
}