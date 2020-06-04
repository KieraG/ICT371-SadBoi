using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    //Array of possible questions
    public Question[] questions;
    //List of questions that have yet to be answered
    private static List<Question> availableQuestions;

    //Buttons and panels
    public GameObject TrueButton;
    public GameObject FalseButton;
    public GameObject[] OptionButtons;
    public GameObject answerPanel;
    public GameObject questionPanel;
    private Question currentQuestion;

    // Whether the result panel is currently displaying
    private bool displayingAnswerPanel = false;

    //Sets up  initial values and loads questions into the available questions list
    void Start()
    {
        answerPanel.SetActive(false);
        if ((availableQuestions == null || availableQuestions.Count == 0) && questions.Length != 0)
        {
            foreach (var question in questions)
            {
                availableQuestions = questions.ToList<Question>();
            }
        }
        GetRandomQuestion();
        EnableSelections();
        questionPanel.GetComponentInChildren<Text>().text = currentQuestion.text;
        GlobalValues.correctQuestions = 0;
        GlobalValues.incorrectQuestions = 0;
    }

    //Gets a random question from the list of available questions
    void GetRandomQuestion()
    {
        if (availableQuestions.Count > 0)
        {
            var index = Random.Range(0, availableQuestions.Count);
            currentQuestion = availableQuestions[index];
            availableQuestions.RemoveAt(index);
        }
        else
        {
            SceneManager.UnloadSceneAsync(5);

            GlobalValues.quizEnd = true;
            GlobalValues.finishedQuiz = true;
            Cursor.visible = false;
        }

    }

    void EnableSelections()
    {
        if (currentQuestion.isMultichoice)
        {
            disableOptions();
            var optionCount = currentQuestion.multiChoiceOptions.Length + 1;
            SetTrueFalse(false);
            enableOptions(optionCount);
        }
        else
        {
            disableOptions();
            SetTrueFalse(true);
        }
    }

    //Enables the correct butttons and panels based on the type of question being given
    private void enableOptions(int num)
    {
        List<string> answers = new List<string>
        {
            currentQuestion.multiChoiceAnswer
        };
        List<String> wrongAnswers = new List<string>();
        wrongAnswers = currentQuestion.multiChoiceOptions.ToList();

        var questionsToAdd = Math.Min(3, currentQuestion.multiChoiceOptions.Length);


        for (var i = 0; i < questionsToAdd; i++)
        {
            var index = Random.Range(0, wrongAnswers.Count);
            answers.Add(wrongAnswers[index]);
            wrongAnswers.RemoveAt(index);
        }



        for (int i = 0; i < answers.Count; i++)
        {
            string temp = answers[i];
            int randomIndex = Random.Range(i, answers.Count);
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }



        for (var i = 0; i < questionsToAdd + 1; i++)
        {
            OptionButtons[i].SetActive(true);
            OptionButtons[i].GetComponentInChildren<Text>().text = answers[i];

        }


    }

    //Disables the multichoice option buttons
    private void disableOptions()
    {
        foreach (var option in OptionButtons)
        {
            option.SetActive(false);
        }
    }

    //Sets the true and false buttons active or inactive
    private void SetTrueFalse(bool setting)
    {
        TrueButton.SetActive(setting);
        FalseButton.SetActive(setting);
    }

    //Selects a multichoice answer at the given index
    public void SelectAnswer(int multi = 0)
    {

        if (!currentQuestion.isMultichoice || multi > (currentQuestion.multiChoiceOptions.Length)) return;
        var answer = OptionButtons[multi].GetComponentInChildren<Text>().text;
        Debug.Log(answer == currentQuestion.multiChoiceAnswer ? "Correct" : "Wrong");
        if (answer == currentQuestion.multiChoiceAnswer)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }

    }

    //Selects true
    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
        Debug.Log(currentQuestion.isTrue ? "correct" : "wrong");
    }
    //Selectr false
    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
        Debug.Log(currentQuestion.isTrue ? "Wrong" : "correct");
    }

    //Multichoice option button 1
    public void SelectOption1()
    {
        SelectAnswer(0);
    }
    //Multichoice option button 2
    public void SelectOption2()
    {
        SelectAnswer(1);
    }
    //Multichoice option button 3
    public void SelectOption3()
    {
        SelectAnswer(2);
    }
    //Multichoice option button 4
    public void SelectOption4()
    {
        SelectAnswer(3);
    }

    //Called when a correct answer is given
    private void CorrectAnswer()
    {
        SetGlobalValue(currentQuestion.questionType, true);
        displayingAnswerPanel = true;
        answerPanel.SetActive(true);
        answerPanel.GetComponentInChildren<Text>().text = "Correct!\n\n\nPress any key to continue";
        answerPanel.transform.Find("PanelLayer").GetComponent<Image>().color = Color.green;
        GlobalValues.correctQuestions++;

    }

    //Called when a wrong answer is given
    private void WrongAnswer()
    {
        SetGlobalValue(currentQuestion.questionType, false);
        displayingAnswerPanel = true;
        answerPanel.SetActive(true);
        if (currentQuestion.isMultichoice)
        {
            answerPanel.GetComponentInChildren<Text>().text = "Incorrect!\n\nThe correct answer is\n" + currentQuestion.multiChoiceAnswer + "\n\nPress any key to continue";

        }
        else
        {
            answerPanel.GetComponentInChildren<Text>().text = "Incorrect!\n\nThe correct answer is\n" + currentQuestion.isTrue + "\n\nPress any key to continue";
        }

        answerPanel.transform.Find("PanelLayer").GetComponent<Image>().color = Color.red;
        GlobalValues.incorrectQuestions++;

    }

    //Updates the global values for the information screen
    private void SetGlobalValue(Question.TYPE type, bool correct)
    {
        switch (type)
        {
            case Question.TYPE.GENERAL:
                {
                    var count = correct ? 1 : 0;
                    GlobalValues.GeneralKnowledgeCorrect += count;
                    GlobalValues.GeneralKnowledgeCount++;
                }
                break;
            case Question.TYPE.SOLAR:
                {
                    GlobalValues.SolarQuestionCorrect = correct;
                }
                break;
            case Question.TYPE.VEGETATION:
                {
                    GlobalValues.VegetationQuestionCorrect = correct;
                }
                break;
            case Question.TYPE.TILT:
                {
                    GlobalValues.TiltQuestionCorrect = correct;
                }
                break;
            case Question.TYPE.GREENHOUSE:
                {
                    var count = correct ? 1 : 0;
                    GlobalValues.GreenhouseQuestionsCorrect += count;
                    GlobalValues.GreenhouseQuestionsCount++;
                }
                break;
            case Question.TYPE.AEROSOL:
                {
                    GlobalValues.AerosolQuestionCorrect = correct;
                }
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (displayingAnswerPanel)
        {
            if (Input.anyKeyDown)
            {
                answerPanel.SetActive(false);
                displayingAnswerPanel = false;
                GetRandomQuestion();
                EnableSelections();
                questionPanel.GetComponentInChildren<Text>().text = currentQuestion.text;
            }
        }
        else
        {
            //Xbox button A
            if (Input.GetKeyDown("joystick button 0"))
            {
                if (currentQuestion.isMultichoice)
                {
                    SelectOption1();
                }
                else
                {
                    UserSelectTrue();
                }
            }
            //Xbox button B
            if (Input.GetKeyDown("joystick button 1"))
            {
                if (currentQuestion.isMultichoice)
                {
                    SelectOption2();
                }
                else
                {
                    UserSelectFalse();
                }
            }
            //Xbox button X
            if (Input.GetKeyDown("joystick button 2"))
            {
                if (currentQuestion.isMultichoice)
                {
                    SelectOption3();
                }

            }
            //Xbox button Y
            if (Input.GetKeyDown("joystick button 3"))
            {
                if (currentQuestion.isMultichoice)
                {
                    SelectOption4();
                }

            }
        }


    }
}
