// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace DoozyUI.UIButton.Effect
{
    public partial class EffectModule : MonoBehaviour
    {
        void Reset()
        {
            if (GetUIButton.onHoverEnterEffectModule == this) reactTo = UIButton.ReactTo.OnHoverEnter;
            else if (GetUIButton.onHoverExitEffectModule == this) reactTo = UIButton.ReactTo.OnHoverExit;
            else if (GetUIButton.onPointerDownEffectModule == this) reactTo = UIButton.ReactTo.OnPointerDown;
            else if (GetUIButton.onPointerUpEffectModule == this) reactTo = UIButton.ReactTo.OnPointerUp;
            else if (GetUIButton.onClickEffectModule == this) reactTo = UIButton.ReactTo.OnClick;
            else if (GetUIButton.onDoubleClickEffectModule == this) reactTo = UIButton.ReactTo.OnDoubleClick;
            else if (GetUIButton.onLongClickEffectModule == this) reactTo = UIButton.ReactTo.OnLongClick;
        }

        void Awake()
        {
            if (pSystem == null)
            {
                Debug.Log(name + " - UIButton.Effect - Reacts to " + reactTo.ToString() + " - There is no ParticleSystem referenced to the partycleSystem variable. In order for the EffectModule to work you should reference a ParticleSystem. This component has been disabled.");
                enabled = false;
                return;
            }

            Init();
        }

        void OnEnable()
        {
            AddListeners();
        }

        void OnDisable()
        {
            RemoveListeners();
        }

        private void Init()
        {
            referenceCanvas = GetUIButton.GetComponentInParent<Canvas>();
            particleSystemRenderer = pSystem.GetComponent<ParticleSystemRenderer>();
            if (overrideSortingLayer == OverrideSortingLayer.Yes)
            {
                particleSystemRenderer.sortingLayerName = referenceCanvas.sortingLayerName;
            }
            if (overrideSortingOrder == OverrideSortingOrder.Yes)
            {
                if (orderInLayerSteps < 0)
                    orderInLayerSteps = 1;

                if (resetSortingOrderToBe == ResetSortingOrderToBe.InFront)
                {
                    particleSystemRenderer.sortingOrder = referenceCanvas.sortingOrder + orderInLayerSteps;
                }
                else
                {
                    particleSystemRenderer.sortingOrder = referenceCanvas.sortingOrder - orderInLayerSteps;
                }
            }
        }

        private void AddListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnHoverEnter.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnHoverEnter.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnHoverEnter.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnHoverExit:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnHoverExit.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnHoverExit.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnHoverExit.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnPointerDown:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnPointerDown.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnPointerDown.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnPointerDown.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnPointerUp:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnPointerUp.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnPointerUp.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnPointerUp.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnClick.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnClick.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnClick.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnDoubleClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnDoubleClick.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnDoubleClick.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnDoubleClick.AddListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnLongClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnLongClick.AddListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnLongClick.AddListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnLongClick.AddListener(ExecuteBurst); break;
                    }
                    break;
            }
        }

        private void RemoveListeners()
        {
            switch (reactTo)
            {
                case UIButton.ReactTo.OnHoverEnter:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnHoverEnter.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnHoverEnter.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnHoverEnter.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnHoverExit:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnHoverExit.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnHoverExit.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnHoverExit.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnPointerDown:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnPointerDown.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnPointerDown.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnPointerDown.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnPointerUp:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnPointerUp.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnPointerUp.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnPointerUp.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnClick.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnClick.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnClick.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnDoubleClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnDoubleClick.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnDoubleClick.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnDoubleClick.RemoveListener(ExecuteBurst); break;
                    }
                    break;
                case UIButton.ReactTo.OnLongClick:
                    switch (effectAction)
                    {
                        case EffectAction.Play: GetUIButton.OnLongClick.RemoveListener(ExecutePlay); break;
                        case EffectAction.Stop: GetUIButton.OnLongClick.RemoveListener(ExecuteStop); break;
                        case EffectAction.Burst: GetUIButton.OnLongClick.RemoveListener(ExecuteBurst); break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Executes the -play- action on the referenced ParticleSystem
        /// </summary>
        public void ExecutePlay()
        {
            pSystem.Play(withChildren);
        }

        /// <summary>
        /// Executes the -stop- action on the referenced ParticleSystem
        /// </summary>
        public void ExecuteStop()
        {
            pSystem.Stop(withChildren);
            if (clearOnStop)
                pSystem.Clear(withChildren);
        }

        /// <summary>
        /// Executes the -burst- action on the referenced ParticleSystem
        /// </summary>
        public void ExecuteBurst()
        {
            stopAfterBurst = !pSystem.isPlaying;

            pSystem.Emit(emitCount);

            if (stopAfterBurst)
                pSystem.Stop(true);
        }
    }
}
