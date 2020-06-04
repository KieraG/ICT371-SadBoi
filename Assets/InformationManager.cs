using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InformationManager : MonoBehaviour
{

    //Populates the information screen with information 


    public Text TotalText;
    public Text AerosolText;
    public Text VegetationText;
    public Text TilText;
    public Text GreenhouseText;
    public Text SolarText;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
    void Start()
    {
        int totalQuestions = GlobalValues.correctQuestions + GlobalValues.incorrectQuestions;
        float percentage = 0;
        if (totalQuestions != 0)
        {
             percentage = GlobalValues.correctQuestions / totalQuestions * 100;
        }

        TotalText.text = "Out of " + totalQuestions +  " total questions. \n You got \n\n" + percentage + "%";

        if (GlobalValues.AerosolQuestionCorrect)
        {
            AerosolText.text = "You understood aerosols and their effect on the environment.";
        }
        else
        {
            AerosolText.text = "You did not understand aerosols and their effect on the environment.";
        }
       

        if (GlobalValues.VegetationQuestionCorrect)
        {
            VegetationText.text = "You understood the role vegetation plays in the climate.";
        }
        else
        {
            VegetationText.text = "You did not understand the role vegetation plays in the climate.";
        }


        if (GlobalValues.TiltQuestionCorrect)
        {
            TilText.text = "You understood that the tilt of the earth contributes to climate.";
        }
        else
        {
            TilText.text = "You did not understand that the tilt of the earth contributes to climate";
        }

        GreenhouseText.text = "You got " + GlobalValues.GreenhouseQuestionsCorrect + " out of " + GlobalValues.GreenhouseQuestionsCount + " questions correct about Greenhouse Gases.";

        if (GlobalValues.SolarQuestionCorrect)
        {
            SolarText.text = "You understood the effect that solar activity has on the climate.";
        }
        else
        {
            SolarText.text = "You did not understand the effect that solar activity has on the climate";
        }


    }

}
