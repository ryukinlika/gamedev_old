using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testblocker : MonoBehaviour
{

    public GameObject effect;
    private snailH boss;
    private float timer;
    // Use this for initialization
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
