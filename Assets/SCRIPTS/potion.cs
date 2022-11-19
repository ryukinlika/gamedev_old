using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{

    public GameObject potEffect;
    private Health player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void effect()
    {
        player.health += 2;
        Instantiate(potEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
