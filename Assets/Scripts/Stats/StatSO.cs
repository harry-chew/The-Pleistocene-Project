using UnityEngine;

namespace TPP
{
    [CreateAssetMenu(fileName = "Stat Scriptable", menuName = "Scriptables/Stat")]
    public class StatSO : ScriptableObject
    {
        public string statName;
        public int startingStatValue;
        public int maximumStatValue;
        public Sprite statIcon;
        public Color statColor;
    }
}
