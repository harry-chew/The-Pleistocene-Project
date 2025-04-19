using System.Collections.Generic;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Flora
{
    public class FloraPatch : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject[] floraPrefabs;
        public GameObject floraPrefab;

        [Space(10)]
        [Header("Properties")]
        public int maxFlora;
        [Range(0.1f, 1f)]
        public float minStartSize;
        [Range(1.01f, 1.5f)]
        public float maxStartSize;
        [Range(1.51f, 2f)]
        public float maxGrowSize;

        private List<GameObject> floras = new List<GameObject>();
        private SphereCollider sphereCollider;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }

        private void OnEnable()
        {
            CoreEvents.WorldEvent += OnWorldEvent;
        }

        private void OnDisable()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
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

        private void OnWorldEvent(object sender, WorldEventArgs e)
        {
            if (e.eventType == WorldEventType.Tick)
            {
                if (floras == null)
                    return;

                if (floras.Count > 0)
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
            if (floraPrefabs == null || floraPrefabs.Length == 0)
                return floraPrefab;

            int random = Random.Range(0, floraPrefabs.Length);
            return floraPrefabs[random];
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(-sphereCollider.radius, sphereCollider.radius);
            float randomZ = Random.Range(-sphereCollider.radius, sphereCollider.radius);

            Vector3 spawnPosition = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);

            return spawnPosition;
        }

        private Quaternion GetRandomSpawnRotation()
        {
            Quaternion quaternion = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            return quaternion;
        }

        private void SpawnFlora()
        {
            if (floras == null)
                floras = new List<GameObject>();

            GameObject randomFlora = GetRandomFlora();
            GameObject spawnedFlora = Instantiate(randomFlora, GetRandomSpawnPosition(), GetRandomSpawnRotation(), transform);
            float randomSize = Random.Range(minStartSize, maxStartSize);
            spawnedFlora.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            floras.Add(spawnedFlora);
        }

        private void GrowFlora()
        {
            if (floras == null)
                return;

            int randIndex = Random.Range(0, floras.Count);

            GameObject floraToGrow = floras[randIndex];
            if (floraToGrow == null)
            {
                floras.Remove(floraToGrow);
                return;
            }

            Transform tran = floras[randIndex].transform;
            if (tran == null)
                return;

            tran.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            if (tran.localScale.y > maxGrowSize)
            {
                floras.Remove(floras[randIndex]);
                Destroy(tran.gameObject);

                SpawnFlora();
            }
        }
    }
}
