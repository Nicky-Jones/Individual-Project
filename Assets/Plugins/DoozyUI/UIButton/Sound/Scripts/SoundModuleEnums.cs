// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

namespace DoozyUI.UIButton.Sound
{
    public partial class SoundModule
    {
        /// <summary>
        /// Holds the sound source types
        /// </summary>
        public enum SoundSource
        {
            /// <summary>
            /// The source is a sound filename (without the extension .wav or .mp3 or any other sound format). Note that the file should be located under a Resources folder
            /// </summary>
            String,
            /// <summary>
            /// The source is a reference to a sound clip
            /// </summary>
            AudioClip
        }
    }
}
