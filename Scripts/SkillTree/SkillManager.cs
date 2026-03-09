using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    private void OnDisdable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;

        switch (skillName)
        {
            case "MaxHealthBoost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "DamageBoost":
                StatsManager.Instance.UpdateDamage(1);
                break;
            default:
                Debug.LogWarning("Unknown skill:" + skillName);
                break;
        }
    }
}
