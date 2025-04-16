using DG.Tweening;
using TPP.Scripts.Events;
using TPP.Scripts.Interactable;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class InteractPanel : MonoBehaviour
    {
        [Header("Properties")]
        [Range(0.01f, 1f)]
        public float fadeSpeed;

        private CanvasGroup interactPanel;

        private void Awake()
        {
            interactPanel = GetComponent<CanvasGroup>();
        }

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
            DOTween.To(() => interactPanel.alpha, x => interactPanel.alpha = x, interactable == null ? 0f : 1f, fadeSpeed);
        }
    }
}
