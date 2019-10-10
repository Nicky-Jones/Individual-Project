// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using DoozyUI.UIButton.Animator;
using UnityEditor;
using UnityEngine;

namespace DoozyUI.UIButton
{
    [CustomEditor(typeof(AnimatorModule))]
    public class AnimatorModuleEditor : DoozyEditor
    {
        #region HELP MESSAGES
        private const string HELP_MESSAGE_PRESET_INFO = "All the presets are saved as .dat files. All the categories are subfolder names found under UIButton/Resources/Presets/.";
        private const string HELP_MESSAGE_CATEGORY_TITLE = "Category";
        private const string HELP_MESSAGE_CATEGORY = "Select/Create a preset category";
        private const string HELP_MESSAGE_PRESET_NAME_TITLE = "Preset Name";
        private const string HELP_MESSAGE_PRESET_NAME = "Select/Create a preset";

        private const string HELP_MESSAGE_PUNCH_MOVE = "Punches a RectTransform's anchoredPosition towards the given direction and then back to the starting one as if it was connected to the starting position via an elastic.";
        private const string HELP_MESSAGE_PUNCH_ROTATE = "Punches a Transform's localRotation towards the given size and then back to the starting one as if it was connected to the starting rotation via an elastic.";
        private const string HELP_MESSAGE_PUNCH_SCALE = "Punches a Transform's localScale towards the given size and then back to the starting one as if it was connected to the starting scale via an elastic.";
        private const string HELP_MESSAGE_PUNCH_PUNCH_TITLE = "Punch";
        private const string HELP_MESSAGE_PUNCH_MOVE_PUNCH = "The direction and strength of the punch (added to the Transform's current position)";
        private const string HELP_MESSAGE_PUNCH_ROTATE_PUNCH = "The direction and strength of the punch (added to the Transform's current rotation)";
        private const string HELP_MESSAGE_PUNCH_SCALE_PUNCH = "The punch strength (added to the Transform's current scale)";
        private const string HELP_MESSAGE_PUNCH_MOVE_SNAP_TITLE = "Snap";
        private const string HELP_MESSAGE_PUNCH_MOVE_SNAP = "If TRUE the tween will smoothly snap all values to integers";
        private const string HELP_MESSAGE_PUNCH_DURATION_TITLE = "Duration";
        private const string HELP_MESSAGE_PUNCH_DURATION = "The duration of the tween";
        private const string HELP_MESSAGE_PUNCH_DELAY_TITLE = "Delay";
        private const string HELP_MESSAGE_PUNCH_DELAY = "Start delay for the tween";
        private const string HELP_MESSAGE_PUNCH_VIBRATO_TITLE = "Vibrato";
        private const string HELP_MESSAGE_PUNCH_VIBRATO = "Indicates how much will the punch vibrate";
        private const string HELP_MESSAGE_PUNCH_ELASTICITY_TITLE = "Elasticity";
        private const string HELP_MESSAGE_PUNCH_MOVE_ELASTICITY = "Represents how much (0 to 1) the vector will go beyond the starting position when bouncing backwards. 1 creates a full oscillation between the punch direction and the opposite direction, while 0 oscillates only between the punch and the start position";
        private const string HELP_MESSAGE_PUNCH_ROTATE_ELASTICITY = "Represents how much (0 to 1) the vector will go beyond the starting rotation when bouncing backwards. 1 creates a full oscillation between the punch rotation and the opposite rotation, while 0 oscillates only between the punch and the start rotation";
        private const string HELP_MESSAGE_PUNCH_SCALE_ELASTICITY = "Represents how much (0 to 1) the vector will go beyond the starting size when bouncing backwards. 1 creates a full oscillation between the punch scale and the opposite scale, while 0 oscillates only between the punch scale and the start scale";

        private const string HELP_MESSAGE_MOVE = "Moves the button to a target position";
        private const string HELP_MESSAGE_ROTATE = "Rotates the button to a target rotation";
        private const string HELP_MESSAGE_SCALE = "Scales the button to a target scale";
        private const string HELP_MESSAGE_FADE = "Fades the button to a target alpha value";

        private const string HELP_MESSAGE_TO_TITLE = "To";
        private const string HELP_MESSAGE_MOVE_TO = "Target position";
        private const string HELP_MESSAGE_ROTATE_TO = "Target rotation";
        private const string HELP_MESSAGE_SCALE_TO = "Target scale";
        private const string HELP_MESSAGE_FADE_TO = "Target alpha value";

