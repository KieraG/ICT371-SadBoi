using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateDocument : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] documentComponents;
    public TMP_Text timerText;

    [HideInInspector]
    public bool changeDocument = true;

    [HideInInspector]
    public GameObject currentObj = null;

    [HideInInspector]
    public int scoreCounter = 0;

    private float timer = 60;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (changeDocument)
        {
            Destroy(currentObj);
            currentObj = Instantiate(documentComponents[(int)Random.Range(0, documentComponents.Length)]);
            changeDocument = false;
        }

        timer -= Time.deltaTime;

        timerText.text = timer.ToString("F2");
    }
}
