using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    //Whether the player has finished the quiz
    public static bool finishedQuiz = false;
    //The flag to set after the quiz has finished so that certain scripts can be run
    public static bool quizEnd = false;
    //The number of questions gotten correct in the quiz
    public static int correctQuestions = 0;
    //The number of questions gotten incorrect in the quiz
    public static int incorrectQuestions = 0;

    public static int GeneralKnowledgeCount = 0;
    public static int GeneralKnowledgeCorrect = 0;

    public static bool VegetationQuestionCorrect = false;
    public static bool SolarQuestionCorrect = false;
    public static bool TiltQuestionCorrect = false;
    public static bool AerosolQuestionCorrect = false;
    public static int GreenhouseQuestionsCorrect = 0;
    public static int GreenhouseQuestionsCount = 0;
    
}