        private const string HELP_MESSAGE_MOVE_SNAP_TITLE = "Snap";
        private const string HELP_MESSAGE_MOVE_SNAP = "If TRUE the tween will smoothly snap all values to integers";

        private const string HELP_MESSAGE_RELATIVE_TITLE = "Relative";
        private const string HELP_MESSAGE_RELATIVE = "If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly)";

        private const string HELP_MESSAGE_DURATION_TITLE = "Duration";
        private const string HELP_MESSAGE_DURATION = "The duration of the tween";

        private const string HELP_MESSAGE_DELAY_TITLE = "Delay";
        private const string HELP_MESSAGE_DELAY = "Start delay for the tween";

        private const string HELP_MESSAGE_EASE_TITLE = "Ease";
        private const string HELP_MESSAGE_EASE = "Sets the ease of the tween. Easing functions specify the rate of change of a parameter over time. To see how default ease curves look, check out easings.net";

        private const string HELP_MESSAGE_REVERSE_AFTER_TIME_TITLE = "Reverse After Time";
        private const string HELP_MESSAGE_REVERSE_AFTER_TIME = "Should there be another tween that reverts to the initial values";

        private const string HELP_MESSAGE_REVERSE_DURATION_TITLE = "Reverse Duration";
        private const string HELP_MESSAGE_REVERSE_DURATION = "The duration of the reverse tween";

        private const string HELP_MESSAGE_REVERSE_DELAY_TITLE = "Reverse Delay";
        private const string HELP_MESSAGE_REVERSE_DELAY = "Start delay for the revese tween";

        private const string HELP_MESSAGE_REVERSE_EASE_TITLE = "Reverse Ease";
        private const string HELP_MESSAGE_REVERSE_EASE = "The ease of the reverse tween";
        #endregion

        public GUISkin buttonSkin { get { return EditorGUIUtility.isProSkin ? UIButtonStyle.DarkSkin : UIButtonStyle.LightSkin; } }

        private AnimatorModule animatorModule { get { return (AnimatorModule)target; } }
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

        SerializedProperty debugThis;
        SerializedProperty reactTo;
        SerializedProperty presetCategoryName, presetName;
        SerializedProperty punchMove, pmEnabled, pmPunch, pmSnapping, pmDuration, pmDelay, pmVibrato, pmElasticity;
        SerializedProperty punchRotate, prEnabled, prPunch, prDuration, prDelay, prVibrato, prElasticity;
        SerializedProperty punchScale, psEnabled, psPunch, psDuration, psDelay, psVibrato, psElasticity;
        SerializedProperty move, mEnabled, mTo, mRelative, mSnapping, mDuration, mDelay, mEase, mReverseAfterTime, mReverseDuration, mReverseDelay, mReverseEase;
        SerializedProperty rotate, rEnabled, rTo, rRelative, rDuration, rDelay, rEase, rReverseAfterTime, rReverseDuration, rReverseDelay, rReverseEase;
        SerializedProperty scale, sEnabled, sTo, sRelative, sDuration, sDelay, sEase, sReverseAfterTime, sReverseDuration, sReverseDelay, sReverseEase;
        SerializedProperty fade, fEnabled, fTo, fRelative, fDuration, fDelay, fEase, fReverseAfterTime, fReverseDuration, fReverseDelay, fReverseEase;

        private string[] categories, presetNames;
        private string tempCategory, tempPresetName;
        private int tempCategoryIndex = 0, tempPresetNameIndex = 0, previous_tempCategoryIndex = -1;
        private bool createNewCategory = false, createNewPreset = false;
        private string newCategory = "", newPresetName = "";

