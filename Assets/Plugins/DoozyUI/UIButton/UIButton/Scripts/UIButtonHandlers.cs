// Copyright (c) 2015 - 2016 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;
using UnityEngine.EventSystems;

namespace DoozyUI.UIButton
{
    public partial class UIButton : IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (debugThis)
                Debug.Log("DebugMode - UIButton - " + name + " | OnPointerEnter triggered");
            ExecuteHoverEnter();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (debugThis)
                Debug.Log("DebugMode - UIButton - " + name + " | OnPointerExit triggered");
            ExecuteHoverExit();
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (debugThis)
                Debug.Log("DebugMode - UIButton - " + name + " | OnPointerDown triggered");
            ExecutePointerDown();
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (debugThis)
                Debug.Log("DebugMode - UIButton - " + name + " | OnPointerUp triggered");
            ExecutePointerUp();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (debugThis)
                Debug.Log("DebugMode - UIButton - " + name + " | OnPointerClick triggered");
            RegisterClick();
        }
    }
}
