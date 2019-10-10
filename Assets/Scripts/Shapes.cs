using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Shapes : MonoBehaviour {
    public Points points;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text btntext1;
    public TMP_Text btntext2;
    public TMP_Text btntext3;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    Image shapeImage;
    public GameObject image;
    public Sprite[] differentShapes;
    public GameObject completedScene;
    int checker = -1;

	// Use this for initialization
	void Start () {

        shapeImage = image.GetComponent<Image>();

        nextQuestion();
    }
    public void button1()
    {
        if(checker == 0)
        {
            text1.text = "Correct!";
            points.setPoints(5);
        }
        else if(checker == 1)
        {
            text1.text = "Sorry, incorrect answer";
        }
        else if(checker == 2)
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
        if(checker == 0)
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
        if(checker == 0)
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
        image5();
        image6();
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
            btntext1.text = "Circle";
            btntext2.text = "Triangle";
            btntext3.text = "Hexagon";
        }
    }
    void image2()
    {
        if (checker == 1)
        {
            shapeImage.sprite = differentShapes[1];
            btntext1.text = "Pyramid";
            btntext2.text = "Cone";
            btntext3.text = "Triangle";
        }
    }
    void image3()
    {
        if (checker == 2)
        {
            shapeImage.sprite = differentShapes[2];
            btntext1.text = "Square";
            btntext2.text = "Hexagon";
            btntext3.text = "Pentagon";
        }
    }
    void image4()
    {
        if (checker == 3)
        {
            shapeImage.sprite = differentShapes[3];
            btntext1.text = "Sphere";
            btntext2.text = "Circle";
            btntext3.text = "Cone";
        }
    }
    void image5()
    {
        if(checker == 4)
        {
            shapeImage.sprite = differentShapes[4];
            btntext1.text = "Triangle";
            btntext2.text = "Pyramid";
            btntext3.text = "Cone";
        }
    }
    void image6()
    {
        if(checker == 5)
        {
            shapeImage.sprite = differentShapes[5];
            btntext1.text = "Cone";
            btntext2.text = "Pentagon";
            btntext3.text = "Triangle";
        }
    }

    
}
