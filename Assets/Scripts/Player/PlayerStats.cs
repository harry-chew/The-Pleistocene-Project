using System.Collections;
using UnityEngine;

namespace TPP.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        public int hunger;
        public int startingHunger;

        private void Awake()
        {
            hunger = startingHunger;
        }

        private void Start()
        {
            StartCoroutine(TickCoroutine());
        }

        public void Tick()
        {
            hunger--;
        }

        private IEnumerator TickCoroutine()
        {
            while (Time.timeScale > 0)
            {
                yield return new WaitForSeconds(1f);
                Tick();
            }
        }
    }
}
