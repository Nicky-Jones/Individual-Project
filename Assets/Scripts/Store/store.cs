using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class store : MonoBehaviour {
    public Points pointsValue;
    public TMP_Text pointsDisplay;
    public GameObject KS1Background;
    public GameObject KS2Background;
    public GameObject backgroundStore;
    public GameObject storeGameObject;
    Image ks1;
    Image ks2;
    public Sprite[] backgroundImages;
    public TMP_Text errorText;
    int points;

    int imageCounter;

    void Start()
    {
        //pointsValue.GetComponentsInParent<Points>();
        points = pointsValue.getPoints();
        ks1 = KS1Background.GetComponent<Image>();
        ks2 = KS2Background.GetComponent<Image>();
        pointsDisplay.text = points.ToString();
    }
    void Update()
    {
        if (storeGameObject.gameObject.activeSelf == true)
        {
            points = pointsValue.getPoints();
            pointsDisplay.text = points.ToString();
        }
    }
    public void backgroundImageOne()
    {
        if (pointsValue.getPoints() >= 150)
        {
            imageCounter = 1;
            errorText.text = "";
            pointsValue.setPoints(-150);
            changeBackgroundImage();
        }
        else
        {
            errorText.text = "Sorry, You don't have enough points to purchase this background image";
        }
    }
    public void backgroundImageTwo()
    {
        if (pointsValue.getPoints() >= 150)
        {
            imageCounter = 2;
            errorText.text = "";
            pointsValue.setPoints(-150);
            changeBackgroundImage();
        }
        else
        {
            errorText.text = "Sorry, You don't have enough points to purchase this background image";
        }
    }
    public void backgroundImageThree()
    {
        if (pointsValue.getPoints() >= 150)
        {
            imageCounter = 3;
            errorText.text = "";
            pointsValue.setPoints(-150);
            changeBackgroundImage();
            
        }
        else
        {
            errorText.text = "Sorry, You don't have enough points to purchase this background image";
        }
    }

    void changeBackgroundImage()
    {
        if(imageCounter == 1)
        {
            ks1.sprite = backgroundImages[0];
            ks2.sprite = backgroundImages[0];
        }
        else if (imageCounter == 2)
        {
            ks1.sprite = backgroundImages[1];
            ks2.sprite = backgroundImages[1];
        }
        else if (imageCounter == 3)
        {
            ks1.sprite = backgroundImages[2];
            ks2.sprite = backgroundImages[2];
        }
        else
        {
            errorText.text = "Error in changing background image function";
        }
    }
    public void backgroundExit()
    {
        backgroundStore.SetActive(false);
    }
    public void storeExit()
    {
        storeGameObject.SetActive(false);
    }
    public void openStore()
    {
        storeGameObject.SetActive(true);
    }
    public void backgroundStoreOpen()
    {
        backgroundStore.SetActive(true);
    }
}
