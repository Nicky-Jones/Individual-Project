using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableQuestions : MonoBehaviour {

    public GameObject Question1;
    public GameObject Question2;
    public GameObject Question3;
    public GameObject Question4;
    public GameObject Question5;
    public GameObject Question6;
    public GameObject Question7;
    public GameObject Question8;
    public GameObject Question9;
    public GameObject Question10;
    public GameObject Question11;
    public GameObject Question12;
    public int? track = 0;

    public void tracker()
    {
        while (track != null)
        {
            if (track == 0)
            {
                question1();
                break;
            }
            if (track == 1)
            {
                question2();
                break;
            }
            if (track == 2)
            {
                question3();
                break;
            }
            if (track == 3)
            {
                question4();
                break;
            }
            if (track == 4)
            {
                question5();
                break;
            }
            if (track == 5)
            {
                question6();
                break;
            }
            if (track == 6)
            {
                question7();
                break;
            }
            if (track == 7)
            {
                question8();
                break;
            }
            if (track == 8)
            {
                question9();
                break;
            }
            if (track == 9)
            {
                question10();
                break;
            }
            if (track == 10)
            {
                question11();
                break;
            }
            if (track == 11)
            {
                question12();
                break;
            }
        }

    }
    void question1()
    {
        Question1.SetActive(true);
        track++;
    }
    void question2()
    {
        Question2.SetActive(true);
        track++;
    }
    void question3()
    {
        Question3.SetActive(true);
        track++;
    }
    void question4()
    {
        Question4.SetActive(true);
        track++;
    }
    void question5()
    {
        Question5.SetActive(true);
        track++;
    }
    void question6()
    {
        Question6.SetActive(true);
        track++;
    }
    void question7()
    {
        Question7.SetActive(true);
        track++;
    }
    void question8()
    {
        Question8.SetActive(true);
        track++;
    }
    void question9()
    {
        Question9.SetActive(true);
        track++;
    }
    void question10()
    {
        Question10.SetActive(true);
        track++;
    }
    void question11()
    {
        Question11.SetActive(true);
        track++;
    }
    void question12()
    {
        Question12.SetActive(true);
        track++;
    }
}
