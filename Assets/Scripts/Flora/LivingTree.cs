using System;
using System.Collections.Generic;
using TPP.Scripts.Events;
using TPP.Scripts.Interactable;
using UnityEngine;

namespace TPP.Scripts.Flora
{
    public class LivingTree : MonoBehaviour
    {
        public StickInteractable stickInteractablePrefab;

        public List<StickInteractable> sticks = new List<StickInteractable>();

        public int maxSticks;
        [Range(1f, 5f)]
        public float maxSpawnRadius;

        private Bounds bounds;

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
            if (e.eventType == WorldEventType.Tick)
            {
                if (sticks == null)
                    sticks = new List<StickInteractable>();

                if (sticks.Count < maxSticks)
                    SpawnStick();
            }
        }

        private void Start()
        {
            bounds = new Bounds(transform.position, new Vector3(maxSpawnRadius, 0, maxSpawnRadius));

            if (sticks == null)
                sticks = new List<StickInteractable>();

            while (sticks.Count < maxSticks)
            {
                SpawnStick();
            }
        }

        public void SpawnStick()
        {
            StickInteractable spawned = Instantiate(stickInteractablePrefab, GetRandomSpawnPosition(), GetRandomDirection(), transform);
            spawned.Init(this);
            sticks.Add(spawned);
        }

        private Quaternion GetRandomDirection()
        {
            Quaternion quaternion = Quaternion.Euler(0, UnityEngine.Random.Range(0f, 360f), 0);
            return quaternion;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
            float randZ = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
            Vector3 spawnPosition = new Vector3(randX, 0, randZ);

            return spawnPosition;
        }

        public void RemoveStick(StickInteractable stick)
        {
            if (sticks.Contains(stick))
            {
                sticks.Remove(stick);
            }
        }
    }
}
