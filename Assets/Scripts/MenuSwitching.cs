using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuSwitching : MonoBehaviour {
    public Points points;
    public TMP_Text pointsValueY1;
    public TMP_Text pointsValueY2;
    public GameObject openingMenu;
    public GameObject mainMenu;
    public GameObject counting;
    public GameObject AddandSubtract;
    public GameObject Shapes;
    public GameObject multiplication;
    public GameObject yearTwo;
    public GameObject numbersY2Scene;
    public GameObject numbersY2;
    public GameObject MultiplicationY2Scene;
    public GameObject MultiplicationY2;
    public GameObject MeasurementsY2Scene;
    public GameObject MeasurementsY2;
    public GameObject FractionsY2Scene;
    public GameObject FractionsY2;
    public GameObject GeometryY2Scene;
    public GameObject GeometryY2;
    int temp;
    void Update()
    {
        if (mainMenu.activeSelf == true)
        {
            temp = points.getPoints();
            pointsValueY1.text = temp.ToString();
        }
        else if (yearTwo.activeSelf == true)
        {
            temp = points.getPoints();
            pointsValueY2.text = temp.ToString();
        }
    }
    public void mainMenuSwitch()
    {
        openingMenu.SetActive(false);
        mainMenu.SetActive(true);
        int temp = points.getPoints();
        pointsValueY1.text = temp.ToString();
    }
    public void GeometryY2Switch()
    {
        GeometryY2.SetActive(true);
        yearTwo.SetActive(false);
    }
    public void GeometryY2SceneSwitch()
    {
        GeometryY2.SetActive(false);
        GeometryY2Scene.SetActive(true);
    }
    public void FractionsY2Switch()
    {
        FractionsY2.SetActive(true);
        yearTwo.SetActive(false);
    }
    public void FractionsY2SceneSwitch()
    {
        FractionsY2.SetActive(false);
        FractionsY2Scene.SetActive(true);
    }
    public void MeasurementsY2Switch()
    {
        MeasurementsY2.SetActive(true);
        yearTwo.SetActive(false);
    }
    public void MeasurementsY2SceneSwitch()
    {
        MeasurementsY2.SetActive(false);
        MeasurementsY2Scene.SetActive(true);
    }
    public void MultiplicationY2Switch()
    {
        MultiplicationY2.SetActive(true);
        yearTwo.SetActive(false);
    }
    public void MultiplicationY2SceneSwitch()
    {
        MultiplicationY2.SetActive(false);
        MultiplicationY2Scene.SetActive(true);
    }
    public void numbersY2Switch()
    {
        numbersY2.SetActive(true);
        yearTwo.SetActive(false);
    }
    public void numbersY2SceneSwitch()
    {
        numbersY2.SetActive(false);
        numbersY2Scene.SetActive(true);
    }
    public void yearTwoSwitch()
    {
        yearTwo.SetActive(true);
        mainMenu.SetActive(false);
        int temp = points.getPoints();
        pointsValueY2.text = temp.ToString();
    }
    public void CountingMenu()
    {
        mainMenu.SetActive(false);
        counting.SetActive(true);
    }
    public void AddandSubtractMenu()
    {
        mainMenu.SetActive(false);
        AddandSubtract.SetActive(true);
    }
    public void ShapesMenu()
    {
        mainMenu.SetActive(false);
        Shapes.SetActive(true);
    }
    public void MultiplicationMenu()
    {
        mainMenu.SetActive(false);
        multiplication.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
