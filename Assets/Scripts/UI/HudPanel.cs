using System;
using TPP.Scripts.Events;
using TPP.Scripts.Interactable;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class HudPanel : MonoBehaviour
    {
        public GameObject interactPanel;

        void Start()
        {
            CoreEvents.SelectInteractableEvent += OnSelectInteractableEvent;
        }

        private void OnDestroy()
        {
            CoreEvents.SelectInteractableEvent -= OnSelectInteractableEvent;
        }

        private void OnSelectInteractableEvent(IInteractable interactable)
        {
            interactPanel.SetActive(interactable != null);
        }
    }
}
