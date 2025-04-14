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
                timeOfDay += Time.deltaTime;
                timeOfDay %= 24f;
                UpdateLighting(timeOfDay / 24f);
            }
            else
            {
                UpdateLighting(timeOfDay / 24f);
            }
        }
    }
}
