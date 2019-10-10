// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;
using UnityEditor;

public static class DoozyUIHelper
{
    #region COLOR
    public static Color ColorBlack = new Color(255, 255, 255);

    public static void SetZoneColor(Color c)
    {
        GUI.backgroundColor = c;
    }

    public static void SetZoneColor(int r, int g, int b, int a = 255)
    {
        GUI.backgroundColor = GetColor(r, g, b, a);
    }

    public static Color GetColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

    public static Color GetColor(int r, int g, int b, int a)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
    }

    public static void ResetColors()
    {
        GUI.color = Color.white;
        GUI.contentColor = Color.white;
        GUI.backgroundColor = Color.white;
    }
    #endregion

    #region Spaces - VerticalSpace, HorizontalSpace
    public static void VerticalSpace(int pixels)
    {
        EditorGUILayout.BeginVertical();
        GUILayout.Space(pixels);
        EditorGUILayout.EndVertical();
    }

    public static void HorizontalSpace(int pixels)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(pixels);
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
