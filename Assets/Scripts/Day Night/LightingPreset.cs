using System;
using UnityEngine;

namespace TPP.Scripts.Systems
{
    [Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
    public class LightingPreset : ScriptableObject
    {
        public Gradient ambientColor;
        public Gradient lightColor;
        public Gradient fogColor;
        public Gradient fogIntensity;
    }
}
