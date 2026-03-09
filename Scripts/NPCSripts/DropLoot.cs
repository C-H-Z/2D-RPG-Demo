using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public Animator anim;
    public GameObject Prefab;
    public ItemSO ItemData;
    public int quantity = 3;

    public void Droploot()
    {
        GameObject lootObject = Instantiate(Prefab, transform.position, Quaternion.identity);
        Loot loot = lootObject.GetComponent<Loot>();
        loot.Initialize(ItemData, quantity);
    }

}
