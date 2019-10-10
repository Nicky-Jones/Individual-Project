using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FractionsY2 : MonoBehaviour {
    public Points points;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text btntext1;
    public TMP_Text btntext2;
    public TMP_Text btntext3;
    public TMP_Text part2Text;
    public TMP_Text answerMessage;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    Image shapeImage;
    public GameObject image;
    public Sprite[] differentShapes;
    public GameObject completedScene;
    public Button checkAnswer;
    public TMP_InputField number1;
    public TMP_InputField number2;
    public TMP_InputField mathStatement;
    public TMP_InputField questionAnswer;
    int checker = -1;

    // Use this for initialization
    void Start()
    {

        shapeImage = image.GetComponent<Image>();

        nextQuestion();
    }
    public void button1()
    {
        if (checker == 0)
        {
            text1.text = "Correct!";
            points.setPoints(5);
        }
        else if (checker == 1)
        {
            text1.text = "Sorry, incorrect answer";
        }
        else if (checker == 2)
        {
            text1.text = "Sorry, incorrect answer";
        }
        else if (checker == 3)
        {
            text1.text = "Correct!";
            points.setPoints(5);
        }
        else if (checker == 4)
        {
            text1.text = "Sorry, incorrect answer";
        }
        else if (checker == 5)
        {
            text1.text = "Correct!";
            points.setPoints(5);
        }
    }
    public void button2()
    {
        if (checker == 0)
        {
            text2.text = "Sorry, incorrect answer";
        }
        else if (checker == 1)
        {
            text2.text = "Sorry, incorrect answer";
        }
        else if (checker == 2)
        {
            text2.text = "Correct!";
            points.setPoints(5);
        }
        else if (checker == 3)
        {
            text2.text = "Sorry, incorrect answer";
        }
        else if (checker == 4)
        {
            text2.text = "Correct!";
            points.setPoints(5);
        }
        else if (checker == 5)
        {
            text2.text = "Sorry, incorrect answer";
        }
    }
    public void button3()
    {
        if (checker == 0)
        {
            text3.text = "Sorry, incorrect answer";
        }
        else if (checker == 1)
        {
            text3.text = "Correct!";
            points.setPoints(5);
        }
        else if (checker == 2)
        {
            text3.text = "Sorry, incorrect answer";
        }
        else if (checker == 3)
        {
            text3.text = "Sorry, incorrect answer";
        }
        else if (checker == 4)
        {
            text3.text = "Sorry, incorrect answer";
        }
        else if (checker == 5)
        {
            text3.text = "Sorry, incorrect answer";
        }
    }
    public void nextQuestion()
    {
        checker = checker + 1;
        image1();
        image2();
        image3();
        image4();
        if (checker == 4)
        {
            image.gameObject.SetActive(false);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            btntext1.gameObject.SetActive(false);
            btntext2.gameObject.SetActive(false);
            btntext3.gameObject.SetActive(false);
            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
            btn3.gameObject.SetActive(false);
            //number1.enabled = true;
            number2.gameObject.SetActive(true);
            checkAnswer.gameObject.SetActive(true);
            mathStatement.gameObject.SetActive(true);
            questionAnswer.gameObject.SetActive(true);
            part2Text.text = "Finish the sentence";
        }
        mathStatement.text = "";
        answerMessage.text = "";
        fractionQuestion();
        fractionQuestion2();
        text1.text = "";
        text2.text = "";
        text3.text = "";
        if (checker == 6)
        {
            completedScene.SetActive(true);
        }

    }
    void image1()
    {
        if (checker == 0)
        {
            shapeImage.sprite = differentShapes[0];
            btntext1.text = "1/4";
            btntext2.text = "2/4";
            btntext3.text = "1/3";
        }
    }
    void image2()
    {
        if (checker == 1)
        {
            shapeImage.sprite = differentShapes[1];
            btntext1.text = "3/4 Circle";
            btntext2.text = "1/4 Circle";
            btntext3.text = "1/3 Circle";
        }
    }
    void image3()
    {
        if (checker == 2)
        {
            shapeImage.sprite = differentShapes[2];
            btntext1.text = "1/4 Circle";
            btntext2.text = "2/4 Circle";
            btntext3.text = "2/3 Circle";
        }
    }
    void image4()
    {
        if (checker == 3)
        {
            shapeImage.sprite = differentShapes[3];
            btntext1.text = "3/4";
            btntext2.text = "2/4";
            btntext3.text = "3/5";
        }
    }
    void fractionQuestion()
    {
        if(checker == 4)
        {
            part2Text.text = "What is the faction for half of 6";
            number2.text = "6";
            questionAnswer.text = "3";
        }
    }
    void fractionQuestion2()
    {
        if (checker == 5)
        {
            part2Text.text = "What fraction do you need to get 2 from 8";
            number2.text = "8";
            questionAnswer.text = "2";
        }
    }

    public void checkAnswers()
    {
        if(checker == 4)
        {
            if(mathStatement.text == "1/2")
            {
                answerMessage.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
        }
        if(checker == 5)
        {
            if (mathStatement.text == "1/4")
            {
                answerMessage.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                answerMessage.text = "Incorrect";
            }
        }
    }
}
