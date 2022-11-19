using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propHP : MonoBehaviour
{

    public int health;
    private float dropChance;
    public GameObject drop, hitEffect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            dropChance = Random.Range(-0.2f, 0.8f);
            if (dropChance >= 0) Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
}
