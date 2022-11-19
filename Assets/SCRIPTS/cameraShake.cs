using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{

    // Transform of the GameObject you want to shake
    private Transform tr;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    //private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;
    // Use this for initialization

    void Awake()
    {
        if (tr == null) tr = GetComponent(typeof(Transform)) as Transform;
    }

    void OnEnable()
    {
        initialPosition = tr.localPosition;
    }
    void Start()
    {

    }

    public

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
