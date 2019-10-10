// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using UnityEngine;

namespace DoozyUI.UIButton
{
    public class UIButtonStyle
    {
        public enum StyleName
        {
            BtnPunchMoveEnabled,
            BtnPunchMoveDisabled,
            BtnPunchRotateEnabled,
            BtnPunchRotateDisabled,
            BtnPunchScaleEnabled,
            BtnPunchScaleDisabled,
            BtnMoveEnabled,
            BtnMoveDisabled,
            BtnRotateEnabled,
            BtnRotateDisabled,
            BtnScaleEnabled,
            BtnScaleDisabled,
            BtnFadeEnabled,
            BtnFadeDisabled
        }

        private static GUISkin darkSkin = null;
        public static GUISkin DarkSkin { get { if (darkSkin == null) darkSkin = GetDarkSkin(); return darkSkin; } }
        private static GUISkin lightSkin = null;
        public static GUISkin LightSkin { get { if (lightSkin == null) lightSkin = GetLightSkin(); return lightSkin; } }

        private static GUISkin GetDarkSkin()
        {
            GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
            List<GUIStyle> styles = new List<GUIStyle>();

            //PunchMove
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchMoveEnabled, DoozyResources.Btn420x18NormalPunchMoveEnabled, DoozyResources.Btn420x18ActivePunchMoveEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchMoveDisabled, DoozyResources.Btn420x18NormalPunchMoveDisabled, DoozyResources.Btn420x18ActivePunchMoveDisabled));
            //PunchRotate
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchRotateEnabled, DoozyResources.Btn420x18NormalPunchRotateEnabled, DoozyResources.Btn420x18ActivePunchRotateEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchRotateDisabled, DoozyResources.Btn420x18NormalPunchRotateDisabled, DoozyResources.Btn420x18ActivePunchRotateDisabled));
            //PunchScale
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchScaleEnabled, DoozyResources.Btn420x18NormalPunchScaleEnabled, DoozyResources.Btn420x18ActivePunchScaleEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchScaleDisabled, DoozyResources.Btn420x18NormalPunchScaleDisabled, DoozyResources.Btn420x18ActivePunchScaleDisabled));
            //Move
            styles.Add(GetStyle_RegionButton(StyleName.BtnMoveEnabled, DoozyResources.Btn420x18NormalMoveEnabled, DoozyResources.Btn420x18ActiveMoveEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnMoveDisabled, DoozyResources.Btn420x18NormalMoveDisabled, DoozyResources.Btn420x18ActiveMoveDisabled));
            //Rotate
            styles.Add(GetStyle_RegionButton(StyleName.BtnRotateEnabled, DoozyResources.Btn420x18NormalRotateEnabled, DoozyResources.Btn420x18ActiveRotateEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnRotateDisabled, DoozyResources.Btn420x18NormalRotateDisabled, DoozyResources.Btn420x18ActiveRotateDisabled));
            //Scale
            styles.Add(GetStyle_RegionButton(StyleName.BtnScaleEnabled, DoozyResources.Btn420x18NormalScaleEnabled, DoozyResources.Btn420x18ActiveScaleEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnScaleDisabled, DoozyResources.Btn420x18NormalScaleDisabled, DoozyResources.Btn420x18ActiveScaleDisabled));
            //Fade
            styles.Add(GetStyle_RegionButton(StyleName.BtnFadeEnabled, DoozyResources.Btn420x18NormalFadeEnabled, DoozyResources.Btn420x18ActiveFadeEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnFadeDisabled, DoozyResources.Btn420x18NormalFadeDisabled, DoozyResources.Btn420x18ActiveFadeDisabled));

            skin.customStyles = styles.ToArray();
            return skin;
        }

        private static GUISkin GetLightSkin()
        {
            GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
            List<GUIStyle> styles = new List<GUIStyle>();

            //PunchMove
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchMoveEnabled, DoozyResources.Btn420x18NormalPunchMoveEnabled, DoozyResources.Btn420x18ActivePunchMoveEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchMoveDisabled, DoozyResources.Btn420x18NormalPunchMoveDisabled, DoozyResources.Btn420x18ActivePunchMoveDisabled));
            //PunchRotate
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchRotateEnabled, DoozyResources.Btn420x18NormalPunchRotateEnabled, DoozyResources.Btn420x18ActivePunchRotateEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchRotateDisabled, DoozyResources.Btn420x18NormalPunchRotateDisabled, DoozyResources.Btn420x18ActivePunchRotateDisabled));
            //PunchScale
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchScaleEnabled, DoozyResources.Btn420x18NormalPunchScaleEnabled, DoozyResources.Btn420x18ActivePunchScaleEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnPunchScaleDisabled, DoozyResources.Btn420x18NormalPunchScaleDisabled, DoozyResources.Btn420x18ActivePunchScaleDisabled));
            //Move
            styles.Add(GetStyle_RegionButton(StyleName.BtnMoveEnabled, DoozyResources.Btn420x18NormalMoveEnabled, DoozyResources.Btn420x18ActiveMoveEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnMoveDisabled, DoozyResources.Btn420x18NormalMoveDisabled, DoozyResources.Btn420x18ActiveMoveDisabled));
            //Rotate
            styles.Add(GetStyle_RegionButton(StyleName.BtnRotateEnabled, DoozyResources.Btn420x18NormalRotateEnabled, DoozyResources.Btn420x18ActiveRotateEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnRotateDisabled, DoozyResources.Btn420x18NormalRotateDisabled, DoozyResources.Btn420x18ActiveRotateDisabled));
            //Scale
            styles.Add(GetStyle_RegionButton(StyleName.BtnScaleEnabled, DoozyResources.Btn420x18NormalScaleEnabled, DoozyResources.Btn420x18ActiveScaleEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnScaleDisabled, DoozyResources.Btn420x18NormalScaleDisabled, DoozyResources.Btn420x18ActiveScaleDisabled));
            //Fade
            styles.Add(GetStyle_RegionButton(StyleName.BtnFadeEnabled, DoozyResources.Btn420x18NormalFadeEnabled, DoozyResources.Btn420x18ActiveFadeEnabled));
            styles.Add(GetStyle_RegionButton(StyleName.BtnFadeDisabled, DoozyResources.Btn420x18NormalFadeDisabled, DoozyResources.Btn420x18ActiveFadeDisabled));

            skin.customStyles = styles.ToArray();
            return skin;
        }

        private static GUIStyle GetStyle_RegionButton(StyleName stylename, Texture nBackground, Texture aBackground, float fixedWidth = 420f, float fixedHeight = 18f)
        {
            return new GUIStyle
            {
                name = stylename.ToString(),
                normal =
                {
                    background = (Texture2D) nBackground
                },
                active =
                {
                    background = (Texture2D) aBackground
                },
                fixedWidth = fixedWidth,
                fixedHeight = fixedHeight
            };
        }
    }
}