using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolbehaviour : MonoBehaviour
{

    public float speed;
    public Transform groundCheck;
    public Transform wallCheck;
    public float checkRad;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    public SpriteRenderer sr;
    private Rigidbody2D rb;

    private int dir;
    private bool valid;
    private bool wallValid;
    // Use this for initialization
    void Start()
    {
        dir = -1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        valid = Physics2D.OverlapCircle(groundCheck.position, checkRad, whatIsGround);
        wallValid = Physics2D.OverlapCircle(wallCheck.position, checkRad, whatIsGround);
        if (!valid || wallValid)
        {
            dir = -1 * dir;
            Flip();
        }
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);

    }
    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }


}
