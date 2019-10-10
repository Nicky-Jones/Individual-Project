// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DoozyUI.UIButton
{
    public partial class UIButton
    {
        /// <summary>
        /// Prints to Debug.Log all the relevant functionality informations needed for debug purposes
        /// </summary>
        public bool debugThis = false;

        private InitialData initialData = new InitialData();
        /// <summary>
        /// Returns a class that contains the startAnchoredPosition3D, startLocalRotation, startLocalScale and startAlpha for this UIButton
        /// </summary>
        public InitialData GetInitialData { get { return initialData; } }

        private RectTransform nRectTransform = null;
        /// <summary>
        /// Reference to the RectTransform component of this UIButton
        /// </summary>
        public RectTransform rectTransform { get { if (nRectTransform == null) nRectTransform = GetComponent<RectTransform>(); return nRectTransform; } }
        private Button nButton = null;
        /// <summary>
        /// Reference to the Button component of this UIButton
        /// </summary>
        public Button button { get { if (nButton == null) nButton = GetComponent<Button>(); return nButton; } }
        /// <summary>
        /// Returns TRUE if the button is interactable and FALSE otherwise
        /// </summary>
        public bool interactable { get { return button.interactable; } set { button.interactable = value; } }

        /// <summary>
        /// Toggles if the UIButton should allow multiple clicks or if it should disable the UIButton after each click for a set time interval. (default:true)
        /// </summary>
        public bool allowMultipleClicks = true;
        /// <summary>
        /// How long will the button get disabled after each click
        /// </summary>
        public float disableButtonInterval = UIBUTTON_ON_CLICK_DISABLE_INTERVAL;

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnHoverEnter = false;
        /// <summary>
        /// The time interval between two OnHoverEnter event triggers. This disables the OnHoverEnter for a set time interval
        /// </summary>
        public float onHoverEnterDisableInterval = UIBUTTON_ON_HOVER_ENTER_DISABLE_INTERVAL;
        private bool onHoverEnterReady = true;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onHoverEnterAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onHoverEnterSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onHoverEnterEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listeners from the Inspector
        /// </summary>
        public UnityEvent OnHoverEnter = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnHoverExit = false;
        /// <summary>
        /// The time interval between two OnHoverExit event triggers. This disables the OnHoverExit for a set time interval
        /// </summary>
        public float onHoverExitDisableInterval = UIBUTTON_ON_HOVER_EXIT_DISABLE_INTERVAL;
        private bool onHoverExitReady = true;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onHoverExitAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onHoverExitSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onHoverExitEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnHoverExit = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnPointerDown = false;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onPointerDownAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onPointerDownSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onPointerDownEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnPointerDown = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnPointerUp = false;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onPointerUpAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onPointerUpSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onPointerUpEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnPointerUp = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnClick = false;
        /// <summary>
        /// Set if the click should get registered instantly without checking if it's a double click or not
        /// </summary>
        public SingleClickMode singleClickMode = SingleClickMode.Instant;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onClickAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onClickSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onClickEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnClick = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnDoubleClick = false;
        /// <summary>
        /// The time inverval between two sequential clicks that makes them count as a DoubleClick
        /// </summary>
        public float doubleClickRegisterInterval = UIBUTTON_DOUBLE_CLICK_REGISTER_INTERVAL;
        private float doubleClickTimeoutCounter = 0f;
        private bool clickedOnce = false;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onDoubleClickAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onDoubleClickSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onDoubleClickEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnDoubleClick = new UnityEvent();

        /// <summary>
        /// Toggles the active state of this trigger (default:false)
        /// </summary>
        public bool useOnLongClick = false;
        /// <summary>
        /// The time interval the button has to be pressed down in order to trigger a LongClick
        /// </summary>
        public float longClickRegisterInterval = UIBUTTON_LONG_CLICK_REGISTER_INTERVAL;
        private Coroutine coroutineLongClickRegistered = null;
        private float longClickTimeoutCounter = 0f;
        private bool executedLongClick = false;
        /// <summary>
        /// Reference to the UIButton.Animator Component linked to this trigger
        /// </summary>
        public Animator.AnimatorModule onLongClickAnimatorModule = null;
        /// <summary>
        /// Reference to the UIButton.Sound Component linked to this trigger
        /// </summary>
        public Sound.SoundModule onLongClickSoundModule = null;
        /// <summary>
        /// Reference to the UIButton.Effect Component linked to this trigger
        /// </summary>
        public Effect.EffectModule onLongClickEffectModule = null;
        /// <summary>
        /// UnityEvent that is Invoked every time this trigger is fired. You can set non-persistent listeners to it from code and a persistent listener from the Inspector
        /// </summary>
        public UnityEvent OnLongClick = new UnityEvent();
    }
}
