using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplicationMenuSwitchScript : MonoBehaviour {

    public GameObject oneStepProblemScene;
    public GameObject multiplicationMainMenu;

    public void changetoOneStep()
    {
        multiplicationMainMenu.SetActive(false);
        oneStepProblemScene.SetActive(true);
    }
}