        void SerializedObjectFindProperties()
        {
            debugThis = serializedObject.FindProperty("debugThis");
            reactTo = serializedObject.FindProperty("reactTo");

            presetCategoryName = serializedObject.FindProperty("presetCategoryName");
            presetName = serializedObject.FindProperty("presetName");

            #region PunchMove
            punchMove = serializedObject.FindProperty("punchMove");
            pmEnabled = punchMove.FindPropertyRelative("enabled");
            pmPunch = punchMove.FindPropertyRelative("punch");
            pmSnapping = punchMove.FindPropertyRelative("snapping");
            pmDuration = punchMove.FindPropertyRelative("duration");
            pmDelay = punchMove.FindPropertyRelative("delay");
            pmVibrato = punchMove.FindPropertyRelative("vibrato");
            pmElasticity = punchMove.FindPropertyRelative("elasticity");
            #endregion
            #region PunchRotate
            punchRotate = serializedObject.FindProperty("punchRotate");
            prEnabled = punchRotate.FindPropertyRelative("enabled");
            prPunch = punchRotate.FindPropertyRelative("punch");
            prDuration = punchRotate.FindPropertyRelative("duration");
            prDelay = punchRotate.FindPropertyRelative("delay");
            prVibrato = punchRotate.FindPropertyRelative("vibrato");
            prElasticity = punchRotate.FindPropertyRelative("elasticity");
            #endregion
            #region PunchScale
            punchScale = serializedObject.FindProperty("punchScale");
            psEnabled = punchScale.FindPropertyRelative("enabled");
            psPunch = punchScale.FindPropertyRelative("punch");
            psDuration = punchScale.FindPropertyRelative("duration");
            psDelay = punchScale.FindPropertyRelative("delay");
            psVibrato = punchScale.FindPropertyRelative("vibrato");
            psElasticity = punchScale.FindPropertyRelative("elasticity");
            #endregion

            #region Move
            move = serializedObject.FindProperty("move");
            mEnabled = move.FindPropertyRelative("enabled");
            mTo = move.FindPropertyRelative("to");
            mRelative = move.FindPropertyRelative("relative");
            mSnapping = move.FindPropertyRelative("snapping");
            mDuration = move.FindPropertyRelative("duration");
            mDelay = move.FindPropertyRelative("delay");
            mEase = move.FindPropertyRelative("ease");
            mReverseAfterTime = move.FindPropertyRelative("reverseAfterTime");
            mReverseDuration = move.FindPropertyRelative("reverseDuration");
            mReverseDelay = move.FindPropertyRelative("reverseDelay");
            mReverseEase = move.FindPropertyRelative("reverseEase");
            #endregion
            #region Rotate
            rotate = serializedObject.FindProperty("rotate");
            rEnabled = rotate.FindPropertyRelative("enabled");
            rTo = rotate.FindPropertyRelative("to");
            rRelative = rotate.FindPropertyRelative("relative");
            rDuration = rotate.FindPropertyRelative("duration");
            rDelay = rotate.FindPropertyRelative("delay");
            rEase = rotate.FindPropertyRelative("ease");
            rReverseAfterTime = rotate.FindPropertyRelative("reverseAfterTime");
            rReverseDuration = rotate.FindPropertyRelative("reverseDuration");
            rReverseDelay = rotate.FindPropertyRelative("reverseDelay");
            rReverseEase = rotate.FindPropertyRelative("reverseEase");
            #endregion
            #region Scale
            scale = serializedObject.FindProperty("scale");
            sEnabled = scale.FindPropertyRelative("enabled");
            sTo = scale.FindPropertyRelative("to");
            sRelative = scale.FindPropertyRelative("relative");
            sDuration = scale.FindPropertyRelative("duration");
            sDelay = scale.FindPropertyRelative("delay");
            sEase = scale.FindPropertyRelative("ease");
            sReverseAfterTime = scale.FindPropertyRelative("reverseAfterTime");
            sReverseDuration = scale.FindPropertyRelative("reverseDuration");
            sReverseDelay = scale.FindPropertyRelative("reverseDelay");
            sReverseEase = scale.FindPropertyRelative("reverseEase");
            #endregion
            #region Fade
            fade = serializedObject.FindProperty("fade");
            fEnabled = fade.FindPropertyRelative("enabled");
            fTo = fade.FindPropertyRelative("to");
            fRelative = fade.FindPropertyRelative("relative");
            fDuration = fade.FindPropertyRelative("duration");
            fDelay = fade.FindPropertyRelative("delay");
            fEase = fade.FindPropertyRelative("ease");
            fReverseAfterTime = fade.FindPropertyRelative("reverseAfterTime");
            fReverseDuration = fade.FindPropertyRelative("reverseDuration");
            fReverseDelay = fade.FindPropertyRelative("reverseDelay");
            fReverseEase = fade.FindPropertyRelative("reverseEase");
            #endregion
        }

