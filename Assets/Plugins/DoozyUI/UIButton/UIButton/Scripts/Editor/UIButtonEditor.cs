// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEditor;
using UnityEngine;

namespace DoozyUI.UIButton
{
    [CustomEditor(typeof(UIButton))]
    public class UIButtonEditor : DoozyEditor
    {
        #region HELP MESSAGES
        private const string HELP_MESSAGE_MULTIPLE_CLICKS_ENABLED = "Multiple clicks are enabled. The button will not be disabled after each click.";
        private const string HELP_MESSAGE_MULTIPLE_CLICKS_DISABLED = "Multiple clicks are disabled. The button will get disabled after each click for the set disable interval.";
        private const string HELP_MESSAGE_SINGLE_CLICK_MODE_INSTANT = "The click will get registered instantly without checking if it's a double click or not. This is the normal behaviour of a single click in any OS. Use this if you want to make sure a single click will get executed before a double click (dual actions). (usage example: SingleClick - selects, DoubleClick - executes an action)";
        private const string HELP_MESSAGE_SINGLE_CLICK_MODE_DELAYED = "The click will get registered after checking if it's a double click or not. If it's a double click, the single click will not get triggered. Use this if you want to make sure the user does not execute a single click before a double click. The donwside is that there is a delay when executing the single click (the delay is the doulbe click register interval), so make sure you take that into account.";
        private const string HELP_MESSAGE_ON_HOVER_ENTER_DISABLE_INTERVAL = "The time interval between two OnHoverEnter event triggers. This disables the OnHoverEnter for a set time interval.";
        private const string HELP_MESSAGE_ON_HOVER_EXIT_DISABLE_INTERVAL = "The time interval between two OnHoverExit event triggers. This disables the OnHoverExit for a set time interval.";
        private const string HELP_MESSAGE_DOUBLE_CLICK_INTERVAL = "The time inverval between two sequential clicks that makes them count as a DoubleClick.";
        private const string HELP_MESSAGE_LONG_CLICK_INTERVAL = "The time interval the button has to be pressed down in order to trigger a LongClick.";
        #endregion

        private const string titleRemoveModule = "REMOVE MODULE?";
        private const string messageRemoveModule = "Are you sure you want to remove this module?\nThis action will delete the component and it cannot be undone.";

        private UIButton uiButton;

        SerializedProperty debugThis;
        SerializedProperty allowMultipleClicks, disableButtonInterval;
        SerializedProperty useOnHoverEnter, onHoverEnterAnimatorModule, onHoverEnterSoundModule, onHoverEnterEffectModule, onHoverEnterDisableInterval, OnHoverEnter;
        SerializedProperty useOnHoverExit, onHoverExitAnimatorModule, onHoverExitSoundModule, onHoverExitEffectModule, onHoverExitDisableInterval, OnHoverExit;
        SerializedProperty useOnPointerDown, onPointerDownAnimatorModule, onPointerDownSoundModule, onPointerDownEffectModule, OnPointerDown;
        SerializedProperty useOnPointerUp, onPointerUpAnimatorModule, onPointerUpSoundModule, onPointerUpEffectModule, OnPointerUp;
        SerializedProperty useOnClick, onClickAnimatorModule, onClickSoundModule, onClickEffectModule, singleClickMode, OnClick;
        SerializedProperty useOnDoubleClick, onDoubleClickAnimatorModule, onDoubleClickSoundModule, onDoubleClickEffectModule, doubleClickRegisterInterval, OnDoubleClick;
        SerializedProperty useOnLongClick, onLongClickAnimatorModule, onLongClickSoundModule, onLongClickEffectModule, longClickRegisterInterval, OnLongClick;

