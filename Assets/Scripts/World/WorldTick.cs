using System.Collections;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.World
{
    public class WorldTick : MonoBehaviour
    {
        public float tickTimer;

        private Coroutine tick;

        private void OnEnable()
        {
            tick = StartCoroutine(TickCoroutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            tick = null;
        }

        private IEnumerator TickCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(tickTimer);
                CoreEvents.FireWorldTickEvent();
            }
        }
    }
}
