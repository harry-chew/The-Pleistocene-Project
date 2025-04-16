using DG.Tweening;
using TPP.Scripts.Events;
using TPP.Scripts.Interactable;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class HudPanel : MonoBehaviour
    {
        public CanvasGroup interactPanel;

        private void OnEnable()
        {
            CoreEvents.SelectInteractableEvent += OnSelectInteractableEvent;
        }

        private void OnDisable()
        {
            CoreEvents.SelectInteractableEvent -= OnSelectInteractableEvent;
        }

        private void OnSelectInteractableEvent(IInteractable interactable)
        {
            DOTween.To(() => interactPanel.alpha, x => interactPanel.alpha = x, interactable == null ? 0f : 1f, 0.2f);
        }
    }
}
