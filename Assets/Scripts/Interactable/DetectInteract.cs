using TPP.Scripts.Events;
using TPP.Scripts.Interactable;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class DetectInteract : MonoBehaviour
    {
        private Camera cam;

        private IInteractable selectedInteractable;

        private Vector3 rayPoint;

        private void Awake()
        {
            cam = GetComponent<Camera>();

            rayPoint = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, cam.nearClipPlane);
        }

        void Update()
        {
            Ray ray = cam.ScreenPointToRay(rayPoint);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 5f))
            {
                if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    if (selectedInteractable == null || selectedInteractable != interactable)
                    {
                        SetSelectedInteractable(interactable);
                    }
                }
                else
                {
                    if (selectedInteractable == null)
                        return;

                    SetSelectedInteractable(null);
                }
            }
            else
            {
                if (selectedInteractable == null)
                    return;

                SetSelectedInteractable(null);
            }
        }

        private void SetSelectedInteractable(IInteractable interactable)
        {
            selectedInteractable = interactable;
            CoreEvents.FireSelectInteractableEvent(selectedInteractable);

            string message = interactable == null ? "deselected" : $"{selectedInteractable.GetGameObject().name}";
            Debug.Log(message);
        }
    }
}
