using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ReadAndWrite : MonoBehaviour {

    public Points points;
    public TMP_Text random;
    public TMP_InputField answer;
    public TMP_Text answerText;
    public Button checkAnswerBTN;
    public GameObject completedScene;
    public int choice = 0;
    public int choiceAnswer = 0;

    int score;

    public void pickSomethingRandom()
    {
        choice1();
        checkAnswerBTN.enabled = true;
        choice2();
        checkAnswerBTN.enabled = true;
        choice3();
        checkAnswerBTN.enabled = true;
        choice4();
        checkAnswerBTN.enabled = true;
        choice5();
        checkIfCompleted();
        choice = choice + 1;


    }
    public void checkAnswers()
    {
        answer1();
        answer2();
        answer3();
        answer4();
        answer5();
        choiceAnswer = choiceAnswer + 1;
    }

    void choice1()
    {
        if(choice == 0)
        {
            random.text = "Five";
            
        }
    }
    
    void answer1()
    {
        if (choiceAnswer == 0)
        {
            if (answer.text == 5.ToString())
            {
                answerText.text = "Well done, you're correct";
                checkAnswerBTN.enabled = false;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, you're not correct this time";
                checkAnswerBTN.enabled = false;
            }
            score = score + 1;
        }
        
    }

    void choice2()
    {
        if (choice == 1)
        {
            random.text = 8.ToString();
        }
    }

    void answer2()
    {
        if (choiceAnswer == 1)
        {
            if (answer.text == "Eight")
            {
                answerText.text = "Well done, you're correct!";
                checkAnswerBTN.enabled = false;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, you're not correct this time";
                checkAnswerBTN.enabled = false;
            }
            score = score + 1;
        }

    }
    void choice3()
    {
        if(choice == 2)
        {
            random.text = "Twenty";
        }
    }
    void answer3()
    {
        if (choiceAnswer == 2)
        {
            if (answer.text == 20.ToString())
            {
                answerText.text = "Well done, you're correct!";
                checkAnswerBTN.enabled = false;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, you're not correct this time";
                checkAnswerBTN.enabled = false;
            }
            score = score + 1;
        }

    }
    
    void choice4()
    {
        if(choice == 3)
        {
            random.text = 13.ToString();
        }
    }
    void answer4()
    {
        if(choiceAnswer == 3)
        {
            if(answer.text == "Thirteen")
            {
                answerText.text = "Well done, you're correct!";
                checkAnswerBTN.enabled = false;
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, you're not correct this time";
                checkAnswerBTN.enabled = false;
            }
            score = score + 1;
        }

    }
    void choice5()
    {
        if(choice == 4)
        {
            random.text = 17.ToString();
        }
    }
    void answer5()
    {
        if(choiceAnswer == 4)
        {
            if(answer.text == "Seventeen")
            {
                answerText.text = "Well done, you're correct!";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, you're not correct this time";
            }
            score = score + 1;
        }
    }
    void checkIfCompleted()
    {
        if (score == 5)
        {
            completedScene.SetActive(true);
        }
    }
}
