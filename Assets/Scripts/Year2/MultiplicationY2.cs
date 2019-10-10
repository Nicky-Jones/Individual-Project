using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiplicationY2 : MonoBehaviour {
    public Points points;
    public TMP_InputField number1;
    public TMP_InputField number2;
    public TMP_InputField mathStatement;
    public TMP_InputField questionAnswer;
    public Button nextQuestion;
    public Button checkAnswer;
    public TMP_Text answerMessage;
    public TMP_Text oddEvenAnswerMessage;
    public GameObject completedScene;
    public GameObject oddEvenPanel;
    int tracker = 0;
    int answer = 0;
    int randomNumber;
    public void Questions()
    {
        checkAnswer.enabled = true;
        if (tracker == 0)
        {
            Question1();
        }
        if (tracker == 1)
        {
            Question2();
        }
        if (tracker == 2)
        {
            Question3();
        }
        if (tracker == 3)
        {
            Question4();
        }
        if (tracker == 4)
        {
            Question5();
        }
        if (tracker == 5)
        {
            Question6();
        }
    }
    public void EvenAnswer()
    {
        if(answer%2 == 0)
        {
            oddEvenAnswerMessage.text = "Correct";
            points.setPoints(5);
        }
        else
        {
            oddEvenAnswerMessage.text = "Incorrect";
        }
        StartCoroutine(Delay());
    }
    public void OddAnswer()
    {
        if(answer%2 != 0)
        {
            oddEvenAnswerMessage.text = "Correct";
            points.setPoints(5);
        }
        else
        {
            oddEvenAnswerMessage.text = "Incorrect";
        }
        StartCoroutine(Delay());
    }
    public void Answers()
    {
        if(tracker == 0)
        {
            answer = 2 * randomNumber;
            if(questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                points.setPoints(5);
                OddOrEven();
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        if (tracker == 1)
        {
            answer = randomNumber / 2;
            Debug.Log(answer);
            Debug.Log(randomNumber);
            if (questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                OddOrEven();
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        if (tracker == 2)
        {
            answer = 5 * randomNumber;
            if (questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                OddOrEven();
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        if (tracker == 3)
        {
            answer = randomNumber / 5;
            Debug.Log(answer);
            Debug.Log(randomNumber);
            if (questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                OddOrEven();
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        if (tracker == 4)
        {
            answer = 10 * randomNumber;
            if (questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                OddOrEven();
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        if (tracker == 5)
        {
            answer = randomNumber / 10;
            Debug.Log(answer);
            Debug.Log(randomNumber);
            if (questionAnswer.text == answer.ToString())
            {
                answerMessage.text = "Well done";
                OddOrEven();
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
            checkAnswer.enabled = false;
        }
        nextQuestion.enabled = true;
        tracker++;
    }
    private void Question1()
    {
        randomNumber = Random.Range(0, 10);
        number1.text = 2.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "x";
        nextQuestion.enabled = false;
    }
    private void Question2()
    {
        randomNumber = Random.Range(1, 10);
        number1.text = 2.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "/";
        nextQuestion.enabled = false;
    }
    private void Question3()
    {
        randomNumber = Random.Range(0, 10);
        number1.text = 5.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "x";
        nextQuestion.enabled = false;
    }
    private void Question4()
    {
        randomNumber = Random.Range(1, 10);
        number1.text = 5.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "/";
        nextQuestion.enabled = false;
    }
    private void Question5()
    {
        randomNumber = Random.Range(0, 10);
        number1.text = 10.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "x";
        nextQuestion.enabled = false;
    }
    private void Question6()
    {
        randomNumber = Random.Range(1, 10);
        number1.text = 10.ToString();
        number2.text = randomNumber.ToString();
        mathStatement.text = "/";
        nextQuestion.enabled = false;
    }
    public void OddOrEven()
    {
        oddEvenPanel.SetActive(true);
    }
    // Use this for initialization
    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
        oddEvenPanel.SetActive(false);
    }
}
