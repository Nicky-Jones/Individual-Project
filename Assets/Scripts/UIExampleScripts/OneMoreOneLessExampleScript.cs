using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class OneMoreOneLessExampleScript : MonoBehaviour {


    public TMP_Text mainTextBox;
    public TMP_Text randomNumber;
    public TMP_Text oneMore;
    public TMP_Text oneLess;
    public TMP_Text mainPanelTextBox;
    public GameObject arrowPointingToRandomNumber;
    public GameObject arrowPointingToOneMore;
    public GameObject arrowPointingToOneLess;
    public GameObject examplePanel;
    int changeValue = 0;
    int number;
    public void changeText()
    {
        changeValue1();
        changeValue2();
        changeValue3();
        changeValue4();
        changeValue5();
        changeValue6();
        changeValue = changeValue + 1;
    }
    void changeValue1()
    {
        if (changeValue == 0)
        {
            mainTextBox.SetText("Here is an example");
            arrowPointingToRandomNumber.SetActive(true);
            number = Random.Range(0, 101);
            randomNumber.text = number.ToString();
        }
    }
    void changeValue2()
    {
        if (changeValue == 1)
        {
            mainTextBox.SetText("Now that we've got a number, lets find a number that's One more and One less than " + randomNumber.text.ToString());
        }
    }
    void changeValue3()
    {
        if (changeValue == 2)
        {
            mainTextBox.SetText("if you look to the right, you'll see two boxes to enter the values in, lets do this example");
            arrowPointingToOneMore.SetActive(true);
            int number1 = number + 1;
            oneMore.text = number1.ToString();
            mainTextBox.SetText("Lets figure out whats One more than " + randomNumber.text.ToString() + " that would be " + oneMore.text.ToString());
            
        }
    }
    void changeValue4()
    {
        if (changeValue == 3)
        {
            arrowPointingToOneMore.SetActive(false);
            arrowPointingToOneLess.SetActive(true);
            int number2 = number - 1;
            oneLess.text = number2.ToString();
            mainTextBox.SetText("Now Lets figure out whats One less than " + randomNumber.text.ToString() + " that would be " + oneLess.text.ToString());
            
        }
    }
    void changeValue5()
    {
        if (changeValue == 4)
        {
            mainTextBox.text = "Hope you enjoyed this tutorial, Good Luck! :) ";
            
        }
    }
    void changeValue6()
    {
        if (changeValue == 5)
        {
            examplePanel.SetActive(false);
            mainPanelTextBox.enabled = true;
        }
    }
}
