using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class mathStatements : MonoBehaviour {
    public Points points;
    public TMP_InputField number1;
    public TMP_InputField number2;
    public TMP_InputField mathStatement;
    public TMP_InputField answer;
    public TMP_Text answerMessage;
    public GameObject completedScene;
    int rndNumber1 = 0;
    int rndNumber2 = 0;
    int rndAnswer = 0;
    int statementChecker = 0;
    int rndNumber;
    int answerValue = 0;

    public void mathStatementMain()
    {
        answer.enabled = true;
        mathStatement.enabled = true;
        if (statementChecker < 3)
        {
            answer.text = "";
            randomStatement();
            answerEditor();
        }
        if (statementChecker >= 3)
        {
            mathStatement.text = "";
            notFalse();
            overideRndNumberDisplayer();
        }
        answerMessage.text = "";
        //answerChecker();
        completedscene();
        statementChecker++;
    }

    void notFalse()
    {
        rndNumber = Random.Range(0, 2);

        if (rndNumber == 1)
        {
            int checker = 0;
            rndNumber1 = Random.Range(0, 21);
            number1.text = rndNumber1.ToString();
            while (checker == 0)
            {
                rndNumber2 = Random.Range(0, 21);
                if (rndNumber2 + rndNumber1 < 0)
                {
                    rndNumber2 = Random.Range(0, 21);
                }
                else
                {
                    checker = 1;
                }
                number2.text = rndNumber2.ToString();
            }
        }
        else
        {
            int checker = 0;
            rndNumber1 = Random.Range(0, 21);
            number1.text = rndNumber1.ToString();
            while (checker == 0)
            {
                rndNumber2 = Random.Range(0, 21);
                if (rndNumber2 + rndNumber1 < 0)
                {
                    rndNumber2 = Random.Range(0, 21);
                }
                else
                {
                    checker = 1;
                }
                number2.text = rndNumber2.ToString();
            }
        }
    }
    public void answerChecker()
    {
        if(statementChecker <= 3)
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
        if((mathStatement.text == "+" && rndNumber == 0) || (mathStatement.text == "-" && rndNumber == 1))
        {
            answerMessage.text = "Congratulations you're correct";
            answerValue = answerValue + 1;
            points.setPoints(5);
        }
        else
        {
            answerMessage.text = "Sorry, you're incorrect";
        }
        mathStatement.enabled = false;
    } 
    void overideRndNumberDisplayer()
    {
        rndNumber = Random.Range(0, 2);
        if (rndNumber == 0)
        {
            rndAnswer = rndNumber1 + rndNumber2;
        }
        else
        {
            rndAnswer = rndNumber1 - rndNumber2;
        }
        answer.text = rndAnswer.ToString();
    }
    void answerChecker1()
    {
        if (answer.text == rndAnswer.ToString())
        {
            answerMessage.text = "Congratulations, you're correct!";
            answerValue = answerValue + 1;
            points.setPoints(5);
        }
        else if(answer.text != rndAnswer.ToString())
        {
            answerMessage.text = "Sorry, maybe next time!";
        }

        answer.enabled = false;
    }
    void answerEditor()
    {
        if(mathStatement.text == "+")
        {
            rndAnswer = rndNumber1 + rndNumber2;
        }
        else
        {
            rndAnswer = rndNumber1 - rndNumber2;
        }
    }
    void rndNumber1Editor()
    {
        number1.text = rndNumber1.ToString();
    }
    void rndNumber2Editor()
    {
        number2.text = rndNumber2.ToString();
    }
    void randomStatement()
    {
        rndNumber = Random.Range(0,2);

        if(rndNumber == 1)
        {
            mathStatement.text = "+";
            int checker = 0;
            rndNumber1 = Random.Range(0, 21);
            number1.text = rndNumber1.ToString();
            while (checker == 0)
            {
                rndNumber2 = Random.Range(0, 21);
                if(rndNumber2 + rndNumber1 < 0)
                {
                    rndNumber2 = Random.Range(0, 21);
                }
                else
                {
                    checker = 1;
                }
                number2.text = rndNumber2.ToString();
            }
        }
        else
        {
            mathStatement.text = "-";
            int checker = 0;
            rndNumber1 = Random.Range(0, 21);
            number1.text = rndNumber1.ToString();
            while (checker == 0)
            {
                rndNumber2 = Random.Range(0, 21);
                if (rndNumber2 + rndNumber1 < 0)
                {
                    rndNumber2 = Random.Range(0, 21);
                }
                else
                {
                    checker = 1;
                }
                number2.text = rndNumber2.ToString();
            }
        }
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
