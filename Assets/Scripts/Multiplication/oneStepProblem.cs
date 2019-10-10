using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class oneStepProblem : MonoBehaviour {
    public Points points;
    public TMP_Text questionMessage;
    public TMP_InputField answer;
    public TMP_Text answerMessage;
    public GameObject completedScene;
    public Sprite Socks;
    Image[] shapeImage = new Image[6];
    int checker = -1;

    public GameObject[] image1;

    void Start()
    {
        for (int x = 0; x < 6; x++)
        {
            shapeImage[x] = image1[x].GetComponent<Image>();
        }
        for (int x = 0; x < 6; x++)
        {
            shapeImage[x].sprite = Socks;
        }
        nextQuestion();
    }
    public void nextQuestion()
    {
        checker++;
        questionMessage.text = "";
        answerMessage.text = "";
        answer.enabled = true;
        answer.text = "";
        for (int x = 0; x < 6; x++)
        {
            image1[x].SetActive(false);
        }
        question1();
        question2();
        question3();
        question4();
    }
    public void answers()
    {
        if(checker == 0)
        {
            if(answer.text == 4.ToString())
            {
                answerMessage.text = "You're correct!";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Sorry, maybe next time";
                answer.enabled = false;
            }
        }
        if (checker == 1)
        {
            if (answer.text == 6.ToString())
            {
                answerMessage.text = "You're correct!";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Sorry, maybe next time";
                answer.enabled = false;
            }
        }
        if (checker == 2)
        {
            if (answer.text == 10.ToString())
            {
                answerMessage.text = "You're correct!";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Sorry, maybe next time";
                answer.enabled = false;
            }
        }
        if (checker == 3)
        {
            if (answer.text == 12.ToString())
            {
                answerMessage.text = "You're correct!";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Sorry, maybe next time";
                answer.enabled = false;
            }
            completedscene();
        }
    }
    void question1()
    {
        if (checker == 0)
        {
            image1[0].SetActive(true);
            image1[1].SetActive(true);
            questionMessage.text = "There is Two pairs of socks, how many socks altogether?";
        }
    }
    void question2()
    {
        if (checker == 1)
        {
            image1[0].SetActive(true);
            image1[1].SetActive(true);
            image1[2].SetActive(true);
            questionMessage.text = "There is Three pairs of socks, how many socks altogether?";
        }
    }
    void question3()
    {
        if(checker == 2)
        {
            image1[0].SetActive(true);
            image1[1].SetActive(true);
            image1[2].SetActive(true);
            image1[3].SetActive(true);
            image1[4].SetActive(true);
            questionMessage.text = "There is Five pairs of socks, how many socks altogether?";
        }
    }
    void question4()
    {
        if (checker == 3)
        {
            image1[0].SetActive(true);
            image1[1].SetActive(true);
            image1[2].SetActive(true);
            image1[3].SetActive(true);
            image1[4].SetActive(true);
            image1[5].SetActive(true);
            questionMessage.text = "There is Six pairs of socks, how many socks altogether?";
        }
    }


    void completedscene()
    {
        completedScene.SetActive(true);
        checker = -1;
        for (int x = 0; x < 6; x++)
        {
            image1[x].SetActive(false);
        }
        questionMessage.text = "";
        answer.text = "";
        answerMessage.text = "";
    }
}
