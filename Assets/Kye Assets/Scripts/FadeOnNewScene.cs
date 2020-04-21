using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnNewScene : MonoBehaviour
{
    public Canvas busTransition;
    public GameObject player;
    private Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Place this script on the main character of the scene.
    IEnumerator FadeOutTime()
    {
        var transOpacity = 1f;
        Debug.Log(busTransition.GetComponent<CanvasGroup>().alpha);

        // Fades from black to white
        while (busTransition.GetComponent<CanvasGroup>().alpha > 0)
        {
            transOpacity = transOpacity - 0.02f;
            tempColor.a = transOpacity;
            busTransition.GetComponent<CanvasGroup>().alpha = tempColor.a;

            yield return new WaitForSeconds(0.02f);
        }

        busTransition.gameObject.SetActive(false);
    }
}

