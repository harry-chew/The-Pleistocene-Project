using System;
using System.Collections.Generic;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Flora
{
    public class FloraPatch : MonoBehaviour
    {
        public GameObject[] floraPrefabs;
        public GameObject floraPrefab;
        public int maxFlora;
        [Range(0.1f, 1f)]
        public float minStartSize;
        [Range(1.01f, 1.5f)]
        public float maxStartSize;
        [Range(1.51f, 2f)]
        public float maxGrowSize;
        public List<GameObject> floras = new List<GameObject>();
        private SphereCollider sphereCollider;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            if (floras == null)
                floras = new List<GameObject>();

            while (floras.Count < maxFlora)
            {
                SpawnFlora();
            }
        }

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
                if (floras == null || floras.Count == 0)
                    return;

                GrowFlora();

                if (floras.Count < maxFlora)
                {
                    SpawnFlora();
                }
            }
            if (e.eventType == WorldEventType.HourTick)
            {
                if (floras == null)
                    return;

                if (floras.Count < maxFlora)
                {
                    SpawnFlora();
                }
            }
        }

        private GameObject GetRandomFlora()
        {
            if (floraPrefabs.Length == 0)
                return floraPrefab;

            int random = UnityEngine.Random.Range(0, floraPrefabs.Length);
            return floraPrefabs[random];
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = UnityEngine.Random.Range(-sphereCollider.radius, sphereCollider.radius);
            float randomZ = UnityEngine.Random.Range(-sphereCollider.radius, sphereCollider.radius);

            Vector3 spawnPosition = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);

            return spawnPosition;
        }

        private Quaternion GetRandomSpawnRotation()
        {
            Quaternion quaternion = Quaternion.Euler(0, UnityEngine.Random.Range(0f, 360f), 0);

            return quaternion;
        }

        private void SpawnFlora()
        {
            if (floras == null)
                floras = new List<GameObject>();

            GameObject randomFlora = GetRandomFlora();
            GameObject spawnedFlora = Instantiate(randomFlora, GetRandomSpawnPosition(), GetRandomSpawnRotation(), transform);
            float randomSize = UnityEngine.Random.Range(minStartSize, maxStartSize);
            spawnedFlora.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            floras.Add(spawnedFlora);
        }

        private void GrowFlora()
        {
            int randIndex = UnityEngine.Random.Range(0, floras.Count);

            GameObject floraToGrow = floras[randIndex];
            if (floraToGrow == null)
            {
                floras.Remove(floraToGrow);
                return;
            }

            Transform tran = floras[randIndex].transform;
            if (tran == null)
                return;

            if (tran.localScale.y > maxGrowSize)
            {
                floras.Remove(floras[randIndex]);
                Destroy(tran.gameObject);

                SpawnFlora();
            }

            floras[randIndex].transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
