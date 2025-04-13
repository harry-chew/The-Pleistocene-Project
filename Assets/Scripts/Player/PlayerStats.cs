using System.Collections;
using UnityEngine;

namespace TPP.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        public int hunger;
        public int startingHunger;
        public float hungerTickRate;

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

            if (hunger <= 0)
            {
                Debug.Log("you are starving. eat very soon");
                hunger = 0;
            }
        }

        private IEnumerator TickCoroutine()
        {
            while (Time.timeScale > 0)
            {
                yield return new WaitForSeconds(hungerTickRate);
                Tick();
            }
        }
    }
}
