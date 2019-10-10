using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class NumbersY2 : MonoBehaviour {
    public Points points;
    public string[] numberWords = new string[]{"Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
    "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty-One", "Twenty-Two", "Twenty-Three", "Twenty-Four", "Twenty-Five", "Twenty-Six", "Twenty-Seven",
    "Twenty-Eight", "Twenty-Nine", "Thirty", "Thirty-One", "Thirty-Two", "Thirty-Three", "Thirty-Four", "Thirty-Five", "Thirty-Six", "Thirty-Seven", "Thirty-Eight", "Thirty-Nine",
    "Forty", "Forty-One", "Forty-Two", "Forty-Three", "Forty-Four", "Forty-Five", "Forty-Six", "Forty-Seven", "Forty-Eight", "Forty-Nine", "Fifty", "Fifty-One", "Fifty-Two",
    "Fifty-Three", "Fifty-Four", "Fifty-Five", "Fifty-Six", "Fifty-Seven", "Fifty-Eight", "Fifty-Nine", "Sixty","Sixty-One", "Sixty-Two", "Sixty-Three", "Sixty-Four", "Sixty-Five",
    "Sixty-Six", "Sixty-Seven", "Sixty-Eight", "Sixty-Nine", "Seventy", "Seventy-One", "Seventy-Two", "Seventy-Three", "Seventy-Four", "Seventy-Five", "Seventy-Six", "Seventy-Seven",
    "Seventy-Eight", "Seventy-Nine", "Eighty", "Eighty-One", "Eighty-Two", "Eighty-Three", "Eighty-Four", "Eighty-Five", "Eighty-Six", "Eighty-Seven", "Eighty-Eight", "Eighty-Nine",
    "Ninety", "Ninety-One", "Ninety-Two", "Ninety-Three", "Ninety-Four", "Ninety-Five", "Ninety-Six", "Ninety-Seven", "Ninety-Eight", "Ninety-Nine", "One Hundred"};
    public int[] numbers = new int[100];
    int randNumberForQuestion;
    public TMP_InputField value;
    public TMP_InputField value2;
    public TMP_InputField inputAnswer;
    public TMP_InputField mathStatement;
    public GameObject valueGameObject;
    public GameObject value2GameObject;
    public GameObject mathStatementGameObject;
    public GameObject inputAnswerGameObject;
    public TMP_Text Question;
    public TMP_Text answerText;
    public Button checkAnswerBTN;
    public Button nextQuestionBTN;
    public GameObject completedSceneObject;
    int randNumberStore;
    int Points;
    string question5Answer;
    int questionTracker = 0;
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            numbers[i] = i;
        }
    }
    public void questionChanger()
    {
        Question.text = "";
        answerText.text = "";
        inputAnswer.text = "";
        if (questionTracker == 0)
        {
            question1();
        }
        else if (questionTracker == 1)
        {
            question2();
        }
        else if (questionTracker == 2)
        {
            question3();
        }
        else if (questionTracker == 3)
        {
            question4();
        }
        else if (questionTracker == 4)
        {
            question5();
        }
        else if (questionTracker == 5)
        {
            question6();
        }
        else
        {
            Question.text = "Error";
        }
        if(questionTracker < 4)
        {
            valueGameObject.SetActive(false);
            value2GameObject.SetActive(false);
            mathStatementGameObject.SetActive(false);
        }
        else
        {
            valueGameObject.SetActive(true);
            value2GameObject.SetActive(true);
            mathStatementGameObject.SetActive(true);
            inputAnswerGameObject.SetActive(false);
        }
        nextQuestionBTN.enabled = false;
        checkAnswerBTN.enabled = true;

    }
    public void questionAnswers()
    {
        if(questionTracker == 0)
        {
            int temp = numbers[randNumberStore];
            if (inputAnswer.text == temp.ToString())
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        if (questionTracker == 1)
        {
            if (inputAnswer.text == numberWords[randNumberStore])
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        if (questionTracker == 2)
        {
            if (inputAnswer.text == numbers[randNumberStore].ToString())
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        if (questionTracker == 3)
        {
            if (inputAnswer.text == numberWords[randNumberStore])
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        if (questionTracker == 4)
        {
            if (mathStatement.text == question5Answer)
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        if (questionTracker == 5)
        {
            if (mathStatement.text == question5Answer)
            {
                answerText.text = "You're Correct";
                Points++;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, maybe next time";
            }
        }
        nextQuestionBTN.enabled = true;
        checkAnswerBTN.enabled = false;
        questionTracker++;
        mathStatement.text = "";
        if (questionTracker == 6)
        {
            completedScene();
        }
    }
    void question1()
    {
        randNumberForQuestion = Random.Range(0, 100);
        Question.text = numberWords[randNumberForQuestion].ToString();
        randNumberStore = randNumberForQuestion;
        answerText.text = "Write this word as a value";
    }

    void question2()
    {
        randNumberForQuestion = Random.Range(0, 100);
        Question.text = numbers[randNumberForQuestion].ToString();
        randNumberStore = randNumberForQuestion;
        answerText.text = "Write this value as a word";
    }
    void question3()
    {
        randNumberForQuestion = Random.Range(0, 100);
        Question.text = numberWords[randNumberForQuestion].ToString();
        randNumberStore = randNumberForQuestion;
        answerText.text = "Write this word as a value";
    }
    void question4()
    {
        randNumberForQuestion = Random.Range(0, 100);
        Question.text = numbers[randNumberForQuestion].ToString();
        randNumberStore = randNumberForQuestion;
        answerText.text = "Write this value as a word";
    }

    void question5()
    {
        randNumberForQuestion = Random.Range(0, 100);
        value.text = randNumberForQuestion.ToString();
        int temp = randNumberForQuestion;
        randNumberForQuestion = Random.Range(0, 100);
        value2.text = randNumberForQuestion.ToString();
        Question.text = "is value One greater or less than value Two or equal";
        int temp2 = randNumberForQuestion;
        if(temp2 < temp)
        {
            question5Answer = ">";
        }
        else if(temp2 == temp)
        {
            question5Answer = "=";
        }
        else
        {
            question5Answer = "<";
        }
    }
    void question6()
    {
        randNumberForQuestion = Random.Range(0, 100);
        value.text = randNumberForQuestion.ToString();
        int temp = randNumberForQuestion;
        randNumberForQuestion = Random.Range(0, 100);
        value2.text = randNumberForQuestion.ToString();
        Question.text = "is value One greater or less than value One or equal";
        int temp2 = randNumberForQuestion;
        if (temp2 < temp)
        {
            question5Answer = ">";
        }
        else if (temp2 == temp)
        {
            question5Answer = "=";
        }
        else
        {
            question5Answer = "<";
        }
    }
    void completedScene()
    {
        Points = 0;
        questionTracker = 0;
        completedSceneObject.SetActive(true);
    }
}
