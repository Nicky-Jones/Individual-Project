using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GeometryY2 : MonoBehaviour {
    public Points points;
    public TMP_InputField userAnswer;
    public TMP_InputField userEdges;
    public TMP_InputField userFaces;
    public TMP_InputField userCorners;
    public TMP_Text answerText;
    public TMP_Text questionText;
    public TMP_Text edgeAnswerText;
    public TMP_Text faceAnswerText;
    public TMP_Text cornerAnswerText;
    public TMP_Text edgeText;
    public TMP_Text faceText;
    public TMP_Text cornerText;
    public GameObject cube;
    public GameObject sphere;
    public GameObject completedScene;
    int questionTracker = 0;
    int threeDshapeTracker = 0;
    public void questionDataBase()
    {
        questionTracker++;
        reset();
        cube.SetActive(false);
        sphere.SetActive(false);
        question1();
        question2();
        question3();
        if(questionTracker == 4)
        {
            answerText.gameObject.SetActive(false);
            userAnswer.gameObject.SetActive(false);
            userEdges.gameObject.SetActive(true);
            userFaces.gameObject.SetActive(true);
            userCorners.gameObject.SetActive(true);
            edgeText.gameObject.SetActive(true);
            faceText.gameObject.SetActive(true);
            cornerText.gameObject.SetActive(true);
        }
        question4();
        question5();
        if(questionTracker == 6)
        {
            completedScene.SetActive(true);
        }
    }
    private void reset()
    {
        userAnswer.text = "";
        userCorners.text = "";
        userEdges.text = "";
        userFaces.text = "";
        answerText.text = "";
        edgeAnswerText.text = "";
        faceAnswerText.text = "";
        cornerAnswerText.text = "";
    }
    public void questionAnswers()
    {
        if(questionTracker == 1)
        {
            if (userAnswer.text == "Square")
            {
                answerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Incorrect";
            }
        }
        if (questionTracker == 2)
        {
            if (userAnswer.text == "Circle")
            {
                answerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Incorrect";
            }
        }
        if (questionTracker == 3)
        {
            if (userAnswer.text == "Triangle")
            {
                answerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                answerText.text = "Incorrect";
            }
        }
        if (questionTracker == 4)
        {
            if (userEdges.text == 12.ToString())
            {
                edgeAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                edgeAnswerText.text = "Incorrect";
            }
            if (userFaces.text == 6.ToString())
            {
                faceAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                faceAnswerText.text = "Incorrect";

            }
            if(userCorners.text == 8.ToString())
            {
                cornerAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                cornerAnswerText.text = "Incorrect";
            }
        }
        if (questionTracker == 5)
        {
            if (userEdges.text == 0.ToString())
            {
                edgeAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                edgeAnswerText.text = "Incorrect";
            }
            if (userFaces.text == 1.ToString())
            {
                faceAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                faceAnswerText.text = "Incorrect";

            }
            if (userCorners.text == 0.ToString())
            {
                cornerAnswerText.text = "Correct";
                points.setPoints(5);
            }
            else
            {
                cornerAnswerText.text = "Incorrect";
            }
        }
    }
    void question1()
    {
        if (questionTracker == 1)
        {
            questionText.text = "This 2D shape has 4 straight edges which are all the same length, it has 4 corners, What is it?";
        }
    }
    void question2()
    {
        if(questionTracker == 2)
        {
            questionText.text = "This 2D shape has no straight edges, only one curved edge and has no corners, What is it?";
        }
    }
    void question3()
    {
        if(questionTracker == 3)
        {
            questionText.text = "This 2D shape has 3 straight edges, and 3 corners, What is it?";
        }
    }
    void question4()
    {
        if (questionTracker == 4)
        {
            questionText.text = "How many straight edges, faces and corners does this 3D shape have?";
            cube.SetActive(true);
        }
    }
    void question5()
    {
        if(questionTracker == 5)
        {
            questionText.text = "How many Curve edges, faces and corners does this 3D shape have?";
            sphere.SetActive(true);
        }
    }
}
