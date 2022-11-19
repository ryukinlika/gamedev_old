using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snailH : MonoBehaviour
{
    public int health, maxHp;
    public GameObject damageAnim, damageLocation;

    public SpriteRenderer sr;
    private Animator animator;
    Color lerpedColor = Color.white;
    Color ini = Color.white;
    Color fin = Color.red;
    private float t = 0;
    public float duration;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(ini, fin, t);
        sr.color = lerpedColor;
        if (t <= 0) t = 0;
        else t -= Time.deltaTime / duration;
        if (health <= 0)
        {
            animator.SetTrigger("imdedyo");
        }
    }

    public void TakeDamage(int damage)
    {
        if (!animator.GetBool("body"))
        {
            health -= damage;
            Instantiate(damageAnim, damageLocation.transform.position, Quaternion.identity);
            t = 1f;
            Debug.Log("OOF");

        }
    }

    IEnumerator colorchange()
    {
        sr.color = new Color(1, 0.5f, 0.5f, 1);

        yield return new WaitForSeconds(0.5f);
        sr.color = Color.white;
    }
}