        void SerializedObjectFindProperties()
        {
            debugThis = serializedObject.FindProperty("debugThis");

            allowMultipleClicks = serializedObject.FindProperty("allowMultipleClicks");
            disableButtonInterval = serializedObject.FindProperty("disableButtonInterval");

            useOnHoverEnter = serializedObject.FindProperty("useOnHoverEnter");
            onHoverEnterDisableInterval = serializedObject.FindProperty("onHoverEnterDisableInterval");
            onHoverEnterAnimatorModule = serializedObject.FindProperty("onHoverEnterAnimatorModule");
            onHoverEnterSoundModule = serializedObject.FindProperty("onHoverEnterSoundModule");
            onHoverEnterEffectModule = serializedObject.FindProperty("onHoverEnterEffectModule");
            OnHoverEnter = serializedObject.FindProperty("OnHoverEnter");

            useOnHoverExit = serializedObject.FindProperty("useOnHoverExit");
            onHoverExitDisableInterval = serializedObject.FindProperty("onHoverExitDisableInterval");
            onHoverExitAnimatorModule = serializedObject.FindProperty("onHoverExitAnimatorModule");
            onHoverExitSoundModule = serializedObject.FindProperty("onHoverExitSoundModule");
            onHoverExitEffectModule = serializedObject.FindProperty("onHoverExitEffectModule");
            OnHoverExit = serializedObject.FindProperty("OnHoverExit");

            useOnPointerDown = serializedObject.FindProperty("useOnPointerDown");
            onPointerDownAnimatorModule = serializedObject.FindProperty("onPointerDownAnimatorModule");
            onPointerDownSoundModule = serializedObject.FindProperty("onPointerDownSoundModule");
            onPointerDownEffectModule = serializedObject.FindProperty("onPointerDownEffectModule");
            OnPointerDown = serializedObject.FindProperty("OnPointerDown");

            useOnPointerUp = serializedObject.FindProperty("useOnPointerUp");
            onPointerUpAnimatorModule = serializedObject.FindProperty("onPointerUpAnimatorModule");
            onPointerUpSoundModule = serializedObject.FindProperty("onPointerUpSoundModule");
            onPointerUpEffectModule = serializedObject.FindProperty("onPointerUpEffectModule");
            OnPointerUp = serializedObject.FindProperty("OnPointerUp");

            useOnClick = serializedObject.FindProperty("useOnClick");
            onClickAnimatorModule = serializedObject.FindProperty("onClickAnimatorModule");
            onClickSoundModule = serializedObject.FindProperty("onClickSoundModule");
            onClickEffectModule = serializedObject.FindProperty("onClickEffectModule");
            singleClickMode = serializedObject.FindProperty("singleClickMode");
            OnClick = serializedObject.FindProperty("OnClick");

            useOnDoubleClick = serializedObject.FindProperty("useOnDoubleClick");
            onDoubleClickAnimatorModule = serializedObject.FindProperty("onDoubleClickAnimatorModule");
            onDoubleClickSoundModule = serializedObject.FindProperty("onDoubleClickSoundModule");
            onDoubleClickEffectModule = serializedObject.FindProperty("onDoubleClickEffectModule");
            doubleClickRegisterInterval = serializedObject.FindProperty("doubleClickRegisterInterval");
            OnDoubleClick = serializedObject.FindProperty("OnDoubleClick");

            useOnLongClick = serializedObject.FindProperty("useOnLongClick");
            onLongClickAnimatorModule = serializedObject.FindProperty("onLongClickAnimatorModule");
            onLongClickSoundModule = serializedObject.FindProperty("onLongClickSoundModule");
            onLongClickEffectModule = serializedObject.FindProperty("onLongClickEffectModule");
            longClickRegisterInterval = serializedObject.FindProperty("longClickRegisterInterval");
            OnLongClick = serializedObject.FindProperty("OnLongClick");
        }

