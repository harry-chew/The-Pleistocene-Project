using TMPro;
using TPP.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace TPP.Scripts.UI.Components
{
    public class PlayerStatsComponent : MonoBehaviour
    {
        [Header("Stat Properties")]
        public StatSO statSO;

        [Header("Components")]
        public TextMeshProUGUI statLabel;
        public Image statIcon;
        public Slider statSlider;
        public Image fill;
        public float maxValue;

        public Color sliderFillColor;

        public void Init()
        {
            statLabel.text = statSO.statName;
            maxValue = statSO.maximumStatValue;
            statIcon.sprite = statSO.statIcon;
            sliderFillColor = statSO.statColor;
            fill.color = sliderFillColor;
            statSlider.value = CommonUtils.Map(maxValue, 0, maxValue, 0f, 1f);
        }

        public void UpdateValue(float value)
        {
            statSlider.value = CommonUtils.Map(value, 0, maxValue, 0f, 1f);
        }
    }
}
