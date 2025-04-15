using DG.Tweening;
using TMPro;
using TPP.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TPP.Scripts.UI
{
    public class InventorySlot : MonoBehaviour
    {
        public Image border;
        public Image icon;
        public TextMeshProUGUI itemCount;

        public Color borderColor;
        public Color selectedColor;

        public Item item;

        public void Init(Item item)
        {
            this.item = item;
            itemCount.text = item.quantity.ToString();
            border.color = borderColor;
        }

        public void SelectSlot(bool selected)
        {
            border.color = selected ? selectedColor : borderColor;
        }

        public void UpdateQuantity(int quantity)
        {
            item.quantity += quantity;
            itemCount.text = item.quantity.ToString();

            float fontSize = itemCount.fontSize;

            Sequence anim = DOTween.Sequence(itemCount);
            anim.Append(DOTween.To(() => itemCount.fontSize, x => itemCount.fontSize = x, fontSize * 1.1f, 0.1f));
            anim.Append(DOTween.To(() => itemCount.fontSize, x => itemCount.fontSize = x, fontSize, 0.1f));
            anim.Play();
        }
    }
}
