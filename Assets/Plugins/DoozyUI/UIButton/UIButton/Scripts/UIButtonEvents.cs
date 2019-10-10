// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton
{
    public partial class UIButton
    {
        /// <summary>
        /// Executes the OnHoverEnter trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecuteHoverEnter(bool forcedExecution = false)
        {
            if(forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnHoverEnter initiated through forcedExecution");
                OnHoverEnter.Invoke();
                return;
            }

            if (useOnHoverEnter)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnHoverEnter");
                if (interactable && onHoverEnterReady)
                {
                    OnHoverEnter.Invoke();
                    if (onHoverEnterDisableInterval > 0)
                        StartCoroutine("DisableOnHoverEnter");
                }
            }
        }

        /// <summary>
        /// Executes the OnHoverExit trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        private void ExecuteHoverExit(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnHoverExit initiated through forcedExecution");
                OnHoverExit.Invoke();
                return;
            }

            if (useOnHoverExit)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnHoverExit");
                if (interactable && onHoverExitReady)
                {
                    OnHoverExit.Invoke();
                    if (onHoverExitDisableInterval > 0)
                        StartCoroutine("DisableOnHoverExit");
                }
            }
        }

        /// <summary>
        /// Executes the OnPointerDown trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecutePointerDown(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnPointerDown initiated through forcedExecution");
                OnPointerDown.Invoke();
                return;
            }

            if (useOnPointerDown)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnPointerDown");
                if (interactable) OnPointerDown.Invoke();
            }

            if (useOnLongClick)
            {
                if (interactable) RegisterLongClick();
            }
        }

        /// <summary>
        /// Executes the OnPointerUp trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecutePointerUp(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnPointerUp initiated through forcedExecution");
                OnPointerUp.Invoke();
                return;
            }

            if (useOnPointerUp)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnPointerUp");
                if (interactable) OnPointerUp.Invoke();
            }

            if (useOnLongClick)
            {
                StopLongClickListener();
            }
        }

        /// <summary>
        /// Executes the OnClick trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecuteClick(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnClick initiated through forcedExecution");
                OnClick.Invoke();
                return;
            }

            if (useOnClick)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnClick");
                if (interactable) OnClick.Invoke();
                if (!interactable & useOnHoverExit & onHoverExitReady) OnHoverExit.Invoke();
            }
        }

        /// <summary>
        /// Executes the OnDoubleClick trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecuteDoubleClick(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnDoubleClick initiated through forcedExecution");
                OnDoubleClick.Invoke();
                return;
            }

            if (useOnDoubleClick)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnDoubleClick");
                if (interactable) OnDoubleClick.Invoke();
                if (!interactable & useOnHoverExit & onHoverExitReady) OnHoverExit.Invoke();
            }
        }

        /// <summary>
        /// Executes the OnLongClick trigger. You can force an execution of this trigger (regardless if it's enabled or not) by calling this method with forcedExecution set to TRUE
        /// </summary>
        /// <param name="forcedExecution">Fires this trigger regardless if it is enabled or not (default:false)</param>
        public void ExecuteLongClick(bool forcedExecution = false)
        {
            if (forcedExecution)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnLongClick initiated through forcedExecution");
                OnLongClick.Invoke();
                return;
            }

            if (useOnLongClick)
            {
                if (debugThis) Debug.Log("DebugMode - UIButton - " + name + " | Executing OnLongClick");
                if (interactable) OnLongClick.Invoke();
                if (!interactable & useOnHoverExit & onHoverExitReady) OnHoverExit.Invoke();
            }
        }
    }
}
