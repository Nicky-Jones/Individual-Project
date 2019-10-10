using System.Collections.Generic;
using UnityEngine;

namespace DoozyUI
{
    public static class DoozyStyle
    {
        public enum StyleName
        {
            Version,
            Copyright,
            HelpBox,
            BtnBlue,
            BtnGreen,
            BtnOrange,
            BtnRed,
            BtnPurple,
            BtnGreyLight,
            BtnGreyMild,
            BtnGreyDark,
            LabelMidLeft,
            LabelMidCenter,
            LabelMidRight,
            HeaderSubtitle
        }

        private static GUISkin darkSkin = null;
        public static GUISkin DarkSkin { get { if (darkSkin == null) darkSkin = GetDarkSkin(); return darkSkin; } }
        private static GUISkin lightSkin = null;
        public static GUISkin LightSkin { get { if (lightSkin == null) lightSkin = GetLightSkin(); return lightSkin; } }

        private static GUISkin GetDarkSkin()
        {
            GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
            List<GUIStyle> styles = new List<GUIStyle>();


            styles.Add(GetStyle_Version(StyleName.Version, DoozyColors.UNITY_LIGHT, 10, FontStyle.Normal, TextAnchor.MiddleLeft));
            styles.Add(GetStyle_Copyright(StyleName.Copyright, DoozyColors.UNITY_LIGHT, 10, FontStyle.Normal, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_HelpBox(StyleName.HelpBox, DoozyResources.HelpBoxDark, DoozyColors.UNITY_LIGHT, 9, FontStyle.Italic, true, true));

            styles.Add(GetStyle_Button(StyleName.BtnBlue, DoozyResources.BtnBlueNormal, DoozyColors.L_BLUE, DoozyResources.BtnBlueActive, DoozyColors.BLUE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreen, DoozyResources.BtnGreenNormal, DoozyColors.L_GREEN, DoozyResources.BtnGreenActive, DoozyColors.GREEN, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnOrange, DoozyResources.BtnOrangeNormal, DoozyColors.L_ORANGE, DoozyResources.BtnOrangeActive, DoozyColors.ORANGE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnRed, DoozyResources.BtnRedNormal, DoozyColors.L_RED, DoozyResources.BtnRedActive, DoozyColors.RED, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnPurple, DoozyResources.BtnPurpleNormal, DoozyColors.L_PURPLE, DoozyResources.BtnPurpleActive, DoozyColors.PURPLE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyLight, DoozyResources.BtnGreyLightNormal, DoozyColors.UNITY_DARK, DoozyResources.BtnGreyLightActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyMild, DoozyResources.BtnGreyMildNormal, DoozyColors.UNITY_LIGHT, DoozyResources.BtnGreyMildActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyDark, DoozyResources.BtnGreyDarkNormal, DoozyColors.UNITY_LIGHT, DoozyResources.BtnGreyDarkActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));

            styles.Add(GetStyle_Label(StyleName.LabelMidLeft, DoozyColors.UNITY_LIGHT, TextAnchor.MiddleLeft));
            styles.Add(GetStyle_Label(StyleName.LabelMidCenter, DoozyColors.UNITY_LIGHT, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Label(StyleName.LabelMidRight, DoozyColors.UNITY_LIGHT, TextAnchor.MiddleRight));

            styles.Add(GetStyle_HeaderSubtitle(StyleName.HeaderSubtitle, DoozyColors.BLUE, 11, FontStyle.Normal, TextAnchor.MiddleLeft));

            skin.customStyles = styles.ToArray();
            return skin;
        }
      
        private static GUISkin GetLightSkin()
        {
            GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
            List<GUIStyle> styles = new List<GUIStyle>();

            styles.Add(GetStyle_Version(StyleName.Version, DoozyColors.UNITY_LIGHT, 10, FontStyle.Normal, TextAnchor.MiddleLeft));
            styles.Add(GetStyle_Copyright(StyleName.Copyright, DoozyColors.UNITY_LIGHT, 10, FontStyle.Normal, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_HelpBox(StyleName.HelpBox, DoozyResources.HelpBoxLight, DoozyColors.UNITY_DARK, 9, FontStyle.Italic, true, true));

            styles.Add(GetStyle_Button(StyleName.BtnBlue, DoozyResources.BtnBlueNormal, DoozyColors.L_BLUE, DoozyResources.BtnBlueActive, DoozyColors.BLUE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreen, DoozyResources.BtnGreenNormal, DoozyColors.L_GREEN, DoozyResources.BtnGreenActive, DoozyColors.GREEN, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnOrange, DoozyResources.BtnOrangeNormal, DoozyColors.L_ORANGE, DoozyResources.BtnOrangeActive, DoozyColors.ORANGE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnRed, DoozyResources.BtnRedNormal, DoozyColors.L_RED, DoozyResources.BtnRedActive, DoozyColors.RED, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnPurple, DoozyResources.BtnPurpleNormal, DoozyColors.L_PURPLE, DoozyResources.BtnPurpleActive, DoozyColors.PURPLE, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyLight, DoozyResources.BtnGreyLightNormal, DoozyColors.UNITY_DARK, DoozyResources.BtnGreyLightActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyMild, DoozyResources.BtnGreyMildNormal, DoozyColors.UNITY_LIGHT, DoozyResources.BtnGreyMildActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Button(StyleName.BtnGreyDark, DoozyResources.BtnGreyDarkNormal, DoozyColors.UNITY_LIGHT, DoozyResources.BtnGreyDarkActive, DoozyColors.UNITY_MILD, 10, FontStyle.Bold, TextAnchor.MiddleCenter));

            styles.Add(GetStyle_Label(StyleName.LabelMidLeft, DoozyColors.UNITY_DARK, TextAnchor.MiddleLeft));
            styles.Add(GetStyle_Label(StyleName.LabelMidCenter, DoozyColors.UNITY_DARK, TextAnchor.MiddleCenter));
            styles.Add(GetStyle_Label(StyleName.LabelMidRight, DoozyColors.UNITY_DARK, TextAnchor.MiddleRight));

            styles.Add(GetStyle_HeaderSubtitle(StyleName.HeaderSubtitle, DoozyColors.BLUE, 11, FontStyle.Normal, TextAnchor.MiddleLeft));

            skin.customStyles = styles.ToArray();
            return skin;
        }

        private static GUIStyle GetStyle_Version(StyleName styleName, Color nTextColor, int fontSize = 10, FontStyle fontStyle = FontStyle.Normal, TextAnchor alignment = TextAnchor.MiddleLeft)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal =
                {
                    textColor = nTextColor
                },
                font = DoozyResources.FontLuckiestGuy,
                fontSize = fontSize,
                fontStyle = fontStyle,
                alignment = alignment
            };
        }
        private static GUIStyle GetStyle_Copyright(StyleName styleName, Color nTextColor, int fontSize = 10, FontStyle fontStyle = FontStyle.Normal, TextAnchor alignment = TextAnchor.MiddleCenter)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal =
                {
                    textColor = nTextColor
                },
                font = DoozyResources.FontLuckiestGuy,
                fontSize = fontSize,
                fontStyle = fontStyle,
                alignment = alignment
            };
        }
        private static GUIStyle GetStyle_HelpBox(StyleName styleName, Texture2D nBackground, Color nTextColor, int fontSize = 9, FontStyle fontStyle = FontStyle.Italic, bool richText = true, bool wordWrap = true)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal =
                {
                    background = nBackground,
                    textColor = nTextColor
                },
                fontSize = fontSize,
                fontStyle = fontStyle,
                richText = richText,
                wordWrap = wordWrap,
                padding = new RectOffset(8, 8, 8, 8),
                border = new RectOffset(2, 2, 2, 2)
            };
        }
        private static GUIStyle GetStyle_Button(StyleName styleName, Texture nBackground, Color nTextColor, Texture aBackground, Color aTextColor, int fontSize = 10, FontStyle fontStyle = FontStyle.Bold, TextAnchor alignment = TextAnchor.MiddleCenter)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal =
                {
                    background = (Texture2D) nBackground,
                    textColor = nTextColor
                },
                active =
                {
                    background = (Texture2D) aBackground,
                    textColor = aTextColor
                },
                fontSize = fontSize,
                fontStyle = fontStyle,
                alignment = alignment,
                padding = new RectOffset(2, 2, 1, 2),
                border = new RectOffset(4, 4, 4, 4),
                margin = new RectOffset(1, 1, 1, 1)
            };
        }
        private static GUIStyle GetStyle_Label(StyleName styleName, Color nTextColor, TextAnchor alignment)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal = { textColor = nTextColor },
                alignment = alignment
            };
        }
        private static GUIStyle GetStyle_HeaderSubtitle(StyleName styleName, Color nTextColor, int fontSize = 11, FontStyle fontStyle = FontStyle.Bold, TextAnchor alignment = TextAnchor.UpperLeft)
        {
            return new GUIStyle
            {
                name = styleName.ToString(),
                normal =
                {
                    textColor = nTextColor
                },
                font = DoozyResources.FontLuckiestGuy,
                fontSize = fontSize,
                fontStyle = fontStyle,
                alignment = alignment
            };
        }

    }
}
