using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour {

    public GameObject[] escMenu;
    public GameObject mainMenu;
    public GameObject openingMenu;
    public GameObject escapeMenu;
    public GameObject completedScene;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Escape"))
        {
            escapeMenu.SetActive(true);
            
        }
        escMenu = GameObject.FindGameObjectsWithTag("switchableMenu");
    }
    public void MainMenu()
    {
        foreach (GameObject n in escMenu)
        {
            n.SetActive(false);
            mainMenu.SetActive(true);
            escapeMenu.SetActive(false);
            if (completedScene.activeInHierarchy == true)
            {
                completedScene.SetActive(false);
            }
        }
    }
    public void OpeningMenu()
    {
        foreach (GameObject n in escMenu)
        {
            n.SetActive(false);
            openingMenu.SetActive(true);
            escapeMenu.SetActive(false);
            if (completedScene.activeInHierarchy == true)
            {
                completedScene.SetActive(false);
            }
        }
    }
    public void CloseEscMenu()
    {
        escapeMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
