using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float speedMod;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public int kb;
    public Animator animator;
    public float invul;
    public float invulMax;
    private bool facingRight;


    public Health player;
    void start()
    {
        speedMod = 1;
        invul = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (speed != 0) rb.velocity = new Vector2(moveInput * speed * speedMod, rb.velocity.y);
        else if (isGrounded) rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.1f), rb.velocity.y);
        animator.SetFloat("Speeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vSpeed", rb.velocity.y);
        if (!facingRight && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight && moveInput > 0)
        {
            Flip();
        }

    }

    void Update()
    {
        invul -= Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            animator.SetTrigger("grounded");
            animator.SetBool("midair", false);
        }
        else
        {
            animator.SetBool("midair", true);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    public IEnumerator OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy" && invul < 0)
        {
            var force = transform.position - c.transform.position;
            force.x *= 10;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * kb);

            invul = invulMax;
            player.health--;
            sr.color = Color.red;
            Debug.Log(player.health);
            yield return new WaitForSeconds(1);
            sr.color = Color.white;
        }
    }

    public void takeDamage(Transform c)
    {
        var force = transform.position - c.transform.position;
        force.x *= 10;
        force.Normalize();
        GetComponent<Rigidbody2D>().AddForce(force * kb);
        StartCoroutine("ChangeColor");

    }

    IEnumerator ChangeColor()
    {
        invul = invulMax - 0.05f;
        player.health -= 2;
        sr.color = Color.red;
        Debug.Log(player.health);
        yield return new WaitForSeconds(1);
        sr.color = Color.white;
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}