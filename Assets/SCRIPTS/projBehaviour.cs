using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projBehaviour : MonoBehaviour
{

    public float timer, speedmod, life;
    public GameObject effect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector2.left * Mathf.Max(0f, timer) * speedmod);
        if (timer >= life)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("GOTTEM");
            other.gameObject.GetComponent<PlayerCtrl>().takeDamage(gameObject.GetComponent<Transform>());
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
