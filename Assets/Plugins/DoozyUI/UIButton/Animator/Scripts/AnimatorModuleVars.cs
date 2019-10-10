// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton.Animator
{
    public partial class AnimatorModule
    {
        private static string presetsPath;
        public static string GetPresetsPath
        {
            get
            {
                if (string.IsNullOrEmpty(presetsPath))
                {
                    presetsPath = FileHelper.GetRelativeFolderPath("DoozyUI") + "/UIButton/Resources/Presets/";
                }
                return presetsPath;
            }
        }

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
        /// The preset category name (this is a folder name)
        /// </summary>
        public string presetCategoryName = PresetHelper.DEFAULT_PRESET_CATEGORY_NAME;
        /// <summary>
        /// The preset name (this is a file name)
        /// </summary>
        public string presetName = PresetHelper.DEFAULT_PRESET_NAME;
        /// <summary>
        /// Returns TRUE if this Animator uses a preset and FALSE otherwise
        /// </summary>
        public bool UsesPreset { get { return !presetCategoryName.Equals(PresetHelper.DEFAULT_PRESET_CATEGORY_NAME) && !presetName.Equals(PresetHelper.DEFAULT_PRESET_NAME); } }

        /// <summary>
        /// Animation settings for PunchMove
        /// </summary>
        public PunchMove punchMove = new PunchMove();
        /// <summary>
        /// Animation settings for PunchRotate
        /// </summary>
        public PunchRotate punchRotate = new PunchRotate();
        /// <summary>
        /// Animations settings for PunchScale
        /// </summary>
        public PunchScale punchScale = new PunchScale();

        /// <summary>
        /// Animation settings for Move
        /// </summary>
        public Move move = new Move();
        /// <summary>
        /// Animation settings for Rotate
        /// </summary>
        public Rotate rotate = new Rotate();
        /// <summary>
        /// Animation settings for Scale
        /// </summary>
        public Scale scale = new Scale();
        /// <summary>
        /// Animation settings for Fade
        /// </summary>
        public Fade fade = new Fade();

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
        public bool IsAnimatorModuleEnabled
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
