using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public abstract class AbstractInteractable : MonoBehaviour, IInteractable
    {
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public abstract void Interact();
    }
}
