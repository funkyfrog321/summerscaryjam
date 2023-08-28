using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    public Material lightMaterial;
    public Light light;

    public float flickerIntensity = 1.0f;

    [Range(0f, 1f)]
    // How often the light flickers
    public float flickerRate = 0.2f;
    public double flickerFreq = 1;
    [Range (0f, (float)Math.PI*2)]
    public float flickerPhase = 0;

    // Baselines to be adjusted
    public Color lightColor;
    public float lightIntensity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool flicker = UnityEngine.Random.Range(0.0f, 1.0f) < flickerRate;
        if (flicker)
        {
            float flickerValue = (float)Math.Sin(Time.time*flickerFreq + flickerPhase);
            flickerValue = flickerValue * flickerIntensity;
            light.intensity = lightIntensity + flickerValue;
            lightMaterial.SetColor("_EmissionColor", lightColor * (1.0f + flickerValue));
        }
        else
        {
            light.intensity = lightIntensity;
            lightMaterial.SetColor("_EmissionColor", lightColor);
        }
    }
}
