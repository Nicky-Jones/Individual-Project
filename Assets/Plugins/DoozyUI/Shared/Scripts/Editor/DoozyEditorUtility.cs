// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DoozyUI
{
    public class DoozyEditorUtility
    {
        private static System.Diagnostics.Stopwatch stopwatch;

        #region SetBackgroundColor ResetColors
        public static void SetBackgroundColor(UnityEngine.Color darkSkinColor, UnityEngine.Color lightSkinColor)
        {
            if (EditorGUIUtility.isProSkin)
                GUI.backgroundColor = darkSkinColor;
            else
                GUI.backgroundColor = lightSkinColor;
        }

        public static void SetBackgroundColor(UnityEngine.Color color)
        {
            GUI.backgroundColor = color;
        }

        public static void ResetColors()
        {
            GUI.color = UnityEngine.Color.white;
            GUI.contentColor = UnityEngine.Color.white;
            GUI.backgroundColor = UnityEngine.Color.white;
        }
        #endregion

        #region Vertical/Horizontal Space
        public static void VerticalSpace(int pixels)
        {
            EditorGUILayout.BeginVertical();
            {
                GUILayout.Space(pixels);
            }
            EditorGUILayout.EndVertical();
        }

        public static void HorizontalSpace(int pixels)
        {
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(pixels);
            }
            EditorGUILayout.EndHorizontal();
        }
        #endregion

        #region Editor IsCompiling/IsInPlayMode
        public static bool EditorIsCompiling(EditorWindow editorWindow, Texture texture, float width, float height)
        {
            if (EditorApplication.isCompiling)
            {
                DrawTexture(texture, width, height);
                editorWindow.Repaint();
            }
            return EditorApplication.isCompiling;
        }

        public static bool EditorIsInPlayMode(EditorWindow editorWindow, Texture texture, float width, float height)
        {
            if (Application.isPlaying)
            {
                DrawTexture(texture, width, height);
                editorWindow.Repaint();
            }
            return Application.isPlaying;
        }
        #endregion

        #region Get/Draw Texture
        public static Texture GetTexture(string fileName, string folderPath, string fileExtension = ".png")
        {
            return AssetDatabase.LoadAssetAtPath<Texture>(folderPath + fileName + fileExtension);
        }

        public static void DrawTexture(Texture tex)
        {
            if (tex == null)
            {
                Debug.Log("[DoozyEditorUtility] Texture is null");
                return;
            }

            //tex.hideFlags = HideFlags.DontSave;
            var rect = GUILayoutUtility.GetRect(0f, 0f);
            rect.width = tex.width;
            rect.height = tex.height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, tex);
        }

        public static void DrawTexture(Texture tex, float width, float height)
        {
            if (tex == null)
            {
                Debug.Log("[DoozyEditorUtility] Texture is null");
                return;
            }

            var rect = GUILayoutUtility.GetRect(0f, 0f);
            rect.width = width;
            rect.height = height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, tex);
        }
        #endregion

        #region Get/Draw GIF
        public enum ImageFormat { png, jpg }
        /// <summary>
        /// Returns a list of Texture2D from a .gif file. :)
        /// </summary>
        /// <param name="imageFormat">Convet to png (slower) / jpg (faster - no alpha)</param>
        /// <returns></returns>
        public static List<Texture2D> GetGIF(string folderPath, string fileName, bool printLoadingInfo = false, ImageFormat imageFormat = ImageFormat.jpg)
        {
            if (printLoadingInfo)
            {
                stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                //Debug.Log("Loading GIF @ " + folderPath + fileName + ".gif");
            }

            var gifFrames = new List<Texture2D>();
            var gifImage = Image.FromFile(folderPath + fileName + ".gif");
            var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            int frameCount = gifImage.GetFrameCount(dimension);
            for (int i = 0; i < frameCount; i++)
            {
                gifImage.SelectActiveFrame(dimension, i);
                var frame = new Bitmap(gifImage.Width, gifImage.Height);
                System.Drawing.Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);
                var frameTexture = new Texture2D(frame.Width, frame.Height);
                using (MemoryStream s = new MemoryStream())
                {
                    switch (imageFormat)
                    {
                        case ImageFormat.png: frame.Save(s, System.Drawing.Imaging.ImageFormat.Png); break;     //slower
                        case ImageFormat.jpg: frame.Save(s, System.Drawing.Imaging.ImageFormat.Jpeg); break;    //faster - no alpha
                    }
                    s.Seek(0, SeekOrigin.Begin);
                    frameTexture.LoadImage(s.ToArray());
                    s.Close();
                }

                gifFrames.Add(frameTexture);
            }

            if (printLoadingInfo)
            {
                stopwatch.Stop();
                Debug.Log(fileName + ".gif loaded in "+ stopwatch.ElapsedMilliseconds+" ms | " + gifFrames.Count + " frames");
                stopwatch.Reset();
            }

            return gifFrames;

        }

        public static void DrawGIF(List<Texture2D> gif, float framesPerSecond = 30)
        {
            if (gif == null)
            {
                Debug.Log("[DoozyEditorUtility] GIF is null");
                return;
            }

            var rect = GUILayoutUtility.GetRect(0f, 0f);
            rect.width = gif[0].width;
            rect.height = gif[0].height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, gif[(int)(Time.realtimeSinceStartup * framesPerSecond) % gif.Count]);
        }

        public static void DrawGIF(List<Texture2D> gif, float width, float height, float framesPerSecond = 30)
        {
            if (gif == null)
            {
                Debug.Log("[DoozyEditorUtility] GIF is null");
                return;
            }

            var rect = GUILayoutUtility.GetRect(0f, 0f);
            rect.width = width;
            rect.height = height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, gif[(int)(Time.realtimeSinceStartup * framesPerSecond) % gif.Count]);
        }
        #endregion

        #region Add/Remove ScriptingDefineSymbol
        public static void AddScriptingDefineSymbol(string symbol)
        {
            string currentDefinedSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            if (currentDefinedSymbols.Contains(symbol) == false)
            {
                currentDefinedSymbols += ";" + symbol;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currentDefinedSymbols);
            }
        }

        public static void RemoveScriptingDefineSymbol(string symbol)
        {
            string currentDefinedSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            if (currentDefinedSymbols.Contains(symbol) == true)
            {
                currentDefinedSymbols = currentDefinedSymbols.Replace(symbol, "");
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currentDefinedSymbols);
            }
        }
        #endregion

        #region Play/Stop AudioClip
        public static void PlayAudioClip(AudioClip clip)
        {
            if (clip == null)
                return;
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod("PlayClip",
                                                         BindingFlags.Static | BindingFlags.Public,
                                                         null,
                                                         new System.Type[] { typeof(AudioClip) },
                                                         null);
            method.Invoke(null, new object[] { clip });
        }

        public static void StopAllClips()
        {
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod("StopAllClips",
                                                         BindingFlags.Static | BindingFlags.Public,
                                                         null,
                                                         new System.Type[] { },
                                                         null);
            method.Invoke(null, new object[] { });
        }
        #endregion
    }
}
