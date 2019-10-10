using UnityEditor;
using UnityEngine;

namespace DoozyUI
{
    public class DoozyBaseWindow : EditorWindow
    {
        /// <summary>
        /// Sets the Repaint() update interval. 
        /// Never = it never does an auto Repaint();
        /// Update = calls the Repaint() method on every frame, making the framerate normal for the editor window;
        /// InspectorUpdate = calls the Repaint() method 10 times per second;
        /// </summary>
        protected enum RepaintOn { Never, Update, InspectorUpdate }
        protected RepaintOn repaintOn = RepaintOn.Never;

        public GUISkin WindowSkin { get { return EditorGUIUtility.isProSkin ? DoozyStyle.DarkSkin : DoozyStyle.LightSkin; } }

        public void Update() // This is necessary to make the framerate normal for the editor window.
        {
            if (repaintOn == RepaintOn.Update)
                Repaint();
        }

        public void OnInspectorUpdate() // This will only get called 10 times per second.
        {
            if (repaintOn == RepaintOn.InspectorUpdate)
                Repaint();
        }

        public bool OnGUIEditorStateCheck(EditorWindow editorWindow, float windowWidth, float windowHeight)
        {
            if (DoozyEditorUtility.EditorIsCompiling(this, DoozyResources.InfoBarDisabled, windowWidth, windowHeight))
                return true;
            if (DoozyEditorUtility.EditorIsInPlayMode(this, DoozyResources.InfoBarDisabled, windowWidth, windowHeight))
                return true;
            return false;
        }

        public void OnGUIShowBackground(float windowWidth, float windowHeight, Texture windowBackground)
        {
            GUI.DrawTexture(new Rect(0, 0, windowWidth, windowHeight), windowBackground);
        }

        public void OnGUIShowVersion(string versionNumber)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label("v" + versionNumber, WindowSkin.GetStyle("ModuleVersion"));
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        public void OnGUIShowTxtMsg(string message, GUIStyle style)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label(message, style);
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        public void OnGUIShowEnableButton(string symbol)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("", WindowSkin.GetStyle("BtnWideEnable")))
                {
                    DoozyEditorUtility.AddScriptingDefineSymbol(symbol);
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        public void OnGUIShowDisableButton(string symbol)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("", WindowSkin.GetStyle("BtnWideDisable")))
                {
                    DoozyEditorUtility.RemoveScriptingDefineSymbol(symbol);
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        public void OnGUIShowAddToSceneButton(string moduleName, GameObject prefab)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("", WindowSkin.GetStyle("BtnWideAddToScene")))
                {
                    if (prefab == null)
                    {
                        Debug.LogError("[" + moduleName + "] Could not find the " + moduleName + " prefab.");
                        return;
                    }

                    var go = Instantiate(prefab) as GameObject;
                    go.name = go.name.Replace("(Clone)", "");
                    Undo.RegisterCreatedObjectUndo(go, "Add the " + go.name + " prefab to the scene");
                    Selection.activeObject = go;
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }
    }
}
