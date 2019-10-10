using UnityEngine;
using System.Collections;
using System.Reflection;

namespace DoozyUI
{
    public static class GraphicUtility
    {
        public static Color ColorFrom256(int r, int g, int b, int a) { return new Color(r / 255f, g / 255f, b / 255f, a / 255f); }
        public static Color ColorFrom256(int r, int g, int b) { return new Color(r / 255f, g / 255f, b / 255f); }

        public static void PrintManifestResources()
        {
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Debug.Log("------------------");
            Debug.Log("Manifest Resources");
            Debug.Log("------------------");
            for (int i = 0; i < resourceNames.Length; i++)
                Debug.Log(i + 1 + ") " + resourceNames[i]);
            Debug.Log("--------END-------");

        }
    }
}
