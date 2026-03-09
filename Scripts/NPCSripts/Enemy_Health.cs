using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 5;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;
    public int currentHealth;
    public int maxHealth;
    public GameObject goldPrefab;
    public int quantity = 3;
    public ItemSO goldItemData;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
    void DropGold()
    {
        GameObject goldObject = Instantiate(goldPrefab, transform.position, Quaternion.identity);
        Loot loot = goldObject.GetComponent<Loot>();
        loot.Initialize(goldItemData, quantity);
        Rigidbody2D rb = goldObject.GetComponent<Rigidbody2D>();
    }
    }
