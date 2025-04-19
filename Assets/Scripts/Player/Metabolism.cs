using UnityEngine;

namespace TPP.Scripts
{
    public class Metabolism : MonoBehaviour
    {
        [SerializeField] private float sated;
        private float maxSated;

        public void Init(float sated)
        {
            maxSated = sated;
            this.sated = sated;
        }

        public void Tick()
        {
            sated -= 1f;
        }

        public float GetSated()
        {
            return sated;
        }

        public void Eat(float amount)
        {
            sated += amount;

            if (sated >= maxSated)
                sated = maxSated;
        }
    }
}
