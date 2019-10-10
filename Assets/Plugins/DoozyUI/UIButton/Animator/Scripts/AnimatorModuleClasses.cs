// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using DG.Tweening;
using System;
using UnityEngine;

namespace DoozyUI.UIButton.Animator
{
    public partial class AnimatorModule
    {
        /// <summary>
        /// Punches a RectTransform's anchoredPosition towards the given direction and then back to the starting one as if it was connected to the starting position via an elastic
        /// </summary>
        [Serializable]
        public class PunchMove
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// The direction and strength of the punch (added to the Transform's current position)
            /// </summary>
            public Vector3 punch = new Vector3(0, 20, 0);
            /// <summary>
            /// If TRUE the tween will smoothly snap all values to integers (default:false)
            /// </summary>
            public bool snapping = false;
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Indicates how much will the punch vibrate
            /// </summary>
            public int vibrato = 4;
            /// <summary>
            /// Represents how much (0 to 1) the vector will go beyond the starting position when bouncing backwards. 1 creates a full oscillation between the punch direction and the opposite direction, while 0 oscillates only between the punch and the start position
            /// </summary>
            public float elasticity = 0.5f;
        }

        /// <summary>
        /// Punches a Transform's localRotation towards the given size and then back to the starting one as if it was connected to the starting rotation via an elastic
        /// </summary>
        [Serializable]
        public class PunchRotate
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// The direction and strength of the punch (added to the Transform's current rotation)
            /// </summary>
            public Vector3 punch = new Vector3(0, 0, 30);
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Indicates how much will the punch vibrate
            /// </summary>
            public int vibrato = 4;
            /// <summary>
            /// Represents how much (0 to 1) the vector will go beyond the starting rotation when bouncing backwards. 1 creates a full oscillation between the punch rotation and the opposite rotation, while 0 oscillates only between the punch and the start rotation
            /// </summary>
            public float elasticity = 0.5f;
        }

        /// <summary>
        /// Punches a Transform's localScale towards the given size and then back to the starting one as if it was connected to the starting scale via an elastic
        /// </summary>
        [Serializable]
        public class PunchScale
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// The punch strength (added to the Transform's current scale)
            /// </summary>
            public Vector3 punch = new Vector3(0.2f, 0.2f, 0);
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Indicates how much will the punch vibrate
            /// </summary>
            public int vibrato = 4;
            /// <summary>
            /// Represents how much (0 to 1) the vector will go beyond the starting size when bouncing backwards. 1 creates a full oscillation between the punch scale and the opposite scale, while 0 oscillates only between the punch scale and the start scale
            /// </summary>
            public float elasticity = 0.5f;
        }

        /// <summary>
        /// Animation settings for Movement
        /// </summary>
        [Serializable]
        public class Move
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// Target position
            /// </summary>
            public Vector3 to = new Vector3(0, 20, 0);
            /// <summary>
            /// If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly) (default:true)
            /// </summary>
            public bool relative = true;
            /// <summary>
            /// If TRUE the tween will smoothly snap all values to integers
            /// </summary>
            public bool snapping = false;
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Sets the ease of the tween. Easing functions specify the rate of change of a parameter over time.
            /// <para>To see how default ease curves look, check out easings.net</para>
            /// </summary>
            public Ease ease = Ease.Linear;
            /// <summary>
            /// Should there be another tween that reverts to the initial values
            /// </summary>
            public bool reverseAfterTime = false;
            /// <summary>
            /// The duration of the reverse tween
            /// </summary>
            public float reverseDuration = 0.2f;
            /// <summary>
            /// Start delay for the revese tween
            /// </summary>
            public float reverseDelay = 0.2f;
            /// <summary>
            /// The ease of the reverse tween
            /// </summary>
            public Ease reverseEase = Ease.Linear;
        }

        /// <summary>
        /// Animation settings for Rotation
        /// </summary>
        [Serializable]
        public class Rotate
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// Target rotation
            /// </summary>
            public Vector3 to = new Vector3(0, 0, 30);
            /// <summary>
            /// If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly) (default:true)
            /// </summary>
            public bool relative = true;
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Sets the ease of the tween. Easing functions specify the rate of change of a parameter over time.
            /// <para>To see how default ease curves look, check out easings.net</para>
            /// </summary>
            public Ease ease = Ease.Linear;
            /// <summary>
            /// Should there be another tween that reverts to the initial values
            /// </summary>
            public bool reverseAfterTime = false;
            /// <summary>
            /// The duration of the reverse tween
            /// </summary>
            public float reverseDuration = 0.2f;
            /// <summary>
            /// Start delay for the revese tween
            /// </summary>
            public float reverseDelay = 0.2f;
            /// <summary>
            /// The ease of the reverse tween
            /// </summary>
            public Ease reverseEase = Ease.Linear;
        }

        /// <summary>
        /// Animation settings for Scale
        /// </summary>
        [Serializable]
        public class Scale
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// Target scale
            /// </summary>
            public Vector3 to = new Vector3(0.2f, 0.2f, 1f);
            /// <summary>
            /// If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly) (default:true)
            /// </summary>
            public bool relative = true;
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Sets the ease of the tween. Easing functions specify the rate of change of a parameter over time.
            /// <para>To see how default ease curves look, check out easings.net</para>
            /// </summary>
            public Ease ease = Ease.Linear;
            /// <summary>
            /// Should there be another tween that reverts to the initial values
            /// </summary>
            public bool reverseAfterTime = false;
            /// <summary>
            /// The duration of the reverse tween
            /// </summary>
            public float reverseDuration = 0.2f;
            /// <summary>
            /// Start delay for the revese tween
            /// </summary>
            public float reverseDelay = 0.2f;
            /// <summary>
            /// The ease of the reverse tween
            /// </summary>
            public Ease reverseEase = Ease.Linear;
        }

        /// <summary>
        /// Animation settings for Fade (alpha value)
        /// </summary>
        [Serializable]
        public class Fade
        {
            /// <summary>
            /// If TRUE, this animation will get executed by the Animator when triggered, FALSE otherwise (default:false)
            /// </summary>
            public bool enabled = false;
            /// <summary>
            /// Target fade (alpha value)
            /// </summary>
            public bool relative = false;
            /// <summary>
            /// If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly) (default:false)
            /// </summary>
            public float to = 0.5f;
            /// <summary>
            /// The duration of the tween
            /// </summary>
            public float duration = 0.2f;
            /// <summary>
            /// Start delay for the tween
            /// </summary>
            public float delay = 0f;
            /// <summary>
            /// Sets the ease of the tween. Easing functions specify the rate of change of a parameter over time.
            /// <para>To see how default ease curves look, check out easings.net</para>
            /// </summary>
            public Ease ease = Ease.Linear;
            /// <summary>
            /// Should there be another tween that reverts to the initial values
            /// </summary>
            public bool reverseAfterTime = false;
            /// <summary>
            /// The duration of the reverse tween
            /// </summary>
            public float reverseDuration = 0.2f;
            /// <summary>
            /// Start delay for the revese tween
            /// </summary>
            public float reverseDelay = 0.2f;
            /// <summary>
            /// The ease of the reverse tween
            /// </summary>
            public Ease reverseEase = Ease.Linear;
        }
    }
}
