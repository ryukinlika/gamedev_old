using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{

    private Health player;
    public int kb;
    private float lastContact;

    // Use this for initialization
    void Start()
    {
        lastContact = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastContact -= Time.deltaTime;
    }


    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player" && lastContact < 0)
        {
            lastContact = 1.3f;
            var force = transform.position - c.transform.position;
            force.x *= 10;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * kb);
        }
    }
}

