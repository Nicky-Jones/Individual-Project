// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace DoozyUI
{
    public partial class DoozyResources
    {
        private static Font _fontLuckiestGuy;
        public static Font FontLuckiestGuy
        {
            get
            {
                if (_fontLuckiestGuy == null)
                    _fontLuckiestGuy = (Font) AssetDatabase.LoadAssetAtPath(FileHelper.GetRelativeFolderPath("DoozyUI") + "/Shared/Fonts/LuckiestGuy.ttf", typeof(Font));
                return _fontLuckiestGuy;
            }
        }

        private static string pathSharedImages;
        public static string PathSharedImages
        {
            get
            {
                if (string.IsNullOrEmpty(pathSharedImages))
                {
                    pathSharedImages = FileHelper.GetRelativeFolderPath("DoozyUI") + "/Shared/Images/";
                }
                return pathSharedImages;
            }
        }

        private static string pathSharedGifs;
        public static string PathSharedGifs
        {
            get
            {
                if (string.IsNullOrEmpty(pathSharedGifs))
                {
                    pathSharedGifs = FileHelper.GetRelativeFolderPath("DoozyUI") + "/Shared/Gifs/";
                }
                return pathSharedGifs;
            }
        }

        #region GIFs
        private static List<Texture2D> _dUI_ElectricLogo;
        public static List<Texture2D> dUI_ElectricLogo { get { if (_dUI_ElectricLogo == null) _dUI_ElectricLogo = DoozyEditorUtility.GetGIF(PathSharedGifs, "dUI_ElectricLogo"); return _dUI_ElectricLogo; } }
        #endregion

        #region GENERATED_TEXTURES
        private static Texture2D helpBoxDark;
        public static Texture2D HelpBoxDark
        {
            get
            {
                if (helpBoxDark == null)
                {
                    Color borderColor = DoozyColors.D3_GREY;
                    Color contentColor = DoozyColors.D2_GREY;
                    helpBoxDark = new Texture2D(4, 4, TextureFormat.ARGB32, false); // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
                    helpBoxDark.SetPixel(0, 0, borderColor);
                    helpBoxDark.SetPixel(0, 1, borderColor);
                    helpBoxDark.SetPixel(0, 2, borderColor);
                    helpBoxDark.SetPixel(0, 3, borderColor);
                    helpBoxDark.SetPixel(1, 0, borderColor);
                    helpBoxDark.SetPixel(1, 1, contentColor);
                    helpBoxDark.SetPixel(1, 2, contentColor);
                    helpBoxDark.SetPixel(1, 3, borderColor);
                    helpBoxDark.SetPixel(2, 0, borderColor);
                    helpBoxDark.SetPixel(2, 1, contentColor);
                    helpBoxDark.SetPixel(2, 2, contentColor);
                    helpBoxDark.SetPixel(2, 3, borderColor);
                    helpBoxDark.SetPixel(3, 0, borderColor);
                    helpBoxDark.SetPixel(3, 1, borderColor);
                    helpBoxDark.SetPixel(3, 2, borderColor);
                    helpBoxDark.SetPixel(3, 3, borderColor);
                    helpBoxDark.Apply();
                }
                return helpBoxDark;
            }
        }

        private static Texture2D helpBoxLight;
        public static Texture2D HelpBoxLight
        {
            get
            {
                if (helpBoxLight == null)
                {
                    Color borderColor = DoozyColors.UNITY_DARK;
                    Color contentColor = DoozyColors.UNITY_LIGHT;
                    helpBoxLight = new Texture2D(4, 4, TextureFormat.ARGB32, false); // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
                    helpBoxLight.SetPixel(0, 0, borderColor);
                    helpBoxLight.SetPixel(0, 1, borderColor);
                    helpBoxLight.SetPixel(0, 2, borderColor);
                    helpBoxLight.SetPixel(0, 3, borderColor);
                    helpBoxLight.SetPixel(1, 0, borderColor);
                    helpBoxLight.SetPixel(1, 1, contentColor);
                    helpBoxLight.SetPixel(1, 2, contentColor);
                    helpBoxLight.SetPixel(1, 3, borderColor);
                    helpBoxLight.SetPixel(2, 0, borderColor);
                    helpBoxLight.SetPixel(2, 1, contentColor);
                    helpBoxLight.SetPixel(2, 2, contentColor);
                    helpBoxLight.SetPixel(2, 3, borderColor);
                    helpBoxLight.SetPixel(3, 0, borderColor);
                    helpBoxLight.SetPixel(3, 1, borderColor);
                    helpBoxLight.SetPixel(3, 2, borderColor);
                    helpBoxLight.SetPixel(3, 3, borderColor);
                    helpBoxLight.Apply();
                }
                return helpBoxLight;
            }
        }

        #endregion

        #region Buttons 18x18 - Normal&Active - Blue, Green, Orange, Red, Purple, GreyLight, GreyMild, GreyDark
        private static Texture btnBlueNormal, btnBlueActive, btnGreenNormal, btnGreenActive, btnOrangeNormal, btnOrangeActive, btnRedNormal, btnRedActive, btnPurpleNormal, btnPurpleActive, btnGreyLightNormal, btnGreyLightActive, btnGreyMildNormal, btnGreyMildActive, btnGreyDarkNormal, btnGreyDarkActive;
        public static Texture BtnBlueNormal { get { if (btnBlueNormal == null) btnBlueNormal = DoozyEditorUtility.GetTexture("b_blue_normal", PathSharedImages) as Texture; return btnBlueNormal; } }
        public static Texture BtnBlueActive { get { if (btnBlueActive == null) btnBlueActive = DoozyEditorUtility.GetTexture("b_blue_active", PathSharedImages) as Texture; return btnBlueActive; } }
        public static Texture BtnGreenNormal { get { if (btnGreenNormal == null) btnGreenNormal = DoozyEditorUtility.GetTexture("b_green_normal", PathSharedImages) as Texture; return btnGreenNormal; } }
        public static Texture BtnGreenActive { get { if (btnGreenActive == null) btnGreenActive = DoozyEditorUtility.GetTexture("b_green_active", PathSharedImages) as Texture; return btnGreenActive; } }
        public static Texture BtnOrangeNormal { get { if (btnOrangeNormal == null) btnOrangeNormal = DoozyEditorUtility.GetTexture("b_orange_normal", PathSharedImages) as Texture; return btnOrangeNormal; } }
        public static Texture BtnOrangeActive { get { if (btnOrangeActive == null) btnOrangeActive = DoozyEditorUtility.GetTexture("b_orange_active", PathSharedImages) as Texture; return btnOrangeActive; } }
        public static Texture BtnRedNormal { get { if (btnRedNormal == null) btnRedNormal = DoozyEditorUtility.GetTexture("b_red_normal", PathSharedImages) as Texture; return btnRedNormal; } }
        public static Texture BtnRedActive { get { if (btnRedActive == null) btnRedActive = DoozyEditorUtility.GetTexture("b_red_active", PathSharedImages) as Texture; return btnRedActive; } }
        public static Texture BtnPurpleNormal { get { if (btnPurpleNormal == null) btnPurpleNormal = DoozyEditorUtility.GetTexture("b_purple_normal", PathSharedImages) as Texture; return btnPurpleNormal; } }
        public static Texture BtnPurpleActive { get { if (btnPurpleActive == null) btnPurpleActive = DoozyEditorUtility.GetTexture("b_purple_active", PathSharedImages) as Texture; return btnPurpleActive; } }
        public static Texture BtnGreyLightNormal { get { if (btnGreyLightNormal == null) btnGreyLightNormal = DoozyEditorUtility.GetTexture("b_grey_light_normal", PathSharedImages) as Texture; return btnGreyLightNormal; } }
        public static Texture BtnGreyLightActive { get { if (btnGreyLightActive == null) btnGreyLightActive = DoozyEditorUtility.GetTexture("b_grey_light_active", PathSharedImages) as Texture; return btnGreyLightActive; } }
        public static Texture BtnGreyMildNormal { get { if (btnGreyMildNormal == null) btnGreyMildNormal = DoozyEditorUtility.GetTexture("b_grey_mild_normal", PathSharedImages) as Texture; return btnGreyMildNormal; } }
        public static Texture BtnGreyMildActive { get { if (btnGreyMildActive == null) btnGreyMildActive = DoozyEditorUtility.GetTexture("b_grey_mild_active", PathSharedImages) as Texture; return btnGreyMildActive; } }
        public static Texture BtnGreyDarkNormal { get { if (btnGreyDarkNormal == null) btnGreyDarkNormal = DoozyEditorUtility.GetTexture("b_grey_dark_normal", PathSharedImages) as Texture; return btnGreyDarkNormal; } }
        public static Texture BtnGreyDarkActive { get { if (btnGreyDarkActive == null) btnGreyDarkActive = DoozyEditorUtility.GetTexture("b_grey_dark_active", PathSharedImages) as Texture; return btnGreyDarkActive; } }
        #endregion

        #region Window InfoCards
        //Info UIManager Installed/Not Installed
        private static Texture windowAboutInfoUIManagerInstalled, windowAboutInfoUIManagerNotInstalled;
        public static Texture WindowAboutInfoUIManagerInstalled { get { if (windowAboutInfoUIManagerInstalled == null) windowAboutInfoUIManagerInstalled = DoozyEditorUtility.GetTexture("w_about_info_uimanager_installed", PathSharedImages) as Texture; return windowAboutInfoUIManagerInstalled; } }
        public static Texture WindowAboutInfoUIManagerNotInstalled { get { if (windowAboutInfoUIManagerNotInstalled == null) windowAboutInfoUIManagerNotInstalled = DoozyEditorUtility.GetTexture("w_about_info_uimanager_not_installed", PathSharedImages) as Texture; return windowAboutInfoUIManagerNotInstalled; } }
        //Info UIButton Installed/Not Installed
        private static Texture windowAboutInfoUIButtonInstalled, windowAboutInfoUIButtonNotInstalled;
        public static Texture WindowAboutInfoUIButtonInstalled { get { if (windowAboutInfoUIButtonInstalled == null) windowAboutInfoUIButtonInstalled = DoozyEditorUtility.GetTexture("w_about_info_uibutton_installed", PathSharedImages) as Texture; return windowAboutInfoUIButtonInstalled; } }
        public static Texture WindowAboutInfoUIButtonNotInstalled { get { if (windowAboutInfoUIButtonNotInstalled == null) windowAboutInfoUIButtonNotInstalled = DoozyEditorUtility.GetTexture("w_about_info_uibutton_not_installed", PathSharedImages) as Texture; return windowAboutInfoUIButtonNotInstalled; } }
        //Info UIElement Installed/Not Installed
        private static Texture windowAboutInfoUIElementInstalled, windowAboutInfoUIElementNotInstalled;
        public static Texture WindowAboutInfoUIElementInstalled { get { if (windowAboutInfoUIElementInstalled == null) windowAboutInfoUIElementInstalled = DoozyEditorUtility.GetTexture("w_about_info_uielement_installed", PathSharedImages) as Texture; return windowAboutInfoUIElementInstalled; } }
        public static Texture WindowAboutInfoUIElementNotInstalled { get { if (windowAboutInfoUIElementNotInstalled == null) windowAboutInfoUIElementNotInstalled = DoozyEditorUtility.GetTexture("w_about_info_uielement_not_installed", PathSharedImages) as Texture; return windowAboutInfoUIElementNotInstalled; } }
        //Info OrientationManager Installed/Not Installed
        private static Texture windowAboutInfoOrientationManagerInstalled, windowAboutInfoOrientationManagerNotInstalled;
        public static Texture WindowAboutInfoOrientationManagerInstalled { get { if (windowAboutInfoOrientationManagerInstalled == null) windowAboutInfoOrientationManagerInstalled = DoozyEditorUtility.GetTexture("w_about_info_orientation_manager_installed", PathSharedImages) as Texture; return windowAboutInfoOrientationManagerInstalled; } }
        public static Texture WindowAboutInfoOrientationManagerNotInstalled { get { if (windowAboutInfoOrientationManagerNotInstalled == null) windowAboutInfoOrientationManagerNotInstalled = DoozyEditorUtility.GetTexture("w_about_info_orientation_manager_not_installed", PathSharedImages) as Texture; return windowAboutInfoOrientationManagerNotInstalled; } }
        //Info FontAwesome Installed/Not Installed
        private static Texture windowAboutInfoFontAwesomeInstalled, windowAboutInfoFontAwesomeNotInstalled;
        public static Texture WindowAboutInfoFontAwesomeInstalled { get { if (windowAboutInfoFontAwesomeInstalled == null) windowAboutInfoFontAwesomeInstalled = DoozyEditorUtility.GetTexture("w_about_info_font_awesome_installed", PathSharedImages) as Texture; return windowAboutInfoFontAwesomeInstalled; } }
        public static Texture WindowAboutInfoFontAwesomeNotInstalled { get { if (windowAboutInfoFontAwesomeNotInstalled == null) windowAboutInfoFontAwesomeNotInstalled = DoozyEditorUtility.GetTexture("w_about_info_font_awesome_not_installed", PathSharedImages) as Texture; return windowAboutInfoFontAwesomeNotInstalled; } }
        #endregion

        #region Header Bar 420x18 - Info Disabled/Enabled, Subtitle Bar
        private static Texture mInfoBarDisabled, mInfoBarEnabled;
        public static Texture InfoBarDisabled { get { if (mInfoBarDisabled == null) mInfoBarDisabled = DoozyEditorUtility.GetTexture("h_bar_info_disabled", PathSharedImages) as Texture; return mInfoBarDisabled; } }
        public static Texture InfoBarEnabled { get { if (mInfoBarEnabled == null) mInfoBarEnabled = DoozyEditorUtility.GetTexture("h_bar_info_enabled", PathSharedImages) as Texture; return mInfoBarEnabled; } }
        
        private static Texture mHeaderBarSubtitle;
        public static Texture HeaderBarSubtitle { get { if (mHeaderBarSubtitle == null) mHeaderBarSubtitle = DoozyEditorUtility.GetTexture("h_bar_subtitle", PathSharedImages) as Texture;  return mHeaderBarSubtitle; } }
        #endregion
    }
}
