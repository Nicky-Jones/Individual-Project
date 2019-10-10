// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using DoozyUI.UIButton.Effect;
using UnityEditor;
using UnityEngine;

namespace DoozyUI.UIButton
{
    [CustomEditor(typeof(EffectModule))]
    public class EffectModuleEditor : DoozyEditor
    {
        #region HELP MESSAGES
        private const string HELP_MESSAGE_PARTICLE_SYSTEM_TITLE = "Particle System";
        private const string HELP_MESSAGE_PARTICLE_SYSTEM = "Reference the Particle System you would like to be affected by this module";

        private const string HELP_MESSAGE_EFFECT_ACTION_TITLE = "Effect Action";
        private const string HELP_MESSAGE_EFFECT_ACTION = "Select the action this module should execute -play-, -stop- or emit a -burst- of particles on trigger";

        private const string HELP_MESSAGE_WITH_CHILDREN_TITLE = "With Children";
        private const string HELP_MESSAGE_WITH_CHILDREN = "If TRUE it will also trigger the child particle systems under the main one (default:true)";

        private const string HELP_MESSAGE_CLEAR_ON_STOP_TITLE = "Clear On Stop";
        private const string HELP_MESSAGE_CLEAR_ON_STOP = "If TRUE, the particles will dissapear instantly on -stop- otherwise they will dissapear after lifetime (default:false)";

        private const string HELP_MESSAGE_EMIT_COUNT_TITLE = "Emit Count";
        private const string HELP_MESSAGE_EMIT_COUNT = "The number of particles that should be emitted on a -burst-";

        private const string HELP_MESSAGE_OVERRIDE_SORTING_LAYER_TITLE = "Override Sorting Layer";
        private const string HELP_MESSAGE_OVERRIDE_SORTING_LAYER = "Set the particle system's sorting layer the same as the UIButton's";

        private const string HELP_MESSAGE_OVERRIDE_SORTING_ORDER_TITLE = "Override Sorting Order";
        private const string HELP_MESSAGE_OVERRIDE_SORTING_ORDER = "Change the particle system's order in layer with the specified number of steps";

        private const string HELP_MESSAGE_RESET_SORTING_ORDER_TITLE = "Reset Sorting Order to be";
        private const string HELP_MESSAGE_RESET_SORTING_ORDER = "In Front (+) or Behind (-) of the UIButton with the set number of steps";

        private const string HELP_MESSAGE_STEPS_TITLE = "Steps";
        private const string HELP_MESSAGE_STEPS = "The number of steps that the sorting order should be changed to depending on the direction (In Front (+) or Behind (-) )";
        #endregion

        private EffectModule effectModule { get { return (EffectModule)target; } }
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
        SerializedProperty pSystem, effectAction, clearOnStop, withChildren, emitCount;
        SerializedProperty overrideSortingLayer, overrideSortingOrder, resetSortingOrderToBe, orderInLayerSteps;

        void SerializedObjectFindProperties()
        {
            debugThis = serializedObject.FindProperty("debugThis");
            reactTo = serializedObject.FindProperty("reactTo");

            pSystem = serializedObject.FindProperty("pSystem");
            effectAction = serializedObject.FindProperty("effectAction");
            clearOnStop = serializedObject.FindProperty("clearOnStop");
            withChildren = serializedObject.FindProperty("withChildren");
            emitCount = serializedObject.FindProperty("emitCount");
            overrideSortingLayer = serializedObject.FindProperty("overrideSortingLayer");
            overrideSortingOrder = serializedObject.FindProperty("overrideSortingOrder");
            resetSortingOrderToBe = serializedObject.FindProperty("resetSortingOrderToBe");
            orderInLayerSteps = serializedObject.FindProperty("orderInLayerSteps");
        }

