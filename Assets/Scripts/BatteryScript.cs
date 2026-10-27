using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BatteryDisplay : MonoBehaviour
{
    public Slider batterySlider;
    public TMP_Text batteryText;

    private void Start()
    {
        UpdateBatteryDisplay();

        batterySlider.onValueChanged.AddListener(
            OnBatteryChanged
        );
    }

    private void OnDestroy()
    {
        if (batterySlider != null)
        {
            batterySlider.onValueChanged.RemoveListener(
                OnBatteryChanged
            );
        }
    }

    private void OnBatteryChanged(float value)
    {
        UpdateBatteryDisplay();
    }

    public void UpdateBatteryDisplay()
    {
        int percentage = Mathf.RoundToInt(batterySlider.value);

        batteryText.text = percentage + "%";
    }

    public void SetBattery(float value)
    {
        batterySlider.value = Mathf.Clamp(value, 0f, 100f);
        UpdateBatteryDisplay();
    }
}