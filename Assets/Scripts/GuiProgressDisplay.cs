using UnityEngine;

public class GuiProgressDisplay : MonoBehaviour
{
    public Health health;
    public float ProgressValue { get; set; }
    public float MaximumValue { get; set; }

    private void Awake()
    {
        ProgressValue = health.currentHealth;
        MaximumValue = health.maximumHealth;
    }
    private void OnGUI()
    {
        ProgressSlider(ProgressValue, MaximumValue);
    }

    private void ProgressSlider(float value, float maxValue)
    {
        GUI.Box(new Rect(Screen.width - 220, 10, 200, 20), $"{value}/{maxValue}");
    }
}
