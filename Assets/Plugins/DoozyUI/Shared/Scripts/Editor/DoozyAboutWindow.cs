// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEditor;
using UnityEngine;

namespace DoozyUI
{
    public class DoozyAboutWindow : DoozyEditorWindow
    {
        private static bool _utility = true;
        private static string _title = "About";
        private static bool _focus = true;

        private static float _width = 512f;
        private static float _height = 512f;

        private const int VERTICAL_SPACE_BETWEEN_INFO_CARDS = 8;

        [MenuItem("DoozyUI/About", false)]
        static void Init()
        {
            GetWindow<DoozyAboutWindow>(_utility, _title, _focus);
        }

        void OnEnable()
        {
            repaintOn = RepaintOn.Update;
            SetupWindow();
        }

        void SetupWindow()
        {
            titleContent = new GUIContent(_title);
            maxSize = new Vector2(_width, _height);
            minSize = maxSize;
        }

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.Height(_height));
            {
                GUILayout.FlexibleSpace();
                DoozyEditorUtility.DrawGIF(DoozyResources.dUI_ElectricLogo, 30);
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(-_height); //move the pointer up back to the top 
            GUILayout.Space(180); //move the pointer down after the logo

            EditorGUILayout.BeginVertical();
            {
                EditorGUILayout.BeginHorizontal(GUILayout.Width(_width));
                {
                    DoozyEditorUtility.HorizontalSpace(152);
                    EditorGUILayout.BeginVertical(GUILayout.Width(208));
                    {
#if dUI_MANAGER
                    DrawInfoCardInstalled(DoozyResources.WindowAboutInfoUIManagerInstalled, DoozyConstants.VERSION_UIMANAGER);
#else
                        DrawInfoCardNotInstalled(DoozyResources.WindowAboutInfoUIManagerNotInstalled, DoozyConstants.LINK_UIMANAGER);
#endif

                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_INFO_CARDS);

#if dUI_BUTTON
                        DrawInfoCardInstalled(DoozyResources.WindowAboutInfoUIButtonInstalled, DoozyConstants.VERSION_UIBUTTON);
#else
                    DrawInfoCardNotInstalled(DoozyResources.WindowAboutInfoUIButtonNotInstalled, DoozyConstants.LINK_UIBUTTON);
#endif

                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_INFO_CARDS);

#if dUI_ELEMENT
                    DrawInfoCardInstalled(DoozyResources.WindowAboutInfoUIElementInstalled, DoozyConstants.VERSION_UIELEMENT);
#else
                        DrawInfoCardNotInstalled(DoozyResources.WindowAboutInfoUIElementNotInstalled, DoozyConstants.LINK_UIELEMENT);
#endif

                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_INFO_CARDS);

#if dUI_ORIENTATION_MANAGER
                    DrawInfoCardInstalled(DoozyResources.WindowAboutInfoOrientationManagerInstalled, DoozyConstants.VERSION_ORIENTATION_MANAGER);
#else
                        DrawInfoCardNotInstalled(DoozyResources.WindowAboutInfoOrientationManagerNotInstalled, DoozyConstants.LINK_ORIENTATION_MANAGER);
#endif

                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_INFO_CARDS);

#if dUI_FONT_AWESOME
                    DrawInfoCardInstalled(DoozyResources.WindowAboutInfoFontAwesomeInstalled, DoozyConstants.VERSION_FONT_AWESOME);
#else
                        DrawInfoCardNotInstalled(DoozyResources.WindowAboutInfoFontAwesomeNotInstalled, DoozyConstants.LINK_FONT_AWESOME);
#endif

                    }
                    EditorGUILayout.EndVertical();
                    DoozyEditorUtility.HorizontalSpace(152);
                }
                EditorGUILayout.EndHorizontal();

                GUILayout.FlexibleSpace();

                EditorGUILayout.BeginHorizontal(GUILayout.Height(23));//space for copyright info
                {
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField(DoozyConstants.COPYRIGHT, skin.GetStyle(DoozyStyle.StyleName.Copyright.ToString()), GUILayout.Width(384));
                    GUILayout.FlexibleSpace();
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }

        void DrawInfoCardNotInstalled(Texture texture, string url = "")
        {
            EditorGUILayout.BeginVertical();
            {
                DoozyEditorUtility.DrawTexture(texture, 208, 32);
                if (!string.IsNullOrEmpty(url))
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("Download", skin.GetStyle(DoozyStyle.StyleName.BtnGreyDark.ToString()), GUILayout.Width(200)))
                        {
                            Application.OpenURL(url);
                            //Application.OpenURL("http://unity3d.com/");
                        }
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndVertical();
        }

        void DrawInfoCardInstalled(Texture texture, string version)
        {
            DoozyEditorUtility.DrawTexture(texture, 208, 32);
            GUILayout.Space(-16);
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(76);
                EditorGUILayout.LabelField(version, skin.GetStyle(DoozyStyle.StyleName.Version.ToString()), GUILayout.Width(104));
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(-4);
        }

    }
}