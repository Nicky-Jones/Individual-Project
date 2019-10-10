// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;
using DG.Tweening;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DoozyUI.UIButton.Animator
{
    public partial class AnimatorModule : MonoBehaviour
    {
        void Reset()
        {
            if (GetUIButton.onHoverEnterAnimatorModule == this) reactTo = UIButton.ReactTo.OnHoverEnter;
            else if (GetUIButton.onHoverExitAnimatorModule == this) reactTo = UIButton.ReactTo.OnHoverExit;
            else if (GetUIButton.onPointerDownAnimatorModule == this) reactTo = UIButton.ReactTo.OnPointerDown;
            else if (GetUIButton.onPointerUpAnimatorModule == this) reactTo = UIButton.ReactTo.OnPointerUp;
            else if (GetUIButton.onClickAnimatorModule == this) reactTo = UIButton.ReactTo.OnClick;
            else if (GetUIButton.onDoubleClickAnimatorModule == this) reactTo = UIButton.ReactTo.OnDoubleClick;
            else if (GetUIButton.onLongClickAnimatorModule == this) reactTo = UIButton.ReactTo.OnLongClick;
        }

        void Awake()
        {
            rectTransfrom = GetComponent<RectTransform>();
            if (rectTransfrom == null)
            {
                Debug.Log(name + " - UIButton.AnimatorModule - Reacts to " + reactTo.ToString() + " - There is no RectTransform component attached to the gameobject. In order for the AnimatorModule to work you should have a gameobject with a RectTransfrom and an UIButton components attached.");
                return;
            }

            uiButton = GetComponent<UIButton>();
            if (uiButton == null)
            {
                Debug.Log(name + " - UIButton.AnimatorModule - Reacts to " + reactTo.ToString() + " - There is no UIButton component attached to the gameobject. In order for the AnimatorModule to work you should have a gameobject with a RectTransfrom and an UIButton components attached.");
                return;
            }

#if UNITY_EDITOR
            if (UsesPreset && File.Exists(GetPresetsPath + "/" + presetCategoryName + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION))
            {
                SetPresetValues(LoadPreset(presetCategoryName, presetName));
            }
#else
            if (UsesPreset && File.Exists(Application.persistentDataPath + "/Plugins/DoozyUI/UIButton/Resources/" + presetCategoryName + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION))
            {
                SetPresetValues(LoadPreset(presetCategoryName, presetName));
            }
#endif
        }

        void OnEnable()
        {
            if (punchMove.enabled == false && punchRotate.enabled == false && punchScale.enabled == false && move.enabled == false && rotate.enabled == false && scale.enabled == false && fade.enabled == false)
            {
                enabled = false;
                Debug.Log(name + " - UIButton.AnimatorManager - Reacts to " + reactTo.ToString() + " - No animation has been enabled on the gameobject. In order for the AnimatorModule to work you should enable at least one animation. This component has been disabled.");
            }

            AddListeners();
        }

        void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter:
                    uiButton.OnHoverEnter.AddListener(ExecutePunchMove);
                    uiButton.OnHoverEnter.AddListener(ExecutePunchRotate);
                    uiButton.OnHoverEnter.AddListener(ExecutePunchScale);
                    uiButton.OnHoverEnter.AddListener(ExecuteMove);
                    uiButton.OnHoverEnter.AddListener(ExecuteRotate);
                    uiButton.OnHoverEnter.AddListener(ExecuteScale);
                    uiButton.OnHoverEnter.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnHoverExit:
                    uiButton.OnHoverExit.AddListener(ExecutePunchMove);
                    uiButton.OnHoverExit.AddListener(ExecutePunchRotate);
                    uiButton.OnHoverExit.AddListener(ExecutePunchScale);
                    uiButton.OnHoverExit.AddListener(ExecuteMove);
                    uiButton.OnHoverExit.AddListener(ExecuteRotate);
                    uiButton.OnHoverExit.AddListener(ExecuteScale);
                    uiButton.OnHoverExit.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnPointerDown:
                    uiButton.OnPointerDown.AddListener(ExecutePunchMove);
                    uiButton.OnPointerDown.AddListener(ExecutePunchRotate);
                    uiButton.OnPointerDown.AddListener(ExecutePunchScale);
                    uiButton.OnPointerDown.AddListener(ExecuteMove);
                    uiButton.OnPointerDown.AddListener(ExecuteRotate);
                    uiButton.OnPointerDown.AddListener(ExecuteScale);
                    uiButton.OnPointerDown.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnPointerUp:
                    uiButton.OnPointerUp.AddListener(ExecutePunchMove);
                    uiButton.OnPointerUp.AddListener(ExecutePunchRotate);
                    uiButton.OnPointerUp.AddListener(ExecutePunchScale);
                    uiButton.OnPointerUp.AddListener(ExecuteMove);
                    uiButton.OnPointerUp.AddListener(ExecuteRotate);
                    uiButton.OnPointerUp.AddListener(ExecuteScale);
                    uiButton.OnPointerUp.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnClick:
                    uiButton.OnClick.AddListener(ExecutePunchMove);
                    uiButton.OnClick.AddListener(ExecutePunchRotate);
                    uiButton.OnClick.AddListener(ExecutePunchScale);
                    uiButton.OnClick.AddListener(ExecuteMove);
                    uiButton.OnClick.AddListener(ExecuteRotate);
                    uiButton.OnClick.AddListener(ExecuteScale);
                    uiButton.OnClick.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnDoubleClick:
                    uiButton.OnDoubleClick.AddListener(ExecutePunchMove);
                    uiButton.OnDoubleClick.AddListener(ExecutePunchRotate);
                    uiButton.OnDoubleClick.AddListener(ExecutePunchScale);
                    uiButton.OnDoubleClick.AddListener(ExecuteMove);
                    uiButton.OnDoubleClick.AddListener(ExecuteRotate);
                    uiButton.OnDoubleClick.AddListener(ExecuteScale);
                    uiButton.OnDoubleClick.AddListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnLongClick:
                    uiButton.OnLongClick.AddListener(ExecutePunchMove);
                    uiButton.OnLongClick.AddListener(ExecutePunchRotate);
                    uiButton.OnLongClick.AddListener(ExecutePunchScale);
                    uiButton.OnLongClick.AddListener(ExecuteMove);
                    uiButton.OnLongClick.AddListener(ExecuteRotate);
                    uiButton.OnLongClick.AddListener(ExecuteScale);
                    uiButton.OnLongClick.AddListener(ExecuteFade);
                    break;
            }
        }

        private void RemoveListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter:
                    uiButton.OnHoverEnter.RemoveListener(ExecutePunchMove);
                    uiButton.OnHoverEnter.RemoveListener(ExecutePunchRotate);
                    uiButton.OnHoverEnter.RemoveListener(ExecutePunchScale);
                    uiButton.OnHoverEnter.RemoveListener(ExecuteMove);
                    uiButton.OnHoverEnter.RemoveListener(ExecuteRotate);
                    uiButton.OnHoverEnter.RemoveListener(ExecuteScale);
                    uiButton.OnHoverEnter.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnHoverExit:
                    uiButton.OnHoverExit.RemoveListener(ExecutePunchMove);
                    uiButton.OnHoverExit.RemoveListener(ExecutePunchRotate);
                    uiButton.OnHoverExit.RemoveListener(ExecutePunchScale);
                    uiButton.OnHoverExit.RemoveListener(ExecuteMove);
                    uiButton.OnHoverExit.RemoveListener(ExecuteRotate);
                    uiButton.OnHoverExit.RemoveListener(ExecuteScale);
                    uiButton.OnHoverExit.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnPointerDown:
                    uiButton.OnPointerDown.RemoveListener(ExecutePunchMove);
                    uiButton.OnPointerDown.RemoveListener(ExecutePunchRotate);
                    uiButton.OnPointerDown.RemoveListener(ExecutePunchScale);
                    uiButton.OnPointerDown.RemoveListener(ExecuteMove);
                    uiButton.OnPointerDown.RemoveListener(ExecuteRotate);
                    uiButton.OnPointerDown.RemoveListener(ExecuteScale);
                    uiButton.OnPointerDown.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnPointerUp:
                    uiButton.OnPointerUp.RemoveListener(ExecutePunchMove);
                    uiButton.OnPointerUp.RemoveListener(ExecutePunchRotate);
                    uiButton.OnPointerUp.RemoveListener(ExecutePunchScale);
                    uiButton.OnPointerUp.RemoveListener(ExecuteMove);
                    uiButton.OnPointerUp.RemoveListener(ExecuteRotate);
                    uiButton.OnPointerUp.RemoveListener(ExecuteScale);
                    uiButton.OnPointerUp.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnClick:
                    uiButton.OnClick.RemoveListener(ExecutePunchMove);
                    uiButton.OnClick.RemoveListener(ExecutePunchRotate);
                    uiButton.OnClick.RemoveListener(ExecutePunchScale);
                    uiButton.OnClick.RemoveListener(ExecuteMove);
                    uiButton.OnClick.RemoveListener(ExecuteRotate);
                    uiButton.OnClick.RemoveListener(ExecuteScale);
                    uiButton.OnClick.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnDoubleClick:
                    uiButton.OnDoubleClick.RemoveListener(ExecutePunchMove);
                    uiButton.OnDoubleClick.RemoveListener(ExecutePunchRotate);
                    uiButton.OnDoubleClick.RemoveListener(ExecutePunchScale);
                    uiButton.OnDoubleClick.RemoveListener(ExecuteMove);
                    uiButton.OnDoubleClick.RemoveListener(ExecuteRotate);
                    uiButton.OnDoubleClick.RemoveListener(ExecuteScale);
                    uiButton.OnDoubleClick.RemoveListener(ExecuteFade);
                    break;
                case UIButton.ReactTo.OnLongClick:
                    uiButton.OnLongClick.RemoveListener(ExecutePunchMove);
                    uiButton.OnLongClick.RemoveListener(ExecutePunchRotate);
                    uiButton.OnLongClick.RemoveListener(ExecutePunchScale);
                    uiButton.OnLongClick.RemoveListener(ExecuteMove);
                    uiButton.OnLongClick.RemoveListener(ExecuteRotate);
                    uiButton.OnLongClick.RemoveListener(ExecuteScale);
                    uiButton.OnLongClick.RemoveListener(ExecuteFade);
                    break;
            }
        }

        /// <summary>
        /// Executes the PunchMove animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecutePunchMove(bool forcedExecution)
        {
            if (!punchMove.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOPunchAnchorPos(punchMove.punch, punchMove.duration, punchMove.vibrato, punchMove.elasticity, punchMove.snapping)
                         .SetUpdate(true)
                         .SetDelay(punchMove.delay)
                         .OnComplete(() => { rectTransfrom.DOAnchorPos3D(uiButton.GetInitialData.startAnchoredPosition3D, 0.1f).Play(); })
                         .Play();
        }
        /// <summary>
        /// Executes the PunchMove animation
        /// </summary>
        public void ExecutePunchMove() { ExecutePunchMove(false); }

        /// <summary>
        /// Executes the PunchRotate animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecutePunchRotate(bool forcedExecution)
        {
            if (!punchRotate.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOPunchRotation(punchRotate.punch, punchRotate.duration, punchRotate.vibrato, punchRotate.elasticity)
                         .SetUpdate(true)
                         .SetDelay(punchRotate.delay)
                         .OnComplete(() => { rectTransfrom.DOLocalRotate(uiButton.GetInitialData.startLocalRotation, 0.1f).Play(); })
                         .Play();
        }
        /// <summary>
        /// Executes the PunchRotate animation
        /// </summary>
        public void ExecutePunchRotate() { ExecutePunchRotate(false); }

        /// <summary>
        /// Executes the PunchScale animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecutePunchScale(bool forcedExecution)
        {
            if (!punchScale.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOPunchScale(punchScale.punch, punchScale.duration, punchScale.vibrato, punchScale.elasticity)
                     .SetUpdate(true)
                     .SetDelay(punchScale.delay)
                     .OnComplete(() => { rectTransfrom.DOScale(uiButton.GetInitialData.startLocalScale, 0.1f).Play(); })
                     .Play();
        }
        /// <summary>
        /// Executes the PunchScale animation
        /// </summary>
        public void ExecutePunchScale() { ExecutePunchScale(false); }

        /// <summary>
        /// Executes the Move animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecuteMove(bool forcedExecution)
        {
            if (!move.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOAnchorPos3D(move.to, move.duration, move.snapping)
                         .SetUpdate(true)
                         .SetDelay(move.delay)
                         .SetEase(move.ease)
                         .SetRelative(move.relative)
                         .OnComplete(() =>
                         {
                             if (move.reverseAfterTime)
                                 rectTransfrom.DOAnchorPos3D(uiButton.GetInitialData.startAnchoredPosition3D, move.reverseDuration, move.snapping)
                                              .SetUpdate(true)
                                              .SetDelay(move.reverseDelay)
                                              .SetEase(move.reverseEase)
                                              .Play();
                         })
                         .Play();
        }
        /// <summary>
        /// Executes the Move animation
        /// </summary>
        public void ExecuteMove() { ExecuteMove(false); }

        /// <summary>
        /// Executes the Rotate animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecuteRotate(bool forcedExecution)
        {
            if (!rotate.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOLocalRotate(rotate.to, rotate.duration, RotateMode.Fast)
                         .SetUpdate(true)
                         .SetDelay(rotate.delay)
                         .SetEase(rotate.ease)
                         .SetRelative(rotate.relative)
                         .OnComplete(() =>
                         {
                             if (rotate.reverseAfterTime)
                                 rectTransfrom.DOLocalRotate(uiButton.GetInitialData.startLocalRotation, rotate.reverseDuration, RotateMode.Fast)
                                              .SetUpdate(true)
                                              .SetDelay(rotate.reverseDelay)
                                              .SetEase(rotate.reverseEase)
                                              .Play();
                         })
                         .Play();
        }
        /// <summary>
        /// Executes the Rotate animation
        /// </summary>
        public void ExecuteRotate() { ExecuteRotate(false); }

        /// <summary>
        /// Executes the Scale animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecuteScale(bool forcedExecution)
        {
            if (!scale.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            rectTransfrom.DOScale(scale.to, scale.duration)
                         .SetUpdate(true)
                         .SetDelay(scale.delay)
                         .SetEase(scale.ease)
                         .SetRelative(scale.relative)
                         .OnComplete(() =>
                         {
                             if (scale.reverseAfterTime)
                                 rectTransfrom.DOScale(uiButton.GetInitialData.startLocalScale, scale.reverseDuration)
                                              .SetUpdate(true)
                                              .SetDelay(scale.reverseDelay)
                                              .SetEase(scale.reverseEase)
                                              .Play();
                         })
                         .Play();
        }
        /// <summary>
        /// Executes the Scale animation
        /// </summary>
        public void ExecuteScale() { ExecuteScale(false); }

        /// <summary>
        /// Executes the Fade animation. You can force an execution of this animation (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this animation regardless if it is enabled or not (default:false)</param>
        public void ExecuteFade(bool forcedExecution)
        {
            if (!fade.enabled)
            {
                if (!forcedExecution)
                    return;
            }

            CanvasGroup canvasGroup = rectTransfrom.GetComponent<CanvasGroup>();
            if (canvasGroup == null) canvasGroup = rectTransfrom.gameObject.AddComponent<CanvasGroup>();
            canvasGroup.DOFade(fade.to, fade.duration)
                       .SetUpdate(true)
                       .SetDelay(fade.delay)
                       .SetEase(fade.ease)
                       .SetRelative(fade.relative)
                       .OnComplete(() =>
                       {
                           if (fade.reverseAfterTime)
                               canvasGroup.DOFade(uiButton.GetInitialData.startAlpha, fade.reverseDuration)
                                          .SetUpdate(true)
                                          .SetDelay(fade.reverseDelay)
                                          .SetEase(fade.reverseEase)
                                          .Play();
                       })
                       .Play();
        }
        /// <summary>
        /// Executes the Fade animation
        /// </summary>
        public void ExecuteFade() { ExecuteFade(false); }

        /// <summary>
        /// Executes all the enabled animations PuchMove, PunchRotate, PunchScale, Move, Rotate, Scale and Fade
        /// </summary>
        public void ExecuteAllAnimations()
        {
            ExecutePunchMove();
            ExecutePunchRotate();
            ExecutePunchScale();

            ExecuteMove();
            ExecuteRotate();
            ExecuteScale();
            ExecuteFade();
        }

        #region PRESET METHODS: SetPresetValues, GetPresetValues, PresetExists, SavePreset, LoadPreset
        /// <summary>
        /// Gets the values from the source AnimatorPreset and overrides the animator module's values.
        /// </summary>
        /// <param name="source"></param>
        public void SetPresetValues(AnimatorPreset source)
        {
            if (source == null)
                return;

            punchMove.enabled = source.pm_enabled;
            punchMove.punch = new Vector3(source.pm_punch_x, source.pm_punch_y, source.pm_punch_z);
            punchMove.snapping = source.pm_snapping;
            punchMove.duration = source.pm_duration;
            punchMove.delay = source.pm_delay;
            punchMove.vibrato = source.pm_vibrato;
            punchMove.elasticity = source.pm_elasticity;

            punchRotate.enabled = source.pr_enabled;
            punchRotate.punch = new Vector3(source.pr_punch_x, source.pr_punch_y, source.pr_punch_z);
            punchRotate.duration = source.pr_duration;
            punchRotate.delay = source.pr_delay;
            punchRotate.vibrato = source.pr_vibrato;
            punchRotate.elasticity = source.pr_elasticity;

            punchScale.enabled = source.ps_enabled;
            punchScale.punch = new Vector3(source.ps_punch_x, source.ps_punch_y, source.ps_punch_z);
            punchScale.duration = source.ps_duration;
            punchScale.delay = source.ps_delay;
            punchScale.vibrato = source.ps_vibrato;
            punchScale.elasticity = source.ps_elasticity;

            move.enabled = source.m_enabled;
            move.to = new Vector3(source.m_to_x, source.m_to_y, source.m_to_z);
            move.relative = source.m_relative;
            move.snapping = source.m_snapping;
            move.duration = source.m_duration;
            move.delay = source.m_delay;
            move.ease = source.m_ease;
            move.reverseAfterTime = source.m_reverseAfterTime;
            move.reverseDuration = source.m_reverseDuration;
            move.reverseDelay = source.m_reverseDelay;
            move.reverseEase = source.m_reverseEase;

            rotate.enabled = source.r_enabled;
            rotate.to = new Vector3(source.r_to_x, source.r_to_y, source.r_to_z);
            rotate.relative = source.r_relative;
            rotate.duration = source.r_duration;
            rotate.delay = source.r_delay;
            rotate.ease = source.r_ease;
            rotate.reverseAfterTime = source.r_reverseAfterTime;
            rotate.reverseDuration = source.r_reverseDuration;
            rotate.reverseDelay = source.r_reverseDelay;
            rotate.reverseEase = source.r_reverseEase;

            scale.enabled = source.s_enabled;
            scale.to = new Vector3(source.s_to_x, source.s_to_y, source.s_to_z);
            scale.relative = source.s_relative;
            scale.duration = source.s_duration;
            scale.delay = source.s_delay;
            scale.ease = source.s_ease;
            scale.reverseAfterTime = source.s_reverseAfterTime;
            scale.reverseDuration = source.s_reverseDuration;
            scale.reverseDelay = source.s_reverseDelay;
            scale.reverseEase = source.s_reverseEase;

            fade.enabled = source.f_enabled;
            fade.to = source.f_to;
            fade.relative = source.f_relative;
            fade.duration = source.f_duration;
            fade.delay = source.f_delay;
            fade.ease = source.f_ease;
            fade.reverseAfterTime = source.f_reverseAfterTime;
            fade.reverseDuration = source.f_reverseDuration;
            fade.reverseDelay = source.f_reverseDelay;
            fade.reverseEase = source.f_reverseEase;
        }

        /// <summary>
        /// Returns an AnimatorPreset with all the values of the animator module.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public AnimatorPreset GetPresetValues()
        {
            AnimatorPreset preset = new AnimatorPreset();

            //PunchMove
            preset.pm_enabled = punchMove.enabled;
            preset.pm_punch_x = punchMove.punch.x;
            preset.pm_punch_y = punchMove.punch.y;
            preset.pm_punch_z = punchMove.punch.z;
            preset.pm_snapping = punchMove.snapping;
            preset.pm_duration = punchMove.duration;
            preset.pm_delay = punchMove.delay;
            preset.pm_vibrato = punchMove.vibrato;
            preset.pm_elasticity = punchMove.elasticity;

            //PunchRotate
            preset.pr_enabled = punchRotate.enabled;
            preset.pr_punch_x = punchRotate.punch.x;
            preset.pr_punch_y = punchRotate.punch.y;
            preset.pr_punch_z = punchRotate.punch.z;
            preset.pr_duration = punchRotate.duration;
            preset.pr_delay = punchRotate.delay;
            preset.pr_vibrato = punchRotate.vibrato;
            preset.pr_elasticity = punchRotate.elasticity;

            //PunchScale
            preset.ps_enabled = punchScale.enabled;
            preset.ps_punch_x = punchScale.punch.x;
            preset.ps_punch_y = punchScale.punch.y;
            preset.ps_punch_z = punchScale.punch.z;
            preset.ps_duration = punchScale.duration;
            preset.ps_delay = punchScale.delay;
            preset.ps_vibrato = punchScale.vibrato;
            preset.ps_elasticity = punchScale.elasticity;

            //Move
            preset.m_enabled = move.enabled;
            preset.m_to_x = move.to.x;
            preset.m_to_y = move.to.y;
            preset.m_to_z = move.to.z;
            preset.m_relative = move.relative;
            preset.m_snapping = move.snapping;
            preset.m_duration = move.duration;
            preset.m_delay = move.delay;
            preset.m_ease = move.ease;
            preset.m_reverseAfterTime = move.reverseAfterTime;
            preset.m_reverseDuration = move.reverseDuration;
            preset.m_reverseDelay = move.reverseDelay;
            preset.m_reverseEase = move.reverseEase;

            //Rotate
            preset.r_enabled = rotate.enabled;
            preset.r_to_x = rotate.to.x;
            preset.r_to_y = rotate.to.y;
            preset.r_to_z = rotate.to.z;
            preset.r_relative = rotate.relative;
            preset.r_duration = rotate.duration;
            preset.r_delay = rotate.delay;
            preset.r_ease = rotate.ease;
            preset.r_reverseAfterTime = rotate.reverseAfterTime;
            preset.r_reverseDuration = rotate.reverseDuration;
            preset.r_reverseDelay = rotate.reverseDelay;
            preset.r_reverseEase = rotate.reverseEase;

            //Scale
            preset.s_enabled = scale.enabled;
            preset.s_to_x = scale.to.x;
            preset.s_to_y = scale.to.y;
            preset.s_to_z = scale.to.z;
            preset.s_relative = scale.relative;
            preset.s_duration = scale.duration;
            preset.s_delay = scale.delay;
            preset.s_ease = scale.ease;
            preset.s_reverseAfterTime = scale.reverseAfterTime;
            preset.s_reverseDuration = scale.reverseDuration;
            preset.s_reverseDelay = scale.reverseDelay;
            preset.s_reverseEase = scale.reverseEase;

            //Fade
            preset.f_enabled = fade.enabled;
            preset.f_to = fade.to;
            preset.f_relative = fade.relative;
            preset.f_duration = fade.duration;
            preset.f_delay = fade.delay;
            preset.f_ease = fade.ease;
            preset.f_reverseAfterTime = fade.reverseAfterTime;
            preset.f_reverseDuration = fade.reverseDuration;
            preset.f_reverseDelay = fade.reverseDelay;
            preset.f_reverseEase = fade.reverseEase;

            return preset;
        }

        /// <summary>
        /// Returns true if the preset file exists and false if it does not.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        /// <returns></returns>
        public static bool PresetExists(string category, string presetName)
        {
            return File.Exists(GetPresetsPath + "/" + category + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION);
        }

        /// <summary>
        /// Saves a preset as a new file. Note: Check if the file exists before calling this method.
        /// </summary>
        /// <param name="preset"></param>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        public static void SavePreset(AnimatorPreset preset, string category, string presetName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(GetPresetsPath + "/" + category + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION);
            bf.Serialize(file, preset);
            file.Close();
        }

        /// <summary>
        /// Loads a preset from a file. Note: Check that the file exists before calling this method.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="presetName"></param>
        /// <returns></returns>
        public static AnimatorPreset LoadPreset(string category, string presetName)
        {
            if (!File.Exists(GetPresetsPath + "/" + category + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION))
                return null;

            BinaryFormatter bf = new BinaryFormatter();
#if UNITY_EDITOR
            FileStream file = File.Open(GetPresetsPath + "/" + category + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION, FileMode.Open);
#else
            FileStream file = File.Open(Application.persistentDataPath + "/Plugins/DoozyUI/UIButton/Resources/" + category + "/" + presetName + "." + PresetHelper.PRESET_EXTENSION, FileMode.Open);
#endif
            AnimatorPreset preset = (AnimatorPreset)bf.Deserialize(file);
            file.Close();
            return preset;
        }
        #endregion
    }
}
