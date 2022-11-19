using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyH : MonoBehaviour
{
    public int health;
    public GameObject damageAnim;

    private float dazedTime;
    public float StartDazedTime;
    private float def;
    public SpriteRenderer sr;

    Color lerpedColor = Color.white;
    Color ini = Color.white;
    Color fin = Color.red;
    private float t = 0;
    private float duration = 0.5f;
    // Use this for initialization
    void Start()
    {
        def = GetComponent<patrolbehaviour>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(ini, fin, t);
        sr.color = lerpedColor;
        if (t <= 0) t = 0;
        else t -= Time.deltaTime / duration;
        if (dazedTime <= 0)
        {
            GetComponent<patrolbehaviour>().speed = def;
        }
        else
        {
            GetComponent<patrolbehaviour>().speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        t = 1f;
        dazedTime = StartDazedTime;
        Instantiate(damageAnim, transform.position, Quaternion.identity);
        Debug.Log("OOF");
    }

}
