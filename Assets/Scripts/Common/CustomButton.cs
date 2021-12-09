using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class CustomButton : MonoBehaviour, IPointerDownHandler
    {
        public event Action Clicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}