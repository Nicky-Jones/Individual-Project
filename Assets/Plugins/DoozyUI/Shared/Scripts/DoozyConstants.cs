// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

namespace DoozyUI
{
    public static partial class DoozyConstants
    {
        #region SYMBOLS, DOWNLOAD LINKS & BOOLS
        public const string SYMBOL_UIMANAGER = "dUI_MANAGER";
        public const string LINK_UIMANAGER = "";
#if dUI_MANAGER
        public static bool dUI_MANAGER = true;
#else
        public static bool dUI_MANAGER = false;
#endif

        public const string SYMBOL_UIBUTTON = "dUI_BUTTON";
        public const string LINK_UIBUTTON = "http://u3d.as/CKp";
#if dUI_BUTTON
        public static bool dUI_BUTTON = true;
#else
        public static bool dUI_BUTTON = false;
#endif

        public const string SYMBOL_UIELEMENT = "dUI_ELEMENT";
        public const string LINK_UIELEMENT = "";
#if dUI_ELEMENT
        public static bool dUI_ELEMENT = true;
#else
        public static bool dUI_ELEMENT = false;
#endif

        public const string SYMBOL_ORIENTATION_MANAGER = "dUI_ORIENTATION_MANAGER";
        public const string LINK_ORIENTATION_MANAGER = "";
#if dUI_ORIENTATION_MANAGER
        public static bool dUI_ORIENTATION_MANAGER = true;
#else
        public static bool dUI_ORIENTATION_MANAGER = false;
#endif

        public const string SYMBOL_FONT_AWESOME = "dUI_FONT_AWESOME";
        public const string LINK_FONT_AWESOME = "";
#if dUI_FONT_AWESOME
        public static bool dUI_FONT_AWESOME = true;
#else
        public static bool dUI_FONT_AWESOME = false;
#endif

        public const string SYMBOL_PLAYMAKER = "dUI_PLAYMAKER";
#if dUI_PLAYMAKER
        public static bool dUI_PLAYMAKER = true;
#else
        public static bool dUI_PLAYMAKER = false;
#endif

        public const string SYMBOL_NODE_CANVAS = "dUI_NODE_CANVAS";
#if dUI_NODE_CANVAS
        public static bool dUI_NODE_CANVAS = true;
#else
        public static bool dUI_NODE_CANVAS = false;
#endif
        #endregion

        public const string COPYRIGHT = "Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved";

        public const string TXT_IS_ENABLED = " is enabled!";
        public const string TXT_IS_DISABLED = " is disabled!";
    }
}
