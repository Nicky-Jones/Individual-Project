// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DoozyUI.UIButton
{
    [RequireComponent(typeof(RectTransform), typeof(Button))]
    [DisallowMultipleComponent]
    public partial class UIButton : MonoBehaviour
    {
        void Reset()
        {
            Animator.AnimatorModule[] animatorModules = GetComponents<Animator.AnimatorModule>();
            if (animatorModules != null && animatorModules.Length > 0)
            {
                for (int i = 0; i < animatorModules.Length; i++)
                {
                    switch (animatorModules[i].reactTo)
                    {
                        case ReactTo.OnHoverEnter: onHoverEnterAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnHoverExit: onHoverExitAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnPointerDown: onPointerDownAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnPointerUp: onPointerDownAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnClick: onClickAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnDoubleClick: onDoubleClickAnimatorModule = animatorModules[i]; break;
                        case ReactTo.OnLongClick: onLongClickAnimatorModule = animatorModules[i]; break;
                    }
                }
            }

            Sound.SoundModule[] soundModules = GetComponents<Sound.SoundModule>();
            if(soundModules != null && soundModules.Length > 0)
            {
                for(int i = 0; i < soundModules.Length; i++)
                {
                    switch (soundModules[i].reactTo)
                    {
                        case ReactTo.OnHoverEnter: onHoverEnterSoundModule= soundModules[i]; break;
                        case ReactTo.OnHoverExit: onHoverExitSoundModule= soundModules[i]; break;
                        case ReactTo.OnPointerDown: onPointerDownSoundModule= soundModules[i]; break;
                        case ReactTo.OnPointerUp: onPointerDownSoundModule= soundModules[i]; break;
                        case ReactTo.OnClick: onClickSoundModule= soundModules[i]; break;
                        case ReactTo.OnDoubleClick: onDoubleClickSoundModule= soundModules[i]; break;
                        case ReactTo.OnLongClick: onLongClickSoundModule= soundModules[i]; break;
                    }
                }
            }

            Effect.EffectModule[] effectModules = GetComponents<Effect.EffectModule>();
            if(effectModules != null && effectModules.Length > 0)
            {
                for(int i = 0; i < effectModules.Length; i++)
                {
                    switch (effectModules[i].reactTo)
                    {
                        case ReactTo.OnHoverEnter: onHoverEnterEffectModule = effectModules[i]; break;
                        case ReactTo.OnHoverExit: onHoverExitEffectModule = effectModules[i]; break;
                        case ReactTo.OnPointerDown: onPointerDownEffectModule = effectModules[i]; break;
                        case ReactTo.OnPointerUp: onPointerDownEffectModule = effectModules[i]; break;
                        case ReactTo.OnClick: onClickEffectModule = effectModules[i]; break;
                        case ReactTo.OnDoubleClick: onDoubleClickEffectModule = effectModules[i]; break;
                        case ReactTo.OnLongClick: onLongClickEffectModule = effectModules[i]; break;
                    }
                }
            }
        }

        void Awake()
        {
            Init();
            AddListeners();
        }

        private void Init()
        {
            initialData.startAnchoredPosition3D = rectTransform.anchoredPosition3D;
            initialData.startLocalRotation = rectTransform.localRotation.eulerAngles;
            initialData.startLocalScale = rectTransform.localScale;
            if (GetComponent<CanvasGroup>() != null) initialData.startAlpha = GetComponent<CanvasGroup>().alpha; else initialData.startAlpha = 1;
        }

        private void AddListeners()
        {
            if (allowMultipleClicks == false)
            {
                OnClick.AddListener(DisableButton);
                OnDoubleClick.AddListener(DisableButton);
                OnLongClick.AddListener(DisableButton);
            }
        }

        private void DisableButton()
        {
            DisableButtonClicks(disableButtonInterval);
        }

        /// <summary>
        /// Disables this button by setting the interactable value to FALSE
        /// </summary>
        public void DisableButtonClicks()
        {
            interactable = false;
        }

        /// <summary>
        /// Disables this button by setting the interactable value to FALSE. And it enables it after the set time interval
        /// </summary>
        public void DisableButtonClicks(float time)
        {
            DisableButtonClicks();
            Invoke("EnableButtonClicks", time);
        }

        /// <summary>
        /// Enables this button by setting the interactable value to TRUE
        /// </summary>
        public void EnableButtonClicks()
        {
            interactable = true;
        }

        private void RegisterLongClick()
        {
            if (executedLongClick == false)
            {
                UnregisterLongClick();
                coroutineLongClickRegistered = StartCoroutine(LongClickRegistered());
            }
        }

        private void StopLongClickListener()
        {
            if (executedLongClick == false && coroutineLongClickRegistered != null)
                UnregisterLongClick();
        }

        private void UnregisterLongClick()
        {
            executedLongClick = false;
            longClickTimeoutCounter = 0f;
            if (coroutineLongClickRegistered != null)
                StopCoroutine(coroutineLongClickRegistered);
            coroutineLongClickRegistered = null;
        }

        private IEnumerator LongClickRegistered()
        {
            while (longClickTimeoutCounter < longClickRegisterInterval)
            {
                longClickTimeoutCounter += Time.deltaTime; //increment counter by change in time between frames
                yield return null;
            }
            ExecuteLongClick();
            executedLongClick = true;
        }

        private void RegisterClick()
        {
            if (executedLongClick == false)
                StartCoroutine(ClickRegistered());
            else
                UnregisterLongClick();
        }

        private IEnumerator ClickRegistered()
        {
            if (clickedOnce == false && doubleClickTimeoutCounter < doubleClickRegisterInterval)
            {
                clickedOnce = true;
            }
            else
            {
                clickedOnce = false;
                yield break; //button is pressed twice -> don't allow the second function call to fully execute
            }
            yield return new WaitForEndOfFrame();

            if (singleClickMode == SingleClickMode.Instant) ExecuteClick();

            while (doubleClickTimeoutCounter < doubleClickRegisterInterval)
            {
                if (clickedOnce == false)
                {
                    ExecuteDoubleClick();
                    doubleClickTimeoutCounter = 0f;
                    clickedOnce = false;
                    yield break;
                }
                doubleClickTimeoutCounter += Time.deltaTime; //increment counter by change in time between frames
                yield return null; //wait for the next frame
            }

            if (singleClickMode == SingleClickMode.Delayed) ExecuteClick();
            doubleClickTimeoutCounter = 0f;
            clickedOnce = false;
        }

        private IEnumerator DisableOnHoverEnter()
        {
            onHoverEnterReady = false;
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + onHoverEnterDisableInterval)
                yield return null;
            onHoverEnterReady = true;
        }

        private IEnumerator DisableOnHoverExit()
        {
            onHoverExitReady = false;
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + onHoverExitDisableInterval)
                yield return null;
            onHoverExitReady = true;
        }
    }
}
