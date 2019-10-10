// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton.Effect
{
    public partial class EffectModule
    {
        /// <summary>
        /// Prints to Debug.Log all the relevant functionality informations needed for debug purposes
        /// </summary>
        public bool debugThis = false;

        /// <summary>
        /// Selects the UIButton's trigger that this module reacts to.
        /// <para>You should not change this in code as you might break the UIButton</para>
        /// </summary>
        public UIButton.ReactTo reactTo = UIButton.ReactTo.OnClick;

        /// <summary>
        /// Reference the Particle System you would like to be affected by this module
        /// </summary>
        public ParticleSystem pSystem = null;
        /// <summary>
        /// Select the action this module should execute -play-, -stop- or emit a -burst- of particles on trigger
        /// </summary>
        public EffectAction effectAction = EffectAction.Play;
        /// <summary>
        /// If TRUE, the particles will dissapear instantly on -stop- otherwise they will dissapear after lifetime (default:false)
        /// </summary>
        public bool clearOnStop = false;
        /// <summary>
        /// If TRUE it will also trigger the child particle systems under the main one (default:true)
        /// </summary>
        public bool withChildren = true;
        /// <summary>
        /// The number of particles that should be emitted on a -burst-
        /// </summary>
        public int emitCount = 32;
        /// <summary>
        /// Set the particle system's sorting layer the same as the UIButton's
        /// </summary>
        public OverrideSortingLayer overrideSortingLayer = OverrideSortingLayer.Yes;
        /// <summary>
        /// Change the particle system's order in layer with the specified number of steps
        /// </summary>
        public OverrideSortingOrder overrideSortingOrder = OverrideSortingOrder.Yes;
        /// <summary>
        /// In Front (+) or Behind (-) of the UIButton with the set number of steps
        /// </summary>
        public ResetSortingOrderToBe resetSortingOrderToBe = ResetSortingOrderToBe.InFront;
        /// <summary>
        /// The number of steps that the sorting order should be changed to depending on the direction (In Front (+) or Behind (-) )
        /// </summary>
        public int orderInLayerSteps = 1;

        private RectTransform rectTransfrom;
        /// <summary>
        /// Reference to the RectTransform component of this UIButton
        /// </summary>
        public RectTransform GetRectTransform { get { if (rectTransfrom == null) rectTransfrom = GetComponent<RectTransform>(); return rectTransfrom; } }

        private UIButton uiButton;
        /// <summary>
        /// Reference of the UIButton component that this module reacts to
        /// </summary>
        public UIButton GetUIButton { get { if (uiButton == null) uiButton = GetComponent<UIButton>(); return uiButton; } }

        private Canvas referenceCanvas;
        private ParticleSystemRenderer particleSystemRenderer;
        private bool stopAfterBurst = false;

        /// <summary>
        /// Returns TRUE it this module will get triggered by the UIButton and FALSE otherwise
        /// </summary>
        public bool IsEffectModuleEnabled
        {
            get
            {
                switch (reactTo)
                {
                    case UIButton.ReactTo.OnHoverEnter: return GetUIButton.useOnHoverEnter;
                    case UIButton.ReactTo.OnHoverExit: return GetUIButton.useOnHoverExit;
                    case UIButton.ReactTo.OnPointerDown: return GetUIButton.useOnPointerDown;
                    case UIButton.ReactTo.OnPointerUp: return GetUIButton.useOnPointerUp;
                    case UIButton.ReactTo.OnClick: return GetUIButton.useOnClick;
                    case UIButton.ReactTo.OnDoubleClick: return GetUIButton.useOnDoubleClick;
                    case UIButton.ReactTo.OnLongClick: return GetUIButton.useOnLongClick;
                    default: return false;
                }
            }
        }
    }
}
