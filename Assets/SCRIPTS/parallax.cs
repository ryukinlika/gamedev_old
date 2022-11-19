using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject obj;
    public float posX;
    public float posY;

    void Start()
    {
        posX = 160.6f;
        posY = -0.82f;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(obj.transform.position.x, posX, 0.6f), Mathf.Lerp(obj.transform.position.y, posY, 0.9f), transform.position.z);
    }

}