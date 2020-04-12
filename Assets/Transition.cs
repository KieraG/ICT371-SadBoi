using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{

    public Canvas busTransition;
    public GameObject player;
    public bool continueOn = false;
    private Color tempColor;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && continueOn)
        {
            busTransition.gameObject.SetActive(true);
            Debug.Log("hello");
            StartCoroutine(FadeInTime());
        }

        else if (col.gameObject.tag == "Player" && !continueOn)
        {

        }
    }

    IEnumerator FadeInTime()
    {
        var transOpacity = 0f;

        for (int i = 0; i <= 22; i++)
        {
            transOpacity = transOpacity + 0.05f;
            tempColor.a = transOpacity;
            busTransition.GetComponent<CanvasGroup>().alpha = tempColor.a;


            if (i == 22)
            {
                SceneManager.LoadScene("scene-3-2", LoadSceneMode.Single);
                //player.transform.position = player.GetComponent<PlayerController>().getStartPos();
                StartCoroutine(FadeOutTime());
                yield return null;
            }

            yield return new WaitForSeconds(0.02f);
        }

    }

    IEnumerator FadeOutTime()
    {
        var transOpacity = 1f;

        for (int i = 0; i <= 22; i++)
        {
            transOpacity = transOpacity - 0.05f;
            tempColor.a = transOpacity;
            busTransition.GetComponent<CanvasGroup>().alpha = tempColor.a;

            yield return new WaitForSeconds(0.02f);
        }

    }
}
