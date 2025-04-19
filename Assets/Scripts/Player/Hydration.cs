using UnityEngine;

namespace TPP.Scripts
{
    public class Hydration : MonoBehaviour
    {
        [SerializeField] private float hydration;
        private float maxHydration;

        public void Init(float startingValue)
        {
            maxHydration = startingValue;
            hydration = startingValue;
        }

        public float GetHydrationLevel()
        {
            return hydration;
        }
        
        public void Hydrate(float amount)
        {
            hydration += amount;

            if (hydration >= maxHydration)
                hydration = maxHydration;
        }

        public void Tick()
        {
            hydration -= 1f;
        }
    }
}
