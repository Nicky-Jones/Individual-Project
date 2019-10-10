using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesMenuScript : MonoBehaviour {

    public GameObject shapes2d3d;
    public GameObject shapesMainMenu;

    public void changetoShapes()
    {
        shapesMainMenu.SetActive(false);
        shapes2d3d.SetActive(true);
    }
}
