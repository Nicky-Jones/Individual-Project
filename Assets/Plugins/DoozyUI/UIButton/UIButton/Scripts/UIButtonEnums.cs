// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

namespace DoozyUI.UIButton
{
    public partial class UIButton
    {
        /// <summary>
        /// Setting for the OnClick trigger that marks if it should be registered instantly without checking if it's a double click or not.
        /// </summary>
        public enum SingleClickMode
        {
            /// <summary>
            /// The click will get registered instantly without checking if it's a double click or not. 
            /// <para>This is the normal behaviour of a single click in any OS.</para>
            /// <para>Use this if you want to make sure a single click will get executed before a double click (dual actions).</para>
            /// <para>(usage example: SingleClick - selects, DoubleClick - executes an action)</para>
            /// </summary>
            Instant,
            /// <summary>
            /// The click will get registered after checking if it's a double click or not.
            /// <para>If it's a double click, the single click will not get triggered.</para>
            /// <para>Use this if you want to make sure the user does not execute a single click before a double click.</para>
            /// <para>The donwside is that there is a delay when executing the single click (the delay is the doulbe click register interval), so make sure you take that into account</para>
            /// </summary>
            Delayed
        }

        /// <summary>
        /// Used by the UIButton's modules (Animator, Sound, Effect) to set the trigger type that the module reacts to
        /// </summary>
        public enum ReactTo { OnHoverEnter, OnHoverExit, OnPointerDown, OnPointerUp, OnClick, OnDoubleClick, OnLongClick }
    }
}
