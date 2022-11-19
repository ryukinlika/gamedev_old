using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLeftRight : MonoBehaviour
{
    private float timeLeft;
    private Vector2 movement;
    public float speed;
    private Rigidbody2D rb;

    private bool facingRight;
    // Use this for initialization
    void Start()
    {
        facingRight = false;
        timeLeft = 2f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), 0);
            timeLeft += Random.Range(0.5f, 2f);
        }
        if (!facingRight && movement.x > 0)
        {
            Flip();
        }
        else if (facingRight && movement.x < 0)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(speed * movement);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
