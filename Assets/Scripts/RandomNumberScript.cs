using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class RandomNumberScript : MonoBehaviour {
    public Points points;
    public TMP_InputField oneMore;
    public TMP_InputField oneLess;
    public TMP_InputField actualNumber;
    public TMP_Text randomNumber;
    public TMP_Text Score;
    public TMP_Text answer1Text;
    public TMP_Text answer2Text;
    public TMP_Text answer3Text;
    public GameObject completedScene;
    int scoreValue;
    int randomNumberValue;




    public void generateRandomNumber()
    {
        randomNumberValue = Random.Range(0, 101);

        randomNumber.text = randomNumberValue.ToString();
    }

    public void checkAnswers()
    {
        int oneMoreValue = randomNumberValue + 1;
        if (oneMore.text == oneMoreValue.ToString())
        {
            answer1Text.text = "Correct, well done!";
            points.setPoints(5);

        }
        else if (oneMore.text != oneMoreValue.ToString())
        {
            answer1Text.text = "Sorry, this value is incorrect";

        }
        int oneLessValue = randomNumberValue - 1;
        if (oneLess.text == oneLessValue.ToString())
        {
            answer2Text.text = "Correct, well done!";
            points.setPoints(5);

        }
        else if (oneLess.text != oneLessValue.ToString())
        {
            answer2Text.text = "Sorry, this value is incorrect";

        }
        if(actualNumber.text == randomNumber.text)
        {
            answer3Text.text = "Correct, well done!";
            points.setPoints(5);

        }
        else
        {
            answer3Text.text = "Sorry, this value is incorrect";
            scoreValue = scoreValue + 1;
            Score.text = scoreValue.ToString();
        }
        if (oneMore.text == oneMoreValue.ToString())
        {
            if (oneLess.text == oneLessValue.ToString())
            {
                if (actualNumber.text == randomNumber.text)
                {
                    points.setPoints(5);
                    scoreValue = scoreValue + 1;
                    Score.text = scoreValue.ToString();
                }
            }
        }
        if (Score.text == "10")
        {
            completedScene.SetActive(true);
        }
    }
}
