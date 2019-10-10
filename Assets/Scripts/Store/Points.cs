using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public int points = 150;

    public void setPoints(int pointValue)
    {
        points = points + pointValue;
    }
    public int getPoints()
    {
        return points;
    }
}