        void OnEnable()
        {
            SerializedObjectFindProperties();

            showHelp = false;
            repaintOn = RepaintOn.Never;
            valueReactTo = (UIButton.ReactTo)reactTo.enumValueIndex;
            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SetBackgroundColor(DoozyColors.BLUE, DoozyColors.L_BLUE);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeader(DoozyResources.HeaderBarUIButtonEffect);
            DrawInfoBar(effectModule.IsEffectModuleEnabled, false);
            DrawTitleAndRemoveButton(" " + GetSubtitle, (EffectModule)target);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DrawHeaderToolbar(target as EffectModule, debugThis);
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS * 2);
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.PropertyField(pSystem, new GUIContent { text = "" }, GUILayout.Width(160));
                EditorGUILayout.PropertyField(effectAction, new GUIContent { text = "" }, GUILayout.Width(50));
                withChildren.boolValue = EditorGUILayout.ToggleLeft("With Children", withChildren.boolValue, GUILayout.Width(92));
                if ((EffectModule.EffectAction)effectAction.enumValueIndex == EffectModule.EffectAction.Stop)
                {
                    GUILayout.Space(4);
                    clearOnStop.boolValue = EditorGUILayout.ToggleLeft("Clear On Stop", clearOnStop.boolValue, GUILayout.Width(122));
                }
                else
                {
                    EditorGUILayout.LabelField("Emit Count", GUILayout.Width(66));
                    EditorGUILayout.PropertyField(emitCount, new GUIContent { text = "" }, GUILayout.Width(35));
                }
            }
            EditorGUILayout.EndHorizontal();
            DrawHelpBox(showHelp, HELP_MESSAGE_PARTICLE_SYSTEM, HELP_MESSAGE_PARTICLE_SYSTEM_TITLE);
            DrawHelpBox(showHelp, HELP_MESSAGE_EFFECT_ACTION, HELP_MESSAGE_EFFECT_ACTION_TITLE);
            DrawHelpBox(showHelp, HELP_MESSAGE_WITH_CHILDREN, HELP_MESSAGE_WITH_CHILDREN_TITLE);
            if ((EffectModule.EffectAction)effectAction.enumValueIndex == EffectModule.EffectAction.Stop)
            {
                DrawHelpBox(showHelp, HELP_MESSAGE_CLEAR_ON_STOP, HELP_MESSAGE_CLEAR_ON_STOP_TITLE);
            }
            else
            {
                DrawHelpBox(showHelp, HELP_MESSAGE_EMIT_COUNT, HELP_MESSAGE_EMIT_COUNT_TITLE);
            }
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
            EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
            {
                EditorGUILayout.LabelField("Override Sorting Layer", GUILayout.Width(WIDTH_3 - 4));
                EditorGUILayout.PropertyField(overrideSortingLayer, new GUIContent { text = "" }, GUILayout.Width(WIDTH_6 - 1));
                EditorGUILayout.LabelField("Override Sorting Order", GUILayout.Width(WIDTH_3 - 4));
                EditorGUILayout.PropertyField(overrideSortingOrder, new GUIContent { text = "" }, GUILayout.Width(WIDTH_6 - 1));
            }
            EditorGUILayout.EndHorizontal();
            DrawHelpBox(showHelp, HELP_MESSAGE_OVERRIDE_SORTING_LAYER, HELP_MESSAGE_OVERRIDE_SORTING_LAYER_TITLE);
            DrawHelpBox(showHelp, HELP_MESSAGE_OVERRIDE_SORTING_ORDER, HELP_MESSAGE_OVERRIDE_SORTING_ORDER_TITLE);
            if ((EffectModule.OverrideSortingOrder)overrideSortingOrder.enumValueIndex == EffectModule.OverrideSortingOrder.Yes)
            {
                DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS / 2);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(WIDTH_1));
                {
                    EditorGUILayout.LabelField("Reset Sorting Order to be", GUILayout.Width(WIDTH_3 + 12));
                    EditorGUILayout.PropertyField(resetSortingOrderToBe, new GUIContent { text = "" }, GUILayout.Width(90));
                    EditorGUILayout.LabelField("of the UIButon.", GUILayout.Width(WIDTH_4 - 14));
                    EditorGUILayout.LabelField("Steps", GUILayout.Width(35));
                    EditorGUILayout.PropertyField(orderInLayerSteps, new GUIContent { text = "" }, GUILayout.Width(35));
                }
                EditorGUILayout.EndHorizontal();
                DrawHelpBox(showHelp, HELP_MESSAGE_RESET_SORTING_ORDER, HELP_MESSAGE_RESET_SORTING_ORDER_TITLE);
                DrawHelpBox(showHelp, HELP_MESSAGE_STEPS, HELP_MESSAGE_STEPS_TITLE);
            }
            DoozyEditorUtility.VerticalSpace(VERTICAL_SPACE_BETWEEN_ELEMENTS);
            DoozyEditorUtility.ResetColors();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
