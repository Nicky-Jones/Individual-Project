// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEditor;
using UnityEngine;

namespace DoozyUI
{
    public class DoozyEditorWindow : EditorWindow
    {
        /// <summary>
        /// Sets the Repaint() update interval. 
        /// Never = it never does an auto Repaint();
        /// Update = calls the Repaint() method on every frame, making the framerate normal for the editor window;
        /// InspectorUpdate = calls the Repaint() method 10 times per second;
        /// </summary>
        protected enum RepaintOn { Never, Update, InspectorUpdate }
        protected RepaintOn repaintOn = RepaintOn.Never;

        public GUISkin skin { get { return EditorGUIUtility.isProSkin ? DoozyStyle.DarkSkin : DoozyStyle.LightSkin; } }
        private Color tempColor;
        private Color tempContentColor;
        private Color tempBackgroundColor;

        public void SetBackgroundColor(Color darkColor, Color lightColor)
        {
            if (EditorGUIUtility.isProSkin)
                DoozyEditorUtility.SetBackgroundColor(darkColor);
            else
                DoozyEditorUtility.SetBackgroundColor(lightColor);
        }

        public void SetBackgroundTexture(Texture texture, float width, float height)
        {
            DoozyEditorUtility.DrawTexture(texture, width, height);
        }

        public void SaveCurrentColors()
        {
            tempColor = GUI.color;
            tempContentColor = GUI.contentColor;
            tempBackgroundColor = GUI.backgroundColor;
        }

        public void SaveCurrentColorsAndResetColors()
        {
            SaveCurrentColors();
            DoozyEditorUtility.ResetColors();
        }

        public void LoadPreviousColors()
        {
            GUI.color = tempColor;
            GUI.contentColor = tempContentColor;
            GUI.backgroundColor = tempBackgroundColor;
        }

        /// <summary>
        /// This is necessary to make the framerate normal for the editor window.
        /// </summary>
        public void Update()
        {
            if (repaintOn == RepaintOn.Update)
                Repaint();
        }

        /// <summary>
        /// This will only get called 10 times per second.
        /// </summary>
        public void OnInspectorUpdate()
        {
            if (repaintOn == RepaintOn.InspectorUpdate)
                Repaint();
        }

    }
}
