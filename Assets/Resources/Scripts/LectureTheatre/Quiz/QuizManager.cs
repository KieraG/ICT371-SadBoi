using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> availableQuestions;
    public GameObject TrueButton;
    public GameObject FalseButton;
    public GameObject[] OptionButtons;
    public enum AnswerType
    {
        TRUE,
        FALSE,
        MULTICHOICE
    }
    private Question currentQuestion;
    // Start is called before the first frame update
    void Start()
    {
        if ((availableQuestions == null || availableQuestions.Count == 0) && questions.Length != 0)
        {
            foreach (var question in questions)
            {
                availableQuestions = questions.ToList<Question>();
            }
        }
        GetRandomQuestion();
        EnableSelections();
        GameObject.Find("QuestionPanel").GetComponentInChildren<Text>().text = currentQuestion.text;
    }

    void GetRandomQuestion()
    {
        if (availableQuestions.Count > 0)
        {
            var index = Random.Range(0, availableQuestions.Count);
            currentQuestion = availableQuestions[index];
            availableQuestions.RemoveAt(index);
        }

    }

    void EnableSelections()
    {
        if (currentQuestion.isMultichoice)
        {
            disableOptions();
            var optionCount = currentQuestion.multiChoiceOptions.Length;
            SetTrueFalse(false);
            enableOptions(optionCount);
        }
        else
        {
            disableOptions();
            SetTrueFalse(true);
        }
    }

    private void enableOptions(int num)
    {
        List<string> answers = new List<string>();
        answers.Add(currentQuestion.multiChoiceAnswer);


        if (num > OptionButtons.Length)
        {
            num = OptionButtons.Length;
        }

        for (var i = 0; i < num ; i++)
        {
            answers.Add(currentQuestion.multiChoiceOptions[i]);

        }

        for (var i = 0; i < num + 1; i++)
        {
            OptionButtons[i].SetActive(true);
            var index = Random.Range(0, answers.Count);
            OptionButtons[i].GetComponentInChildren<Text>().text = answers[index];
            answers.RemoveAt(index);

        }


    }

    private void disableOptions()
    {
        foreach (var option in OptionButtons)
        {
            option.SetActive(false);   
        }
    }

    private void SetTrueFalse(bool setting)
    {
        TrueButton.SetActive(setting);
        FalseButton.SetActive(setting);
    }

    public void SelectAnswer(AnswerType type, int multi = 0)
    {
        if (type == AnswerType.MULTICHOICE)
        {
            if (!currentQuestion.isMultichoice) return;
            var answer = OptionButtons[multi].GetComponentInChildren<Text>().text;
            Debug.Log(answer == currentQuestion.multiChoiceAnswer ? "Correct" : "Wrong");
        }
        else
        {
            if (currentQuestion.isMultichoice) return;
            if (currentQuestion.isTrue)
            {
                Debug.Log(type == AnswerType.TRUE ? "correct" : "wrong");
            }
            else
            {
                Debug.Log(type == AnswerType.FALSE ? "correct" : "wrong");
            }
        }
    }

    public void UserSelectTrue()
    {
        SelectAnswer(AnswerType.TRUE);
    }

    public void UserSelectFalse()
    {
        SelectAnswer(AnswerType.FALSE);
    }

    public void SelectOption1()
    {
        SelectAnswer(AnswerType.MULTICHOICE, 0);
    }

    public void SelectOption2()
    {
        SelectAnswer(AnswerType.MULTICHOICE, 1);
    }
    public void SelectOption3()
    {
        SelectAnswer(AnswerType.MULTICHOICE, 2);
    }
    public void SelectOption4()
    {
        SelectAnswer(AnswerType.MULTICHOICE, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    GetRandomQuestion();
        //    EnableSelections();
        //    GameObject.Find("QuestionPanel").GetComponentInChildren<Text>().text = currentQuestion.text;
        //}
    }
}
