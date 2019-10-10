// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using DoozyUI.UIButton.Sound;
using UnityEditor;
using UnityEngine;

namespace DoozyUI.UIButton
{
    [CustomEditor(typeof(SoundModule))]
    public class SoundModuleEditor : DoozyEditor
    {
        #region HELP MESSAGES
        private const string HELP_MESSAGE_EVENT_DISABLED = "This module is disabled because the event, that it is linked to on the UIButton, is disabled.";
        private const string HELP_MESSAGE_AUDIOCLIP = "Reference to a sound clip that you would like to play when this event is fired.";
        private const string HELP_MESSAGE_STRING = "A sound filename (without the extension .wav or .mp3 or any other sound format) that you would like to play when this event is fired. Note that the file should be located under a Resources folder.";
        #endregion

        private SoundModule soundModule;
        private UIButton.ReactTo valueReactTo;
        public string GetSubtitle
        {
            get
            {
                switch (valueReactTo)
                {
                    case UIButton.ReactTo.OnHoverEnter: return "On Hover Enter";
                    case UIButton.ReactTo.OnHoverExit: return "On Hover Exit";
                    case UIButton.ReactTo.OnPointerDown: return "On Pointer Down";
                    case UIButton.ReactTo.OnPointerUp: return "On Pointer Up";
                    case UIButton.ReactTo.OnClick: return "On Click";
                    case UIButton.ReactTo.OnDoubleClick: return "On Double Click";
                    case UIButton.ReactTo.OnLongClick: return "On Long Click";
                    default: return "---";
                }
            }
        }
        private SoundModule.SoundSource valueSoundSource;

        SerializedProperty debugThis;
        SerializedProperty reactTo;
        SerializedProperty soundSource, sound, soundName, audioClip, volume;

        void SerializedObjectFindProperties()
        {
            debugThis = serializedObject.FindProperty("debugThis");
            reactTo = serializedObject.FindProperty("reactTo");
            soundSource = serializedObject.FindProperty("soundSource");
            sound = serializedObject.FindProperty("sound");
            soundName = sound.FindPropertyRelative("soundName");
            audioClip = sound.FindPropertyRelative("audioClip");
            volume = serializedObject.FindProperty("volume");
        }

        void OnEnable()
        {
            showHelp = false;
            repaintOn = RepaintOn.Never;
            soundModule = (SoundModule)target;
            SerializedObjectFindProperties();
            valueReactTo = (UIButton.ReactTo)reactTo.enumValueIndex;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SetBackgroundColor(DoozyColors.BLUE, DoozyColors.L_BLUE);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeader(DoozyResources.HeaderBarUIButtonSound);
            DrawInfoBar(soundModule.IsSoundModuleEnabled, false);
            DrawTitleAndRemoveButton(" " + GetSubtitle, (SoundModule)target);
            DrawHelpBox(showHelp && !soundModule.IsSoundModuleEnabled, HELP_MESSAGE_EVENT_DISABLED, "");
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeaderToolbar(target as SoundModule, debugThis);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.PropertyField(soundSource, new GUIContent() { text = "" }, GUILayout.Width(WIDTH_4));
                valueSoundSource = (SoundModule.SoundSource)soundSource.enumValueIndex;
                switch (valueSoundSource)
                {
                    case SoundModule.SoundSource.String: EditorGUILayout.PropertyField(soundName, new GUIContent() { text = "" }, GUILayout.Width(WIDTH_3 + 27f)); break;
                    case SoundModule.SoundSource.AudioClip: EditorGUILayout.PropertyField(audioClip, new GUIContent() { text = "" }, GUILayout.Width(WIDTH_3 + 27f)); break;
                }
                SaveCurrentColorsAndResetColors();
                if (GUILayout.Button("PLAY", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_6)))
                {
                    DoozyEditorUtility.StopAllClips();
                    DoozyEditorUtility.PlayAudioClip(soundModule.GetLoadedSound());
                }
                if (GUILayout.Button("STOP", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_6)))
                {
                    DoozyEditorUtility.StopAllClips();
                }
                LoadPreviousColors();
            }
            EditorGUILayout.EndHorizontal();
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            switch (valueSoundSource)
            {
                case SoundModule.SoundSource.String: DrawHelpBox(showHelp, HELP_MESSAGE_STRING, "String"); break;
                case SoundModule.SoundSource.AudioClip: DrawHelpBox(showHelp, HELP_MESSAGE_AUDIOCLIP, "AudioClip"); break;
            }
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.LabelField("Volume", GUILayout.Width(48));
                volume.floatValue = EditorGUILayout.Slider(volume.floatValue, 0f, 1f, GUILayout.Width(WIDTH_1 - 50));
            }
            EditorGUILayout.EndHorizontal();
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DoozyEditorUtility.ResetColors();
            serializedObject.ApplyModifiedProperties();
        }
    }
}

