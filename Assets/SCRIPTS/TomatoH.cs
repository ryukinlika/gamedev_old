using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoH : MonoBehaviour
{
    public int health;
    public GameObject damageAnim;

    void Start()
    {
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(damageAnim, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("OOF");
    }

}
