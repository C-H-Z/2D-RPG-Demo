using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalDayNight : MonoBehaviour
{
    [Header("时间设置")]
    [Range(0, 24)]
    public float currentTime = 12f;
    public float timeScale = 0.1f;
    public bool autoCycle = true;

    [Header("光照设置")]
    public Light2D globalLight;  

    [Header("颜色曲线")]
    public Gradient dayNightGradient; 

    [Header("亮度曲线")]
    public AnimationCurve brightnessCurve;  

    [Header("事件")]
    public UnityEngine.Events.UnityEvent onSunrise;  
    public UnityEngine.Events.UnityEvent onSunset;   

    private bool wasDay = true;

    void Start()
    {
        if (globalLight == null)
            globalLight = GetComponent<Light2D>();

        
        if (dayNightGradient == null || dayNightGradient.colorKeys.Length == 0)
        {
            InitDefaultGradient();
        }

        
        if (brightnessCurve == null || brightnessCurve.keys.Length == 0)
        {
            InitDefaultCurve();
        }
    }

    void Update()
    {
        Debug.Log("昼夜系统运行中，当前时间：" + currentTime);
        if (autoCycle)
        {
            currentTime += Time.deltaTime * timeScale;
            if (currentTime >= 24f) currentTime = 0f;
        }

        UpdateLight();
        CheckTimeEvents();
    }

    void UpdateLight()
    {
        if (globalLight == null) return;

        
        float t = currentTime / 24f;

        
        float brightness = brightnessCurve.Evaluate(t);
        Color lightColor = dayNightGradient.Evaluate(t);

        
        globalLight.intensity = brightness;
        globalLight.color = lightColor;
    }

    void CheckTimeEvents()
    {
        bool isDay = currentTime > 6 && currentTime < 18;

        
        if (!wasDay && currentTime >= 6 && currentTime < 6.1f)
        {
            onSunrise.Invoke();
        }

        
        if (wasDay && currentTime >= 18 && currentTime < 18.1f)
        {
            onSunset.Invoke();
        }

        wasDay = isDay;
    }

    void InitDefaultGradient()
    {
        
        dayNightGradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.2f, 0.2f, 0.5f), 0f),   
            new GradientColorKey(new Color(0.8f, 0.5f, 0.3f), 0.25f), 
            new GradientColorKey(Color.white, 0.5f),                  
            new GradientColorKey(new Color(1f, 0.6f, 0.3f), 0.75f),   
            new GradientColorKey(new Color(0.2f, 0.2f, 0.5f), 1f)     
        };

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(1f, 0f),
            new GradientAlphaKey(1f, 1f)
        };

        dayNightGradient.SetKeys(colorKeys, alphaKeys);
    }

    void InitDefaultCurve()
    {
        
        brightnessCurve = new AnimationCurve();
        brightnessCurve.AddKey(0f, 0.3f);    
        brightnessCurve.AddKey(0.25f, 0.7f);  
        brightnessCurve.AddKey(0.5f, 1.2f);   
        brightnessCurve.AddKey(0.75f, 0.7f);  
        brightnessCurve.AddKey(1f, 0.3f);     
    }

    
    public void SetTime(float hour)
    {
        currentTime = Mathf.Clamp(hour, 0f, 24f);
    }

    public void SetDay() => currentTime = 12f;
    public void SetNight() => currentTime = 0f;
}