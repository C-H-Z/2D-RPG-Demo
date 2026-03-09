using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUI statsUI;
    public TMP_Text healthText;
    public GameObject[] statsSlots;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public float speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP:" + currentHealth + "/" + maxHealth;
    }

    public void UpdateDamage(int amount)
    {
        damage += amount;
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + damage;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        healthText.text = "HP:" + currentHealth + "/" + maxHealth;
    }
    public void UpdateSpeed(float amount)
    {
        speed += amount;
        statsUI.UpdateAllStats();
    }
}
