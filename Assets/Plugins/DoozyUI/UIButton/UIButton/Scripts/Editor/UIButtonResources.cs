// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using UnityEngine;

namespace DoozyUI
{
    public partial class DoozyResources
    {
        private static string pathUIButtonPresets;
        public static string PathUIButtonPresets
        {
            get
            {
                if (string.IsNullOrEmpty(pathUIButtonPresets))
                {
                    pathUIButtonPresets = FileHelper.GetRelativeFolderPath("DoozyUI") + "/UIButton/Resources/Presets/";
                }
                return pathUIButtonPresets;
            }
        }

        private static string pathUIButtonImages;
        public static string PathUIButtonImages
        {
            get
            {
                if (string.IsNullOrEmpty(pathUIButtonImages))
                {
                    pathUIButtonImages = FileHelper.GetRelativeFolderPath("DoozyUI") + "/UIButton/Images/";
                }
                return pathUIButtonImages;
            }
        }

        #region Header Bars - UIButton, UIButton.Animator, UIButton.Sound, UIButton.Effect
        private static Texture headerBarUIButton, headerBarUIButtonAnimator, headerBarUIButtonSound, headerBarUIButtonEffect;
        public static Texture HeaderBarUIButton { get { if (headerBarUIButton == null) headerBarUIButton = DoozyEditorUtility.GetTexture("h_bar_uibutton", PathUIButtonImages) as Texture; return headerBarUIButton; } }
        public static Texture HeaderBarUIButtonAnimator { get { if (headerBarUIButtonAnimator == null) headerBarUIButtonAnimator = DoozyEditorUtility.GetTexture("h_bar_uibutton_animator", PathUIButtonImages) as Texture; return headerBarUIButtonAnimator; } }
        public static Texture HeaderBarUIButtonSound { get { if (headerBarUIButtonSound == null) headerBarUIButtonSound = DoozyEditorUtility.GetTexture("h_bar_uibutton_sound", PathUIButtonImages) as Texture; return headerBarUIButtonSound; } }
        public static Texture HeaderBarUIButtonEffect { get { if (headerBarUIButtonEffect == null) headerBarUIButtonEffect = DoozyEditorUtility.GetTexture("h_bar_uibutton_effect", PathUIButtonImages) as Texture; return headerBarUIButtonEffect; } }
        #endregion

        #region  Buttons 420x18 - Normal&Active - Enabled&Disabled - punchMove, punchRotate, punchScale, move, rotate, scale, fade
        private static Texture btnPunchMoveEnabledNormal, btnPunchMoveEnabledActive, btnPunchMoveDisabledNormal, btnPunchMoveDisabledActive;
        public static Texture Btn420x18NormalPunchMoveEnabled { get { if (btnPunchMoveEnabledNormal == null) btnPunchMoveEnabledNormal = DoozyEditorUtility.GetTexture("b_punchMove_enabled_normal", PathUIButtonImages) as Texture; return btnPunchMoveEnabledNormal; } }
        public static Texture Btn420x18ActivePunchMoveEnabled { get { if (btnPunchMoveEnabledActive == null) btnPunchMoveEnabledActive = DoozyEditorUtility.GetTexture("b_punchMove_enabled_active", PathUIButtonImages) as Texture; return btnPunchMoveEnabledActive; } }
        public static Texture Btn420x18NormalPunchMoveDisabled { get { if (btnPunchMoveDisabledNormal == null) btnPunchMoveDisabledNormal = DoozyEditorUtility.GetTexture("b_punchMove_disabled_normal", PathUIButtonImages) as Texture; return btnPunchMoveDisabledNormal; } }
        public static Texture Btn420x18ActivePunchMoveDisabled { get { if (btnPunchMoveDisabledActive == null) btnPunchMoveDisabledActive = DoozyEditorUtility.GetTexture("b_punchMove_disabled_active", PathUIButtonImages) as Texture; return btnPunchMoveDisabledActive; } }

