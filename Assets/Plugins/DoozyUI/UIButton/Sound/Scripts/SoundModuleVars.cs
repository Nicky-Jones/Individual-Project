// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton.Sound
{
    public partial class SoundModule
    {
        /// <summary>
        /// Prints to Debug.Log all the relevant functionality informations needed for debug purposes
        /// </summary>
        public bool debugThis = false;

        /// <summary>
        /// Selects the UIButton's trigger that this module reacts to.
        /// <para>You should not change this in code as you might break the UIButton</para>
        /// </summary>
        public UIButton.ReactTo reactTo = UIButton.ReactTo.OnClick;

        /// <summary>
        /// Selected sound source to play
        /// </summary>
        public SoundSource soundSource = SoundSource.AudioClip;
        /// <summary>
        /// Contains the sound references
        /// </summary>
        public Sound sound = new Sound();
        private AudioClip loadedAudioClip;
        /// <summary>
        /// Sound volume (0,1)
        /// </summary>
        public float volume = 1;

        private RectTransform rectTransfrom;
        /// <summary>
        /// Reference to the RectTransform component of this UIButton
        /// </summary>
        public RectTransform GetRectTransform { get { if (rectTransfrom == null) rectTransfrom = GetComponent<RectTransform>(); return rectTransfrom; } }

        private UIButton uiButton;
        /// <summary>
        /// Reference of the UIButton component that this module reacts to
        /// </summary>
        public UIButton GetUIButton { get { if (uiButton == null) uiButton = GetComponent<UIButton>(); return uiButton; } }


        /// <summary>
        /// Returns TRUE it this module will get triggered by the UIButton and FALSE otherwise
        /// </summary>
        public bool IsSoundModuleEnabled
        {
            get
            {
                switch (reactTo)
                {
                    case UIButton.ReactTo.OnHoverEnter: return GetUIButton.useOnHoverEnter;
                    case UIButton.ReactTo.OnHoverExit: return GetUIButton.useOnHoverExit;
                    case UIButton.ReactTo.OnPointerDown: return GetUIButton.useOnPointerDown;
                    case UIButton.ReactTo.OnPointerUp: return GetUIButton.useOnPointerUp;
                    case UIButton.ReactTo.OnClick: return GetUIButton.useOnClick;
                    case UIButton.ReactTo.OnDoubleClick: return GetUIButton.useOnDoubleClick;
                    case UIButton.ReactTo.OnLongClick: return GetUIButton.useOnLongClick;
                    default: return false;
                }
            }
        }
    }
}
