using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class DrinkableWaterSourceInteractable : AbstractInteractable
    {
        [Range(5, 25)]
        public int waterPerDrink;

        public override void Interact()
        {
            CoreEvents.FireDrinkWaterEvent(waterPerDrink);
        }
    }
}
