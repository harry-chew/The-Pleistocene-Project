using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public interface IInteractable
    {
        public void Interact();

        public GameObject GetGameObject();
    }
}
