using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class MushroomInteractable : AbstractInteractable, IInteractable
    {
        public override void Interact()
        {
            Debug.Log($"interact on {transform.name}");
            Destroy(gameObject);
        }
    }
}
