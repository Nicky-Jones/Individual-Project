// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEditor;
using UnityEngine;

namespace DoozyUI
{
    public class DoozyEditor : Editor
    {
        public const float WIDTH_1 = 420f;
        public const float WIDTH_2 = 210f;
        public const float WIDTH_3 = 140f;
        public const float WIDTH_4 = 105f;
        public const float WIDTH_5 = 84f;
        public const float WIDTH_6 = 70f;
        public const float WIDTH_7 = 60f;
        public const float WIDTH_8 = 52.5f;

        public const float HEIGHT_1 = 22;

        public const float DEFAULT_LINE_HEIGHT = 18;

        public const int VERTICAL_SPACE_BETWEEN_ELEMENTS = 4;

        public const float HEADER_WIDTH = 420f;
        public const float HEADER_HEIGHT = 36f;

        public bool showHelp = false;

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

        /// <summary>
        /// Removes the object/component by using DestroyImmediate.
        /// </summary>
        public void RemoveComponent(Object obj)
        {
            DestroyImmediate(obj);
            EditorGUIUtility.ExitGUI();
        }

        /// <summary>
        /// Draws the component's header.
        /// </summary>
        public void DrawHeader(Texture texture, float width = HEADER_WIDTH, float height = HEADER_HEIGHT)
        {
            SaveCurrentColorsAndResetColors();
            DoozyEditorUtility.DrawTexture(texture, width, height);
            LoadPreviousColors();
        }

        /// <summary>
        /// Adds a title and a remove component button.
        /// </summary>
        public void DrawTitleAndRemoveButton(string title, Object obj = null)
        {
            SaveCurrentColorsAndResetColors();
            DoozyEditorUtility.DrawTexture(DoozyResources.HeaderBarSubtitle, WIDTH_1, 18f);
            GUILayout.Space(-18f);
            GUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                GUILayout.Space(44f);
                EditorGUILayout.LabelField(title, skin.GetStyle(DoozyStyle.StyleName.HeaderSubtitle.ToString()), GUILayout.Width(WIDTH_3 * 2 - 48));
                if (GUILayout.Button("REMOVE COMPONENT", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_3)))
                {
                    if (obj != null)
                    {
                        if (EditorUtility.DisplayDialog("REMOVE COMPONENT", "Are you sure you want to remove this component?\nThis action will delete the component and it cannot be undone.", "Yes", "Cancel"))
                            RemoveComponent(obj);
                    }
                }
            }
            GUILayout.EndHorizontal();
            LoadPreviousColors();
        }

        /// <summary>
        /// Draws the toolbar with showHelp, Debug and the component mover buttons
        /// </summary>
        public void DrawHeaderToolbar(Component component = null, SerializedProperty debugThis = null)
        {
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                showHelp = EditorGUILayout.ToggleLeft("Show Help", showHelp, GUILayout.Width(WIDTH_5));

                if (debugThis != null)
                    debugThis.boolValue = EditorGUILayout.ToggleLeft("Debug", debugThis.boolValue, GUILayout.Width(WIDTH_5));

                GUILayout.FlexibleSpace();

                if (component != null)
                {
                    SaveCurrentColorsAndResetColors();
                    if (GUILayout.Button("UP", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_6)))
                    {
                        UnityEditorInternal.ComponentUtility.MoveComponentUp(component);
                    }
                    if (GUILayout.Button("DOWN", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_6)))
                    {
                        UnityEditorInternal.ComponentUtility.MoveComponentDown(component);
                    }
                    LoadPreviousColors();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draws DISABLED or ENABLED textures for the target component depending on the isEnabled bool value.
        /// </summary>
        public void DrawInfoBar(bool isEnabled, bool showEnabledState = true)
        {
            SaveCurrentColorsAndResetColors();
            if (isEnabled)
            {
                if (showEnabledState)
                    DoozyEditorUtility.DrawTexture(DoozyResources.InfoBarEnabled, WIDTH_1, 18f);
            }
            else
                DoozyEditorUtility.DrawTexture(DoozyResources.InfoBarDisabled, WIDTH_1, 18f);
            LoadPreviousColors();
        }

        /// <summary>
        /// Draws a custom Help Box.
        /// </summary>
        public void DrawHelpBox(bool show, string message, string title = "", float width = WIDTH_1)
        {
            if (!show)
                return;

            GUIStyle style = skin.GetStyle(DoozyStyle.StyleName.HelpBox.ToString());
            string helpText = string.Empty;

            if (!string.IsNullOrEmpty(title))
                helpText += "<b>" + title + "</b> - ";

            helpText += message;

            SaveCurrentColorsAndResetColors();
            EditorGUILayout.LabelField(helpText, style, GUILayout.Width(width));
            LoadPreviousColors();
        }
    }
}
