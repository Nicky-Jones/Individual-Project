using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ReadWriteExampleScript : MonoBehaviour {

    public TMP_Text mainTextBox;
    public TMP_Text randomNumber;
    public TMP_Text oneMore;
    public TMP_Text mainPanelTextBox;
    public GameObject arrowPointingToRandomNumber;
    public GameObject arrowPointingToOneMore;
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
            
            number = 2;
            randomNumber.text = number.ToString();
        }
    }
    void changeValue2()
    {
        
        if (changeValue == 1)
        {
            mainTextBox.SetText("Now that we've got a number or word lets see if we have to type a number or a word");
        }
    }
    void changeValue3()
    {
        if(changeValue == 2)
        {
            arrowPointingToRandomNumber.SetActive(true);
            mainTextBox.SetText("As you can see because it is a number and not a word we know we have to type the word of that number");
        }
    }
    void changeValue4()
    {
        if (changeValue == 3)
        {
            arrowPointingToRandomNumber.SetActive(false);
            arrowPointingToOneMore.SetActive(true);
            mainTextBox.SetText("which would be");
            oneMore.text = "Two";
        }
    }
    void changeValue5()
    {
        if(changeValue == 4)
        {
            mainTextBox.text = "Hope you enjoyed the tutorial, good luck on the rest of the questions!";
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