        void OnEnable()
        {
            SerializedObjectFindProperties();

            showHelp = false;
            repaintOn = RepaintOn.Never;
            valueReactTo = (UIButton.ReactTo)reactTo.enumValueIndex;

            RefreshCategories();
            RefreshPresetNames();

            if (animatorModule.UsesPreset)
            {
                if (AnimatorModule.PresetExists(presetCategoryName.stringValue, presetName.stringValue))
                {
                    LoadPreset(presetCategoryName.stringValue, presetName.stringValue);
                }
                else
                {
                    animatorModule.presetCategoryName = PresetHelper.DEFAULT_PRESET_CATEGORY_NAME;
                    animatorModule.presetName = PresetHelper.DEFAULT_PRESET_NAME;
                    Repaint();
                }
            }

            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SetBackgroundColor(DoozyColors.BLUE, DoozyColors.L_BLUE);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeader(DoozyResources.HeaderBarUIButtonAnimator);
            DrawInfoBar(animatorModule.IsAnimatorModuleEnabled, false);
            DrawTitleAndRemoveButton(" " + GetSubtitle, (AnimatorModule)target);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeaderToolbar(target as AnimatorModule, debugThis);
            if (showHelp)
            {
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                DrawHelpBox(showHelp, HELP_MESSAGE_PRESET_INFO);
            }
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
            #region Category
            if (previous_tempCategoryIndex != tempCategoryIndex)
            {
                RefreshPresetNames();
                previous_tempCategoryIndex = tempCategoryIndex;
            }
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.LabelField(presetCategoryName.stringValue, GUILayout.Width(WIDTH_4));
                if (!createNewCategory)
                {
                    tempCategoryIndex = EditorGUILayout.Popup(tempCategoryIndex, categories, GUILayout.Width(WIDTH_4));
                    tempCategory = categories[tempCategoryIndex];
                    SaveCurrentColorsAndResetColors();
                    if (tempCategory.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME))
                    {
                        if (GUILayout.Button("new category", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 - 8)))
                        {
                            newCategory = "";
                            createNewCategory = true;
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("new", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                            createNewCategory = true;
                        if (GUILayout.Button("delete", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                        {
                            if (EditorUtility.DisplayDialog("Delete Category", "Are you sure you want to delete the '" + tempCategory + "' category? This will also delete all of it's presets. This operation cannot be undone!", "Yes", "Cancel"))
                            {
                                PresetHelper.DeleteCategory(DoozyResources.PathUIButtonPresets, tempCategory);
                                tempCategoryIndex = 0;
                                tempPresetNameIndex = 0;
                                RefreshCategories();
                                serializedObject.ApplyModifiedProperties();
                                OnInspectorGUI();
                            }
                        }
                    }
                    LoadPreviousColors();
                }
                else
                {
                    newCategory = EditorGUILayout.TextField(newCategory, GUILayout.Width(WIDTH_4));
                    SaveCurrentColorsAndResetColors();
                    if (GUILayout.Button("save", skin.GetStyle(DoozyStyle.StyleName.BtnGreen.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                    {
                        if (string.IsNullOrEmpty(newCategory))
                        {
                            EditorUtility.DisplayDialog("New Category", "You cannot create a category with no name.", "Ok");
                        }
                        else if (newCategory.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME))
                        {
                            EditorUtility.DisplayDialog("New Category", "You cannot create a category with the name '" + tempCategory + "'.", "Ok");
                        }
                        else
                        {
                            PresetHelper.CreateCategory(DoozyResources.PathUIButtonPresets, newCategory);
                            RefreshCategories();
                            createNewCategory = false;
                        }
                    }
                    if (GUILayout.Button("cancel", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                        createNewCategory = false;
                    LoadPreviousColors();
                }
            }
            EditorGUILayout.EndHorizontal();
            DrawHelpBox(showHelp, HELP_MESSAGE_CATEGORY, HELP_MESSAGE_CATEGORY_TITLE);
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
            #region PresetName
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.LabelField(presetName.stringValue, GUILayout.Width(WIDTH_4));
                if (!createNewPreset)
                {
                    tempPresetNameIndex = EditorGUILayout.Popup(tempPresetNameIndex, presetNames, GUILayout.Width(WIDTH_4));
                    tempPresetName = presetNames[tempPresetNameIndex];
                    SaveCurrentColorsAndResetColors();
                    if (tempPresetName.Equals(PresetHelper.DEFAULT_PRESET_NAME))
                    {
                        if (GUILayout.Button("new preset", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 - 8)))
                        {
                            if (tempCategory.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME))
                            {
                                EditorUtility.DisplayDialog("New Preset", "Select a category first!", "Ok");
                            }
                            else
                            {

                                newPresetName = "";
                                createNewPreset = true;
                            }
                        }
                    }
                    else
                    {
                        if (GUILayout.Button("load", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 / 4 - 3)))
                        {
                            if (EditorUtility.DisplayDialog("Load Preset", "Are you sure you want to load the '" + tempPresetName + "'? This operation will overwrite the current values and it cannot be undone!", "Yes", "Cancel"))
                            {
                                LoadPreset(tempCategory, tempPresetName);
                            }
                        }
                        if (GUILayout.Button("update", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 / 4 - 3)))
                        {
                            if (EditorUtility.DisplayDialog("Update Preset", "Are you sure you want to overwrite the values of the '" + tempPresetName + "' preset? This operation cannot be undone!", "Yes", "Cancel"))
                            {
                                SavePreset(tempCategory, tempPresetName);
                                RefreshPresetNames();
                            }
                        }
                        if (GUILayout.Button("new", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 / 4 - 3)))
                            createNewPreset = true;
                        if (GUILayout.Button("delete", skin.GetStyle(DoozyStyle.StyleName.BtnBlue.ToString()), GUILayout.Width(WIDTH_2 / 4 - 3)))
                        {
                            if (EditorUtility.DisplayDialog("Delete Preset", "Are you sure you want to delete the '" + tempPresetName + "' preset? This operation cannot be undone!", "Yes", "Cancel"))
                            {
                                PresetHelper.DeletePreset(DoozyResources.PathUIButtonPresets, tempCategory, tempPresetName);
                                tempPresetNameIndex = 0;
                                RefreshPresetNames();
                                serializedObject.ApplyModifiedProperties();
                                OnInspectorGUI();
                            }
                        }
                    }
                    LoadPreviousColors();
                }
                else
                {
                    newPresetName = EditorGUILayout.TextField(newPresetName, GUILayout.Width(WIDTH_4));
                    SaveCurrentColorsAndResetColors();
                    if (GUILayout.Button("save", skin.GetStyle(DoozyStyle.StyleName.BtnGreen.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                    {
                        if (string.IsNullOrEmpty(newPresetName))
                        {
                            EditorUtility.DisplayDialog("New Preset", "You cannot create a preset with no name.", "Ok");
                        }
                        else if (newPresetName.Equals(PresetHelper.DEFAULT_PRESET_NAME))
                        {
                            EditorUtility.DisplayDialog("New Preset", "You cannot create a preset with the name '" + newPresetName + "'.", "Ok");
                        }
                        else
                        {
                            SavePreset(tempCategory, newPresetName);
                            RefreshPresetNames();
                            createNewPreset = false;
                        }
                    }
                    if (GUILayout.Button("cancel", skin.GetStyle(DoozyStyle.StyleName.BtnRed.ToString()), GUILayout.Width(WIDTH_4 - 5)))
                        createNewPreset = false;
                    LoadPreviousColors();
                }
            }
            EditorGUILayout.EndHorizontal();
            DrawHelpBox(showHelp, HELP_MESSAGE_PRESET_NAME, HELP_MESSAGE_PRESET_NAME_TITLE);
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
            #region PunchMove
            DrawZoneButton(pmEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchMoveEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchMoveDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE);
            if (pmEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.GREEN);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_GREEN);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Punch", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(35f));
                    EditorGUILayout.PropertyField(pmPunch, new GUIContent { text = "" }, GUILayout.Width(325f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Snap", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(30f));
                    EditorGUILayout.PropertyField(pmSnapping, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(50f));
                    EditorGUILayout.PropertyField(pmDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(33f));
                    EditorGUILayout.PropertyField(pmDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Vibrato", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(42f));
                    EditorGUILayout.PropertyField(pmVibrato, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Elasticity", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(51f));
                    EditorGUILayout.PropertyField(pmElasticity, new GUIContent { text = "" }, GUILayout.Width(50f));
                }
                EditorGUILayout.EndHorizontal();
                LoadPreviousColors();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE_PUNCH, HELP_MESSAGE_PUNCH_PUNCH_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE_SNAP, HELP_MESSAGE_PUNCH_MOVE_SNAP_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DURATION, HELP_MESSAGE_PUNCH_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DELAY, HELP_MESSAGE_PUNCH_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_VIBRATO, HELP_MESSAGE_PUNCH_VIBRATO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE_ELASTICITY, HELP_MESSAGE_PUNCH_ELASTICITY_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                }
                else
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
                }
            }
            #endregion
            #region PunchRotate
            DrawZoneButton(prEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchRotateEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchRotateDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_ROTATE);
            if (prEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.ORANGE);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_ORANGE);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Punch", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(35f));
                    EditorGUILayout.PropertyField(prPunch, new GUIContent { text = "" }, GUILayout.Width(380f));
                }
                EditorGUILayout.EndHorizontal();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(50f));
                    EditorGUILayout.PropertyField(prDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(33f));
                    EditorGUILayout.PropertyField(prDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Vibrato", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(42f));
                    EditorGUILayout.PropertyField(prVibrato, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Elasticity", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(51f));
                    EditorGUILayout.PropertyField(prElasticity, new GUIContent { text = "" }, GUILayout.Width(50f));
                }
                EditorGUILayout.EndHorizontal();
                LoadPreviousColors();

                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_ROTATE_PUNCH, HELP_MESSAGE_PUNCH_PUNCH_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DURATION, HELP_MESSAGE_PUNCH_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DELAY, HELP_MESSAGE_PUNCH_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_VIBRATO, HELP_MESSAGE_PUNCH_VIBRATO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE_ELASTICITY, HELP_MESSAGE_PUNCH_ELASTICITY_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                }
                else
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
                }
            }
            #endregion
            #region PunchScale
            DrawZoneButton(psEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchScaleEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnPunchScaleDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_SCALE);
            if (psEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.RED);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_RED);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Punch", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(35f));
                    EditorGUILayout.PropertyField(psPunch, new GUIContent { text = "" }, GUILayout.Width(380f));
                }
                EditorGUILayout.EndHorizontal();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(50f));
                    EditorGUILayout.PropertyField(psDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(33f));
                    EditorGUILayout.PropertyField(psDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Vibrato", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(42f));
                    EditorGUILayout.PropertyField(psVibrato, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Elasticity", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(51f));
                    EditorGUILayout.PropertyField(psElasticity, new GUIContent { text = "" }, GUILayout.Width(50f));
                }
                EditorGUILayout.EndHorizontal();
                LoadPreviousColors();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_SCALE_PUNCH, HELP_MESSAGE_PUNCH_PUNCH_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DURATION, HELP_MESSAGE_PUNCH_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_DELAY, HELP_MESSAGE_PUNCH_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_VIBRATO, HELP_MESSAGE_PUNCH_VIBRATO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_PUNCH_MOVE_ELASTICITY, HELP_MESSAGE_PUNCH_ELASTICITY_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
                }
                else
                {

                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
                }
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
            #region Move
            DrawZoneButton(mEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnMoveEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnMoveDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_MOVE);
            if (mEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.GREEN);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_GREEN);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("To", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(15f));
                    EditorGUILayout.PropertyField(mTo, new GUIContent { text = "" }, GUILayout.Width(265f));
                    GUILayout.Space(7f);
                    EditorGUILayout.LabelField("Relative", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(46f));
                    EditorGUILayout.PropertyField(mRelative, new GUIContent { text = "" }, GUILayout.Width(20f));
                    GUILayout.Space(3f);
                    EditorGUILayout.LabelField("Snap", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(30f));
                    EditorGUILayout.PropertyField(mSnapping, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_MOVE_TO, HELP_MESSAGE_TO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_RELATIVE, HELP_MESSAGE_RELATIVE_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_MOVE_SNAP, HELP_MESSAGE_MOVE_SNAP_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                    EditorGUILayout.PropertyField(mDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                    EditorGUILayout.PropertyField(mDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Ease", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                    EditorGUILayout.PropertyField(mEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DURATION, HELP_MESSAGE_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DELAY, HELP_MESSAGE_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_EASE, HELP_MESSAGE_EASE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Reverse Animation?", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(114f));
                    EditorGUILayout.PropertyField(mReverseAfterTime, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_AFTER_TIME, HELP_MESSAGE_REVERSE_AFTER_TIME_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                if (mReverseAfterTime.boolValue)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                    {
                        EditorGUILayout.LabelField("rDuration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                        EditorGUILayout.PropertyField(mReverseDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rDelay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                        EditorGUILayout.PropertyField(mReverseDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rEase", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                        EditorGUILayout.PropertyField(mReverseEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                    }
                    EditorGUILayout.EndHorizontal();

                    if (showHelp)
                    {
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DURATION, HELP_MESSAGE_REVERSE_DURATION_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DELAY, HELP_MESSAGE_REVERSE_DELAY_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_EASE, HELP_MESSAGE_REVERSE_EASE_TITLE);
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    }
                }
                LoadPreviousColors();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            #region Rotate
            DrawZoneButton(rEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnRotateEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnRotateDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_ROTATE);
            if (rEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.ORANGE);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_ORANGE);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("To", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(15f));
                    EditorGUILayout.PropertyField(rTo, new GUIContent { text = "" }, GUILayout.Width(326f));
                    GUILayout.Space(7f);
                    EditorGUILayout.LabelField("Relative", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(46f));
                    EditorGUILayout.PropertyField(rRelative, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_ROTATE_TO, HELP_MESSAGE_TO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_RELATIVE, HELP_MESSAGE_RELATIVE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                    EditorGUILayout.PropertyField(rDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                    EditorGUILayout.PropertyField(rDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Ease", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                    EditorGUILayout.PropertyField(rEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DURATION, HELP_MESSAGE_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DELAY, HELP_MESSAGE_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_EASE, HELP_MESSAGE_EASE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Reverse Animation?", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(114f));
                    EditorGUILayout.PropertyField(rReverseAfterTime, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_AFTER_TIME, HELP_MESSAGE_REVERSE_AFTER_TIME_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                if (rReverseAfterTime.boolValue)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                    {
                        EditorGUILayout.LabelField("rDuration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                        EditorGUILayout.PropertyField(rReverseDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rDelay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                        EditorGUILayout.PropertyField(rReverseDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rEase", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                        EditorGUILayout.PropertyField(rReverseEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                    }
                    EditorGUILayout.EndHorizontal();

                    if (showHelp)
                    {
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DURATION, HELP_MESSAGE_REVERSE_DURATION_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DELAY, HELP_MESSAGE_REVERSE_DELAY_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_EASE, HELP_MESSAGE_REVERSE_EASE_TITLE);
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    }
                }
                LoadPreviousColors();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            #region Scale
            DrawZoneButton(sEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnScaleEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnScaleDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_SCALE);
            if (sEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.RED);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_RED);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("To", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(15f));
                    EditorGUILayout.PropertyField(sTo, new GUIContent { text = "" }, GUILayout.Width(326f));
                    GUILayout.Space(7f);
                    EditorGUILayout.LabelField("Relative", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(46f));
                    EditorGUILayout.PropertyField(sRelative, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_ROTATE_TO, HELP_MESSAGE_TO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_RELATIVE, HELP_MESSAGE_RELATIVE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                    EditorGUILayout.PropertyField(sDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                    EditorGUILayout.PropertyField(sDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Ease", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                    EditorGUILayout.PropertyField(sEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DURATION, HELP_MESSAGE_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DELAY, HELP_MESSAGE_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_EASE, HELP_MESSAGE_EASE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Reverse Animation?", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(114f));
                    EditorGUILayout.PropertyField(sReverseAfterTime, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_AFTER_TIME, HELP_MESSAGE_REVERSE_AFTER_TIME_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                if (sReverseAfterTime.boolValue)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                    {
                        EditorGUILayout.LabelField("rDuration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                        EditorGUILayout.PropertyField(sReverseDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rDelay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                        EditorGUILayout.PropertyField(sReverseDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rEase", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                        EditorGUILayout.PropertyField(sReverseEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                    }
                    EditorGUILayout.EndHorizontal();

                    if (showHelp)
                    {
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DURATION, HELP_MESSAGE_REVERSE_DURATION_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DELAY, HELP_MESSAGE_REVERSE_DELAY_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_EASE, HELP_MESSAGE_REVERSE_EASE_TITLE);
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    }
                }
                LoadPreviousColors();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            #region Fade
            DrawZoneButton(fEnabled, buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnFadeEnabled.ToString()), buttonSkin.GetStyle(UIButtonStyle.StyleName.BtnFadeDisabled.ToString()));
            DrawHelpBox(showHelp, HELP_MESSAGE_FADE);
            if (fEnabled.boolValue)
            {
                SaveCurrentColorsAndResetColors();

                if (EditorGUIUtility.isProSkin)
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.PURPLE);
                else
                    DoozyEditorUtility.SetBackgroundColor(DoozyColors.L_PURPLE);

                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("To", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(15f));
                    EditorGUILayout.PropertyField(fTo, new GUIContent { text = "" }, GUILayout.Width(326f));
                    GUILayout.Space(7f);
                    EditorGUILayout.LabelField("Relative", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(46f));
                    EditorGUILayout.PropertyField(fRelative, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_ROTATE_TO, HELP_MESSAGE_TO_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_RELATIVE, HELP_MESSAGE_RELATIVE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Duration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                    EditorGUILayout.PropertyField(fDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Delay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                    EditorGUILayout.PropertyField(fDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                    GUILayout.Space(5f);
                    EditorGUILayout.LabelField("Ease", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                    EditorGUILayout.PropertyField(fEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DURATION, HELP_MESSAGE_DURATION_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_DELAY, HELP_MESSAGE_DELAY_TITLE);
                    DrawHelpBox(showHelp, HELP_MESSAGE_EASE, HELP_MESSAGE_EASE_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Reverse Animation?", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(114f));
                    EditorGUILayout.PropertyField(fReverseAfterTime, new GUIContent { text = "" }, GUILayout.Width(20f));
                }
                EditorGUILayout.EndHorizontal();
                if (showHelp)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_AFTER_TIME, HELP_MESSAGE_REVERSE_AFTER_TIME_TITLE);
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                }
                if (fReverseAfterTime.boolValue)
                {
                    DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                    {
                        EditorGUILayout.LabelField("rDuration", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(54f));
                        EditorGUILayout.PropertyField(fReverseDuration, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rDelay", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(37f));
                        EditorGUILayout.PropertyField(fReverseDelay, new GUIContent { text = "" }, GUILayout.Width(50f));
                        GUILayout.Space(5f);
                        EditorGUILayout.LabelField("rEase", skin.GetStyle(DoozyStyle.StyleName.LabelMidLeft.ToString()), GUILayout.Width(32f));
                        EditorGUILayout.PropertyField(fReverseEase, new GUIContent { text = "" }, GUILayout.Width(168f));
                    }
                    EditorGUILayout.EndHorizontal();

                    if (showHelp)
                    {
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DURATION, HELP_MESSAGE_REVERSE_DURATION_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_DELAY, HELP_MESSAGE_REVERSE_DELAY_TITLE);
                        DrawHelpBox(showHelp, HELP_MESSAGE_REVERSE_EASE, HELP_MESSAGE_REVERSE_EASE_TITLE);
                        DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                    }
                }
                LoadPreviousColors();
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            }
            #endregion
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DoozyEditorUtility.ResetColors();
            serializedObject.ApplyModifiedProperties();
        }

        void DrawZoneButton(SerializedProperty boolSerializedProperty, GUIStyle enabledStateStyle, GUIStyle disabledStateStyle)

        {
            SaveCurrentColorsAndResetColors();
            if (boolSerializedProperty.boolValue)
            {
                if (GUILayout.Button("", enabledStateStyle))
                    boolSerializedProperty.boolValue = !boolSerializedProperty.boolValue;
            }
            else
            {
                if (GUILayout.Button("", disabledStateStyle))
                    boolSerializedProperty.boolValue = !boolSerializedProperty.boolValue;
            }
            LoadPreviousColors();
        }

        void RefreshCategories()
        {
            categories = PresetHelper.GetCategories(DoozyResources.PathUIButtonPresets);
            if (string.IsNullOrEmpty(presetCategoryName.stringValue) || !ArrayUtility.Contains(categories, presetCategoryName.stringValue))
            {
                presetCategoryName.stringValue = PresetHelper.DEFAULT_PRESET_CATEGORY_NAME;
            }
            tempCategory = presetCategoryName.stringValue;
            tempCategoryIndex = ArrayUtility.IndexOf(categories, tempCategory);
        }

        void RefreshPresetNames()
        {
            presetNames = PresetHelper.GetPresetNames(DoozyResources.PathUIButtonPresets, tempCategory);
            if (string.IsNullOrEmpty(presetName.stringValue) || tempCategory.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME))
            {
                presetName.stringValue = PresetHelper.DEFAULT_PRESET_NAME;
            }
            if (!tempCategory.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME) && !ArrayUtility.Contains(presetNames, presetName.stringValue))
            {
                presetName.stringValue = PresetHelper.DEFAULT_PRESET_NAME;
            }
            tempPresetName = presetName.stringValue;
            tempPresetNameIndex = ArrayUtility.IndexOf(presetNames, tempPresetName);
        }

        void LoadPreset(string c, string pName)
        {
            animatorModule.SetPresetValues(AnimatorModule.LoadPreset(c, pName));
            animatorModule.presetCategoryName = c;
            animatorModule.presetName = pName;
            Repaint();
        }

        void SavePreset(string c, string pName)
        {
            if (c.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME) || pName.Equals(PresetHelper.DEFAULT_PRESET_NAME))
                return;

            if (AnimatorModule.PresetExists(c, pName))
            {
                if (EditorUtility.DisplayDialog("Save preset", "There is another preset in the " + c + " category with the same preset name. Overwrite?", "Yes", "Cancel"))
                {
                    PresetHelper.DeletePreset(DoozyResources.PathUIButtonPresets, c, pName);
                }
                else
                {
                    return;
                }
            }

            AnimatorModule.SavePreset(animatorModule.GetPresetValues(), c, pName);
            presetCategoryName.stringValue = c;
            presetName.stringValue = pName;
        }
    }
}
