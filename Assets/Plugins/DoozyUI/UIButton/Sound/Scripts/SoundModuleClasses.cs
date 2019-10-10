// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;

namespace DoozyUI.UIButton.Sound
{
    public partial class SoundModule
    {
        [Serializable]
        public class Sound
        {
            /// <summary>
            /// A sound filename (without the extension .wav or .mp3 or any other sound format). Note that the file should be located under a Resources folder
            /// </summary>
            public string soundName;
            /// <summary>
            /// Reference to a sound clip
            /// </summary>
            public AudioClip audioClip;
        }
    }
}
