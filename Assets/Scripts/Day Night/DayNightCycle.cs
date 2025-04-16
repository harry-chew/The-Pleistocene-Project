using UnityEngine;

namespace TPP.Scripts.Systems
{
    [ExecuteAlways]
    public class DayNightCycle : MonoBehaviour
    {
        [Header("References")]
        public Light sun;
        public LightingPreset preset;
        
        [Space(10)]
        [Header("Variables")]
        [Range(0f, 24f)]
        public float timeOfDay;
        private static float TimeOfDay;

        [Range(1f, 60f)]
        public float dayNightRateMultiplier;

        public static float DayNightRateMultiplier;

        private void Awake()
        {
            DayNightRateMultiplier = dayNightRateMultiplier;
        }

        private void UpdateLighting(float timePercent)
        {
            RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
            RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);
            RenderSettings.fogDensity = preset.fogIntensity.Evaluate(timePercent).a;

            sun.color = preset.lightColor.Evaluate(timePercent);
            sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

        private void Update()
        {
            if (preset == null)
                return;

            if (Application.isPlaying)
            {
                timeOfDay += Time.deltaTime / dayNightRateMultiplier;
                timeOfDay %= 24f;
                TimeOfDay = timeOfDay;
                UpdateLighting(timeOfDay / 24f);
            }
            else
            {
                UpdateLighting(timeOfDay / 24f);
            }
        }

        public static bool IsDayTime()
        {
            if (TimeOfDay >= 5f && TimeOfDay <= 20f)
                return true;

            return false;
        }
    }
}
