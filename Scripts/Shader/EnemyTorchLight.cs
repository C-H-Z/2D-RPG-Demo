using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyTorchLight : MonoBehaviour
{
    [Header("光源设置")]
    public Color torchColor = new Color(1f, 0.5f, 0f);
    public float baseIntensity = 3f;
    public float lightRadius = 5f;

    [Header("动态效果")]
    public bool enableFlicker = true;
    public float flickerSpeed = 5f;
    public float flickerAmount = 0.3f;

    [Header("昼夜联动")]
    public bool adjustWithDayNight = true;
    public float nightIntensityMultiplier = 2.5f;  

    private Light2D torchLight;
    private float originalIntensity;
    private float flickerOffset;
    private GlobalDayNight dayNight;

    void Start()
    {
        torchLight = GetComponent<Light2D>();
        if (torchLight == null)
        {
            Debug.LogError("请先添加Light 2D组件！");
            return;
        }

        
        torchLight.color = torchColor;
        torchLight.intensity = baseIntensity;
        torchLight.pointLightOuterRadius = lightRadius;
        torchLight.pointLightInnerRadius = lightRadius * 0.2f;

        originalIntensity = baseIntensity;
        flickerOffset = Random.Range(0f, 100f);

        
        dayNight = FindObjectOfType<GlobalDayNight>();
    }

    void Update()
    {
        if (torchLight == null) return;

        float targetIntensity = originalIntensity;

       
        if (adjustWithDayNight && dayNight != null)
        {
            float time = dayNight.currentTime;
            bool isNight = time < 6 || time > 18;

            if (isNight)
            {
               
                targetIntensity = originalIntensity * nightIntensityMultiplier;
            }
        }

        
        if (enableFlicker)
        {
            float flicker = Mathf.Sin((Time.time + flickerOffset) * flickerSpeed);
            flicker = 1f + (flicker * flickerAmount);
            targetIntensity *= flicker;
        }

        torchLight.intensity = targetIntensity;
    }

    public void Flash(float intensity = 5f, float duration = 0.2f)
    {
        StartCoroutine(FlashRoutine(intensity, duration));
    }

    private System.Collections.IEnumerator FlashRoutine(float intensity, float duration)
    {
        torchLight.intensity = intensity;
        yield return new WaitForSeconds(duration);
        torchLight.intensity = originalIntensity;
    }
}