using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public FlickerLights flickerLights;
    public Slider brightnessSlider;

    // Start is called before the first frame update
    void Start()
    {
        brightnessSlider.minValue = 0f;
        brightnessSlider.maxValue = 10f;

        brightnessSlider.value = flickerLights.GetLightIntesity();

        brightnessSlider.onValueChanged.AddListener(UpdateLightBrightness);
    }

    public void UpdateLightBrightness(float newBrightness)
    {
        flickerLights.SetLightIntensity(newBrightness);
    }
}
