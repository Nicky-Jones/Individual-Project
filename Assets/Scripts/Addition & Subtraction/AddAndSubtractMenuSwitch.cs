using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAndSubtractMenuSwitch : MonoBehaviour {

    public GameObject mathStatementScene;
    public GameObject AddAndSubtractMainMenu;
    public GameObject oneDigitTwoDigit;

    public void changetoShapes()
    {
        AddAndSubtractMainMenu.SetActive(false);
        mathStatementScene.SetActive(true);
    }
    public void OneDigitTwoDigit()
    {
        AddAndSubtractMainMenu.SetActive(false);
        oneDigitTwoDigit.SetActive(true);
    }
}
