using System.Collections;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class DrinkableWaterSourceInteractable : AbstractInteractable
    {
        [Header("Properties")]
        [Range(5, 25)]
        public int waterPerDrink;

        [Range(0.5f, 5f)]
        public float interactCooldown;

        private bool canInteract;

        private void Start()
        {
            canInteract = true;
        }

        public override void Interact()
        {
            if (canInteract)
            {
                StartCoroutine(ResetInteract());
            }
        }

        private IEnumerator ResetInteract()
        {
            CoreEvents.FireDrinkWaterEvent(waterPerDrink);
            canInteract = false;

            yield return new WaitForSeconds(interactCooldown);

            canInteract = true;
        }
    }
}
