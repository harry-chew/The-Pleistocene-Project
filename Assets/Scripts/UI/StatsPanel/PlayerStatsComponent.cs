using TMPro;
using TPP.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace TPP.Scripts.UI.Components
{
    public class PlayerStatsComponent : MonoBehaviour
    {
        public TextMeshProUGUI statLabel;
        public Image statIcon;
        public Slider statSlider;

        public float maxValue;

        public void Init(string labelText, float value)
        {
            statLabel.text = labelText;
            maxValue = value;

            statSlider.value = CommonUtils.Map(value, 0, maxValue, 0f, 1f);
        }

        public void UpdateValue(float value)
        {
            statSlider.value = CommonUtils.Map(value, 0, maxValue, 0f, 1f);
        }
    }
}
