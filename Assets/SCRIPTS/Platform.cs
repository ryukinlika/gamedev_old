using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PlatformEffector2D effector;

    float temp;
    public float waitTime;

    // Use this for initialization
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.1f;
            StartCoroutine("flipsoon");
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 90f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = -90f;
        }
    }
    IEnumerator flipsoon()
    {
        yield return new WaitForSeconds(0.3f);
        effector.rotationalOffset = -90f;
    }
}
