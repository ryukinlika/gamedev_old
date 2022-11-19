using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    // Use this for initialization
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemy, whatIsProp;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public Animator animator;
    public PlayerCtrl controller;
    public float defSpeed;
    void start()
    {
        timeBtwAttack = startTimeBtwAttack;
    }
    void Update()
    {
        if (timeBtwAttack < 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!controller.isJumping || controller.isGrounded) controller.speedMod = 0;
                Debug.Log("pressed E");
                animator.SetTrigger("attacking");
                timeBtwAttack = startTimeBtwAttack;
                StartCoroutine("damageEnemies");
                StartCoroutine("speedChange");
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


    }

    IEnumerator speedChange()
    {
        yield return new WaitForSeconds(0.4f);
        controller.speedMod = defSpeed;
    }

    IEnumerator damageEnemies()
    {
        yield return new WaitForSeconds(0.2f);
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemy);
        Collider2D[] propToDmg = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsProp);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].GetComponent<EnemyH>() != null) enemiesToDamage[i].GetComponent<EnemyH>().TakeDamage(damage);
            if (enemiesToDamage[i].GetComponent<TomatoH>() != null) enemiesToDamage[i].GetComponent<TomatoH>().TakeDamage(damage);
            if (enemiesToDamage[i].GetComponent<snailH>() != null) enemiesToDamage[i].GetComponent<snailH>().TakeDamage(damage);
        }
        for (int i = 0; i < propToDmg.Length; i++)
        {
            propToDmg[i].GetComponent<propHP>().TakeDamage(damage);
        }
        yield return new WaitForSeconds(0.2f);
        controller.speedMod = defSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1f));
    }
}
