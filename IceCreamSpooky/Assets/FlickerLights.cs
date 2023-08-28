using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    public Material lightMaterial;
    public Light light;

    [Range(0f, 1f)]
    public float flickerRate = 0.2f;

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
            float sinTime = (float)Math.Sin(Time.time);
            sinTime = (sinTime + 1) * 0.5f;
            light.intensity = lightIntensity * sinTime;
            lightMaterial.SetColor("_EmissionColor", lightColor * sinTime);
        }
        else
        {
            light.intensity = lightIntensity;
            lightMaterial.SetColor("_EmissionColor", lightColor);
        }
    }
}
