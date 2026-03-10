using UnityEngine;

/// <summary>
/// 2D角色受伤闪红组件（独立功能，仅负责闪红效果）
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlashEffect : MonoBehaviour
{
    [Header("闪红效果配置")]
    [Tooltip("闪红最大强度（0-1，1=完全红色）")]
    [Range(0f, 1f)] public float maxFlashIntensity = 0.8f;

    [Tooltip("闪红持续时间（秒）")]
    public float flashDuration = 0.3f;

    // 私有变量
    private SpriteRenderer _spriteRenderer;
    private Material _materialInstance; // 材质实例（避免影响其他对象）
    private float _flashTimer; // 闪红计时器
    private int _flashAmountID; // Shader变量ID（优化性能）

    // 初始化
    private void Awake()
    {
        // 获取组件
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // 缓存Shader变量ID（比字符串查找更快）
        _flashAmountID = Shader.PropertyToID("_FlashAmount");

        // 创建材质实例（防止修改共享材质）
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

    // 每帧更新闪红强度
    private void Update()
    {
        if (_flashTimer > 0 && _materialInstance != null)
        {
            _flashTimer -= Time.deltaTime;
            // 线性渐变恢复原颜色
            float currentIntensity = Mathf.Lerp(maxFlashIntensity, 0f, 1 - (_flashTimer / flashDuration));
            _materialInstance.SetFloat(_flashAmountID, currentIntensity);
        }
        else if (_materialInstance != null && _materialInstance.GetFloat(_flashAmountID) > 0)
        {
            // 重置闪红强度
            _materialInstance.SetFloat(_flashAmountID, 0f);
        }
    }

    /// <summary>
    /// 触发闪红效果（公共调用函数）
    /// 你可以在任意受击脚本中调用这个方法
    /// </summary>
    public void TriggerRedFlash()
    {
        if (_materialInstance == null) return;

        _flashTimer = flashDuration;
        _materialInstance.SetFloat(_flashAmountID, maxFlashIntensity);
    }

    // 销毁时清理材质实例，避免内存泄漏
    private void OnDestroy()
    {
        if (_materialInstance != null)
        {
            Destroy(_materialInstance);
        }
    }
}