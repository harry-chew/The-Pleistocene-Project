using DG.Tweening;
using TMPro;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TPP.Scripts.UI
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("Slot Components")]
        public Image border;
        public Image icon;
        public TextMeshProUGUI itemCount;
        public bool selected;

        [Space(10)]
        [Header("Border")]
        public Color borderColor;
        public Color selectedColor;

        [Space(10)]
        [Header("Item in Slot")]
        public Item item;

        private float fontSize;

        public void Init(Item item)
        {
            this.item = item;
            itemCount.text = item.quantity.ToString();
            border.color = borderColor;
            icon.sprite = item.icon;
            fontSize = itemCount.fontSize;
        }

        public void SelectSlot(bool selected)
        {
            border.color = selected ? selectedColor : borderColor;
            this.selected = selected;
        }

        public void UpdateQuantity(int quantity)
        {
            item.quantity += quantity;
            itemCount.text = item.quantity.ToString();

            TweenFontSizeOnUpdate();
        }

        private void TweenFontSizeOnUpdate()
        {
            Sequence anim = DOTween.Sequence(itemCount);
            anim.Append(DOTween.To(() => itemCount.fontSize, x => itemCount.fontSize = x, fontSize * 1.1f, 0.1f));
            anim.Append(DOTween.To(() => itemCount.fontSize, x => itemCount.fontSize = x, fontSize, 0.1f));
            anim.Play();
        }
    }
}
