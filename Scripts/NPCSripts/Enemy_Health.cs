using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 5;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;
    public event Action<int> OnThisMonsterDefeated;
    public int currentHealth;
    public int maxHealth;
    public GameObject goldPrefab;
    public int quantity = 3;
    public ItemSO goldItemData;
    public SpriteFlashEffect _flashEffect;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        _flashEffect.TriggerRedFlash();
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            OnThisMonsterDefeated?.Invoke(expReward);
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
 }

