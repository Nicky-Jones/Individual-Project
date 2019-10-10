// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using DG.Tweening;
using System;
using UnityEngine;

namespace DoozyUI.UIButton.Animator
{
    [Serializable]
    public class AnimatorPreset
    {
        //PunchMove
        public bool pm_enabled = false;
        public float pm_punch_x = 0;
        public float pm_punch_y = 20;
        public float pm_punch_z = 0;
        public bool pm_snapping = false;                   
        public float pm_duration = 0.2f;                  
        public float pm_delay = 0f;
        public int pm_vibrato = 4;
        public float pm_elasticity = 0.5f;

        //PunchRotate
        public bool pr_enabled = false;
        public float pr_punch_x = 0;
        public float pr_punch_y = 0;
        public float pr_punch_z = 30;
        public float pr_duration = 0.2f;
        public float pr_delay = 0f;
        public int pr_vibrato = 4;
        public float pr_elasticity = 0.5f;

        //PunchScale
        public bool ps_enabled = false;
        public float ps_punch_x = 0.2f;
        public float ps_punch_y = 0.2f;
        public float ps_punch_z = 0;
        public float ps_duration = 0.2f;
        public float ps_delay = 0f;
        public int ps_vibrato = 4;
        public float ps_elasticity = 0.5f;

        //Move
        public bool m_enabled = false;
        public float m_to_x = 0;
        public float m_to_y = 20;
        public float m_to_z = 0;
        public bool m_relative = true;
        public bool m_snapping = false;
        public float m_duration = 0.2f;
        public float m_delay = 0f;
        public Ease m_ease = Ease.Linear;
        public bool m_reverseAfterTime = false;
        public float m_reverseDuration = 0.2f;
        public float m_reverseDelay = 0.2f;
        public Ease m_reverseEase = Ease.Linear;

        //Rotate
        public bool r_enabled = false;
        public float r_to_x = 0;
        public float r_to_y = 0;
        public float r_to_z = 30;
        public bool r_relative = true;
        public float r_duration = 0.2f;
        public float r_delay = 0f;
        public Ease r_ease = Ease.Linear;
        public bool r_reverseAfterTime = false;
        public float r_reverseDuration = 0.2f;
        public float r_reverseDelay = 0.2f;
        public Ease r_reverseEase = Ease.Linear;

        //Scale
        public bool s_enabled = false;
        public float s_to_x = 0.2f;
        public float s_to_y = 0.2f;
        public float s_to_z = 1f;
        public bool s_relative = true;
        public float s_duration = 0.2f;
        public float s_delay = 0f;
        public Ease s_ease = Ease.Linear;
        public bool s_reverseAfterTime = false;
        public float s_reverseDuration = 0.2f;
        public float s_reverseDelay = 0.2f;
        public Ease s_reverseEase = Ease.Linear;

        //Fade
        public bool f_enabled = false;
        public float f_to = 0.5f;
        public bool f_relative = true;
        public float f_duration = 0.2f;
        public float f_delay = 0f;
        public Ease f_ease = Ease.Linear;
        public bool f_reverseAfterTime = false;
        public float f_reverseDuration = 0.2f;
        public float f_reverseDelay = 0.2f;
        public Ease f_reverseEase = Ease.Linear;
    }
}
