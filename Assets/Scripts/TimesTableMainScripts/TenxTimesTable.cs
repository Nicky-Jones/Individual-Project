using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DoozyUI.UIButton;

public class TenxTimesTable : MonoBehaviour
{
    public Points points;
    public InputField inputFieldx1;
    public InputField inputFieldx2;
    public InputField inputFieldx3;
    public InputField inputFieldx4;
    public InputField inputFieldx5;
    public InputField inputFieldx6;
    public InputField inputFieldx7;
    public InputField inputFieldx8;
    public InputField inputFieldx9;
    public InputField inputFieldx10;
    public Text TimesTableScore;
    public Text Question1Answer;
    public Text Question2Answer;
    public Text Question3Answer;
    public Text Question4Answer;
    public Text Question5Answer;
    public Text Question6Answer;
    public Text Question7Answer;
    public Text Question8Answer;
    public Text Question9Answer;
    public Text Question10Answer;
    public UIButton button;
    public UIButton button2;
    public UIButton button3;
    public UIButton button4;
    public UIButton button5;
    public UIButton button6;
    public UIButton button7;
    public UIButton button8;
    public UIButton button9;
    public UIButton button10;
    public GameObject completedScene;
    //public UIButton UIButton;
    int value = 1;

    public void x2Table1()
    {
        if (inputFieldx1.text == "10")
        {
            Debug.Log("Correct, well done!");
            TimesTableScore.text = value.ToString();
            Question1Answer.text = "Well Done, you're correct!";
            button.ExecutePointerUp();
            button.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question1Answer.text = "Incorrect, nice try! please try again";
            button.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table2()
    {
        if (inputFieldx2.text == "20")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question2Answer.text = "Well Done, you're correct!";
            button2.ExecutePointerUp();
            button2.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question2Answer.text = "Incorrect, nice try! please try again";
            button2.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table3()
    {
        if (inputFieldx3.text == "30")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question3Answer.text = "Well Done, you're correct!";
            button3.ExecutePointerUp();
            button3.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question3Answer.text = "Incorrect, nice try! please try again";
            button3.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table4()
    {
        if (inputFieldx4.text == "40")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question4Answer.text = "Well Done, you're correct!";
            button4.ExecutePointerUp();
            button4.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question4Answer.text = "Incorrect, nice try! please try again";
            button4.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table5()
    {
        if (inputFieldx5.text == "50")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question5Answer.text = "Well Done, you're correct!";
            button5.ExecutePointerUp();
            button5.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question5Answer.text = "Incorrect, nice try! please try again";
            button5.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table6()
    {
        if (inputFieldx6.text == "60")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question6Answer.text = "Well Done, you're correct!";
            button6.ExecutePointerUp();
            button6.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question6Answer.text = "Incorrect, nice try! please try again";
            button6.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table7()
    {
        if (inputFieldx7.text == "70")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question7Answer.text = "Well Done, you're correct!";
            button7.ExecutePointerUp();
            button7.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question7Answer.text = "Incorrect, nice try! please try again";
            button7.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table8()
    {
        if (inputFieldx8.text == "80")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question8Answer.text = "Well Done, you're correct!";
            button8.ExecutePointerUp();
            button8.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question8Answer.text = "Incorrect, nice try! please try again";
            button8.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table9()
    {
        if (inputFieldx9.text == "90")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question9Answer.text = "Well Done, you're correct!";
            button9.ExecutePointerUp();
            button9.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question9Answer.text = "Incorrect, nice try! please try again";
            button9.ExecuteDoubleClick();
        }

        Debug.Log("Testing");
    }
    public void x2Table10()
    {
        if (inputFieldx10.text == "100")
        {
            Debug.Log("Correct, well done!");
            value = value + 1;
            TimesTableScore.text = value.ToString();
            Question10Answer.text = "Well Done, you're correct!";
            button10.ExecutePointerUp();
            button10.DisableButtonClicks();
            points.setPoints(5);

        }
        else
        {
            Question10Answer.text = "Incorrect, nice try! please try again";
            button10.ExecuteDoubleClick();
        }
        end();
        Debug.Log("Testing");
    }
    public void end()
    {
        if (value == 10)
        {

            completedScene.SetActive(true);
        }
    }
}