        private static Texture btnPunchRotateEnabledNormal, btnPunchRotateEnabledActive, btnPunchRotateDisabledNormal, btnPunchRotateDisabledActive;
        public static Texture Btn420x18NormalPunchRotateEnabled { get { if (btnPunchRotateEnabledNormal == null) btnPunchRotateEnabledNormal = DoozyEditorUtility.GetTexture("b_punchRotate_enabled_normal", PathUIButtonImages) as Texture; return btnPunchRotateEnabledNormal; } }
        public static Texture Btn420x18ActivePunchRotateEnabled { get { if (btnPunchRotateEnabledActive == null) btnPunchRotateEnabledActive = DoozyEditorUtility.GetTexture("b_punchRotate_enabled_active", PathUIButtonImages) as Texture; return btnPunchRotateEnabledActive; } }
        public static Texture Btn420x18NormalPunchRotateDisabled { get { if (btnPunchRotateDisabledNormal == null) btnPunchRotateDisabledNormal = DoozyEditorUtility.GetTexture("b_punchRotate_disabled_normal", PathUIButtonImages) as Texture; return btnPunchRotateDisabledNormal; } }
        public static Texture Btn420x18ActivePunchRotateDisabled { get { if (btnPunchRotateDisabledActive == null) btnPunchRotateDisabledActive = DoozyEditorUtility.GetTexture("b_punchRotate_disabled_active", PathUIButtonImages) as Texture; return btnPunchRotateDisabledActive; } }

        private static Texture btnPunchScaleEnabledNormal, btnPunchScaleEnabledActive, btnPunchScaleDisabledNormal, btnPunchScaleDisabledActive;
        public static Texture Btn420x18NormalPunchScaleEnabled { get { if (btnPunchScaleEnabledNormal == null) btnPunchScaleEnabledNormal = DoozyEditorUtility.GetTexture("b_punchScale_enabled_normal", PathUIButtonImages) as Texture; return btnPunchScaleEnabledNormal; } }
        public static Texture Btn420x18ActivePunchScaleEnabled { get { if (btnPunchScaleEnabledActive == null) btnPunchScaleEnabledActive = DoozyEditorUtility.GetTexture("b_punchScale_enabled_active", PathUIButtonImages) as Texture; return btnPunchScaleEnabledActive; } }
        public static Texture Btn420x18NormalPunchScaleDisabled { get { if (btnPunchScaleDisabledNormal == null) btnPunchScaleDisabledNormal = DoozyEditorUtility.GetTexture("b_punchScale_disabled_normal", PathUIButtonImages) as Texture; return btnPunchScaleDisabledNormal; } }
        public static Texture Btn420x18ActivePunchScaleDisabled { get { if (btnPunchScaleDisabledActive == null) btnPunchScaleDisabledActive = DoozyEditorUtility.GetTexture("b_punchScale_disabled_active", PathUIButtonImages) as Texture; return btnPunchScaleDisabledActive; } }

        private static Texture btnMoveEnabledNormal, btnMoveEnabledActive, btnMoveDisabledNormal, btnMoveDisabledActive;
        public static Texture Btn420x18NormalMoveEnabled { get { if (btnMoveEnabledNormal == null) btnMoveEnabledNormal = DoozyEditorUtility.GetTexture("b_move_enabled_normal", PathUIButtonImages) as Texture; return btnMoveEnabledNormal; } }
        public static Texture Btn420x18ActiveMoveEnabled { get { if (btnMoveEnabledActive == null) btnMoveEnabledActive = DoozyEditorUtility.GetTexture("b_move_enabled_active", PathUIButtonImages) as Texture; return btnMoveEnabledActive; } }
        public static Texture Btn420x18NormalMoveDisabled { get { if (btnMoveDisabledNormal == null) btnMoveDisabledNormal = DoozyEditorUtility.GetTexture("b_move_disabled_normal", PathUIButtonImages) as Texture; return btnMoveDisabledNormal; } }
        public static Texture Btn420x18ActiveMoveDisabled { get { if (btnMoveDisabledActive == null) btnMoveDisabledActive = DoozyEditorUtility.GetTexture("b_move_disabled_active", PathUIButtonImages) as Texture; return btnMoveDisabledActive; } }

