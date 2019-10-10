using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timesTableMenuSwitching : MonoBehaviour {
    public GameObject hideJunkScenes;
    public GameObject timesTable;
    public GameObject oneXTable;
    public GameObject twoXTable;
    public GameObject threeXTable;
    public GameObject fourXTable;
    public GameObject fiveXTable;
    public GameObject sixXTable;
    public GameObject sevenXTable;
    public GameObject eightXTable;
    public GameObject nineXTable;
    public GameObject tenXTable;
    public GameObject elevenXTable;
    public GameObject twelveXTable;

    public void onexTable()
    {
        timesTable.SetActive(false);
        oneXTable.SetActive(true);
    }
    public void twoxTable()
    {
        timesTable.SetActive(false);
        hideJunkScenes.SetActive(true);
        twoXTable.SetActive(true);
    }
    public void threexTable()
    {
        timesTable.SetActive(false);
        threeXTable.SetActive(true);
    }
    public void fourxTable()
    {
        timesTable.SetActive(false);
        fourXTable.SetActive(true);
    }
    public void fivexTable()
    {
        timesTable.SetActive(false);
        hideJunkScenes.SetActive(true);
        fiveXTable.SetActive(true);
    }
    public void sixxTable()
    {
        timesTable.SetActive(false);
        sixXTable.SetActive(true);
    }
    public void sevenxTable()
    {
        timesTable.SetActive(false);
        sevenXTable.SetActive(true);
    }
    public void eightxTable()
    {
        timesTable.SetActive(false);
        eightXTable.SetActive(true);
    }
    public void ninexTable()
    {
        timesTable.SetActive(false);
        nineXTable.SetActive(true);
    }
    public void tenxTable()
    {
        timesTable.SetActive(false);
        hideJunkScenes.SetActive(true);
        tenXTable.SetActive(true);
    }
    public void elevenxTable()
    {
        timesTable.SetActive(false);
        elevenXTable.SetActive(true);
    }
    public void twelvexTable()
    {
        timesTable.SetActive(false);
        twelveXTable.SetActive(true);
    }
}


