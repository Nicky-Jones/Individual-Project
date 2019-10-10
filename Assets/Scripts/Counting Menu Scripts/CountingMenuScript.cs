using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingMenuScript : MonoBehaviour {

    public GameObject randomNumber;
    public GameObject countingScene;
    public GameObject oneMoreOneLessExample;
    public GameObject readWrite;

    public void randNumberScene()
    {
        randomNumber.SetActive(true);
        //oneMoreOneLessExample.SetActive(true);
        countingScene.SetActive(false);
    }
    public void readWrite1()
    {
        readWrite.SetActive(true);
        countingScene.SetActive(false);
    }
}
