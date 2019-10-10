using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MeasurementsScript : MonoBehaviour {
    public Points points;
    public Sprite[] images;
    public TMP_Text questionText;
    public TMP_Text questionText2;
    Image shapeImage;
    public GameObject image;
    public TMP_InputField answer;
    public TMP_Text answerText;
    int tracker = -1;

    void Start()
    {
        shapeImage = image.GetComponent<Image>();
    }
    public void nextQuestion()
    {
        tracker++;
        question1();
        question2();
        question3();
        question4();
        question5();
        question6();
        question7();
        question8();
        question9();
        
        
    }
    void question1()
    {
        if (tracker == 0)
        {
            questionText.text = "This jug holds 10ml of water, how much more would you need to add so the jug holds 25ml";
            shapeImage.sprite = images[0];
        }
    }
    void question2()
    {
        if(tracker == 1)
        {
            questionText.text = "This jug holds 20ml of water, how much more would you need to remove so the jug holds 15ml";
            shapeImage.sprite = images[0];
        }
    }
    void question3()
    {
        if (tracker == 2)
        {
            questionText.text = "Sam needs to sort these bags of flour into grams, convert these following measurements for him. example: 2kg = 2000g";
            questionText2.text = "1) 1kg";
        }
    }
    void question4()
    {
        if(tracker == 3)
        {
            questionText.text = "Sam needs to sort these bags of flour into grams, convert these following measurements for him. example: 2kg = 2000g";
            questionText2.text = "1) 4kg";
        }
    }
    void question5()
    {
        if (tracker == 4)
        {
            questionText.text = "What is the time on the clock? example: 2pm, 2:30pm";
            shapeImage.sprite = images[1];
        }
    }
    void question6()
    {
        if (tracker == 5)
        {
            questionText.text = "What is the time on the clock? example: 2pm, 2:30pm";
            shapeImage.sprite = images[2];
        }
    }
    void question7()
    {
        if(tracker == 6)
        {
            questionText.text = "What value is this coin worth? example: 40p, £2, £5";
            shapeImage.sprite = images[3];
        }
    }
    void question8()
    {
        if (tracker == 7)
        {
            questionText.text = "What value is this coin worth? example: 40p, £2, £5";
            shapeImage.sprite = images[4];
        }
    }
    void question9()
    {
        if (tracker == 8)
        {
            questionText.text = "What value is this coin worth? example: 40p, £2, £5";
            shapeImage.sprite = images[5];
        }
    }
    void answer1()
    {
        if(tracker == 0)
        {
            if(answer.text == "25".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer2()
    {
        if (tracker == 1)
        {
            if (answer.text == "15".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer3()
    {
        if (tracker == 2)
        {
            if (answer.text == "1000".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer4()
    {
        if (tracker == 3)
        {
            if (answer.text == "4000".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer5()
    {
        if (tracker == 4)
        {
            if (answer.text == "1pm".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer6()
    {
        if (tracker == 5)
        {
            if (answer.text == "1:25pm".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer7()
    {
        if (tracker == 6)
        {
            if (answer.text == "20p".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer8()
    {
        if (tracker == 7)
        {
            if (answer.text == "50p".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }
    void answer9()
    {
        if (tracker == 8)
        {
            if (answer.text == "£5".ToString())
            {
                answerText.text = "Congratulations you've got it correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Sorry, better luck next time!";
            }
        }
    }


}
