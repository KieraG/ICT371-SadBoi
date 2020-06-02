using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionMinigame : MonoBehaviour
{
    [Tooltip("Canvas attached to the player")]
    public Canvas busTransition;

    [Tooltip("Simple boolean that controls whether or not the transition is active. Have this set to false if you want to wait for an event to occur before the transition is allowed, then set it ture once the event is completed.")]
    public bool continueOn = false;

    [Tooltip("Set this to the number position of the scene you want to transition to is to. Eg. the first scene = 0.")]
    public int sceneNumber = 0;
    private Color tempColor;

    private bool transitionStart = true;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (continueOn && transitionStart)
        {
            busTransition.gameObject.SetActive(true);
            StartCoroutine(FadeInTime());
            transitionStart = false;
        }

    }

    IEnumerator FadeInTime()
    {
        var transOpacity = 0f;

        // Transitions from clear to black
        while (busTransition.GetComponent<CanvasGroup>().alpha <= 1)
        {
            transOpacity = transOpacity + 0.02f;
            tempColor.a = transOpacity;
            busTransition.GetComponent<CanvasGroup>().alpha = tempColor.a;


            if (busTransition.GetComponent<CanvasGroup>().alpha >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                //player.transform.position = player.GetComponent<PlayerController>().getStartPos(); //This here is used to do the reverse transtion. However when going to a new scene, all scripts are canceled (unless specifically work around it). Thus Fade on new scene is used instead.
                //StartCoroutine(FadeOutTime());
                yield return null;
            }

            yield return new WaitForSeconds(0.02f);
        }

    }

   /* IEnumerator FadeOutTime()
    {
        var transOpacity = 1f;

        for (int i = 0; i <= 22; i++)
        {
            transOpacity = transOpacity - 0.05f;
            tempColor.a = transOpacity;
            busTransition.GetComponent<CanvasGroup>().alpha = tempColor.a;

            yield return new WaitForSeconds(0.02f);
        }

    }*/
}
