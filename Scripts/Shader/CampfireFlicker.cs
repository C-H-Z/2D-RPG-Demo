using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampfireFlicker : MonoBehaviour
{
    private Light2D campfireLight;
    private float baseIntensity;
    public bool adjustWithDayNight = true;
    public float nightIntensityMultiplier = 1.5f;

    [Header("…¡À∏…Ë÷√")]
    public float flickerSpeed = 5f;
    public float flickerAmount = 0.3f;

    void Start()
    {
        campfireLight = GetComponent<Light2D>();
        baseIntensity = campfireLight.intensity;
    }

    void Update()
    {
        float targetBase = baseIntensity;

        if (adjustWithDayNight)
        {
            float time = FindObjectOfType<GlobalDayNight>().currentTime;
            bool isNight = time < 6 || time > 18;
            if (isNight) targetBase = baseIntensity * nightIntensityMultiplier;
        }

        float flicker = 1f + Mathf.Sin(Time.time * flickerSpeed) * flickerAmount;
        campfireLight.intensity = targetBase * flicker;
    }
}