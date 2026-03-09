using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestopen : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    public GameObject Prefab;
    public ItemSO ItemData;
    public int quantity = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Chest open");
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DelayedDropLoot(0.5f));
        }
    }

    void DropLoot()
    {
        GameObject lootObject = Instantiate(Prefab, transform.position + transform.right * 1f, Quaternion.identity);
        Loot loot = lootObject.GetComponent<Loot>();
        loot.Initialize(ItemData, quantity);
    }

    IEnumerator DelayedDropLoot(float delay)
    {
        yield return new WaitForSeconds(delay); 
        DropLoot();
    }

}