        private static Texture btnRotateEnabledNormal, btnRotateEnabledActive, btnRotateDisabledNormal, btnRotateDisabledActive;
        public static Texture Btn420x18NormalRotateEnabled { get { if (btnRotateEnabledNormal == null) btnRotateEnabledNormal = DoozyEditorUtility.GetTexture("b_rotate_enabled_normal", PathUIButtonImages) as Texture; return btnRotateEnabledNormal; } }
        public static Texture Btn420x18ActiveRotateEnabled { get { if (btnRotateEnabledActive == null) btnRotateEnabledActive = DoozyEditorUtility.GetTexture("b_rotate_enabled_active", PathUIButtonImages) as Texture; return btnRotateEnabledActive; } }
        public static Texture Btn420x18NormalRotateDisabled { get { if (btnRotateDisabledNormal == null) btnRotateDisabledNormal = DoozyEditorUtility.GetTexture("b_rotate_disabled_normal", PathUIButtonImages) as Texture; return btnRotateDisabledNormal; } }
        public static Texture Btn420x18ActiveRotateDisabled { get { if (btnRotateDisabledActive == null) btnRotateDisabledActive = DoozyEditorUtility.GetTexture("b_rotate_disabled_active", PathUIButtonImages) as Texture; return btnRotateDisabledActive; } }

        private static Texture btnScaleEnabledNormal, btnScaleEnabledActive, btnScaleDisabledNormal, btnScaleDisabledActive;
        public static Texture Btn420x18NormalScaleEnabled { get { if (btnScaleEnabledNormal == null) btnScaleEnabledNormal = DoozyEditorUtility.GetTexture("b_scale_enabled_normal", PathUIButtonImages) as Texture; return btnScaleEnabledNormal; } }
        public static Texture Btn420x18ActiveScaleEnabled { get { if (btnScaleEnabledActive == null) btnScaleEnabledActive = DoozyEditorUtility.GetTexture("b_scale_enabled_active", PathUIButtonImages) as Texture; return btnScaleEnabledActive; } }
        public static Texture Btn420x18NormalScaleDisabled { get { if (btnScaleDisabledNormal == null) btnScaleDisabledNormal = DoozyEditorUtility.GetTexture("b_scale_disabled_normal", PathUIButtonImages) as Texture; return btnScaleDisabledNormal; } }
        public static Texture Btn420x18ActiveScaleDisabled { get { if (btnScaleDisabledActive == null) btnScaleDisabledActive = DoozyEditorUtility.GetTexture("b_scale_disabled_active", PathUIButtonImages) as Texture; return btnScaleDisabledActive; } }

        private static Texture btnFadeEnabledNormal, btnFadeEnabledActive, btnFadeDisabledNormal, btnFadeDisabledActive;
        public static Texture Btn420x18NormalFadeEnabled { get { if (btnFadeEnabledNormal == null) btnFadeEnabledNormal = DoozyEditorUtility.GetTexture("b_fade_enabled_normal", PathUIButtonImages) as Texture; return btnFadeEnabledNormal; } }
        public static Texture Btn420x18ActiveFadeEnabled { get { if (btnFadeEnabledActive == null) btnFadeEnabledActive = DoozyEditorUtility.GetTexture("b_fade_enabled_active", PathUIButtonImages) as Texture; return btnFadeEnabledActive; } }
        public static Texture Btn420x18NormalFadeDisabled { get { if (btnFadeDisabledNormal == null) btnFadeDisabledNormal = DoozyEditorUtility.GetTexture("b_fade_disabled_normal", PathUIButtonImages) as Texture; return btnFadeDisabledNormal; } }
        public static Texture Btn420x18ActiveFadeDisabled { get { if (btnFadeDisabledActive == null) btnFadeDisabledActive = DoozyEditorUtility.GetTexture("b_fade_disabled_active", PathUIButtonImages) as Texture; return btnFadeDisabledActive; } }
        #endregion

    }
}