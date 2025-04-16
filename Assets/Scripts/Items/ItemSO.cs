using UnityEngine;

namespace TPP.Scripts.Items
{
    [CreateAssetMenu(fileName = "Scriptable Item", menuName = "Scriptables/Item", order = 1)]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        public int weight;
        public int quantity;
        public AudioClip interactClip;
        public Sprite icon;
    }
}
