using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeasurementsY2 : MonoBehaviour {
    public Points points;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text btntext1;
    public TMP_Text btntext2;
    public TMP_Text part2Text;
    public TMP_Text clockText;
    public TMP_Text answerMessage;
    public Button btn1;
    public Button btn2;
    public Button CheckAnswer;
    Image shapeImage;
    Image shapeImage2;
    Image clockImages;
    public GameObject image;
    public GameObject images2;
    public GameObject clockImage;
    public Sprite[] differentShapes;
    public GameObject completedScene;
    public Button checkAnswer;
    public TMP_InputField number1;
    public TMP_InputField number2;
    public TMP_InputField mathStatement;
    public TMP_InputField questionAnswer;
    public TMP_InputField clockInput;
    int checker = -1;

    // Use this for initialization
    void Start()
    {

        shapeImage = image.GetComponent<Image>();
        shapeImage2 = images2.GetComponent<Image>();
        clockImages = clockImage.GetComponent<Image>();
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
        else
        {
            text1.text = "Sorry, incorrect";
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
            text2.text = "Correct!";
            points.setPoints(5);
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
        else
        {
            text2.text = "Sorry, incorrect";
        }
    }
    public void nextQuestion()
    {
        checker = checker + 1;
        image1();
        image2();
        image3();
        image4();
        image5();
        if (checker == 5)
        {
            image.gameObject.SetActive(false);
            images2.gameObject.SetActive(false);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            btntext1.gameObject.SetActive(false);
            btntext2.gameObject.SetActive(false);
            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
            //number1.enabled = true;
            clockImage.gameObject.SetActive(true);
            clockInput.gameObject.SetActive(true);
            CheckAnswer.gameObject.SetActive(true);
        }
        if(checker == 7)
        {
            clockImage.gameObject.SetActive(false);
        }
        clockQuestion();
        clockQuestion2();
        minutes();
        minutes2();
        clockInput.text = "";
        clockText.text = "";
        mathStatement.text = "";
        answerMessage.text = "";
        text1.text = "";
        text2.text = "";
        if (checker == 9)
        {
            completedScene.SetActive(true);
        }

    }
    void image1()
    {
        if (checker == 0)
        {
            part2Text.text = "Which is smaller, left or right?";
            shapeImage.sprite = differentShapes[0];
            shapeImage2.sprite = differentShapes[1];
            btntext1.text = "Left";
            btntext2.text = "Right";
        }
    }
    void image2()
    {
        if (checker == 1)
        {
            part2Text.text = "Which is longer, left or right?";
            shapeImage.sprite = differentShapes[2];
            shapeImage2.sprite = differentShapes[3];
            btntext1.text = "Left";
            btntext2.text = "Right";
        }
    }
    void image3()
    {
        if (checker == 2)
        {
            part2Text.text = "Which can hold more, left or right?";
            shapeImage.sprite = differentShapes[4];
            shapeImage2.sprite = differentShapes[5];
            btntext1.text = "left";
            btntext2.text = "right";
        }
    }
    void image4()
    {
        if (checker == 3)
        {
            part2Text.text = "Which is heavier, left or right?";
            shapeImage.sprite = differentShapes[1];
            shapeImage2.sprite = differentShapes[5];
            btntext1.text = "left";
            btntext2.text = "right";
        }
    }
    void image5()
    {
        if(checker == 4)
        {
            part2Text.text = "Which is lighter, left or right?";
            {
                shapeImage.sprite = differentShapes[2];
                shapeImage2.sprite = differentShapes[5];
                btntext1.text = "left";
                btntext2.text = "right";
            }
        }
    }
    void clockQuestion()
    {
        if (checker == 5)
        {
            part2Text.text = "What time is it?";
            clockImages.sprite = differentShapes[6];
        }
    }
    void clockQuestion2()
    {
        if (checker == 6)
        {
            clockImages.sprite = differentShapes[7];
        }
    }
    void minutes()
    {
        if (checker == 7)
        {
            part2Text.text = "How many minutes in an hour?";
        }
    }
    void minutes2()
    {
        if (checker == 8)
        {
            part2Text.text = "How many hours in a day?";
        }
    }

    public void checkAnswers()
    {
        if(checker == 5)
        {
            if (clockInput.text == "1:05")
            {
                clockText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                clockText.text = "Incorrect";
            }
        }
        if(checker == 6)
        {
            if (clockInput.text == "3:15")
            {
                clockText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                clockText.text = "Incorrect";
            }
        }
        if(checker == 7)
        {
            if(clockInput.text == "60")
            {
                clockText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                clockText.text = "Incorrect";
            }
        }
        if(checker == 8)
        {
            if (clockInput.text == "24")
            {
                clockText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                clockText.text = "Incorrect";
            }
        }
    }
}
