using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlashEffect : MonoBehaviour
{
    [Header("闪红效果配置")]
    [Tooltip("闪红最大强度（0-1，1=完全红色）")]
    [Range(0f, 1f)] public float maxFlashIntensity = 0.8f;

    [Tooltip("闪红持续时间（秒）")]
    public float flashDuration = 0.3f;

    private SpriteRenderer _spriteRenderer;
    private Material _materialInstance; 
    private float _flashTimer;
    private int _flashAmountID; 

    private void Awake()
    {
 
        _spriteRenderer = GetComponent<SpriteRenderer>();


        _flashAmountID = Shader.PropertyToID("_FlashAmount");

   
        if (_spriteRenderer.material != null)
        {
            _materialInstance = new Material(_spriteRenderer.material);
            _spriteRenderer.material = _materialInstance;
        }
        else
        {
            Debug.LogError("SpriteRenderer没有绑定材质！请先给角色添加闪红Shader材质", this);
        }
    }


    private void Update()
    {
        if (_flashTimer > 0 && _materialInstance != null)
        {
            _flashTimer -= Time.deltaTime;

            float currentIntensity = Mathf.Lerp(maxFlashIntensity, 0f, 1 - (_flashTimer / flashDuration));
            _materialInstance.SetFloat(_flashAmountID, currentIntensity);
        }
        else if (_materialInstance != null && _materialInstance.GetFloat(_flashAmountID) > 0)
        {

            _materialInstance.SetFloat(_flashAmountID, 0f);
        }
    }

 
    public void TriggerRedFlash()
    {
        if (_materialInstance == null) return;

        _flashTimer = flashDuration;
        _materialInstance.SetFloat(_flashAmountID, maxFlashIntensity);
    }


    private void OnDestroy()
    {
        if (_materialInstance != null)
        {
            Destroy(_materialInstance);
        }
    }

}
