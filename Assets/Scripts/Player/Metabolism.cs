using UnityEngine;

namespace TPP.Scripts.Player
{
    public class Metabolism : MonoBehaviour
    {
        [SerializeField] private float sated;
        private float maxSated;

        public float metabolicRate;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Init(float sated)
        {
            maxSated = sated;
            this.sated = sated;
            metabolicRate = 0.1f;
        }

        private void HandleMetabolism()
        {
            float metabolicUse = rb.velocity.normalized.magnitude;
            if (metabolicUse > 0.1f)
                metabolicRate += 1f;
            else
                metabolicRate -= 1f;

            if (metabolicRate > 5f)
                metabolicRate = 5f;
            else if (metabolicRate < 0f)
                metabolicRate = 0.1f;

                Debug.Log(metabolicRate);
        }

        public void Tick()
        {
            HandleMetabolism();
            sated -= metabolicRate;
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
