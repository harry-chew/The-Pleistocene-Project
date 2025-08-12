using System;
using System.Collections.Generic;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Environment
{
    public class HeatSource : MonoBehaviour
    {
        [Header("Heat Emitted")]
        public int heatStrength;

        private List<IHeatable> heatables = new List<IHeatable>();

        private void OnEnable()
        {
            CoreEvents.WorldEvent += OnWorldEvent;
        }

        private void OnDisable()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
        }

        private void OnWorldEvent(object sender, WorldEventArgs e)
        {
            if (e.eventType == WorldEventType.HourTick)
            {
                if (heatables == null || heatables.Count == 0)
                    return;

                foreach (IHeatable heatable in heatables)
                {
                    heatable.Heat(heatStrength);
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHeatable>(out IHeatable heatable))
            {
                Debug.Log($"[HeatSource] {gameObject.name}: added {other.transform.name}");
                heatables.Add(heatable);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IHeatable>(out IHeatable heatable))
            {
                if (heatables.Contains(heatable))
                {
                    Debug.Log($"[HeatSource] {gameObject.name}: removed {other.transform.name}");
                    heatables.Remove(heatable);
                }
            }
        }
    }
}