        void OnEnable()
        {
            showHelp = false;
            repaintOn = RepaintOn.Never;
            uiButton = (UIButton)target;
            SerializedObjectFindProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SetBackgroundColor(DoozyColors.BLUE, DoozyColors.L_BLUE);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeader(DoozyResources.HeaderBarUIButton);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeaderToolbar(target as UIButton, debugThis);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region Allow multiple clicks / Disable button interval
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                SaveCurrentColorsAndResetColors();
                if (allowMultipleClicks.boolValue)
                {
                    if (GUILayout.Button("Disable Multiple Clicks", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_1)))
                    {
                        allowMultipleClicks.boolValue = !allowMultipleClicks.boolValue;
                    }
                    LoadPreviousColors();
                }
                else
                {
                    EditorGUILayout.BeginVertical();
                    {
                        DoozyEditorUtility.VerticalSpace(3);
                        if (GUILayout.Button("Enable Multiple Clicks", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_3)))
                        {
                            allowMultipleClicks.boolValue = !allowMultipleClicks.boolValue;
                        }
                    }
                    EditorGUILayout.EndVertical();
                    LoadPreviousColors();
                    EditorGUILayout.LabelField("Disable Interval", skin.GetStyle(DoozyStyle.StyleName.LabelMidRight.ToString()), GUILayout.Width(WIDTH_3 - 16));
                    disableButtonInterval.floatValue = EditorGUILayout.FloatField(disableButtonInterval.floatValue, GUILayout.Width(WIDTH_3));
                }
            }
            EditorGUILayout.EndHorizontal();
            DrawHelpBox(showHelp && allowMultipleClicks.boolValue, HELP_MESSAGE_MULTIPLE_CLICKS_ENABLED);
            DrawHelpBox(showHelp && !allowMultipleClicks.boolValue, HELP_MESSAGE_MULTIPLE_CLICKS_DISABLED);
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnHoverEnter
            DrawEventZone(UIButton.ReactTo.OnHoverEnter, useOnHoverEnter, onHoverEnterAnimatorModule, onHoverEnterSoundModule, onHoverEnterEffectModule);
            if (useOnHoverEnter.boolValue)
            {
                EditorGUILayout.PropertyField(onHoverEnterDisableInterval, new GUIContent() { text = "Disable Interval" }, GUILayout.Width(WIDTH_1));
                DrawHelpBox(showHelp, HELP_MESSAGE_ON_HOVER_ENTER_DISABLE_INTERVAL);
                EditorGUILayout.PropertyField(OnHoverEnter, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnHoverExit
            DrawEventZone(UIButton.ReactTo.OnHoverExit, useOnHoverExit, onHoverExitAnimatorModule, onHoverExitSoundModule, onHoverExitEffectModule);
            if (useOnHoverExit.boolValue)
            {
                EditorGUILayout.PropertyField(onHoverExitDisableInterval, new GUIContent() { text = "Disable Interval" }, GUILayout.Width(WIDTH_1));
                DrawHelpBox(showHelp, HELP_MESSAGE_ON_HOVER_EXIT_DISABLE_INTERVAL);
                EditorGUILayout.PropertyField(OnHoverExit, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnPointerDown
            DrawEventZone(UIButton.ReactTo.OnPointerDown, useOnPointerDown, onPointerDownAnimatorModule, onPointerDownSoundModule, onPointerDownEffectModule);
            if (useOnPointerDown.boolValue)
            {
                EditorGUILayout.PropertyField(OnPointerDown, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnPointerUp
            DrawEventZone(UIButton.ReactTo.OnPointerUp, useOnPointerUp, onPointerUpAnimatorModule, onPointerUpSoundModule, onPointerUpEffectModule);
            if (useOnPointerUp.boolValue)
            {
                EditorGUILayout.PropertyField(OnPointerUp, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnClick
            DrawEventZone(UIButton.ReactTo.OnClick, useOnClick, onClickAnimatorModule, onClickSoundModule, onClickEffectModule);
            if (useOnClick.boolValue)
            {
                EditorGUILayout.PropertyField(singleClickMode, GUILayout.Width(WIDTH_1));
                if ((UIButton.SingleClickMode)singleClickMode.enumValueIndex == UIButton.SingleClickMode.Instant)
                {
                    DrawHelpBox(showHelp, HELP_MESSAGE_SINGLE_CLICK_MODE_INSTANT);
                }
                else
                {
                    DrawHelpBox(showHelp, HELP_MESSAGE_SINGLE_CLICK_MODE_DELAYED);
                }
                EditorGUILayout.PropertyField(OnClick, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnDoubleClick
            DrawEventZone(UIButton.ReactTo.OnDoubleClick, useOnDoubleClick, onDoubleClickAnimatorModule, onDoubleClickSoundModule, onDoubleClickEffectModule);
            if (useOnDoubleClick.boolValue)
            {
                EditorGUILayout.PropertyField(doubleClickRegisterInterval, new GUIContent() { text = "Double Click Interval" }, GUILayout.Width(WIDTH_1));
                DrawHelpBox(showHelp, HELP_MESSAGE_DOUBLE_CLICK_INTERVAL);
                EditorGUILayout.PropertyField(OnDoubleClick, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            #region OnLongClick
            DrawEventZone(UIButton.ReactTo.OnLongClick, useOnLongClick, onLongClickAnimatorModule, onLongClickSoundModule, onLongClickEffectModule);
            if (useOnLongClick.boolValue)
            {
                EditorGUILayout.PropertyField(longClickRegisterInterval, new GUIContent() { text = "Long Click Interval" }, GUILayout.Width(WIDTH_1));
                DrawHelpBox(showHelp, HELP_MESSAGE_LONG_CLICK_INTERVAL);
                EditorGUILayout.PropertyField(OnLongClick, GUILayout.Width(WIDTH_1));
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DoozyEditorUtility.ResetColors();
            serializedObject.ApplyModifiedProperties();
        }

        #region Add/Remove AnimatorModule
        private Animator.AnimatorModule AddAnimatorModule(UIButton.ReactTo reactTo)
        {
            RemoveAnimatorModule(reactTo, false);
            Animator.AnimatorModule am = uiButton.gameObject.AddComponent<Animator.AnimatorModule>();
            am.reactTo = reactTo;
            return am;
        }

        private void RemoveAnimatorModule(UIButton.ReactTo reactTo, bool useDialog = true)
        {
            bool removeModule = true;
            if (useDialog)
            {
                removeModule = EditorUtility.DisplayDialog(titleRemoveModule, messageRemoveModule, "Yes", "Cancel");
            }
            if (!removeModule)
                return;

            Animator.AnimatorModule[] am = uiButton.GetComponents<Animator.AnimatorModule>();
            if (am != null && am.Length > 0)
                for (int i = 0; i < am.Length; i++)
                    if (am[i].reactTo == reactTo)
                        RemoveComponent(am[i]);
        }
        #endregion
        #region Add/Remove SoundModule
        private Sound.SoundModule AddSoundModule(UIButton.ReactTo reactTo)
        {
            RemoveSoundModule(reactTo, false);
            Sound.SoundModule sm = uiButton.gameObject.AddComponent<Sound.SoundModule>();
            sm.reactTo = reactTo;
            return sm;
        }

        private void RemoveSoundModule(UIButton.ReactTo reactTo, bool useDialog = true)
        {
            bool removeModule = true;
            if (useDialog)
            {
                removeModule = EditorUtility.DisplayDialog(titleRemoveModule, messageRemoveModule, "Yes", "Cancel");
            }
            if (!removeModule)
                return;

            Sound.SoundModule[] sm = uiButton.GetComponents<Sound.SoundModule>();
            if (sm != null && sm.Length > 0)
                for (int i = 0; i < sm.Length; i++)
                    if (sm[i].reactTo == reactTo)
                        RemoveComponent(sm[i]);

        }
        #endregion
        #region Add/Remove EffectModule
        private Effect.EffectModule AddEffectModule(UIButton.ReactTo reactTo)
        {
            RemoveEffectModule(reactTo, false);
            Effect.EffectModule em = uiButton.gameObject.AddComponent<Effect.EffectModule>();
            em.reactTo = reactTo;
            return em;
        }

        private void RemoveEffectModule(UIButton.ReactTo reactTo, bool useDialog = true)
        {
            bool removeModule = true;
            if (useDialog)
            {
                removeModule = EditorUtility.DisplayDialog(titleRemoveModule, messageRemoveModule, "Yes", "Cancel");
            }
            if (!removeModule)
                return;

            Effect.EffectModule[] em = uiButton.GetComponents<Effect.EffectModule>();
            if (em != null && em.Length > 0)
                for (int i = 0; i < em.Length; i++)
                    if (em[i].reactTo == reactTo)
                        RemoveComponent(em[i]);

        }
        #endregion

        private void DrawEventZone(UIButton.ReactTo eventType, SerializedProperty useEventType, SerializedProperty animatorModule, SerializedProperty soundModule, SerializedProperty effectModule)
        {
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                SaveCurrentColorsAndResetColors();

                if (useEventType.boolValue)
                {
                    if (GUILayout.Button("Disable " + eventType.ToString(), skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_3 + 20), GUILayout.Height(HEIGHT_1)))
                    {
                        useEventType.boolValue = !useEventType.boolValue;
                    }
                    DoozyEditorUtility.VerticalSpace(1);
                    if (animatorModule.objectReferenceValue == null)
                    {
                        if (GUILayout.Button("+ ANIMATOR", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_5 + 16), GUILayout.Height(HEIGHT_1)))
                            animatorModule.objectReferenceValue = AddAnimatorModule(eventType);
                    }
                    else
                    {
                        if (GUILayout.Button("- ANIMATOR", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_5 + 16), GUILayout.Height(HEIGHT_1)))
                            RemoveAnimatorModule(eventType);
                    }
                    DoozyEditorUtility.VerticalSpace(1);
                    if (soundModule.objectReferenceValue == null)
                    {
                        if (GUILayout.Button("+ SOUND", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_5 - 8), GUILayout.Height(HEIGHT_1)))
                            soundModule.objectReferenceValue = AddSoundModule(eventType);
                    }
                    else
                    {
                        if (GUILayout.Button("- SOUND", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_5 - 8), GUILayout.Height(HEIGHT_1)))
                            RemoveSoundModule(eventType);
                    }
                    DoozyEditorUtility.VerticalSpace(1);
                    if (effectModule.objectReferenceValue == null)
                    {
                        if (GUILayout.Button("+ EFFECT", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_5 - 8), GUILayout.Height(HEIGHT_1)))
                            effectModule.objectReferenceValue = AddEffectModule(eventType);
                    }
                    else
                    {
                        if (GUILayout.Button("- EFFECT", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_5 - 8), GUILayout.Height(HEIGHT_1)))
                            RemoveEffectModule(eventType);
                    }
                }
                else
                {
                    if (GUILayout.Button(eventType.ToString() + " is DISABLED", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_1), GUILayout.Height(HEIGHT_1)))
                    {
                        useEventType.boolValue = !useEventType.boolValue;
                    }
                }

                GUILayout.FlexibleSpace();
                LoadPreviousColors();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
