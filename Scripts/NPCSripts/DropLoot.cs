using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public GameObject Prefab;
    public ItemSO ItemData;
    public int quantity = 3;

    private Enemy_Health myEnemyHealth;

    private void Awake()
    {
        myEnemyHealth = GetComponent<Enemy_Health>();
    }
    private void OnEnable()
    {
        if (myEnemyHealth != null)
        {
            myEnemyHealth.OnThisMonsterDefeated += Droploot;
        }
    }
    private void OnDisable()
    {
        if (myEnemyHealth != null)
        {
            myEnemyHealth.OnThisMonsterDefeated -= Droploot;
        }
    }

    private void Droploot(int exp)
    {

            GameObject lootObject = Instantiate(Prefab, transform.position, Quaternion.identity);
            Loot loot = lootObject.GetComponent<Loot>();
            loot.Initialize(ItemData, quantity);

    }
}
