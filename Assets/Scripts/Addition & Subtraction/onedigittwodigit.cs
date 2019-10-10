using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class onedigittwodigit : MonoBehaviour {
    public Points points;
    public TMP_InputField number1;
    public TMP_InputField number2;
    public TMP_InputField mathStatement;
    public TMP_InputField answer;
    public TMP_Text answerMessage;
    public GameObject completedScene;
    int rndNumber1 = 0;
    int rndNumber2 = 0;
    int rndAnswer = 20;
    int statementChecker = 0;
    int rndNumber;
    int answerValue = 0;

    public void mathStatementMain()
    {
        //answer.enabled = true;
        //mathStatement.enabled = true;
        number2.enabled = true;
        answer.text = "20";
        number2.text = "";
        if (statementChecker < 3)
        {
            randomStatement();
        }
        if (statementChecker >= 3)
        {
            
            notFalse();
        }
        answerMessage.text = "";
        completedscene();
        statementChecker++;
    }

    void notFalse()
    {
        rndNumber1 = Random.Range(20, 41);
        mathStatement.text = "-";
        number1.text = rndNumber1.ToString();
    }
    public void answerChecker()
    {
        if (statementChecker <= 3)
        {
            answerChecker1();
        }
        else
        {
            answerChecker2();
        }
    }
    void answerChecker2()
    {
        int temp = rndNumber1 - rndAnswer;
        Debug.Log(temp);
        if(number2.text == temp.ToString())
        {
            answerMessage.text = "You're correct!";
            answerValue = answerValue + 1;
            points.setPoints(5);
        }
        else
        {
            answerMessage.text = "Sorry, you're incorrect";
        }
        number2.enabled = false;
    }
    void answerChecker1()
    {
        int temp = rndAnswer - rndNumber1;
        if(number2.text == temp.ToString())
        {
            answerMessage.text = "You're correct!";
            answerValue = answerValue + 1;
            points.setPoints(5);
        }
        else
        {
            answerMessage.text = "Sorry, you're incorrect";
        }
        number2.enabled = false;
    }
    void randomStatement()
    {
        mathStatement.text = "+";
        rndNumber1 = Random.Range(0, 21);
        number1.text = rndNumber1.ToString();
    }

    void completedscene()
    {
        if (answerValue == 7)
        {
            completedScene.SetActive(true);
            answerValue = 0;
            statementChecker = 0;
            rndNumber1 = 0;
            rndNumber2 = 0;
            answerMessage.text = "";
        }
    }
}
